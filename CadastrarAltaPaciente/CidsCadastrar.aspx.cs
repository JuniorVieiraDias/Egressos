using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;

public partial class CadastrarAltaPaciente_CidsCadastrar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtSeqPaciente.Text = Request.QueryString["nrSeq"];
        txtNomePaciente.Text = Request.QueryString["nomePaciente"];
        pegaNomeLoginUsuario.Text = User.Identity.Name;
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
                    com.CommandText = string.Format("select TOP 40 * from [Egressos].[dbo].[cid_obito] where cid_numero LIKE '{0}%'", cid);
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


    protected void btnFinalizar_Click(object sender, EventArgs e)
    {


        CIDInternacao CidCir = new CIDInternacao();


        try
        {
            CidCir.Nr_Seq = Convert.ToInt32(txtSeqPaciente.Text);

            CidCir.cod_cid_Primario = txbcid1.Text == "" ? "" : txbcid1.Text;
            CidCir.desc_cid_Primario = txbDescricaoCid1.Text == "" ? "" : txbDescricaoCid1.Text;
            CidCir.cod_cid_Secundario = txbcid2.Text == "" ? "" : txbcid2.Text;
            CidCir.desc_cid_Secundario = txbDescricaoCid2.Text == "" ? "" : txbDescricaoCid2.Text;
            CidCir.cod_cid_Ass1 = txbcidA1.Text == "" ? "" : txbcidA1.Text;
            CidCir.desc_cid_Ass1 = txbDescricaoCidA1.Text == "" ? "" : txbDescricaoCidA1.Text;
            CidCir.cod_cid_Ass2 = txbcidA2.Text == "" ? "" : txbcidA2.Text;
            CidCir.desc_cid_Ass2 = txbDescricaoCidA2.Text == "" ? "" : txbDescricaoCidA2.Text;
            CidCir.cod_cid_Ass3 = txbcidA3.Text == "" ? "" : txbcidA3.Text;
            CidCir.desc_cid_Ass3 = txbDescricaoCidA3.Text == "" ? "" : txbDescricaoCidA3.Text;
            CidCir.cod_cid_CausaExterna = txbcidCausaEx.Text == "" ? "" : txbcidCausaEx.Text;
            CidCir.desc_cid_CausaExterna = txbDescricaoCidCausaEx.Text == "" ? "" : txbDescricaoCidCausaEx.Text;



            CidCir.nome_funcionario_cadastrou = pegaNomeLoginUsuario.Text == "" ? "" : pegaNomeLoginUsuario.Text;

            
           
           //GravaProcedimentoCirEcids.GravaCidPaciente(CidCir);

          
           if (GravaProcedimentoCirEcids.GravaCidPaciente(CidCir))
           {

                    string answer = "Registro Gravado!";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                                "alert('" + answer + "'); window.location.href='RhPesquisa.aspx';", true);
               
           }
           else
           {
               { ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mensagem", "alert('Erro!');", true); }

           }
            
            //string url;
            //url = "~/CadastrarAltaPaciente/RhPesquisa.aspx";
            //Response.Redirect(url);
            //}
        }
        catch (Exception ex)
        {

            string erro = ex.Message;

        }
     
    }
    protected void btnCadastrarObito_Click(object sender, EventArgs e)
    {
        CIDInternacao CidCir = new CIDInternacao();


        try
        {
            CidCir.Nr_Seq = Convert.ToInt32(txtSeqPaciente.Text);

            CidCir.cod_cid_Primario = txbcid1.Text == "" ? "" : txbcid1.Text;
            CidCir.desc_cid_Primario = txbDescricaoCid1.Text == "" ? "" : txbDescricaoCid1.Text;
            CidCir.cod_cid_Secundario = txbcid2.Text == "" ? "" : txbcid2.Text;
            CidCir.desc_cid_Secundario = txbDescricaoCid2.Text == "" ? "" : txbDescricaoCid2.Text;
            CidCir.cod_cid_Ass1 = txbcidA1.Text == "" ? "" : txbcidA1.Text;
            CidCir.desc_cid_Ass1 = txbDescricaoCidA1.Text == "" ? "" : txbDescricaoCidA1.Text;
            CidCir.cod_cid_Ass2 = txbcidA2.Text == "" ? "" : txbcidA2.Text;
            CidCir.desc_cid_Ass2 = txbDescricaoCidA2.Text == "" ? "" : txbDescricaoCidA2.Text;
            CidCir.cod_cid_Ass3 = txbcidA3.Text == "" ? "" : txbcidA3.Text;
            CidCir.desc_cid_Ass3 = txbDescricaoCidA3.Text == "" ? "" : txbDescricaoCidA3.Text;
            CidCir.cod_cid_CausaExterna = txbcidCausaEx.Text == "" ? "" : txbcidCausaEx.Text;
            CidCir.desc_cid_CausaExterna = txbDescricaoCidCausaEx.Text == "" ? "" : txbDescricaoCidCausaEx.Text;



            CidCir.nome_funcionario_cadastrou = pegaNomeLoginUsuario.Text == "" ? "" : pegaNomeLoginUsuario.Text;

            GravaProcedimentoCirEcids.GravaCidPaciente(CidCir);
            { ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mensagem", "alert('Gravado com Sucesso!');", true); }

            string url;
            url = "~/CadastrarAltaPaciente/CausaMorte.aspx?nrSeq=" + txtSeqPaciente.Text + "&nomePaciente=" + txtNomePaciente.Text;
            Response.Redirect(url);
            //}
        }
        catch (Exception ex)
        {

            string erro = ex.Message;

        }
    }
}
