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
    
////////////    public static void GravaInternacao_UPDATE(Internacao internacao)
////////////    {
////////////        // verifica se existe a internação
////////////        bool existeInternacao = GetInternacao_UPDATE(internacao);

////////////        bool existePaciente = GetPaciente_UPDATE(internacao.cd_prontuario);

////////////        if (existePaciente == false)
////////////        {
////////////            using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
////////////            {
////////////                try
////////////                {
////////////                    string strQuery = @"INSERT INTO [Egressos].[dbo].[paciente]
////////////                                    ([prontuario],[nome],[sexo],[statusDtNascimento])"
////////////                                        + " VALUES (@prontuario,@nome,@sexo,@statusDtNascimento)";

////////////                    SqlCommand commd = new SqlCommand(strQuery, com);
////////////                    commd.Parameters.Add("@prontuario", SqlDbType.Int).Value = internacao.cd_prontuario;
////////////                    commd.Parameters.Add("@nome", SqlDbType.VarChar).Value = internacao.nm_paciente;
////////////                    commd.Parameters.Add("@sexo", SqlDbType.VarChar).Value = internacao.in_sexo;
////////////                    commd.Parameters.Add("@statusDtNascimento", SqlDbType.VarChar).Value = "2";


////////////                    commd.CommandText = strQuery;
////////////                    com.Open();
////////////                    commd.ExecuteNonQuery();
////////////                    com.Close();

////////////                }
////////////                catch (Exception ex)
////////////                {
////////////                    string erro = ex.Message;

////////////                }
////////////            }
////////////        }

////////////        //Todo completar o insert

////////////        // se não existir a internação então grava no banco
////////////        if (existeInternacao == false)
////////////        {
////////////            using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
////////////            {
////////////                try
////////////                {
////////////                    string strQuery = "INSERT INTO [Egressos].[dbo].[movimentacao_paciente]"
////////////                                   + "([nr_seq],[prontuario_paciente],[leito],[ala]"
////////////                        + ",[clinica],[unidade_funcional],[acomodacao]"
////////////                        + ",[st_leito],[dt_internacao],[dt_entrada_setor]"
////////////                        + ",[especialidade],[medico],[dt_ultimo_evento],[origem]"
////////////                        + ",[sg_cid],[tx_observacao],[convenio],[plano]"
////////////                        + ",[convenio_plano],[crm_profissional],[carater_internacao]"
////////////                        + ",[origem_internacao],[procedimento],[dt_alta_medica]"
////////////                        + ",[dt_saida_paciente],[tipo_alta_medica],[vinculo],[orgao],[situacao])"

////////////                                    + " VALUES (@nr_seq,@prontuario_paciente,@leito,@ala"
////////////                                    + ",@clinica,@unidade_funcional,@acomodacao"
////////////                                    + ",@st_leito,@dt_internacao,@dt_entrada_setor"
////////////                                    + ",@especialidade,@medico,@dt_ultimo_evento,@origem"
////////////                                    + ",@sg_cid,@tx_observacao,@convenio,@plano"
////////////                                    + ",@convenio_plano,@crm_profissional,@carater_internacao"
////////////                                    + ",@origem_internacao,@procedimento,@dt_alta_medica"
////////////                                    + ",@dt_saida_paciente,@tipo_alta_medica,@vinculo,@orgao,@situacao)";

////////////                    SqlCommand commd = new SqlCommand(strQuery, com);

////////////                    commd.Parameters.Add("@nr_seq", SqlDbType.Int).Value = internacao.nr_seq;
////////////                    commd.Parameters.Add("@prontuario_paciente", SqlDbType.Int).Value = internacao.cd_prontuario;
////////////                    if (internacao.nr_leito == null)
////////////                    {
////////////                        internacao.nr_leito = "";
////////////                    }
////////////                    commd.Parameters.Add("@leito", SqlDbType.VarChar).Value = internacao.nr_leito;
////////////                    commd.Parameters.Add("@ala", SqlDbType.VarChar).Value = internacao.nm_ala;
////////////                    commd.Parameters.Add("@clinica", SqlDbType.VarChar).Value = (object)internacao.nm_clinica ?? DBNull.Value;
////////////                    commd.Parameters.Add("@unidade_funcional", SqlDbType.VarChar).Value = (object)internacao.nm_unidade_funcional ?? DBNull.Value;
////////////                    commd.Parameters.Add("@acomodacao", SqlDbType.VarChar).Value = (object)internacao.nm_acomodacao ?? DBNull.Value;
////////////                    commd.Parameters.Add("@st_leito", SqlDbType.VarChar).Value = (object)internacao.st_leito ?? DBNull.Value;
////////////                    commd.Parameters.Add("@dt_internacao", SqlDbType.VarChar).Value = (object)internacao.dt_internacao ?? DBNull.Value;
////////////                    commd.Parameters.Add("@dt_entrada_setor", SqlDbType.VarChar).Value = (object)internacao.dt_entrada_setor ?? DBNull.Value;
////////////                    commd.Parameters.Add("@especialidade", SqlDbType.VarChar).Value = (object)internacao.nm_especialidade ?? DBNull.Value;
////////////                    commd.Parameters.Add("@medico", SqlDbType.VarChar).Value = (object)internacao.nm_medico ?? DBNull.Value;
////////////                    commd.Parameters.Add("@dt_ultimo_evento", SqlDbType.VarChar).Value = (object)internacao.dt_ultimo_evento ?? DBNull.Value;
////////////                    commd.Parameters.Add("@origem", SqlDbType.VarChar).Value = (object)internacao.nm_origem ?? DBNull.Value;
////////////                    commd.Parameters.Add("@sg_cid", SqlDbType.VarChar).Value = (object)internacao.sg_cid ?? DBNull.Value;
////////////                    commd.Parameters.Add("@tx_observacao", SqlDbType.VarChar).Value = (object)internacao.tx_observacao ?? DBNull.Value;
////////////                    commd.Parameters.Add("@convenio", SqlDbType.Int).Value = (object)internacao.nr_convenio ?? DBNull.Value;
////////////                    commd.Parameters.Add("@plano", SqlDbType.Int).Value = (object)internacao.nr_plano ?? DBNull.Value;
////////////                    commd.Parameters.Add("@convenio_plano", SqlDbType.VarChar).Value = (object)internacao.nm_convenio_plano ?? DBNull.Value;
////////////                    commd.Parameters.Add("@crm_profissional", SqlDbType.VarChar).Value = (object)internacao.nr_crm_profissional ?? DBNull.Value;
////////////                    commd.Parameters.Add("@carater_internacao", SqlDbType.VarChar).Value = (object)internacao.nm_carater_internacao ?? DBNull.Value;
////////////                    commd.Parameters.Add("@origem_internacao", SqlDbType.VarChar).Value = (object)internacao.nm_origem_internacao ?? DBNull.Value;
////////////                    commd.Parameters.Add("@procedimento", SqlDbType.VarChar).Value = (object)internacao.nr_procedimento ?? DBNull.Value;
////////////                    commd.Parameters.Add("@dt_alta_medica", SqlDbType.VarChar).Value = (object)internacao.dt_alta_medica ?? DBNull.Value;
////////////                    commd.Parameters.Add("@dt_saida_paciente", SqlDbType.DateTime).Value = (object)internacao.dt_saida_paciente ?? DBNull.Value;
////////////                    commd.Parameters.Add("@tipo_alta_medica", SqlDbType.VarChar).Value = (object)internacao.dc_tipo_alta_medica ?? DBNull.Value;
////////////                    commd.Parameters.Add("@vinculo", SqlDbType.VarChar).Value = (object)internacao.nm_vinculo ?? DBNull.Value;
////////////                    commd.Parameters.Add("@orgao", SqlDbType.VarChar).Value = (object)internacao.nm_orgao ?? DBNull.Value;
////////////                    commd.Parameters.Add("@situacao", SqlDbType.VarChar).Value = "Pendente";

////////////                    commd.CommandText = strQuery;
////////////                    com.Open();
////////////                    commd.ExecuteNonQuery();
////////////                    com.Close();

////////////                }
////////////                catch (Exception ex)
////////////                {
////////////                    string erro = ex.Message;
////////////                    Console.WriteLine(erro);

////////////                }

////////////            }
////////////        }
////////////    }


    //////////public static bool GetInternacao_UPDATE(Internacao internacao)
    //////////{
    //////////    bool valido;
    //////////    using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
    //////////    {
    //////////        string strquerySelect;
    //////////        strquerySelect = @"SELECT [prontuario_paciente],[dt_entrada_setor] FROM [Egressos].[dbo].[movimentacao_paciente] " +
    //////////         " where prontuario_paciente=" + internacao.cd_prontuario + " and dt_entrada_setor='" + internacao.dt_entrada_setor + "'";
    //////////        SqlCommand commd = new SqlCommand(strquerySelect, com);
    //////////        com.Open();
    //////////        SqlDataReader dr = commd.ExecuteReader();

    //////////        int rhInternacao = Convert.ToInt32(internacao.cd_prontuario);

    //////////        valido = dr.Read();

    //////////    }
    //////////    return valido;
    //////////}

    //////////////public static bool GetPaciente_UPDATE(int prontuario)
    //////////////{
    //////////////    bool valido;
    //////////////    using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
    //////////////    {
    //////////////        string strquerySelect;
    //////////////        strquerySelect = "SELECT * " +
    //////////////                          "FROM [Egressos].[dbo].[paciente] WHERE prontuario =" + prontuario;

    //////////////        SqlCommand commd = new SqlCommand(strquerySelect, com);
    //////////////        com.Open();
    //////////////        SqlDataReader dr = commd.ExecuteReader();

    //////////////        valido = dr.Read();

    //////////////    }
    //////////////    return valido;
    //////////////}






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
