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
        int prontuario = Convert.ToInt32(rh_Paciente.Text);
        List<Internacao> details = new List<Internacao>();
        InternacaoDAO_UPDATE.GetListaInternacoePorProntuario_UPDATE(prontuario);
        Bindgrid(prontuario);
    }
    private void Bindgrid(int prontuario)
    {
        GridViewDadosPaciente.DataSource = InternacaoDAO_UPDATE.GetListaInternacoePorProntuario_UPDATE(prontuario);
        GridViewDadosPaciente.DataBind();
    }
    protected void grdDadosPacienteSGH_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int nrSeq = Convert.ToInt32(GridViewDadosPaciente.DataKeys[Convert.ToInt32(e.CommandArgument)].Value.ToString());
        Response.Redirect("~/Administrativo/AlterarDadosInternacao_UPDATE/CadastraAlta_UPDATE.aspx?nrSeq=" + nrSeq);

    }
}
