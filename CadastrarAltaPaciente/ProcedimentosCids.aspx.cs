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
using System.Collections.Generic;
using System.Web.Services;
using System.Data.SqlClient;

public partial class CadastrarAltaPaciente_ProcedimentosCids : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        txtSeqPaciente.Text = Request.QueryString["nrSeq"];
        txtNomePaciente.Text = Request.QueryString["nomePaciente"];
    }

    protected void GravarCid_Click(object sender, EventArgs e)
    {
        

        CID c = new CID();
        CIDInternacao cidInternacao = new CIDInternacao();
        c = CidRepository.GetCIDPorCodigo(txbcid.Text);
        cidInternacao.Nr_Seq = Convert.ToInt32(txtSeqPaciente.Text);
        cidInternacao.Tipo = "Primario"; // depois carregar um dropdow com os tipos
        cidInternacao.Cod_CID = c.Cid_Numero;
        cidInternacao.Usuario = "Junior 2";

        if (!ProcedimentoCirRepository.verificaSituacaoCid(cidInternacao.Nr_Seq, cidInternacao.Cod_CID))
        {            
        
        CidRepository.GravaCidPaciente(cidInternacao);
        }
        else
        {
            { ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Esse Cid já foi cadastrado!');", true); }

        }
        CarregaGrid(cidInternacao.Nr_Seq);

        txbcid.Text = "";
        txbDescricao.Text = "";
    }

    private void CarregaGrid(int nr_seq)
    {
        gvListaCID.DataSource = CidRepository.CarregaCIDInternacao(nr_seq);
        gvListaCID.DataBind();
    }
    //Gravar Procedimento Cirurgico
    protected void btnPesquisarProcedimento_Click(object sender, EventArgs e)
    {
        try
        {
            int codProcedimento = Convert.ToInt32(txtCodigoProcedimento.Text);
            ProcedimentoCir p = new ProcedimentoCir();
            Procedimento_Internacao pI = new Procedimento_Internacao();
            p = ProcedimentoCirRepository.GetProcedimentoCirPorCodigo(codProcedimento);
            pI.Nr_Seq = Convert.ToInt32(txtSeqPaciente.Text);
            pI.Cod_Procedimento = p.Procedimento;
            pI.Data_Cir = txtDtCirurgia.Text;

            pI.Nome_Funcionario_Cadastrou = "Junior2";//verificaSituacaoProcedimentoCir

            if (!ProcedimentoCirRepository.verificaSituacaoProcedimentoCir(pI.Nr_Seq, pI.Cod_Procedimento))
            { 

                ProcedimentoCirRepository.GravaProcedimentoCirPaciente(pI);
            }
            else
            {
                { ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Esse Procedimento já foi cadastrado!');", true); }

            }
            
            CarregaGridProcedimentosInternacao(pI.Nr_Seq);
        }
        catch (Exception ex)
        {
            string erro = ex.Message;
            //if (txtDtCirurgia.Text == "")
            // { ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('É Obrigatório Preencher campo data da Cirurgia!');", true); }
        }
        txtSeqPaciente.Text = "";
       // txbDescricao.Text = "";
    }

    private void CarregaGridProcedimentosInternacao(int p)
    {
        gvProcedimento.DataSource = ProcedimentoCirRepository.CarregaProcedimentosInternacao(p);
        gvProcedimento.DataBind();
    }

    protected void grdProcedimentoCir_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //int id = Convert.ToInt32(txtRemoveProcedimento.Text);
        //CidRepository.RemoverProcedimentoPaciente(id);
        //CarregaGridProcedimentosInternacao(Convert.ToInt32(txtSeqPaciente.Text));

        if (e.CommandName.Equals("deletaProcedimento"))
        {
            GridViewRow row = gvProcedimento.Rows[Convert.ToInt32(e.CommandArgument)];
            CidRepository.RemoverProcedimentoPaciente(Convert.ToInt32(gvProcedimento.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString()));
        }
        CarregaGridProcedimentosInternacao(Convert.ToInt32(txtSeqPaciente.Text));
    }

    protected void grdMain_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("deletaCid"))
        {
            GridViewRow row = gvListaCID.Rows[Convert.ToInt32(e.CommandArgument)];
            CidRepository.RemoverCidPaciente(Convert.ToInt32(gvListaCID.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString()));
        }
        CarregaGrid(Convert.ToInt32(txtSeqPaciente.Text));
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
    // Procedimento Cirurgico
    [WebMethod]
    public static List<ProcedimentoCir> getProcCir(int procCir)
    {
        List<ProcedimentoCir> lista = new List<ProcedimentoCir>();
        string cs = ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString();
        try
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                using (SqlCommand com = new SqlCommand())
                {
                    com.CommandText = string.Format("select * from [Egressos].[dbo].[ProcedimentoCir] where Procedimento LIKE '{0}%'", procCir);
                    com.Connection = con;
                    con.Open();
                    SqlDataReader sdr = com.ExecuteReader();
                    ProcedimentoCir p = null;
                    while (sdr.Read())
                    {
                        p = new ProcedimentoCir();
                        p.Procedimento = Convert.ToInt32(sdr["Procedimento"]);
                        p.Descricao = Convert.ToString(sdr["Descrição"]);
                        lista.Add(p);
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
        if (gvListaCID.Rows.Count<=0 || gvProcedimento.Rows.Count<=0)
        {
                    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Obrigatório pelo menos 1 Procedimento e pelo menos 1 CID!');", true);
        }
        else
        {
            Response.Redirect("~/CadastrarAltaPaciente/RhPesquisa.aspx"); // após cadastrar os dados do paciente ele redireciona a pagina para Rh Pesquisa
                
        }
                
    }
    protected void btnCadastrarObito_Click(object sender, EventArgs e)
    {
        if (gvListaCID.Rows.Count <= 0 || gvProcedimento.Rows.Count <= 0)
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Obrigatório pelo menos 1 Procedimento e pelo menos 1 CID!');", true);
        }
        else
        {
            string url;
            url = "~/CausaMorte/CausaMorte.aspx?nrSeq=" + txtSeqPaciente.Text + "&nomePaciente=" + txtNomePaciente.Text;
            Response.Redirect(url);
           
            Response.Redirect("~/CausaMorte/CausaMorte.aspx"); // após cadastrar os dados do paciente ele redireciona a pagina para Rh Pesquisa

        }

        //redirecionar para pagina de obito
        

    }
}
