using System;
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
using System.Collections.Generic;
using System.Web.Services;


public partial class CadastrarAltaPaciente_CadastraAlta : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            string nrSeq = Request.QueryString["nrSeq"];
            txtSeqPaciente.Text = nrSeq;
            BindDados(Convert.ToInt32(nrSeq));
            txtSeqPaciente.Enabled = false;
        }

    }

    private void BindDados(int p)
    {

        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {
            try
            {
                string strQuery = "";
                SqlCommand commd = new SqlCommand(strQuery, com);
                strQuery = @"SELECT [nr_seq]
                                   ,[prontuario]                                   
                                   ,[nome]
                                   ,[sexo]
                                   ,[dt_internacao]
                                   ,[dt_saida_paciente]
                                   ,[sg_cid]
                                   ,[clinica]
                                   ,[leito]
                                   ,[st_leito]
                                   ,[dtNascimento]
                                   ,[statusDtNascimento]

                            FROM [Egressos].[dbo].[vw_carregaDadosCadastro]
                                    where nr_seq=" + p + "";

                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                SqlDataReader dr = commd.ExecuteReader();
                if (dr.Read())
                {
                    txtRhProntuario.Text = Convert.ToString(dr.GetInt32(1));
                    txtNome.Text = dr.GetString(2);
                    txtSexo.Text = dr.GetString(3);
                    txtDtEntrada.Text = dr.GetString(4);
                    txtDtSaida.Text = Convert.ToString(dr.GetDateTime(5));
                    TxtH_D.Text = dr.GetString(6);
                    string codigoCid = TxtH_D.Text.Replace(".", "");

                    BuscaDescCid(codigoCid); // chama a função que carrega a descrição do H.D                  
                    // BuscaDescCid(TxtH_D.Text); // chama a função que carrega a descrição do H.D                  
                    txtClinica.Text = dr.GetString(7);
                    txtLeito.Text = dr.IsDBNull(8) ? null : dr.GetString(8);
                    txtEnfLeito.Text = dr.IsDBNull(9) ? null : dr.GetString(9);
                  
                    txtDtNasc.Text = dr.GetString(10);

                    string x = dr.GetString(11);
                    if (x != null)
                    {
                        txtDtNasc.Enabled = false;
                    }


                    //GravaDt.GravarDtNasc = txtDtNasc.Text;//ToDo erro                    
                }
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }
        }

    }

    private void BuscaDescCid(string p)//Função que carrega a descriçãodo H.D
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {
            try
            {
                string strQuery = "";
                SqlCommand commd = new SqlCommand(strQuery, com);
                strQuery = @"SELECT [descricao_cid]
                                FROM [Egressos].[dbo].[cid_obito]
                                     Where [cid_numero] = '" + p + "'";
                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                SqlDataReader dr = commd.ExecuteReader();
                if (dr.Read())
                {
                    txtDescricao.Text = dr.GetString(0);
                }
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }
            //return txbDescricao.Text;
        }

    }

    protected void Button2_Click(object sender, EventArgs e)// btn cadastrar
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {
            try
            {
                //campo no banco de dados H.D,[sg_cid]

                Internacao p = new Internacao();
                p.nr_seq = Convert.ToInt32(txtSeqPaciente.Text);
                ////////int Numero_RH = Convert.ToInt32(p.cd_prontuario);
                //////p.nm_paciente = txtNome.Text;
                //////p.dt_entrada_setor = txtDtEntrada.Text;
                //////p.nm_clinica = txtClinica.Text;
                //////p.nr_leito = txtLeito.Text;

                string strQuery = "";

                SqlCommand commd = new SqlCommand(strQuery, com);

                strQuery = @"INSERT INTO [Egressos].[dbo].[mov_paciente_complementar]
                           ([nr_seq]
                           ,[motivo_saida]
                           ,[clinica_alta]
                           ,[situacao])
                     VALUES (@nr_seq,@motivo_saida,@clinica_alta,@situacao)";

                commd.Parameters.Add("@nr_seq", SqlDbType.Int).Value = p.nr_seq;
                commd.Parameters.Add("@motivo_saida", SqlDbType.VarChar).Value = DDLmotivoSaida.SelectedValue;
                commd.Parameters.Add("@clinica_alta", SqlDbType.VarChar).Value = DDLClinicaAlta.SelectedValue;
                commd.Parameters.Add("@situacao", SqlDbType.Int).Value = 1;

                //commd.Parameters.Add("@dtEntradaSetor", SqlDbType.NVarChar).Value = p.dt_entrada_setor;

                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                bool result = AtualizaStatus(p.nr_seq);
                com.Close();


                if (result == true)
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Registro Gravado Com Sucesso!');", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Registro não Gravado!');", true);
                }
            }
            catch (Exception ex)
            {
                string erro = ex.Message;

                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('ERRO Registro Não foi Gravado!');", true);
            }

        }

        //chamada da função gravar data nascimento
        if (txtDtNasc.Enabled == true)
        {
            CadastrarDtNascimento(txtDtNasc.Text, txtRhProntuario.Text);
        }

        //// Response.Redirect("~/CadastrarAltaPaciente/RhPesquisa.aspx"); // após cadastrar os dados do paciente ele redireciona a pagina para Rh Pesquisa
        // int nr_seq = Convert.ToInt32(txtSeqPaciente.Text);


        // Response.Redirect("~/CadastrarAltaPaciente/ProcedimentosCids.aspx?nrSeq=" + nr_seq);
        string url;
        url = "~/CadastrarAltaPaciente/ProcedimentosCids.aspx?nrSeq=" + txtSeqPaciente.Text + "&nomePaciente=" + txtNome.Text;
        Response.Redirect(url);
    }

    private void CadastrarDtNascimento(string dtNasc, string prontuario)// cadastra data de nasciemnto na tabela paciente
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {
            int prontuarioRh = Convert.ToInt32(prontuario);
            try
            {
                string strQuery = "";

                SqlCommand commd = new SqlCommand(strQuery, com);
                strQuery = @"update [Egressos].[dbo].[paciente]           
                                   set dtNascimento='" + dtNasc + "',statusDtNascimento='" + 1 + "'  where prontuario=" + prontuarioRh + "";

                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                com.Close();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }
        }
    }

    private bool AtualizaStatus(int nrSeq)
    {
        bool result = false;
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {
            try
            {
                string strQuery = "UPDATE [Egressos].[dbo].[movimentacao_paciente]"
                   + " SET [situacao] = @situacao where nr_seq=" + nrSeq;
                SqlCommand commd = new SqlCommand(strQuery, com);
                commd.Parameters.Add("@situacao", SqlDbType.VarChar).Value = "Codificado";
                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                com.Close();
                result = true;
            }

            catch (Exception ex)
            {
                string erro = ex.Message;
            }

        }
        return result;
    }
    //começa aqui

}
