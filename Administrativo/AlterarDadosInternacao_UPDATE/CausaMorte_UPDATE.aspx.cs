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
        if (!this.IsPostBack)
        {
            txtSeqPaciente.Text = Request.QueryString["nrSeq"];
            txtNomePaciente.Text = Request.QueryString["nomePaciente"];
            pegaNomeLoginUsuario.Text = User.Identity.Name;
            GetListaCidsCausaMorte_UPDATE(txtSeqPaciente.Text);
        }
    }

    public void GetListaCidsCausaMorte_UPDATE(string nrSeq)
    {
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {
            try
            {
                int nrseq2 = Convert.ToInt32(nrSeq);
                SqlCommand cmm = cnn.CreateCommand();
                string sqlConsulta = @"SELECT 
       [cid_Obito_a]
      ,[obito_p1_a]
      ,[cid_Obito_b]
      ,[obito_p1_b]
      ,[cid_Obito_c]
      ,[obito_p1_c]
      ,[cid_Obito_d]
      ,[obito_p1_d]
      ,[cid_Obito_2_a]
      ,[obito_p2_a]
      ,[cid_Obito_2_b]
      ,[obito_p2_b]
      ,[enc_cadaver]
      ,[cid_obito_causaP]
      ,[causa_prov_obito]
      ,[obs]
      
  FROM [Egressos].[dbo].[causaMorte] where nr_seq_causaMorte=" + nrseq2 + "";
                cmm.CommandText = sqlConsulta;
                //try
                //{
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();

                while (dr1.Read())
                {
                    txtCausaMorteA.Text = dr1.IsDBNull(0) ? "" : dr1.GetString(0);
                    txtDescricaoCausaMorteA.Text = dr1.IsDBNull(1) ? "" : dr1.GetString(1);
                    txtCausaMorteB.Text = dr1.IsDBNull(2) ? "" : dr1.GetString(2);
                    txtDescricaoCausaMorteB.Text = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    txtCausaMorteC.Text = dr1.IsDBNull(4) ? "" : dr1.GetString(4);
                    txtDescricaoCausaMorteC.Text = dr1.IsDBNull(5) ? "" : dr1.GetString(5);
                    txtCausaMorteD.Text = dr1.IsDBNull(6) ? "" : dr1.GetString(6);
                    txtDescricaoCausaMorteD.Text = dr1.IsDBNull(7) ? "" : dr1.GetString(7);
                    txtCausaMorteParte2A.Text = dr1.IsDBNull(8) ? "" : dr1.GetString(8);
                    txtDescricaoCausaMorteParte2A.Text = dr1.IsDBNull(9) ? "" : dr1.GetString(9);
                    txtCausaMorteParte2B.Text = dr1.IsDBNull(10) ? "" : dr1.GetString(10);
                    txtDescricaoCausaMorteParte2B.Text = dr1.IsDBNull(11) ? "" : dr1.GetString(11);
                    DDLencaminhamentoCadaver.Text = dr1.IsDBNull(12) ? "" : dr1.GetString(12);
                    txtCausaProvObito.Text = dr1.IsDBNull(13) ? "" : dr1.GetString(13);
                    txtDescricaoCausaProvObito.Text = dr1.IsDBNull(14) ? "" : dr1.GetString(14);
                    txtObservacaoCausaObito.Text = dr1.IsDBNull(15) ? "" : dr1.GetString(15);
                    //txtCausaMorteA.Text = dr1.IsDBNull(9) ? "" : dr1.GetString(9);
                    //txtCausaMorteA.Text = dr1.IsDBNull(10) ? "" : dr1.GetString(10);
                    //txbDescricaoCidCausaEx.Text = dr1.IsDBNull(11) ? "" : dr1.GetString(11);

                }

            }
            catch (Exception ex)
            {

                string error = ex.Message;
            }

        }

    }

    protected void btnCadastrarCausaMorte_Click(object sender, EventArgs e)//Atualizar
    {
        int nqseq = Convert.ToInt32(txtSeqPaciente.Text);

        if (DDLencaminhamentoCadaver.SelectedValue != "Bem definido" && txtCausaProvObito.Text == "")
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Se escolher IML ou SVO tem que cadastrar Causa provavel Obito');", true);

        }
        else
        {

            string dataAtual = Convert.ToString(DateTime.Now);
            using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
            {
                try
                {
                    string strQuery = "";
                    SqlCommand commd = new SqlCommand(strQuery, com);
                    strQuery = @"UPDATE [Egressos].[dbo].[causaMorte]
   SET
            [cid_Obito_a]=@cid_Obito_a 
            ,[obito_p1_a]=@obito_p1_a
            ,[cid_Obito_b]=@cid_Obito_b 
            ,[obito_p1_b]=@obito_p1_b
            ,[cid_Obito_c]=@cid_Obito_c 
            ,[obito_p1_c]=@obito_p1_c
            ,[cid_Obito_d]=@cid_Obito_d 
            ,[obito_p1_d]=@obito_p1_d
            ,[cid_Obito_2_a]=@cid_Obito_2_a 
            ,[obito_p2_a]=@obito_p2_a
            ,[cid_Obito_2_b]=@cid_Obito_2_b 
            ,[obito_p2_b]=@obito_p2_b
            ,[enc_cadaver]=@enc_cadaver
            ,[cid_obito_causaP]=@cid_obito_causaP 
            ,[causa_prov_obito]=@causa_prov_obito
            ,[obs]=@obs
            ,[nome_funcionario_alterou_obito]=@funcionarioCadastrou
            ,[data_alterou_obito]=@dataCadastrou
     
            WHERE nr_seq_causaMorte=" + nqseq + "";

                    commd.Parameters.Add("@cid_Obito_a", SqlDbType.NVarChar).Value = (object)txtCausaMorteA.Text ?? DBNull.Value; //Caso a variavel seja nula                   
                    commd.Parameters.Add("@obito_p1_a", SqlDbType.NVarChar).Value = (object)txtDescricaoCausaMorteA.Text ?? DBNull.Value; //Caso a variavel seja nula
                    commd.Parameters.Add("@cid_Obito_b", SqlDbType.NVarChar).Value = (object)txtCausaMorteB.Text ?? DBNull.Value; //Caso a variavel seja nula                    
                    commd.Parameters.Add("@obito_p1_b", SqlDbType.NVarChar).Value = (object)txtDescricaoCausaMorteB.Text ?? DBNull.Value;
                    commd.Parameters.Add("@cid_Obito_c", SqlDbType.NVarChar).Value = (object)txtCausaMorteC.Text ?? DBNull.Value; //Caso a variavel seja nula                    
                    commd.Parameters.Add("@obito_p1_c", SqlDbType.NVarChar).Value = (object)txtDescricaoCausaMorteC.Text ?? DBNull.Value;
                    commd.Parameters.Add("@cid_Obito_d", SqlDbType.NVarChar).Value = (object)txtCausaMorteA.Text ?? DBNull.Value; //Caso a variavel seja nula                    
                    commd.Parameters.Add("@obito_p1_d", SqlDbType.NVarChar).Value = (object)txtDescricaoCausaMorteD.Text ?? DBNull.Value;
                    commd.Parameters.Add("@cid_Obito_2_a", SqlDbType.NVarChar).Value = (object)txtCausaMorteParte2A.Text ?? DBNull.Value; //Caso a variavel seja nula                    
                    commd.Parameters.Add("@obito_p2_a", SqlDbType.NVarChar).Value = (object)txtDescricaoCausaMorteParte2A.Text ?? DBNull.Value;
                    commd.Parameters.Add("@cid_Obito_2_b", SqlDbType.NVarChar).Value = (object)txtCausaMorteParte2B.Text ?? DBNull.Value; //Caso a variavel seja nula                    
                    commd.Parameters.Add("@obito_p2_b", SqlDbType.NVarChar).Value = (object)txtDescricaoCausaMorteParte2B.Text ?? DBNull.Value;
                    commd.Parameters.Add("@enc_cadaver", SqlDbType.NVarChar).Value = (object)DDLencaminhamentoCadaver.SelectedValue ?? DBNull.Value;
                    commd.Parameters.Add("@cid_obito_causaP", SqlDbType.NVarChar).Value = (object)txtCausaProvObito.Text ?? DBNull.Value; //Caso a variavel seja nula                    
                    commd.Parameters.Add("@causa_prov_obito", SqlDbType.NVarChar).Value = (object)txtDescricaoCausaProvObito.Text ?? DBNull.Value;
                    commd.Parameters.Add("@obs", SqlDbType.NVarChar).Value = (object)txtObservacaoCausaObito.Text ?? DBNull.Value;
                    commd.Parameters.Add("@funcionarioCadastrou", SqlDbType.NVarChar).Value = (object)pegaNomeLoginUsuario.Text ?? DBNull.Value;
                    commd.Parameters.Add("@dataCadastrou", SqlDbType.NVarChar).Value = (object)dataAtual ?? DBNull.Value;


                    commd.CommandText = strQuery;
                    com.Open();
                    commd.ExecuteNonQuery();
                    com.Close();

                    string answer = "Registro Gravado!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                                "alert('" + answer + "'); window.location.href='RhPesquisa_UPDATE.aspx';", true);

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
                    com.CommandText = string.Format("select top 40 * from [Egressos].[dbo].[cid_obito] where cid_numero LIKE '{0}%'", cid);
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

    //    protected void btnCadastrarCausaMorte_Click(object sender, EventArgs e)
    //    {
    //        if (DDLencaminhamentoCadaver.SelectedValue != "Bem definido" && txtCausaProvObito.Text == "")
    //        {
    //            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Se escolher IML ou SVO tem que cadastrar Causa provavel Obito');", true);

    //        }
    //        else
    //        {

    //            string dataAtual = Convert.ToString(DateTime.Now);
    //            using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
    //            {
    //                try
    //                {
    //                    string strQuery = "";
    //                    SqlCommand commd = new SqlCommand(strQuery, com);
    //                    strQuery = @"INSERT INTO [Egressos].[dbo].[causaMorte]
    //           ([nr_seq_causaMorte],[obito_p1_a],[obito_p1_b],[obito_p1_c],[obito_p1_d],[obito_p2_a],[obito_p2_b],[enc_cadaver],[causa_prov_obito]
    //           ,[obs],[funcionarioCadastrou_obito],[data_cadastrou_obito])
    //     
    //            VALUES (@nr_seq_causaMorte,@obito_p1_a,@obito_p1_b,@obito_p1_c,@obito_p1_d,@obito_p2_a,@obito_p2_b
    //            ,@enc_cadaver,@causa_prov_obito,@obs,@funcionarioCadastrou,@dataCadastrou)";

    //                    commd.Parameters.Add("@nr_seq_causaMorte", SqlDbType.Int).Value = Convert.ToInt32(txtSeqPaciente.Text);
    //                    commd.Parameters.Add("@obito_p1_a", SqlDbType.NVarChar).Value = (object)txtDescricaoCausaMorteA.Text ?? DBNull.Value; //Caso a variavel seja nula
    //                    commd.Parameters.Add("@obito_p1_b", SqlDbType.NVarChar).Value = (object)txtDescricaoCausaMorteB.Text ?? DBNull.Value;
    //                    commd.Parameters.Add("@obito_p1_c", SqlDbType.NVarChar).Value = (object)txtDescricaoCausaMorteC.Text ?? DBNull.Value;
    //                    commd.Parameters.Add("@obito_p1_d", SqlDbType.NVarChar).Value = (object)txtDescricaoCausaMorteD.Text ?? DBNull.Value;
    //                    commd.Parameters.Add("@obito_p2_a", SqlDbType.NVarChar).Value = (object)txtDescricaoCausaMorteParte2A.Text ?? DBNull.Value;
    //                    commd.Parameters.Add("@obito_p2_b", SqlDbType.NVarChar).Value = (object)txtDescricaoCausaMorteParte2B.Text ?? DBNull.Value;
    //                    commd.Parameters.Add("@enc_cadaver", SqlDbType.NVarChar).Value = (object)DDLencaminhamentoCadaver.SelectedValue ?? DBNull.Value;
    //                    commd.Parameters.Add("@causa_prov_obito", SqlDbType.NVarChar).Value = (object)txtDescricaoCausaProvObito.Text ?? DBNull.Value;
    //                    commd.Parameters.Add("@obs", SqlDbType.NVarChar).Value = (object)txtObservacaoCausaObito.Text ?? DBNull.Value;

    //                    commd.Parameters.Add("@funcionarioCadastrou", SqlDbType.NVarChar).Value = (object)pegaNomeLoginUsuario.Text ?? DBNull.Value;
    //                    commd.Parameters.Add("@dataCadastrou", SqlDbType.NVarChar).Value = (object)dataAtual ?? DBNull.Value;

    //                    commd.CommandText = strQuery;
    //                    com.Open();
    //                    commd.ExecuteNonQuery();
    //                    com.Close();

    //                    string answer = "Registro Gravado!";
    //                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
    //                                "alert('" + answer + "'); window.location.href='RhPesquisa.aspx';", true);

    //                    //ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Registro Gravado!');", true);


    //                }
    //                catch (Exception ex)
    //                {

    //                    string erro = ex.Message;


    //                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('ERRO Registro Não foi Gravado!');", true);

    //                }

    //                //Response.Redirect("~/CadastrarAltaPaciente/RhPesquisa.aspx"); // após cadastrar os dados do paciente ele redireciona a pagina para Rh Pesquisa


    //            }
    //        }
    //    }


}
