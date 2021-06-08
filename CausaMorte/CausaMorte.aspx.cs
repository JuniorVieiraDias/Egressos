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
    }
    protected void btnCadastrarCausaMorte_Click(object sender, EventArgs e)
    {
        {
            CID c = new CID();
            CIDInternacao cidInternacao = new CIDInternacao();
            c = CidRepository.GetCIDPorCodigo(txtCausaMorteA.Text);
            cidInternacao.Nr_Seq = Convert.ToInt32(txtSeqPaciente.Text);
            cidInternacao.Tipo = "Primario"; // depois carregar um dropdow com os tipos
            cidInternacao.Cod_CID = c.Cid_Numero;
            //cidInternacao.Usuario = "Junior 2";
            CidRepository.GravaCidPaciente(cidInternacao);                      

            
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
