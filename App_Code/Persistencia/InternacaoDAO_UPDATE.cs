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
using System.Data.SqlClient;
using System.Web.UI.MobileControls;
using System.Collections.Generic;

/// <summary>
/// Summary description for InternacaoDAO_UPDATE
/// </summary>
public class InternacaoDAO_UPDATE
{

    public static void excluir_paralisia(int p)
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {
            try
            {
                string strQuery = "";
                SqlCommand commd = new SqlCommand(strQuery, com);
                strQuery = @"DELETE FROM [Egressos].[dbo].[paralisia]     
                                    where nr_seq_paralisia=" + p + "";

                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                com.Close();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;               
            }           
        }
    }

    // pega a lista de internações de um único paciente

    public static List<Internacao> GetListaInternacoePorProntuario_UPDATE(int prontuario)
    {
        var lista = new List<Internacao>();
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {
            SqlCommand cmm = cnn.CreateCommand();

            string sqlConsulta = @" SELECT 
                                                   [nr_seq]
                                                  ,[prontuario]
                                                  ,[nome]
                                                  ,[sexo] 
                                                  ,[dt_internacao] 
                                                  ,[dt_alta_medica] 
                                                  ,[situacao]
                                                 
                                                     FROM [Egressos].[dbo].[vw_dadosPacienteMovimentacao]
                                                       where prontuario=" + prontuario +" and situacao='Codificado'";            


            cmm.CommandText = sqlConsulta;
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();

                while (dr1.Read())
                {
                    Internacao i = new Internacao();

                    i.nr_seq = dr1.GetInt32(0);
                    i.cd_prontuario = dr1.GetInt32(1);
                    // i.nr_quarto = dr1.IsDBNull(2) ? "" : dr1.GetString(2);
                    i.nm_paciente = dr1.IsDBNull(2) ? "" : dr1.GetString(2);
                    i.in_sexo = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    i.dt_internacao = dr1.IsDBNull(4) ? "" : dr1.GetString(4);
                    i.dt_alta_medica = dr1.IsDBNull(5) ? "" : dr1.GetString(5);
                    i.SituacaoStatus = dr1.GetString(6);
                                                     

                    lista.Add(i);

                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }

            return lista;
        }
    }
}
