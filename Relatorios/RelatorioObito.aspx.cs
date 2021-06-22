using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Data;

public partial class Relatorios_RelatorioObito : System.Web.UI.Page
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
      ,[sexo]
      ,[dtNascimento]
      ,[clinica]
      ,[unidade_funcional]
      ,[dt_internacao]
      ,[especialidade]
      ,[medico]
      ,[crm_profissional]
      ,[dt_saida_paciente]
      ,[tipo_alta_medica]
      ,[vinculo]
      ,[orgao]
      ,[obito_p1_a]
      ,[obito_p1_b]
      ,[obito_p1_c]
      ,[obito_p1_d]
      ,[obito_p2_a]
      ,[obito_p2_b]
      ,[enc_cadaver]
      ,[causa_prov_obito]
      ,[obs]
      ,[funcionarioCadastrou]
  FROM [Egressos].[dbo].[vw_obito]
  WHERE dt_saida_paciente BETWEEN '" + dtAmericanaI + "' AND '" + dtAmericanaF + "'";

                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                SqlDataReader dr = commd.ExecuteReader();
                System.Data.DataTable dt = new System.Data.DataTable();

                #region DataTable

                dt.Columns.Add("nr_seq", System.Type.GetType("System.String"));
                dt.Columns.Add("Prontuario", System.Type.GetType("System.String"));
                dt.Columns.Add("Nome", System.Type.GetType("System.String"));
                dt.Columns.Add("sexo", System.Type.GetType("System.String"));
                dt.Columns.Add("Data Nascimento", System.Type.GetType("System.String"));
               // dt.Columns.Add("quarto", System.Type.GetType("System.String"));
                //dt.Columns.Add("leito", System.Type.GetType("System.String"));
               // dt.Columns.Add("ala", System.Type.GetType("System.String"));
                dt.Columns.Add("clinica", System.Type.GetType("System.String"));
                dt.Columns.Add("unidade_funcional", System.Type.GetType("System.String"));
               // dt.Columns.Add("acomodacao", System.Type.GetType("System.String"));
               // dt.Columns.Add("st_leito", System.Type.GetType("System.String"));
                dt.Columns.Add("dt_internacao", System.Type.GetType("System.String"));
               // dt.Columns.Add("dt_entrada_setor", System.Type.GetType("System.String"));
                dt.Columns.Add("especialidade", System.Type.GetType("System.String"));
                dt.Columns.Add("medico", System.Type.GetType("System.String"));
               // dt.Columns.Add("dt_ultimo_evento", System.Type.GetType("System.String"));
               // dt.Columns.Add("origem", System.Type.GetType("System.String"));
              //  dt.Columns.Add("sg_cid", System.Type.GetType("System.String"));
              //  dt.Columns.Add("tx_observacao", System.Type.GetType("System.String"));
               // dt.Columns.Add("convenio", System.Type.GetType("System.String"));
              //  dt.Columns.Add("plano", System.Type.GetType("System.String"));
              //  dt.Columns.Add("convenio_plano", System.Type.GetType("System.String"));
                dt.Columns.Add("crm_profissional", System.Type.GetType("System.String"));
              //  dt.Columns.Add("carater_internacao", System.Type.GetType("System.String"));
              //  dt.Columns.Add("origem_internacao", System.Type.GetType("System.String"));
               // dt.Columns.Add("procedimento", System.Type.GetType("System.String"));
              //  dt.Columns.Add("dt_alta_medica", System.Type.GetType("System.String"));
                dt.Columns.Add("dt_saida_paciente", System.Type.GetType("System.String"));
                dt.Columns.Add("tipo_alta_medica", System.Type.GetType("System.String"));
                dt.Columns.Add("vinculo", System.Type.GetType("System.String"));
                dt.Columns.Add("orgao", System.Type.GetType("System.String"));
                dt.Columns.Add("obito_p1_a", System.Type.GetType("System.String"));
                dt.Columns.Add("obito_p1_b", System.Type.GetType("System.String"));
                dt.Columns.Add("obito_p1_c", System.Type.GetType("System.String"));
                dt.Columns.Add("obito_p1_d", System.Type.GetType("System.String"));
                dt.Columns.Add("obito_p2_a", System.Type.GetType("System.String"));
                dt.Columns.Add("obito_p2_b", System.Type.GetType("System.String"));
                dt.Columns.Add("enc_cadaver", System.Type.GetType("System.String"));
                dt.Columns.Add("causa_prov_obito", System.Type.GetType("System.String"));
                dt.Columns.Add("obs", System.Type.GetType("System.String"));
                dt.Columns.Add("funcionarioCadastrou", System.Type.GetType("System.String"));
                                
                //dt.Columns.Add("cod_procedimento", System.Type.GetType("System.String"));
                //dt.Columns.Add("Descrição", System.Type.GetType("System.String"));
                //dt.Columns.Add("data_cir", System.Type.GetType("System.String"));
                //dt.Columns.Add("cod_cid", System.Type.GetType("System.String"));
                //dt.Columns.Add("descricao_cid", System.Type.GetType("System.String"));
                //dt.Columns.Add("tipo", System.Type.GetType("System.String"));
                //dt.Columns.Add("nome_funcionario_cadastrou", System.Type.GetType("System.String"));


                #endregion

                while (dr.Read())
                {

                    string nr_seq = Convert.ToString(dr.GetInt32(0));
                    string Prontuario = Convert.ToString(dr.GetInt32(1));
                    string Nome = dr.IsDBNull(2) ? null : dr.GetString(2);
                    string sexo = dr.IsDBNull(3) ? null : dr.GetString(3);
                    string DataNascimento = dr.IsDBNull(4) ? null : dr.GetString(4);
                    //string quarto = dr.IsDBNull(5) ? null : dr.GetString(5);
                    //string leito = dr.IsDBNull(6) ? null : dr.GetString(6);
                    //string ala = dr.IsDBNull(7) ? null : dr.GetString(7);
                    string clinica = dr.IsDBNull(5) ? null : dr.GetString(5);
                    string unidade_funcional = dr.IsDBNull(6) ? null : dr.GetString(6);
                    //string acomodacao = dr.IsDBNull(10) ? null : dr.GetString(10);
                  //  string st_leito = dr.IsDBNull(11) ? null : dr.GetString(11);
                    string dt_internacao = dr.IsDBNull(7) ? null : dr.GetString(7);
                   // string dt_entrada_setor = dr.IsDBNull(13) ? null : dr.GetString(13);
                    string especialidade = dr.IsDBNull(8) ? null : dr.GetString(8);
                    string medico = dr.IsDBNull(9) ? null : dr.GetString(9);
                    //string dt_ultimo_evento = dr.IsDBNull(16) ? null : dr.GetString(16);
                    //string origem = dr.IsDBNull(17) ? null : dr.GetString(17);
                    //string sg_cid = dr.IsDBNull(18) ? null : dr.GetString(18);
                    //string tx_observacao = dr.IsDBNull(19) ? null : dr.GetString(19);
                    //string convenio = dr.IsDBNull(20) ? null : Convert.ToString(dr.GetInt32(20));
                    //string plano = dr.IsDBNull(21) ? null : Convert.ToString(dr.GetInt32(21));
                    //string convenio_plano = dr.IsDBNull(21) ? null : dr.GetString(22);
                    string crm_profissional = dr.IsDBNull(10) ? null : dr.GetString(10);
                    //string carater_internacao = dr.IsDBNull(24) ? null : dr.GetString(24);
                    //string origem_internacao = dr.IsDBNull(25) ? null : dr.GetString(25);
                    //string procedimento = dr.IsDBNull(26) ? null : dr.GetString(26);
                    DateTime dtP = dr.GetDateTime(11);
                    string dt_saida_paciente = dtP.ToString();

                    //string dt_alta_medica = dr.IsDBNull(27) ? null : dr.GetString(27);
                   
                    string tipo_alta_medica = dr.IsDBNull(12) ? null : dr.GetString(12);
                    string vinculo = dr.IsDBNull(13) ? null : dr.GetString(13);
                    string orgao = dr.IsDBNull(14) ? null : dr.GetString(14);

                    string obito_p1_a = dr.IsDBNull(15) ? null : dr.GetString(15);
                    string obito_p1_b = dr.IsDBNull(16) ? null : dr.GetString(16);
                    string obito_p1_c = dr.IsDBNull(17) ? null : dr.GetString(17);
                    string obito_p1_d = dr.IsDBNull(18) ? null : dr.GetString(18);
                    string obito_p2_a = dr.IsDBNull(19) ? null : dr.GetString(19);
                    string obito_p2_b = dr.IsDBNull(20) ? null : dr.GetString(20);
                    string enc_cadaver = dr.IsDBNull(21) ? null : dr.GetString(21);
                    string causa_prov_obito = dr.IsDBNull(22) ? null : dr.GetString(22);
                    string obs = dr.IsDBNull(23) ? null : dr.GetString(23);



                    //string cod_procedimento = dr.IsDBNull(32) ? null : Convert.ToString(dr.GetInt32(32));
                    //string Descrição = dr.IsDBNull(33) ? null : dr.GetString(33);
                    //string data_cir = dr.IsDBNull(34) ? null : dr.GetString(34);
                    //string cod_cid = dr.IsDBNull(35) ? null : dr.GetString(35);
                    //string descricao_cid = dr.IsDBNull(36) ? null : dr.GetString(36);
                    //string tipo = dr.IsDBNull(37) ? null : dr.GetString(37);
                    string funcionarioCadastrou = dr.IsDBNull(24) ? null : dr.GetString(24);


                    dt.Rows.Add(new String[] {nr_seq,Prontuario,Nome,sexo,DataNascimento,clinica,unidade_funcional,dt_internacao,especialidade,medico,
                 crm_profissional,dt_saida_paciente,tipo_alta_medica,vinculo,orgao,obito_p1_a,obito_p1_b,obito_p1_c,obito_p1_d,obito_p2_a,obito_p2_b 
                 ,enc_cadaver,causa_prov_obito,obs,funcionarioCadastrou});



                }
                string dtAgora = Convert.ToString(DateTime.Now);

                string folder = @"C:\RelatoriosEgressos"; //nome do diretorio a ser criado


                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                dtAgora = dtAgora.Replace("/", "-");
                string dthoraAgora = dtAgora.Replace(":", ".");
                string strFilePath = @"C:\RelatoriosEgressos\RelatorioEgresosObitos" + dthoraAgora + ".csv";



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
    private void CreateCSVFile(System.Data.DataTable dt, string strFilePath)
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
}
