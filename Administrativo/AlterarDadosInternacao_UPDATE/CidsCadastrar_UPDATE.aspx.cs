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
        if (!this.IsPostBack)
        {
            txtSeqPaciente.Text = Request.QueryString["nrSeq"];
            txtNomePaciente.Text = Request.QueryString["nomePaciente"];
            pegaNomeLoginUsuario.Text = User.Identity.Name;
            GetListaCidsCadastrados_UPDATE(txtSeqPaciente.Text);
        }
    }

    public void GetListaCidsCadastrados_UPDATE(string nrSeq)
    {

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {
            try
            {
                int nrseq = Convert.ToInt32(nrSeq);
                SqlCommand cmm = cnn.CreateCommand();
                string sqlConsulta = @"SELECT 
       [cod_cid_Primario]
      ,[desc_cid_Primario]
      ,[cod_cid_Secundario]
      ,[desc_cid_Secundario]
      ,[cod_cid_Ass1]
      ,[desc_cid_Ass1]
      ,[cod_cid_Ass2]
      ,[desc_cid_Ass2]
      ,[cod_cid_Ass3]
      ,[desc_cid_Ass3]
      ,[cod_cid_CausaExterna]
      ,[desc_cid_CausaExterna]
      
  FROM [Egressos].[dbo].[cid_intenacao] where nr_seq=" + nrseq + "";
                cmm.CommandText = sqlConsulta;


                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();

                while (dr1.Read())
                {
                    txbcid1.Text = dr1.IsDBNull(0) ? "" : dr1.GetString(0);
                    txbDescricaoCid1.Text = dr1.IsDBNull(1) ? "" : dr1.GetString(1);
                    txbcid2.Text = dr1.IsDBNull(2) ? "" : dr1.GetString(2);
                    txbDescricaoCid2.Text = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    txbcidA1.Text = dr1.IsDBNull(4) ? "" : dr1.GetString(4);
                    txbDescricaoCidA1.Text = dr1.IsDBNull(5) ? "" : dr1.GetString(5);
                    txbcidA2.Text = dr1.IsDBNull(6) ? "" : dr1.GetString(6);
                    txbDescricaoCidA2.Text = dr1.IsDBNull(7) ? "" : dr1.GetString(7);
                    txbcidA3.Text = dr1.IsDBNull(8) ? "" : dr1.GetString(8);
                    txbDescricaoCidA3.Text = dr1.IsDBNull(9) ? "" : dr1.GetString(9);
                    txbcidCausaEx.Text = dr1.IsDBNull(10) ? "" : dr1.GetString(10);
                    txbDescricaoCidCausaEx.Text = dr1.IsDBNull(11) ? "" : dr1.GetString(11);

                }

            }
            catch (Exception ex)
            {

                string error = ex.Message;
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

    protected void btnFinalizar_Click(object sender, EventArgs e)//Atualizar
    {
        int nrseq = Convert.ToInt32(txtSeqPaciente.Text);
        InternacaoDAO_UPDATE.excluir_paralisia(nrseq);
        CIDInternacao CidCir = new CIDInternacao();

        try
        {
            //CidCir.Nr_Seq = Convert.ToInt32(txtSeqPaciente.Text);
            //CidCir.cod_cid_Primario = txbcid1.Text == "" ? "" : txbcid1.Text;
            //CidCir.desc_cid_Primario = txbDescricaoCid1.Text == "" ? "" : txbDescricaoCid1.Text;
            //CidCir.cod_cid_Secundario = txbcid2.Text == "" ? "" : txbcid2.Text;
            //CidCir.desc_cid_Secundario = txbDescricaoCid2.Text == "" ? "" : txbDescricaoCid2.Text;
            //CidCir.cod_cid_Ass1 = txbcidA1.Text == "" ? "" : txbcidA1.Text;
            //CidCir.desc_cid_Ass1 = txbDescricaoCidA1.Text == "" ? "" : txbDescricaoCidA1.Text;
            //CidCir.cod_cid_Ass2 = txbcidA2.Text == "" ? "" : txbcidA2.Text;
            //CidCir.desc_cid_Ass2 = txbDescricaoCidA2.Text == "" ? "" : txbDescricaoCidA2.Text;
            //CidCir.cod_cid_Ass3 = txbcidA3.Text == "" ? "" : txbcidA3.Text;
            //CidCir.desc_cid_Ass3 = txbDescricaoCidA3.Text == "" ? "" : txbDescricaoCidA3.Text;
            //CidCir.cod_cid_CausaExterna = txbcidCausaEx.Text == "" ? "" : txbcidCausaEx.Text;
            //CidCir.desc_cid_CausaExterna = txbDescricaoCidCausaEx.Text == "" ? "" : txbDescricaoCidCausaEx.Text;
            //CidCir.nome_funcionario_cadastrou = pegaNomeLoginUsuario.Text == "" ? "" : pegaNomeLoginUsuario.Text;


            // teste up cids

            CidCir.Nr_Seq = Convert.ToInt32(txtSeqPaciente.Text);
            CidCir.cod_cid_Primario = txbcid1.Text == "" ? "" : txbcid1.Text;
            InternacaoDAO.VerificaExisteParalisia(CidCir.Nr_Seq, CidCir.cod_cid_Primario);
            CidCir.desc_cid_Primario = txbDescricaoCid1.Text == "" ? "" : txbDescricaoCid1.Text;
            CidCir.cod_cid_Secundario = txbcid2.Text == "" ? "" : txbcid2.Text;
            InternacaoDAO.VerificaExisteParalisia(CidCir.Nr_Seq, CidCir.cod_cid_Secundario);
            CidCir.desc_cid_Secundario = txbDescricaoCid2.Text == "" ? "" : txbDescricaoCid2.Text;
            CidCir.cod_cid_Ass1 = txbcidA1.Text == "" ? "" : txbcidA1.Text;
            InternacaoDAO.VerificaExisteParalisia(CidCir.Nr_Seq, CidCir.cod_cid_Ass1);
            CidCir.desc_cid_Ass1 = txbDescricaoCidA1.Text == "" ? "" : txbDescricaoCidA1.Text;
            CidCir.cod_cid_Ass2 = txbcidA2.Text == "" ? "" : txbcidA2.Text;
            InternacaoDAO.VerificaExisteParalisia(CidCir.Nr_Seq, CidCir.cod_cid_Ass2);
            CidCir.desc_cid_Ass2 = txbDescricaoCidA2.Text == "" ? "" : txbDescricaoCidA2.Text;
            CidCir.cod_cid_Ass3 = txbcidA3.Text == "" ? "" : txbcidA3.Text;
            InternacaoDAO.VerificaExisteParalisia(CidCir.Nr_Seq, CidCir.cod_cid_Ass3);
            CidCir.desc_cid_Ass3 = txbDescricaoCidA3.Text == "" ? "" : txbDescricaoCidA3.Text;
            CidCir.cod_cid_CausaExterna = txbcidCausaEx.Text == "" ? "" : txbcidCausaEx.Text;
            InternacaoDAO.VerificaExisteParalisia(CidCir.Nr_Seq, CidCir.cod_cid_CausaExterna);
            CidCir.desc_cid_CausaExterna = txbDescricaoCidCausaEx.Text == "" ? "" : txbDescricaoCidCausaEx.Text;
            CidCir.nome_funcionario_cadastrou = pegaNomeLoginUsuario.Text == "" ? "" : pegaNomeLoginUsuario.Text;

            // Fim teste




            //GravaProcedimentoCirEcids.GravaCidPaciente(CidCir);


            if (GravaProcedimentoCirEcids.AtualizaCidPaciente(CidCir))
            {
                { ScriptManager.RegisterStartupScript(Page, Page.GetType(), "mensagem", "alert('Atualizado!');", true); }

                string url;
                url = "~/Administrativo/AlterarDadosInternacao_UPDATE/CausaMorte_UPDATE.aspx?nrSeq=" + txtSeqPaciente.Text + "&nomePaciente=" + txtNomePaciente.Text;
                Response.Redirect(url);

                //string answer = "Registro Gravado!";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect",
                //            "alert('" + answer + "'); window.location.href='RhPesquisa.aspx';", true);

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
    protected void btnCadastrarObito_Click(object sender, EventArgs e)// proxima pagina
    {
        try
        {
            string url;
            url = "~/Administrativo/AlterarDadosInternacao_UPDATE/CausaMorte_UPDATE.aspx?nrSeq=" + txtSeqPaciente.Text + "&nomePaciente=" + txtNomePaciente.Text;
            Response.Redirect(url);
            //}
        }
        catch (Exception ex)
        {
            string erro = ex.Message;
        }
    }
}
