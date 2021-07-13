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


public partial class Administrativo_AlterarDadosInternacao_UPDATE_CadastraAlta_UPDATE : System.Web.UI.Page
{
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            string nrSeq = Request.QueryString["nrSeq"];
            txtSeqPaciente.Text = nrSeq;           
            pegaNomeLoginUsuario.Text = User.Identity.Name;         
        }              
    }

    protected void btnCadastrar_Click(object sender, EventArgs e)//Excluir
    {
        int numeroSeq = Convert.ToInt32(txtSeqPaciente.Text);
        excluir_movimentacao_paciente(numeroSeq);
        excluir_mov_paciente_complementar(numeroSeq);
        excluir_procedimento_internacao(numeroSeq);
        excluir_cid_intenacao(numeroSeq);
        excluir_causaMorte(numeroSeq);
    }
  
    //Carrega os dados da pagina de cadastro para alterar
    private void excluir_movimentacao_paciente(int p)
    {
        
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {
            try
            {
                string strQuery = "";
                SqlCommand commd = new SqlCommand(strQuery, com);
                strQuery = @"DELETE FROM [Egressos].[dbo].[movimentacao_paciente]     
                                    where nr_seq=" + p + "";

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

    private void excluir_mov_paciente_complementar(int p1)
    {

        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {
            try
            {
                string strQuery = "";
                SqlCommand commd = new SqlCommand(strQuery, com);
                strQuery = @"DELETE FROM [Egressos].[dbo].[mov_paciente_complementar]     
                                    where nr_seq=" + p1 + "";

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

    private void excluir_procedimento_internacao(int p)
    {

        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {
            try
            {
                string strQuery = "";
                SqlCommand commd = new SqlCommand(strQuery, com);
                strQuery = @"DELETE FROM [Egressos].[dbo].[procedimento_internacao]     
                                    where nr_seq=" + p + "";

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

    private void excluir_cid_intenacao(int p)
    {

        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {
            try
            {
                string strQuery = "";
                SqlCommand commd = new SqlCommand(strQuery, com);
                strQuery = @"DELETE FROM [Egressos].[dbo].[cid_intenacao]     
                                    where nr_seq=" + p + "";

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

    private void excluir_causaMorte(int p)
    {

        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {
            try
            {
                string strQuery = "";
                SqlCommand commd = new SqlCommand(strQuery, com);
                strQuery = @"DELETE FROM [Egressos].[dbo].[causaMorte]     
                                    where nr_seq=" + p + "";

                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                com.Close();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Registro Excluido Com Sucesso!');", true);

        }

    }

   
}
