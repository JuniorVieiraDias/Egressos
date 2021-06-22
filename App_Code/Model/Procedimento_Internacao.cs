using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for Procedimento_Internacao
/// </summary>
public class Procedimento_Internacao
{
    public int Id { get; set; }
    public int Nr_Seq { get; set; }
    public int Cod_Procedimento { get; set; }
    public string Descr_Procedimento_Cir { get; set; }
    public string Data_Cir { get; set; }
    public string Obs_Proced_Cir { get; set; }
    public string Nome_Funcionario_Cadastrou { get; set; }

}
