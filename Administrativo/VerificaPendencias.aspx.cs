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
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

public partial class RhPesquisa : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnPesquisar_Click(object sender, EventArgs e)
    {
        string dtIncio = Dt_Inicio.Text;
        string dtFim = Dt_Fim.Text;
        List<Internacao> details = new List<Internacao>();
        try
        {             
             string URI = "http://10.48.21.64:5000/hspmsgh-api/internacoes?tipo=1&dt_inicio='" + dtIncio + " '&dt_fim='" + dtFim + "'";

            WebRequest request = WebRequest.Create(URI);

            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(URI);
            // Sends the HttpWebRequest and waits for a response.
            HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();

            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                var reader = new StreamReader(httpResponse.GetResponseStream());
                JsonSerializer json = new JsonSerializer();
                var objText = reader.ReadToEnd();
                details = JsonConvert.DeserializeObject<List<Internacao>>(objText);
                //Este é um comentário
                foreach (Internacao paciente in details)
                {
                    InternacaoDAO.GravaInternacao(paciente);
                }
            }
        }
        catch (WebException ex)
        {
            string err = ex.Message;
        }
        catch (Exception ex1)
        {
            string err1 = ex1.Message;
        }

        Bindgrid();
    }

    private void Bindgrid()
    {
        GridViewDadosPaciente.DataSource = InternacaoDAO.GetListaInternacoeTodosUsuarios();
        GridViewDadosPaciente.DataBind();
    }

    protected void grdDadosPacienteSGH_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int nrSeq = Convert.ToInt32(GridViewDadosPaciente.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString());
        Response.Redirect("~/CadastrarAltaPaciente/CadastraAlta.aspx?nrSeq=" + nrSeq);

    }
}
