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
                strQuery = @"INSERT INTO [Egressos].[dbo].[clinicaAlta] ([descricao],[status])"
                    + " VALUES (@novaClinica,@status)";


                commd.Parameters.Add("@novaClinica", SqlDbType.VarChar).Value = nomeClinica;
                commd.Parameters.Add("@status", SqlDbType.Int).Value = 1;
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
        txtAddClinica.Text = "";

    }

    protected void btnListaGridClinicas_Click(object sender, EventArgs e)
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {
            try
            {

                string strQuery = "";
                SqlCommand commd = new SqlCommand(strQuery, com);

                strQuery = @"SELECT [idClinica]
                                 ,[descricao]
                                 ,[status]
                                   FROM [Egressos].[dbo].[clinicaAlta]";
                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                SqlDataReader dr = commd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", System.Type.GetType("System.String"));
                dt.Columns.Add("Nome da Clinica", System.Type.GetType("System.String"));
                dt.Columns.Add("Status", System.Type.GetType("System.String"));

                while (dr.Read())
                {
                   
                    int Id = dr.GetInt32(0);
                    string id_controle = Convert.ToString(Id);
                    string nomeClinica = dr.GetString(1);
                    int statusInt = dr.GetInt32(2);
                    string status = Convert.ToString(statusInt);
                    if (status=="1")
                    {
                        status = "ATIVO";
                    }
                    dt.Rows.Add(new String[] { id_controle, nomeClinica, status });

                }
                com.Close();
                GridView1.DataSource = dt;
                GridView1.DataBind();

            }
            catch (Exception ex)
            {
                
             string erro = ex.Message;
            }
        
        }
    }
}
