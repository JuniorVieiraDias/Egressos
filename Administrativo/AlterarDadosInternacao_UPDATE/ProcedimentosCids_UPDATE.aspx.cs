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
            GetListaProcedimentosCadastrados_UPDATE(txtSeqPaciente.Text);
        }
    }


    public void GetListaProcedimentosCadastrados_UPDATE(string nrSeq)
    {
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {
            try
            {
                int nrseq = Convert.ToInt32(nrSeq);

            SqlCommand cmm = cnn.CreateCommand();
            string sqlConsulta = @"SELECT       
       [cod_procedimento1]
      ,[descricao_proc1]
      ,[data_cir_1]
      ,[cod_procedimento2]
      ,[descricao_proc2]
      ,[data_cir_2]
      ,[cod_procedimento3]
      ,[descricao_proc3]
      ,[data_cir_3]
      ,[cod_procedimento4]
      ,[descricao_proc4]
      ,[data_cir_4]
      ,[cod_procedimento5]
      ,[descricao_proc5]
      ,[data_cir_5]
      ,[obs_proced_cir]
            
  FROM [Egressos].[dbo].[procedimento_internacao] where nr_seq=" + nrseq + "";
            cmm.CommandText = sqlConsulta;

           
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();

                while (dr1.Read())
                {

                    txtCodigoProcedimento1.Text = Convert.ToString(dr1.GetInt32(0));
                    txtDescProcedimento1.Text = dr1.GetString(1);
                    txtDtCirurgia1.Text = dr1.IsDBNull(2) ? "" : dr1.GetString(2);
                    txtCodigoProcedimento2.Text = Convert.ToString(dr1.IsDBNull(3) ? 0 : dr1.GetInt32(3));
                    txtDescProcedimento2.Text = dr1.IsDBNull(4) ? "" : dr1.GetString(4);
                    txtDtCirurgia2.Text = dr1.IsDBNull(5) ? "" : dr1.GetString(5);
                    txtCodigoProcedimento3.Text = Convert.ToString(dr1.IsDBNull(6) ? 0 : dr1.GetInt32(6));
                    txtDescProcedimento3.Text = dr1.IsDBNull(7) ? "" : dr1.GetString(7);
                    txtDtCirurgia3.Text = dr1.IsDBNull(8) ? "" : dr1.GetString(8);
                    txtCodigoProcedimento4.Text = Convert.ToString(dr1.IsDBNull(9) ? 0 : dr1.GetInt32(9));
                    txtDescProcedimento4.Text = dr1.IsDBNull(10) ? "" : dr1.GetString(10);
                    txtDtCirurgia4.Text = dr1.IsDBNull(11) ? "" : dr1.GetString(11);
                    txtCodigoProcedimento5.Text = Convert.ToString(dr1.IsDBNull(12) ? 0 : dr1.GetInt32(12));
                    txtDescProcedimento5.Text = dr1.IsDBNull(13) ? "" : dr1.GetString(13);
                    txtDtCirurgia5.Text = dr1.IsDBNull(14) ? "" : dr1.GetString(14);                     
                    txtOBSprocCir.Text = dr1.IsDBNull(15) ? "" : dr1.GetString(15);
                }

            }
            catch (Exception ex)
            {

                string error = ex.Message;
            }


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



    protected void btnAtualizar_Click(object sender, EventArgs e)
    {
        Procedimento_Internacao ProcCir1 = new Procedimento_Internacao();


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
            ProcCir1.Data_Cir_4 = txtDtCirurgia4.Text == "" ? "" : txtDtCirurgia3.Text;
            ProcCir1.Data_Cir_5 = txtDtCirurgia5.Text == "" ? "" : txtDtCirurgia3.Text;


            ProcCir1.Obs_Proced_Cir = txtOBSprocCir.Text == "" ? "" : txtOBSprocCir.Text;
           
            
            ProcCir1.Nome_Funcionario_Cadastrou = pegaNomeLoginUsuario.Text == "" ? "" : pegaNomeLoginUsuario.Text;


            GravaProcedimentoCirEcids.AtualizaProcedimentoCirPaciente(ProcCir1);
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Dados Cadastrados!');", true);

            string url;
            url = "~/Administrativo/AlterarDadosInternacao_UPDATE/CidsCadastrar_UPDATE.aspx?nrSeq=" + txtSeqPaciente.Text + "&nomePaciente=" + txtNomePaciente.Text;

            Response.Redirect(url);
            //}
        }
        catch (Exception ex)
        {

            string erro = ex.Message;

        }

    }
    protected void btnProximo_Click(object sender, EventArgs e)
    {
        string url;
        url = "~/Administrativo/AlterarDadosInternacao_UPDATE/CidsCadastrar_UPDATE.aspx?nrSeq=" + txtSeqPaciente.Text + "&nomePaciente=" + txtNomePaciente.Text;
        Response.Redirect(url);
    }
}
