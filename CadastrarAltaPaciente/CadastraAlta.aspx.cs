﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class CadastrarAltaPaciente_CadastraAlta : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnPesquisa_Click(object sender, EventArgs e)
    {
        int Nr_seq = Convert.ToInt32(txtSeqPaciente.Text);
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
            try
            {
                string strQuery = "";
                SqlCommand commd = new SqlCommand(strQuery, com);
                strQuery = @"SELECT [nr_seq]                                   
                                   ,[nome]
                                   ,[sexo]
                                   ,[dt_internacao]
                                   ,[dt_saida_paciente]
                                   ,[sg_cid]
                                   ,[clinica]
                                   ,[leito]
                                   ,[st_leito]
                            FROM [Egressos].[dbo].[vw_carregaDadosCadastro]
                                    where nr_seq=" + Nr_seq + "";

                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                SqlDataReader dr = commd.ExecuteReader();
                if (dr.Read())
                {
                    txtNome.Text = dr.GetString(1);
                    txtSexo.Text = dr.GetString(2);
                    txtDtEntrada.Text = dr.GetString(3);
                    txtDtSaida.Text = dr.GetString(4);
                    TxtH_D.Text = dr.GetString(5);
                    txtClinica.Text = dr.GetString(6);
                    txtLeito.Text = dr.GetString(7);
                    txtEnfLeito.Text = dr.GetString(8);
                }
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {
            try
            {
                Internacao p = new Internacao();
                p.cd_prontuario = Convert.ToInt32(txtSeqPaciente.Text);
                int Numero_RH = Convert.ToInt32(p.cd_prontuario);
                p.nm_paciente = txtNome.Text;
                p.dt_entrada_setor = txtDtEntrada.Text;
                p.nm_clinica = txtClinica.Text;

                p.nr_leito = txtLeito.Text;

                string strQuery = "";
                SqlCommand commd = new SqlCommand(strQuery, com);

                strQuery = "INSERT INTO [Egressos].[dbo].[movimentacao_paciente] ([prontuario_paciente],[leito],[clinica],[dt_entrada_setor])"
                  + " VALUES (@rh,@leito,@clinica,@dtEntradaSetor)";
                commd.Parameters.Add("@rh", SqlDbType.Int).Value = Numero_RH;
                commd.Parameters.Add("@leito", SqlDbType.NVarChar).Value = p.nr_leito;
                commd.Parameters.Add("@clinica", SqlDbType.NVarChar).Value = p.nm_clinica;
                commd.Parameters.Add("@dtEntradaSetor", SqlDbType.NVarChar).Value = p.dt_entrada_setor;

                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                com.Close();

                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Registro Gravado Com Sucesso!');", true);
            }
            catch (Exception ex)
            {
                string erro = ex.Message;

                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('ERRO Registro Não foi Gravado!');", true);

            }
        }
    }

    protected void pesquisarCid_Click(object sender, EventArgs e)
    {
        CID c = new CID();
        c = CidRepository.GetCIDPorCodigo(txbcid.Text);
        txtDescricaoProc_1.Text = c.Descricao;

        int nr_seq = Convert.ToInt32(txtSeqPaciente.Text);
        string clinica = DDLClinicaAlta.SelectedValue;
        string codProced = c.Cid_Numero;
        CidRepository.GravaCidPaciente(nr_seq, clinica, codProced);

        CarregaGrid(nr_seq);
    }

    private void CarregaGrid(int nr_seq)
    {
        gvListaProcedimentos.DataSource = CidRepository.CarregaCIDInternacao(nr_seq);
        gvListaProcedimentos.DataBind();
    }
}
