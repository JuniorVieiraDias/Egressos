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
       [nome]
      ,[prontuario]
      ,[sexo]
      ,[dtNascimento]
      ,[nr_seq]
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
      ,[cod_procedimento1]
      ,[descricao_proc1]
      ,[data_cir_1]
      ,[cod_procedimento2]
      ,[descricao_proc2]
      ,[data_cir_2]
      ,[cod_procedimento3]
      ,[descricao_proc3]
      ,[data_cir_3]
      ,[obs_proced_cir]
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
      ,[nome_funcionario_cadastrou_cid]
      ,[data_cadastrou_cid]
      ,[nome_funcionario_alterou_cid]
      ,[data_alterou_cid]
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
      ,[funcionarioCadastrou_obito]
      ,[data_cadastrou_obito]
      ,[nome_funcionario_alterou_obito]
      ,[data_alterou_obito]
  FROM [Egressos].[dbo].[vw_alta_paciente_completo]
  WHERE dt_saida_paciente BETWEEN '" + dtAmericanaI + "' AND '" + dtAmericanaF + "'order by nr_seq,nome";

                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                SqlDataReader dr = commd.ExecuteReader();


                #region DataTable

                dt.Columns.Add("Nome", System.Type.GetType("System.String"));
                dt.Columns.Add("Prontuario", System.Type.GetType("System.String"));
                dt.Columns.Add("sexo", System.Type.GetType("System.String"));
                dt.Columns.Add("Data Nascimento", System.Type.GetType("System.String"));
                dt.Columns.Add("nr_seq", System.Type.GetType("System.String"));
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
                dt.Columns.Add("cod_procedimento1", System.Type.GetType("System.String"));
                dt.Columns.Add("Descrição1", System.Type.GetType("System.String"));
                dt.Columns.Add("data_cir1", System.Type.GetType("System.String"));
                dt.Columns.Add("cod_procedimento2", System.Type.GetType("System.String"));
                dt.Columns.Add("Descrição2", System.Type.GetType("System.String"));
                dt.Columns.Add("data_cir2", System.Type.GetType("System.String"));
                dt.Columns.Add("cod_procedimento3", System.Type.GetType("System.String"));
                dt.Columns.Add("Descrição3", System.Type.GetType("System.String"));
                dt.Columns.Add("data_cir3", System.Type.GetType("System.String"));
                dt.Columns.Add("obs_proced_cir", System.Type.GetType("System.String"));
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
                dt.Columns.Add("nome_funcionario_cadastrou", System.Type.GetType("System.String"));
                dt.Columns.Add("data_cadastrou", System.Type.GetType("System.String"));
                dt.Columns.Add("nome_funcionario_alterou", System.Type.GetType("System.String"));
                dt.Columns.Add("data_alterou", System.Type.GetType("System.String"));
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
                dt.Columns.Add("funcionarioCadastrou_obito", System.Type.GetType("System.String"));
                dt.Columns.Add("data_cadastrou_obito", System.Type.GetType("System.String"));
                dt.Columns.Add("nome_funcionario_alterou_obito", System.Type.GetType("System.String"));
                dt.Columns.Add("data_alterou_obito", System.Type.GetType("System.String"));

                #endregion

                while (dr.Read())
                {
                    string Nome = dr.IsDBNull(0) ? null : dr.GetString(0);
                    string Prontuario = Convert.ToString(dr.GetInt32(1));
                    string sexo = dr.IsDBNull(2) ? null : dr.GetString(2);
                    string DataNascimento = dr.IsDBNull(3) ? null : dr.GetString(3);
                    string nr_seq = Convert.ToString(dr.GetInt32(4));
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
                    string convenio_plano = dr.IsDBNull(22) ? null : dr.GetString(22);
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
                    string cod_procedimento1 = dr.IsDBNull(32) ? null : Convert.ToString(dr.GetInt32(32));
                    string Descricao1 = dr.IsDBNull(33) ? null : dr.GetString(33);
                    string data_cir1 = dr.IsDBNull(34) ? null : dr.GetString(34);
                    string cod_procedimento2 = dr.IsDBNull(35) ? null : Convert.ToString(dr.GetInt32(35));
                    string Descricao2 = dr.IsDBNull(36) ? null : dr.GetString(36);
                    string data_cir2 = dr.IsDBNull(37) ? null : dr.GetString(37);
                    string cod_procedimento3 = dr.IsDBNull(38) ? null : Convert.ToString(dr.GetInt32(38));
                    string Descricao3 = dr.IsDBNull(39) ? null : dr.GetString(39);
                    string data_cir3 = dr.IsDBNull(40) ? null : dr.GetString(40);
                    string obs_proced_cir = dr.IsDBNull(41) ? null : dr.GetString(41);
                    string cod_cid_Primario = dr.IsDBNull(42) ? null : dr.GetString(42);
                    string descricao_cid_Primario = dr.IsDBNull(43) ? null : dr.GetString(43);
                    string cod_cid_Secundario = dr.IsDBNull(44) ? null : dr.GetString(44);
                    string descricao_cid_Secundario = dr.IsDBNull(45) ? null : dr.GetString(45);
                    string cod_cid_Ass1 = dr.IsDBNull(46) ? null : dr.GetString(46);
                    string descricao_cid_Ass1 = dr.IsDBNull(47) ? null : dr.GetString(47);
                    string cod_cid_Ass2 = dr.IsDBNull(48) ? null : dr.GetString(48);
                    string descricao_cid_Ass2 = dr.IsDBNull(49) ? null : dr.GetString(49);
                    string cod_cid_Ass3 = dr.IsDBNull(50) ? null : dr.GetString(50);
                    string descricao_cid_Ass3 = dr.IsDBNull(51) ? null : dr.GetString(51);
                    string cod_cid_CausaExterna = dr.IsDBNull(52) ? null : dr.GetString(52);
                    string desc_cid_CausaExterna = dr.IsDBNull(53) ? null : dr.GetString(53);
                    string nome_funcionario_cadastrou = dr.IsDBNull(54) ? null : dr.GetString(54);
                    string data_cadastrou = dr.IsDBNull(55) ? null : dr.GetString(55);
                    string nome_funcionario_alterou = dr.IsDBNull(56) ? null : dr.GetString(56);
                    string data_alterou = dr.IsDBNull(57) ? null : dr.GetString(57);
                    string cid_Obito_a = dr.IsDBNull(58) ? null : dr.GetString(58);
                    string obito_p1_a = dr.IsDBNull(59) ? null : dr.GetString(59);
                    string cid_Obito_b = dr.IsDBNull(60) ? null : dr.GetString(60);
                    string obito_p1_b = dr.IsDBNull(61) ? null : dr.GetString(61);
                    string cid_Obito_c = dr.IsDBNull(62) ? null : dr.GetString(62);
                    string obito_p1_c = dr.IsDBNull(63) ? null : dr.GetString(63);
                    string cid_Obito_d = dr.IsDBNull(64) ? null : dr.GetString(64);
                    string obito_p1_d = dr.IsDBNull(65) ? null : dr.GetString(65);
                    string cid_Obito_2_a = dr.IsDBNull(66) ? null : dr.GetString(66);
                    string obito_p2_a = dr.IsDBNull(67) ? null : dr.GetString(67);
                    string cid_Obito_2_b = dr.IsDBNull(68) ? null : dr.GetString(68);
                    string obito_p2_b = dr.IsDBNull(69) ? null : dr.GetString(69);
                    string enc_cadaver = dr.IsDBNull(70) ? null : dr.GetString(70);
                    string cid_obito_causaP = dr.IsDBNull(71) ? null : dr.GetString(71);
                    string causa_prov_obito = dr.IsDBNull(72) ? null : dr.GetString(72);
                    string obs = dr.IsDBNull(73) ? null : dr.GetString(73);
                    string funcionarioCadastrou_obito = dr.IsDBNull(74) ? null : dr.GetString(74);
                    string data_cadastrou_obito = dr.IsDBNull(75) ? null : dr.GetString(75);
                    string nome_funcionario_alterou_obito = dr.IsDBNull(76) ? null : dr.GetString(76);
                    string data_alterou_obito = dr.IsDBNull(77) ? null : dr.GetString(77);



                    dt.Rows.Add(new String[] {Nome, Prontuario, sexo, DataNascimento, nr_seq, quarto, leito, ala, clinica , unidade_funcional 
                    , acomodacao, st_leito, dt_internacao,dt_entrada_setor, especialidade, medico,dt_ultimo_evento, origem , sg_cid , tx_observacao, convenio 
                    , plano, convenio_plano, crm_profissional, carater_internacao, origem_internacao, procedimento, dt_alta_medica, dt_saida_paciente, tipo_alta_medica, vinculo, orgao, cod_procedimento1 
                    , Descricao1, data_cir1, cod_procedimento2, Descricao2, data_cir2, cod_procedimento3, Descricao3 , data_cir3, obs_proced_cir, cod_cid_Primario, descricao_cid_Primario, cod_cid_Secundario
                    , descricao_cid_Secundario, cod_cid_Ass1, descricao_cid_Ass1, cod_cid_Ass2, descricao_cid_Ass2, cod_cid_Ass3, descricao_cid_Ass3, cod_cid_CausaExterna, desc_cid_CausaExterna
                    , nome_funcionario_cadastrou, data_cadastrou, nome_funcionario_alterou, data_alterou,cid_Obito_a,obito_p1_a,cid_Obito_b, obito_p1_b,cid_Obito_c,obito_p1_c,cid_Obito_d,obito_p1_d,cid_Obito_2_a,obito_p2_a,cid_Obito_2_b,obito_p2_b
                    , enc_cadaver,cid_obito_causaP,causa_prov_obito, obs, funcionarioCadastrou_obito, data_cadastrou_obito, nome_funcionario_alterou_obito, data_alterou_obito});

                }




                //////////// string dtAgora = Convert.ToString(DateTime.Now);

                //////////// string folder = @"C:\RelatoriosEgressos"; //nome do diretorio a ser criado


                //////////// if (!Directory.Exists(folder))
                //////////// {                   
                ////////////     Directory.CreateDirectory(folder);
                //////////// }

                //////////// dtAgora= dtAgora.Replace("/", "-");
                //////////// string dthoraAgora = dtAgora.Replace(":", ".");
                //////////// string strFilePath = @"C:\RelatoriosEgressos\RelatorioEgresos" + dthoraAgora + ".csv";



                ////////////CreateCSVFile(dt, strFilePath);


                com.Close();
                //////////// ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "mensagem", "alert('Arquivo está gravado em  C:> (RelatoriosEgressos) Pacessar clique em Iniciar > computador >C:!');", true);

                //GridViewRelTotal.DataSource = dt;
                //GridViewRelTotal.DataBind();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }
            return dt;
        }
    }

    ////////////////////////////////////////////private void CreateCSVFile(System.Data.DataTable dt,string strFilePath)
    ////////////////////////////////////////////{
    ////////////////////////////////////////////    try
    ////////////////////////////////////////////        {
    ////////////////////////////////////////////            // Create the CSV file to which grid data will be exported.
    ////////////////////////////////////////////            StreamWriter sw = new StreamWriter(strFilePath, false, Encoding.GetEncoding("iso-8859-1"));
    ////////////////////////////////////////////            // First we will write the headers.
    ////////////////////////////////////////////            //DataTable dt = m_dsProducts.Tables[0];
    ////////////////////////////////////////////            int iColCount = dt.Columns.Count;
    ////////////////////////////////////////////            for (int i = 0; i < iColCount; i++)
    ////////////////////////////////////////////            {
    ////////////////////////////////////////////                sw.Write(dt.Columns[i]);
    ////////////////////////////////////////////                if (i < iColCount - 1)
    ////////////////////////////////////////////                {
    ////////////////////////////////////////////                    sw.Write(";");
    ////////////////////////////////////////////                }
    ////////////////////////////////////////////            }
    ////////////////////////////////////////////            sw.Write(sw.NewLine);

    ////////////////////////////////////////////            // Now write all the rows.

    ////////////////////////////////////////////            foreach (DataRow dr in dt.Rows)
    ////////////////////////////////////////////            {
    ////////////////////////////////////////////                for (int i = 0; i < iColCount; i++)
    ////////////////////////////////////////////                {
    ////////////////////////////////////////////                    if (!Convert.IsDBNull(dr[i]))
    ////////////////////////////////////////////                    {
    ////////////////////////////////////////////                        sw.Write(dr[i].ToString());
    ////////////////////////////////////////////                    }
    ////////////////////////////////////////////                    if (i < iColCount - 1)
    ////////////////////////////////////////////                    {
    ////////////////////////////////////////////                        sw.Write(";");
    ////////////////////////////////////////////                    }
    ////////////////////////////////////////////                }

    ////////////////////////////////////////////                sw.Write(sw.NewLine);
    ////////////////////////////////////////////            }
    ////////////////////////////////////////////            sw.Close();
    ////////////////////////////////////////////        }
    ////////////////////////////////////////////        catch (Exception ex)
    ////////////////////////////////////////////        {
    ////////////////////////////////////////////            throw ex;
    ////////////////////////////////////////////        }
    ////////////////////////////////////////////////}

    public override void VerifyRenderingInServerForm(Control control) { }

    private void GerarExcel()
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        //string attachment = "attachment; filename=contatos.xls";
        string FileName = "RelatorioEgressos";// DateTime.Now + ".xls";//arrumar
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
