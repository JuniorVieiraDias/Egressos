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
/// Summary description for Internacao
/// </summary>
public class Internacao
{
    //public Internacao()
    //{}
   // public int cd_prontuario { get; set; }
    public int nr_seq { get; set; }
    public int cd_prontuario { get; set; } // Mudei pra string para poder testar
    public string nm_paciente { get; set; }

    public string dt_internacao { get; set; }
    
    public string in_sexo { get; set; }
    public int nr_idade { get; set; }
    public string nr_quarto { get; set; }
    public string nr_leito { get; set; }
    public string nm_ala { get; set; } //Talvez não seja usado
    public string nm_clinica { get; set; }
    public string nm_unidade_funcional { get; set; }
    public string nm_acomodacao { get; set; }
    public string st_leito { get; set; }   
   // public string dt_internacao { get; set; }
    public string dt_entrada_setor { get; set; }
    public string nm_especialidade { get; set; }
    public string nm_medico { get; set; }
    public string dt_ultimo_evento { get; set; }
    public string nm_origem { get; set; }
    public string sg_cid { get; set; }
    public string tx_observacao { get; set; }
    public int nr_convenio { get; set; }
    public int nr_plano { get; set; }
    public string nm_convenio_plano { get; set; }
    public string nr_crm_profissional { get; set; }
    public string nm_carater_internacao { get; set; }
    public string nm_origem_internacao { get; set; }
    public string nr_procedimento { get; set; }
    public string dt_alta_medica { get; set; }
    public string dt_saida_paciente { get; set; }
    public string dc_tipo_alta_medica { get; set; }
    public string nm_vinculo { get; set; }
    public string nm_orgao { get; set; }

    public string dt_nascimento { get; set; }
    public string sexo { get; set; }
    public string Motivo_Saida { get; set; }
    public string H_D { get; set; }
    public string Enf_Leito { get; set; }
    public string Clinica_Alta { get; set; }

    public int Proc_1 { get; set; }
    public int Proc_2 { get; set; }
    public int Proc_3 { get; set; }

    public string DESCR_C_C { get; set; }
    public int Cid_pri { get; set; }
    public int Cid_Sec { get; set; }
    public int Cid_Ass1 { get; set; }
    public int Cid_Ass2 { get; set; }
    public int CausaExt { get; set; }


    public string Causa_Obito_P1_A { get; set; }
    public string Causa_Obito_P1_B { get; set; }
    public string Causa_Obito_P1_C { get; set; }
    public string Causa_Obito_P1_D { get; set; }
    public string Causa_Obito_P2_A { get; set; }
    public string Causa_Obito_P2_B { get; set; }

    public string Encaminhamento_Do_Cadaver { get; set; }
    public int CausaProv_Obito { get; set; }
    public string Obito_OBS { get; set; }
    
    //feito para teste de status de preenchimento    
    public string SituacaoStatus { get; set; }



        
	}






