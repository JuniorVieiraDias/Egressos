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
using System.Data.SqlClient;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Text;

public partial class Relatorios_Relatorios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnImportar_Click(object sender, EventArgs e)
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
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
            //DateTime dtInicioF = Convert.ToDateTime(dtAmericanaF);

            try
            {
                string strQuery = "";
                SqlCommand commd = new SqlCommand(strQuery, com);
                strQuery = @"SELECT 
       [nr_seq]
      ,[prontuario]
      ,[nome]
      ,[dtNascimento]
      ,[sexo]
      ,[quarto]
      ,[leito]
      ,[ala]
      ,[clinica]
      ,[unidade_funcional]
      ,[acomodacao]
      ,[st_leito]
      ,[dt_internacao]
      ,[dt_entrada_setor]
      ,[especialidade]
      ,[medico]
      ,[dt_ultimo_evento]
      ,[origem]
      ,[sg_cid]
      ,[tx_observacao]
      ,[convenio]
      ,[plano]
      ,[convenio_plano]
      ,[crm_profissional]
      ,[carater_internacao]
      ,[origem_internacao]
      ,[procedimento]
      ,[dt_alta_medica]
      ,[dt_saida_paciente]
      ,[tipo_alta_medica]
      ,[vinculo]
      ,[orgao]
      ,[cod_procedimento]
      ,[Descrição]
      ,[data_cir]
      ,[cod_cid]
      ,[descricao_cid]
      ,[tipo]
      ,[nome_funcionario_cadastrou]
  FROM [Egressos].[dbo].[vw_alta_paciente_completo]
  WHERE dt_saida_paciente BETWEEN '" + dtAmericanaI + "' AND '" + dtAmericanaF + "'order by nr_seq,nome";

                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                SqlDataReader dr = commd.ExecuteReader();
                System.Data.DataTable dt = new System.Data.DataTable();

                #region DataTable

                dt.Columns.Add("nr_seq", System.Type.GetType("System.String"));
                dt.Columns.Add("Prontuario", System.Type.GetType("System.String"));
                dt.Columns.Add("Nome", System.Type.GetType("System.String"));
                dt.Columns.Add("Data Nascimento", System.Type.GetType("System.String"));
                dt.Columns.Add("sexo", System.Type.GetType("System.String"));
                dt.Columns.Add("quarto", System.Type.GetType("System.String"));
                dt.Columns.Add("leito", System.Type.GetType("System.String"));
                dt.Columns.Add("ala", System.Type.GetType("System.String"));
                dt.Columns.Add("clinica", System.Type.GetType("System.String"));
                dt.Columns.Add("unidade_funcional", System.Type.GetType("System.String"));
                dt.Columns.Add("acomodacao", System.Type.GetType("System.String"));
                dt.Columns.Add("st_leito", System.Type.GetType("System.String"));
                dt.Columns.Add("dt_internacao", System.Type.GetType("System.String"));
                dt.Columns.Add("dt_entrada_setor", System.Type.GetType("System.String"));
                dt.Columns.Add("especialidade", System.Type.GetType("System.String"));
                dt.Columns.Add("medico", System.Type.GetType("System.String"));
                dt.Columns.Add("dt_ultimo_evento", System.Type.GetType("System.String"));
                dt.Columns.Add("origem", System.Type.GetType("System.String"));
                dt.Columns.Add("sg_cid", System.Type.GetType("System.String"));
                dt.Columns.Add("tx_observacao", System.Type.GetType("System.String"));
                dt.Columns.Add("convenio", System.Type.GetType("System.String"));
                dt.Columns.Add("plano", System.Type.GetType("System.String"));
                dt.Columns.Add("convenio_plano", System.Type.GetType("System.String"));
                dt.Columns.Add("crm_profissional", System.Type.GetType("System.String"));
                dt.Columns.Add("carater_internacao", System.Type.GetType("System.String"));
                dt.Columns.Add("origem_internacao", System.Type.GetType("System.String"));
                dt.Columns.Add("procedimento", System.Type.GetType("System.String"));
                dt.Columns.Add("dt_alta_medica", System.Type.GetType("System.String"));
                dt.Columns.Add("dt_saida_paciente", System.Type.GetType("System.String"));
                dt.Columns.Add("tipo_alta_medica", System.Type.GetType("System.String"));
                dt.Columns.Add("vinculo", System.Type.GetType("System.String"));
                dt.Columns.Add("orgao", System.Type.GetType("System.String"));
                dt.Columns.Add("cod_procedimento", System.Type.GetType("System.String"));
                dt.Columns.Add("Descrição", System.Type.GetType("System.String"));
                dt.Columns.Add("data_cir", System.Type.GetType("System.String"));
                dt.Columns.Add("cod_cid", System.Type.GetType("System.String"));
                dt.Columns.Add("descricao_cid", System.Type.GetType("System.String"));
                dt.Columns.Add("tipo", System.Type.GetType("System.String"));
                dt.Columns.Add("nome_funcionario_cadastrou", System.Type.GetType("System.String"));


                #endregion

                while (dr.Read())
                {

                    string nr_seq = Convert.ToString(dr.GetInt32(0));
                    string Prontuario = Convert.ToString(dr.GetInt32(1));
                    string Nome = dr.IsDBNull(2) ? null : dr.GetString(2);
                    string DataNascimento = dr.IsDBNull(3) ? null : dr.GetString(3);
                    string sexo = dr.IsDBNull(4) ? null : dr.GetString(4);
                    string quarto = dr.IsDBNull(5) ? null : dr.GetString(5);
                    string leito = dr.IsDBNull(6) ? null : dr.GetString(6);
                    string ala = dr.IsDBNull(7) ? null : dr.GetString(7);
                    string clinica = dr.IsDBNull(8) ? null : dr.GetString(8);
                    string unidade_funcional = dr.IsDBNull(9) ? null : dr.GetString(9);
                    string acomodacao = dr.IsDBNull(10) ? null : dr.GetString(10);
                    string st_leito = dr.IsDBNull(11) ? null : dr.GetString(11);
                    string dt_internacao = dr.IsDBNull(12) ? null : dr.GetString(12);
                    string dt_entrada_setor = dr.IsDBNull(13) ? null : dr.GetString(13);
                    string especialidade = dr.IsDBNull(14) ? null : dr.GetString(14);
                    string medico = dr.IsDBNull(15) ? null : dr.GetString(15);
                    string dt_ultimo_evento = dr.IsDBNull(16) ? null : dr.GetString(16);
                    string origem = dr.IsDBNull(17) ? null : dr.GetString(17);
                    string sg_cid = dr.IsDBNull(18) ? null : dr.GetString(18);
                    string tx_observacao = dr.IsDBNull(19) ? null : dr.GetString(19);
                    string convenio = dr.IsDBNull(20) ? null : Convert.ToString(dr.GetInt32(20));
                    string plano = dr.IsDBNull(21) ? null : Convert.ToString(dr.GetInt32(21));
                    string convenio_plano = dr.IsDBNull(21) ? null : dr.GetString(22);
                    string crm_profissional = dr.IsDBNull(23) ? null : dr.GetString(23);
                    string carater_internacao = dr.IsDBNull(24) ? null : dr.GetString(24);
                    string origem_internacao = dr.IsDBNull(25) ? null : dr.GetString(25);
                    string procedimento = dr.IsDBNull(26) ? null : dr.GetString(26);
                    string dt_alta_medica = dr.IsDBNull(27) ? null : dr.GetString(27);
                    DateTime dtP = dr.GetDateTime(28);
                    string dt_saida_paciente = dtP.ToString();
                    string tipo_alta_medica = dr.IsDBNull(29) ? null : dr.GetString(29);
                    string vinculo = dr.IsDBNull(30) ? null : dr.GetString(30);
                    string orgao = dr.IsDBNull(31) ? null : dr.GetString(31);
                    string cod_procedimento = dr.IsDBNull(32) ? null : Convert.ToString(dr.GetInt32(32));
                    string Descrição = dr.IsDBNull(33) ? null : dr.GetString(33);
                    string data_cir = dr.IsDBNull(34) ? null : dr.GetString(34);
                    string obs_proced_cir = dr.IsDBNull(35) ? null : dr.GetString(35);                   
                    string cod_cid = dr.IsDBNull(36) ? null : dr.GetString(36);
                    string descricao_cid = dr.IsDBNull(37) ? null : dr.GetString(37);
                    string tipo = dr.IsDBNull(38) ? null : dr.GetString(38);
                    string nome_funcionario_cadastrou = dr.IsDBNull(39) ? null : dr.GetString(39);


                    dt.Rows.Add(new String[] {nr_seq,Prontuario,Nome,DataNascimento,sexo,quarto,leito,ala,clinica,unidade_funcional,acomodacao,st_leito,dt_internacao,dt_entrada_setor,especialidade,medico,
                 dt_ultimo_evento,origem,sg_cid,tx_observacao,convenio,plano,convenio_plano,crm_profissional,carater_internacao,origem_internacao,procedimento,dt_alta_medica,dt_saida_paciente,tipo_alta_medica,
                 vinculo,orgao,cod_procedimento,Descrição,data_cir,cod_cid,descricao_cid,tipo,nome_funcionario_cadastrou});

                    
                         
                }
                string dtAgora = Convert.ToString(DateTime.Now);
                
                string folder = @"C:\RelatoriosEgressos"; //nome do diretorio a ser criado
                            

                if (!Directory.Exists(folder))
                {                   
                    Directory.CreateDirectory(folder);
                }

                dtAgora= dtAgora.Replace("/", "-");
                string dthoraAgora = dtAgora.Replace(":", ".");
                string strFilePath = @"C:\RelatoriosEgressos\RelatorioEgresos" + dthoraAgora + ".csv";
                
                              

               CreateCSVFile(dt, strFilePath);

              
               com.Close();
               ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Arquivo está gravado em  C:> (RelatoriosEgressos) Pacessar clique em Iniciar > computador >C:!');", true);
               
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }

        }

      
    }

private void CreateCSVFile(System.Data.DataTable dt,string strFilePath)
{
 	try
        {
            // Create the CSV file to which grid data will be exported.
            StreamWriter sw = new StreamWriter(strFilePath, false, Encoding.GetEncoding("iso-8859-1"));
            // First we will write the headers.
            //DataTable dt = m_dsProducts.Tables[0];
            int iColCount = dt.Columns.Count;
            for (int i = 0; i < iColCount; i++)
            {
                sw.Write(dt.Columns[i]);
                if (i < iColCount - 1)
                {
                    sw.Write(";");
                }
            }
            sw.Write(sw.NewLine);

            // Now write all the rows.

            foreach (DataRow dr in dt.Rows)
            {
                for (int i = 0; i < iColCount; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        sw.Write(dr[i].ToString());
                    }
                    if (i < iColCount - 1)
                    {
                        sw.Write(";");
                    }
                }

                sw.Write(sw.NewLine);
            }
            sw.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
}
    ////private void GerarExcel()
    ////{
        
        
        
        
        
    ////    Response.Clear();
    ////    Response.Buffer = true;
    ////    Response.ClearContent();
    ////    Response.ClearHeaders();
    ////    Response.Charset = "";
    ////    //string attachment = "attachment; filename=contatos.xls";
    ////    string FileName = "RelatorioBE";// DateTime.Now + ".xls";//arrumar
    ////    string dia = Convert.ToString(DateTime.Now.Day);
    ////    string mes = Convert.ToString(DateTime.Now.Month);
    ////    string ano = Convert.ToString(DateTime.Now.Year);
    ////    string hr = Convert.ToString(DateTime.Now.Hour);
    ////    string min = Convert.ToString(DateTime.Now.Minute);
    ////    string seg = Convert.ToString(DateTime.Now.Second);
    ////    string DtCompleta = dia + "_" + mes + "_" + ano + "_" + hr + "_" + min + "_" + seg;
    ////    StringWriter strwritter = new StringWriter();
    ////    HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
    ////    Response.Cache.SetCacheability(HttpCacheability.NoCache);
    ////    Response.ContentType = "application/vnd.ms-excel";
    ////    Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName + "_" + DtCompleta + ".xls");
    ////    GridViewBe.GridLines = GridLines.Both;
    ////    GridViewBe.HeaderStyle.Font.Bold = true;
    ////    GridViewBe.RenderControl(htmltextwrtter);
    ////    Response.Write(strwritter.ToString());
    ////    Response.End(); 
    ////}
}
