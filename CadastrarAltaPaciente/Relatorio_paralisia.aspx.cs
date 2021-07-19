using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;

public partial class Administrativo_Relatorios_Relatorio_paralisia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnImportar_Click(object sender, EventArgs e)
    {
        string dataInicio = txtDtInicio.Text;
        string ano = dataInicio.Substring(6, 4);
        string mes = dataInicio.Substring(3, 2);
        string dia = dataInicio.Substring(0, 2);
        string dtAmericanaI = ano + "-" + mes + "-" + dia;
        // DateTime dtInicio = Convert.ToDateTime(dtAmericanaI);

        string dataFim = txtDtFim.Text;
        string anoF = dataFim.Substring(6, 4);
        string mesF = dataFim.Substring(3, 2);
        string diaF = dataFim.Substring(0, 2);
        string dtAmericanaF = anoF + "-" + mesF + "-" + diaF;

        GridViewRelTotal.DataSource = carregaDados(dtAmericanaI, dtAmericanaF);
        GridViewRelTotal.DataBind();
        GerarExcel();

    }

    private DataTable carregaDados(string dtAmericanaI, string dtAmericanaF)
    {
        DataTable dt = new DataTable();
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {

            //DateTime dtInicioF = Convert.ToDateTime(dtAmericanaF);

            try
            {
                string strQuery = "";
                SqlCommand commd = new SqlCommand(strQuery, com);
                strQuery = @"SELECT 
       [prontuario]
      ,[nome]
      ,[sexo]
      ,[dtNascimento]
      ,[dt_internacao]
      ,[dt_saida_paciente]
      ,[tipo_alta_medica]
      ,[clinica_alta_medica]
      ,[cod_cid_Primario]
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
      ,[cid_Obito_a]
      ,[obito_p1_a]
      ,[cid_Obito_b]
      ,[obito_p1_b]
      ,[cid_Obito_c]
      ,[obito_p1_c]
      ,[cid_Obito_d]
      ,[obito_p1_d]
      ,[cid_Obito_2_a]
      ,[obito_p2_a]
      ,[cid_Obito_2_b]
      ,[obito_p2_b]
      ,[enc_cadaver]
      ,[cid_obito_causaP]
      ,[causa_prov_obito]
      ,[obs]      
  FROM [Egressos].[dbo].[vw_relatorio_paralisia] 
  WHERE [contem]='1' and dt_saida_paciente BETWEEN '" + dtAmericanaI + "' AND '" + dtAmericanaF + "'order by nome";

                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                SqlDataReader dr = commd.ExecuteReader();


                #region DataTable
                dt.Columns.Add("Prontuario", System.Type.GetType("System.String"));
                dt.Columns.Add("Nome", System.Type.GetType("System.String"));                
                dt.Columns.Add("sexo", System.Type.GetType("System.String"));
                dt.Columns.Add("Data Nascimento", System.Type.GetType("System.String"));                
                dt.Columns.Add("Data internacao", System.Type.GetType("System.String")); 
                dt.Columns.Add("Data alta medica", System.Type.GetType("System.String"));                
                dt.Columns.Add("tipo alta medica", System.Type.GetType("System.String"));
                dt.Columns.Add("clinica_alta_medica", System.Type.GetType("System.String"));
                dt.Columns.Add("cod_cid_Primario", System.Type.GetType("System.String"));
                dt.Columns.Add("desc_cid_Primario", System.Type.GetType("System.String"));
                dt.Columns.Add("cod_cid_Secundario", System.Type.GetType("System.String"));
                dt.Columns.Add("desc_cid_Secundario", System.Type.GetType("System.String"));
                dt.Columns.Add("cod_cid_Ass1", System.Type.GetType("System.String"));
                dt.Columns.Add("desc_cid_Ass1", System.Type.GetType("System.String"));
                dt.Columns.Add("cod_cid_Ass2", System.Type.GetType("System.String"));
                dt.Columns.Add("desc_cid_Ass2", System.Type.GetType("System.String"));
                dt.Columns.Add("cod_cid_Ass3", System.Type.GetType("System.String"));
                dt.Columns.Add("desc_cid_Ass3", System.Type.GetType("System.String"));
                dt.Columns.Add("cod_cid_CausaExterna", System.Type.GetType("System.String"));
                dt.Columns.Add("desc_cid_CausaExterna", System.Type.GetType("System.String"));               
                dt.Columns.Add("cid_Obito_a", System.Type.GetType("System.String"));
                dt.Columns.Add("obito_p1_a", System.Type.GetType("System.String"));
                dt.Columns.Add("cid_Obito_b", System.Type.GetType("System.String"));
                dt.Columns.Add("obito_p1_b", System.Type.GetType("System.String"));
                dt.Columns.Add("cid_Obito_c", System.Type.GetType("System.String"));
                dt.Columns.Add("obito_p1_c", System.Type.GetType("System.String"));
                dt.Columns.Add("cid_Obito_d", System.Type.GetType("System.String"));
                dt.Columns.Add("obito_p1_d", System.Type.GetType("System.String"));
                dt.Columns.Add("cid_Obito_2_a", System.Type.GetType("System.String"));
                dt.Columns.Add("obito_p2_a", System.Type.GetType("System.String"));
                dt.Columns.Add("cid_Obito_2_b", System.Type.GetType("System.String"));
                dt.Columns.Add("obito_p2_b", System.Type.GetType("System.String"));
                dt.Columns.Add("enc_cadaver", System.Type.GetType("System.String"));
                dt.Columns.Add("cid_obito_causaP", System.Type.GetType("System.String"));
                dt.Columns.Add("causa_prov_obito", System.Type.GetType("System.String"));
                dt.Columns.Add("obs", System.Type.GetType("System.String"));               

                #endregion

                while (dr.Read())
                {
                    string Prontuario = Convert.ToString(dr.GetInt32(0));
                    string Nome = dr.IsDBNull(1) ? null : dr.GetString(1);                    
                    string sexo = dr.IsDBNull(2) ? null : dr.GetString(2);
                    string DataNascimento = dr.IsDBNull(3) ? null : dr.GetString(3);                    
                    string dt_internacao = dr.IsDBNull(4) ? null : dr.GetString(4);
                    DateTime dtP = dr.GetDateTime(5);
                    string dt_alta_medica = dtP.ToString();                                                        
                    string tipo_alta_medica = dr.IsDBNull(6) ? null : dr.GetString(6);
                    string clinica_altaMedica = dr.IsDBNull(7) ? null : dr.GetString(7);                   
                    string cod_cid_Primario = dr.IsDBNull(8) ? null : dr.GetString(8);
                    string descricao_cid_Primario = dr.IsDBNull(9) ? null : dr.GetString(9);
                    string cod_cid_Secundario = dr.IsDBNull(10) ? null : dr.GetString(10);
                    string descricao_cid_Secundario = dr.IsDBNull(11) ? null : dr.GetString(11);
                    string cod_cid_Ass1 = dr.IsDBNull(12) ? null : dr.GetString(12);
                    string descricao_cid_Ass1 = dr.IsDBNull(13) ? null : dr.GetString(13);
                    string cod_cid_Ass2 = dr.IsDBNull(14) ? null : dr.GetString(14);
                    string descricao_cid_Ass2 = dr.IsDBNull(15) ? null : dr.GetString(15);
                    string cod_cid_Ass3 = dr.IsDBNull(16) ? null : dr.GetString(16);
                    string descricao_cid_Ass3 = dr.IsDBNull(17) ? null : dr.GetString(17);
                    string cod_cid_CausaExterna = dr.IsDBNull(18) ? null : dr.GetString(18);
                    string desc_cid_CausaExterna = dr.IsDBNull(19) ? null : dr.GetString(19);                   
                    string cid_Obito_a = dr.IsDBNull(20) ? null : dr.GetString(20);
                    string obito_p1_a = dr.IsDBNull(21) ? null : dr.GetString(21);
                    string cid_Obito_b = dr.IsDBNull(22) ? null : dr.GetString(22);
                    string obito_p1_b = dr.IsDBNull(23) ? null : dr.GetString(23);
                    string cid_Obito_c = dr.IsDBNull(24) ? null : dr.GetString(24);
                    string obito_p1_c = dr.IsDBNull(25) ? null : dr.GetString(25);
                    string cid_Obito_d = dr.IsDBNull(26) ? null : dr.GetString(26);
                    string obito_p1_d = dr.IsDBNull(27) ? null : dr.GetString(27);
                    string cid_Obito_2_a = dr.IsDBNull(28) ? null : dr.GetString(28);
                    string obito_p2_a = dr.IsDBNull(29) ? null : dr.GetString(29);
                    string cid_Obito_2_b = dr.IsDBNull(30) ? null : dr.GetString(30);
                    string obito_p2_b = dr.IsDBNull(31) ? null : dr.GetString(31);
                    string enc_cadaver = dr.IsDBNull(32) ? null : dr.GetString(32);
                    string cid_obito_causaP = dr.IsDBNull(33) ? null : dr.GetString(33);
                    string causa_prov_obito = dr.IsDBNull(34) ? null : dr.GetString(34);
                    string obs = dr.IsDBNull(35) ? null : dr.GetString(35);  


                    dt.Rows.Add(new String[] {Prontuario, Nome, sexo, DataNascimento, dt_internacao, dt_alta_medica, tipo_alta_medica, clinica_altaMedica                   
                    ,cod_cid_Primario, descricao_cid_Primario, cod_cid_Secundario, descricao_cid_Secundario, cod_cid_Ass1, descricao_cid_Ass1, cod_cid_Ass2 
                    ,descricao_cid_Ass2, cod_cid_Ass3, descricao_cid_Ass3, cod_cid_CausaExterna,desc_cid_CausaExterna, cid_Obito_a, obito_p1_a, cid_Obito_b 
                    ,obito_p1_b, cid_Obito_c, obito_p1_c, cid_Obito_d, obito_p1_d, cid_Obito_2_a, obito_p2_a, cid_Obito_2_b, obito_p2_b, enc_cadaver,cid_obito_causaP
                    ,causa_prov_obito,obs });
                }
               
                com.Close();
                
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert(' MSG ERRO do SISTEMA " + erro + "!');", true);

            }
            return dt;
        }
    }   

    public override void VerifyRenderingInServerForm(Control control) { }

    private void GerarExcel()
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        //string attachment = "attachment; filename=contatos.xls";
        string FileName = "RelatorioParalisiaEgressos";// DateTime.Now + ".xls";//arrumar
        string dia = Convert.ToString(DateTime.Now.Day);
        string mes = Convert.ToString(DateTime.Now.Month);
        string ano = Convert.ToString(DateTime.Now.Year);
        string hr = Convert.ToString(DateTime.Now.Hour);
        string min = Convert.ToString(DateTime.Now.Minute);
        string seg = Convert.ToString(DateTime.Now.Second);
        string DtCompleta = dia + "_" + mes + "_" + ano + "_" + hr + "_" + min + "_" + seg;
        // StreamWriter sw = new StreamWriter(strFilePath, false, Encoding.GetEncoding("iso-8859-1"));
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName + "_" + DtCompleta + ".xls");
        GridViewRelTotal.GridLines = GridLines.Both;
        GridViewRelTotal.HeaderStyle.Font.Bold = true;
        GridViewRelTotal.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        Response.End();
    }
}
