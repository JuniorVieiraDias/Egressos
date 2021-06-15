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

public partial class ClinicaAltaGerenciar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void CadastrarClinica_Click(object sender, EventArgs e)
    {
        

        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {
            try
            {
                string strQuery = "";
                string nomeClinica = txtAddClinica.Text;
                SqlCommand commd = new SqlCommand(strQuery, com);
                strQuery = @"INSERT INTO [Egressos].[dbo].[clinicaAlta] ([descricao])"
                    + " VALUES (@novaClinica)";


                    commd.Parameters.Add("@novaClinica", SqlDbType.VarChar).Value = nomeClinica;
                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                com.Close();
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Clinica Gravada com suecesso!');", true);
            }


            catch (Exception ex)
            {

                string erro = ex.Message;

            }
        }

    }
}
