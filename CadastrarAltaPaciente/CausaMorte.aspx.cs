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
using System.Web.Services;
using System.Collections.Generic;
using System.Data.SqlClient;

public partial class CausaMorte : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        txtSeqPaciente.Text = Request.QueryString["nrSeq"];
        txtNomePaciente.Text = Request.QueryString["nomePaciente"];
        pegaNomeLoginUsuario.Text = User.Identity.Name;

    }
    protected void btnCadastrarCausaMorte_Click(object sender, EventArgs e)
    {
        if (DDLencaminhamentoCadaver.SelectedValue != "Bem definido" && txtCausaProvObito.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Se escolher IML ou SVO tem que cadastrar Causa provavel Obito');", true);

        }
        else
        {


            using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
            {
                try
                {
                    string strQuery = "";
                    SqlCommand commd = new SqlCommand(strQuery, com);
                    strQuery = @"INSERT INTO [Egressos].[dbo].[causaMorte]
           ([nr_seq_causaMorte],[obito_p1_a],[obito_p1_b],[obito_p1_c],[obito_p1_d],[obito_p2_a],[obito_p2_b],[enc_cadaver],[causa_prov_obito]
           ,[obs],[funcionarioCadastrou])
     
            VALUES (@nr_seq_causaMorte,@obito_p1_a,@obito_p1_b,@obito_p1_c,@obito_p1_d,@obito_p2_a,@obito_p2_b
            ,@enc_cadaver,@causa_prov_obito,@obs,@funcionarioCadastrou)";

                    commd.Parameters.Add("@nr_seq_causaMorte", SqlDbType.Int).Value = Convert.ToInt32(txtSeqPaciente.Text);
                    commd.Parameters.Add("@obito_p1_a", SqlDbType.NVarChar).Value = (object)txtDescricaoCausaMorteA.Text ?? DBNull.Value; //Caso a variavel seja nula
                    commd.Parameters.Add("@obito_p1_b", SqlDbType.NVarChar).Value = (object)txtDescricaoCausaMorteB.Text ?? DBNull.Value;
                    commd.Parameters.Add("@obito_p1_c", SqlDbType.NVarChar).Value = (object)txtDescricaoCausaMorteC.Text ?? DBNull.Value;
                    commd.Parameters.Add("@obito_p1_d", SqlDbType.NVarChar).Value = (object)txtDescricaoCausaMorteD.Text ?? DBNull.Value;
                    commd.Parameters.Add("@obito_p2_a", SqlDbType.NVarChar).Value = (object)txtDescricaoCausaMorteParte2A.Text ?? DBNull.Value;
                    commd.Parameters.Add("@obito_p2_b", SqlDbType.NVarChar).Value = (object)txtDescricaoCausaMorteParte2B.Text ?? DBNull.Value;
                    commd.Parameters.Add("@enc_cadaver", SqlDbType.NVarChar).Value = (object)DDLencaminhamentoCadaver.SelectedValue ?? DBNull.Value;
                    commd.Parameters.Add("@causa_prov_obito", SqlDbType.NVarChar).Value = (object)txtDescricaoCausaProvObito.Text ?? DBNull.Value;
                    commd.Parameters.Add("@obs", SqlDbType.NVarChar).Value = (object)txtObservacaoCausaObito.Text ?? DBNull.Value;

                    commd.Parameters.Add("@funcionarioCadastrou", SqlDbType.NVarChar).Value = (object)pegaNomeLoginUsuario.Text ?? DBNull.Value;

                    commd.CommandText = strQuery;
                    com.Open();
                    commd.ExecuteNonQuery();
                    com.Close();

                    string answer = "Registro Gravado!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                                "alert('" + answer + "'); window.location.href='RhPesquisa.aspx';", true);

                    //ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Registro Gravado!');", true);


                }
                catch (Exception ex)
                {

                    string erro = ex.Message;


                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('ERRO Registro Não foi Gravado!');", true);

                }

                //Response.Redirect("~/CadastrarAltaPaciente/RhPesquisa.aspx"); // após cadastrar os dados do paciente ele redireciona a pagina para Rh Pesquisa


            }
        }
    }

    [WebMethod]
    public static List<CID> getCid(string cid)
    {
        List<CID> lista = new List<CID>();
        string cs = ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString();
        try
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand com = new SqlCommand())
                {
                    com.CommandText = string.Format("select * from [Egressos].[dbo].[cid_obito] where cid_numero LIKE '{0}%'", cid);
                    com.Connection = con;
                    con.Open();
                    SqlDataReader sdr = com.ExecuteReader();
                    CID c = null;
                    while (sdr.Read())
                    {
                        c = new CID();
                        c.Cid_Numero = Convert.ToString(sdr["cid_numero"]);
                        c.Descricao = Convert.ToString(sdr["descricao_cid"]);
                        lista.Add(c);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error {0}", ex.Message);
        }
        return lista;
    }

}
