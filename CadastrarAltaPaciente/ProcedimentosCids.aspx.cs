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
        if (!this.IsPostBack)
        {
            txtSeqPaciente.Text = Request.QueryString["nrSeq"];
            txtNomePaciente.Text = Request.QueryString["nomePaciente"];
            pegaNomeLoginUsuario.Text = User.Identity.Name;
        }
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
                    com.CommandText = string.Format("select top 40 * from [Egressos].[dbo].[ProcedimentoCir] where Procedimento LIKE '{0}%'", procCir);
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
  Procedimento_Internacao ProcCir1= new Procedimento_Internacao();

 
  try
  {
      ProcCir1.Nr_Seq = Convert.ToInt32(txtSeqPaciente.Text);


      ProcCir1.Cod_Procedimento1 = txtCodigoProcedimento1.Text == "" ? 0 : Convert.ToInt32(txtCodigoProcedimento1.Text);
      ProcCir1.Cod_Procedimento2 = txtCodigoProcedimento2.Text == "" ? 0 : Convert.ToInt32(txtCodigoProcedimento2.Text);
      ProcCir1.Cod_Procedimento3 = txtCodigoProcedimento3.Text == "" ? 0 : Convert.ToInt32(txtCodigoProcedimento3.Text);
      ProcCir1.Cod_Procedimento4 = txtCodigoProcedimento4.Text == "" ? 0 : Convert.ToInt32(txtCodigoProcedimento4.Text);
      ProcCir1.Cod_Procedimento5 = txtCodigoProcedimento5.Text == "" ? 0 : Convert.ToInt32(txtCodigoProcedimento5.Text);
      ProcCir1.Descr_Procedimento_Cir_1 = txtDescProcedimento1.Text == "" ? "" : txtDescProcedimento1.Text;
      ProcCir1.Descr_Procedimento_Cir_2 = txtDescProcedimento2.Text == "" ? "" : txtDescProcedimento2.Text;
      ProcCir1.Descr_Procedimento_Cir_3 = txtDescProcedimento3.Text == "" ? "" : txtDescProcedimento3.Text;
      ProcCir1.Descr_Procedimento_Cir_4 = txtDescProcedimento4.Text == "" ? "" : txtDescProcedimento4.Text;
      ProcCir1.Descr_Procedimento_Cir_5 = txtDescProcedimento5.Text == "" ? "" : txtDescProcedimento5.Text;
      ProcCir1.Data_Cir_1 = txtDtCirurgia1.Text == "" ? "" : txtDtCirurgia1.Text;
      ProcCir1.Data_Cir_2 = txtDtCirurgia2.Text == "" ? "" : txtDtCirurgia2.Text;
      ProcCir1.Data_Cir_3 = txtDtCirurgia3.Text == "" ? "" : txtDtCirurgia3.Text;
      ProcCir1.Data_Cir_4 = txtDtCirurgia4.Text == "" ? "" : txtDtCirurgia4.Text;
      ProcCir1.Data_Cir_5 = txtDtCirurgia5.Text == "" ? "" : txtDtCirurgia5.Text; 
      
      ProcCir1.Obs_Proced_Cir = txtOBSprocCir.Text == "" ? "" : txtOBSprocCir.Text;
      ProcCir1.Nome_Funcionario_Cadastrou = pegaNomeLoginUsuario.Text == "" ? "" : pegaNomeLoginUsuario.Text;

      //if (ProcCir.Cod_Procedimento1 == null)
      //{
         // ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Obrigatório pelo menos 1 Procedimento e pelo menos 1 CID!');", true);
      //}
      //else
      //{
          GravaProcedimentoCirEcids.GravaProcedimentoCirPaciente(ProcCir1);
          ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Dados Cadastrados!');", true); 

          string url;
          url = "~/CadastrarAltaPaciente/CidsCadastrar.aspx?nrSeq=" + txtSeqPaciente.Text + "&nomePaciente=" + txtNomePaciente.Text;
      
      Response.Redirect(url);
      //}
  }
  catch (Exception ex)
  {

      string erro = ex.Message;
      
  }
        
        

    }
    ////////protected void btnCadastrarObito_Click(object sender, EventArgs e)
    ////////{
        

    ////////}
}
