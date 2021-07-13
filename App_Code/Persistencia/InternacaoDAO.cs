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
/// Summary description for InternacaoDAO
/// </summary>
public class InternacaoDAO
{
    public InternacaoDAO()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static void GravaInternacao(Internacao internacao)
    {
        // verifica se existe a internação
        bool existeInternacao = GetInternacao(internacao);

        bool existePaciente = GetPaciente(internacao.cd_prontuario);

        if (existePaciente == false)
        {
            using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
            {
                try
                {
                    string strQuery = @"INSERT INTO [Egressos].[dbo].[paciente]
                                    ([prontuario],[nome],[sexo],[statusDtNascimento])"
                                        + " VALUES (@prontuario,@nome,@sexo,@statusDtNascimento)";

                    SqlCommand commd = new SqlCommand(strQuery, com);
                    commd.Parameters.Add("@prontuario", SqlDbType.Int).Value = internacao.cd_prontuario;
                    commd.Parameters.Add("@nome", SqlDbType.VarChar).Value = internacao.nm_paciente;
                    commd.Parameters.Add("@sexo", SqlDbType.VarChar).Value = internacao.in_sexo;
                    commd.Parameters.Add("@statusDtNascimento", SqlDbType.VarChar).Value = "2";


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

        //Todo completar o insert

        // se não existir a internação então grava no banco
        if (existeInternacao == false)
        {
            using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
            {
                try
                {
                    string strQuery = "INSERT INTO [Egressos].[dbo].[movimentacao_paciente]"
                                   + "([nr_seq],[prontuario_paciente],[leito],[ala]"
                        + ",[clinica],[unidade_funcional],[acomodacao]"
                        + ",[st_leito],[dt_internacao],[dt_entrada_setor]"
                        + ",[especialidade],[medico],[dt_ultimo_evento],[origem]"
                        + ",[sg_cid],[tx_observacao],[convenio],[plano]"
                        + ",[convenio_plano],[crm_profissional],[carater_internacao]"
                        + ",[origem_internacao],[procedimento],[dt_alta_medica]"
                        + ",[dt_saida_paciente],[tipo_alta_medica],[vinculo],[orgao],[situacao])"

                                    + " VALUES (@nr_seq,@prontuario_paciente,@leito,@ala"
                                    + ",@clinica,@unidade_funcional,@acomodacao"
                                    + ",@st_leito,@dt_internacao,@dt_entrada_setor"
                                    + ",@especialidade,@medico,@dt_ultimo_evento,@origem"
                                    + ",@sg_cid,@tx_observacao,@convenio,@plano"
                                    + ",@convenio_plano,@crm_profissional,@carater_internacao"
                                    + ",@origem_internacao,@procedimento,@dt_alta_medica"
                                    + ",@dt_saida_paciente,@tipo_alta_medica,@vinculo,@orgao,@situacao)";

                    SqlCommand commd = new SqlCommand(strQuery, com);

                    commd.Parameters.Add("@nr_seq", SqlDbType.Int).Value = internacao.nr_seq;
                    commd.Parameters.Add("@prontuario_paciente", SqlDbType.Int).Value = internacao.cd_prontuario;
                    if (internacao.nr_leito == null)
                    {
                        internacao.nr_leito = "";
                    }
                    commd.Parameters.Add("@leito", SqlDbType.VarChar).Value = internacao.nr_leito;
                    commd.Parameters.Add("@ala", SqlDbType.VarChar).Value = internacao.nm_ala;
                    commd.Parameters.Add("@clinica", SqlDbType.VarChar).Value = (object)internacao.nm_clinica ?? DBNull.Value;
                    commd.Parameters.Add("@unidade_funcional", SqlDbType.VarChar).Value = (object)internacao.nm_unidade_funcional ?? DBNull.Value;
                    commd.Parameters.Add("@acomodacao", SqlDbType.VarChar).Value = (object)internacao.nm_acomodacao ?? DBNull.Value;
                    commd.Parameters.Add("@st_leito", SqlDbType.VarChar).Value = (object)internacao.st_leito ?? DBNull.Value;
                    commd.Parameters.Add("@dt_internacao", SqlDbType.VarChar).Value = (object)internacao.dt_internacao ?? DBNull.Value;
                    commd.Parameters.Add("@dt_entrada_setor", SqlDbType.VarChar).Value = (object)internacao.dt_entrada_setor ?? DBNull.Value;
                    commd.Parameters.Add("@especialidade", SqlDbType.VarChar).Value = (object)internacao.nm_especialidade ?? DBNull.Value;
                    commd.Parameters.Add("@medico", SqlDbType.VarChar).Value = (object)internacao.nm_medico ?? DBNull.Value;
                    commd.Parameters.Add("@dt_ultimo_evento", SqlDbType.VarChar).Value = (object)internacao.dt_ultimo_evento ?? DBNull.Value;
                    commd.Parameters.Add("@origem", SqlDbType.VarChar).Value = (object)internacao.nm_origem ?? DBNull.Value;
                    commd.Parameters.Add("@sg_cid", SqlDbType.VarChar).Value = (object)internacao.sg_cid ?? DBNull.Value;
                    commd.Parameters.Add("@tx_observacao", SqlDbType.VarChar).Value = (object)internacao.tx_observacao ?? DBNull.Value;
                    commd.Parameters.Add("@convenio", SqlDbType.Int).Value = (object)internacao.nr_convenio ?? DBNull.Value;
                    commd.Parameters.Add("@plano", SqlDbType.Int).Value = (object)internacao.nr_plano ?? DBNull.Value;
                    commd.Parameters.Add("@convenio_plano", SqlDbType.VarChar).Value = (object)internacao.nm_convenio_plano ?? DBNull.Value;
                    commd.Parameters.Add("@crm_profissional", SqlDbType.VarChar).Value = (object)internacao.nr_crm_profissional ?? DBNull.Value;
                    commd.Parameters.Add("@carater_internacao", SqlDbType.VarChar).Value = (object)internacao.nm_carater_internacao ?? DBNull.Value;
                    commd.Parameters.Add("@origem_internacao", SqlDbType.VarChar).Value = (object)internacao.nm_origem_internacao ?? DBNull.Value;
                    commd.Parameters.Add("@procedimento", SqlDbType.VarChar).Value = (object)internacao.nr_procedimento ?? DBNull.Value;
                    commd.Parameters.Add("@dt_alta_medica", SqlDbType.VarChar).Value = (object)internacao.dt_alta_medica ?? DBNull.Value;
                    commd.Parameters.Add("@dt_saida_paciente", SqlDbType.DateTime).Value = (object)internacao.dt_saida_paciente ?? DBNull.Value;
                    commd.Parameters.Add("@tipo_alta_medica", SqlDbType.VarChar).Value = (object)internacao.dc_tipo_alta_medica ?? DBNull.Value;
                    commd.Parameters.Add("@vinculo", SqlDbType.VarChar).Value = (object)internacao.nm_vinculo ?? DBNull.Value;
                    commd.Parameters.Add("@orgao", SqlDbType.VarChar).Value = (object)internacao.nm_orgao ?? DBNull.Value;
                    commd.Parameters.Add("@situacao", SqlDbType.VarChar).Value = "Pendente";

                    commd.CommandText = strQuery;
                    com.Open();
                    commd.ExecuteNonQuery();
                    com.Close();

                }
                catch (Exception ex)
                {
                    string erro = ex.Message;
                    Console.WriteLine(erro);

                }

            }
        }
    }


    public static bool GetInternacao(Internacao internacao)
    {
        bool valido;
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {
            string strquerySelect;
            strquerySelect = @"SELECT [prontuario_paciente],[dt_entrada_setor] FROM [Egressos].[dbo].[movimentacao_paciente] " +
             " where prontuario_paciente=" + internacao.cd_prontuario + " and dt_entrada_setor='" + internacao.dt_entrada_setor + "'";
            SqlCommand commd = new SqlCommand(strquerySelect, com);
            com.Open();
            SqlDataReader dr = commd.ExecuteReader();

            int rhInternacao = Convert.ToInt32(internacao.cd_prontuario);

            valido = dr.Read();
            com.Close();
        }
        return valido;
    }

    public static bool GetPaciente(int prontuario)
    {
        bool valido;
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {
            string strquerySelect;
            strquerySelect = "SELECT * " +
                              "FROM [Egressos].[dbo].[paciente] WHERE prontuario =" + prontuario;

            SqlCommand commd = new SqlCommand(strquerySelect, com);
            com.Open();
            SqlDataReader dr = commd.ExecuteReader();

            valido = dr.Read();
            com.Close();
        }
        
        return valido;
    }

    // pega a lista de internações de um único paciente
    public static List<Internacao> GetListaInternacoePorProntuario(int prontuario)
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
                                                       where prontuario=" + prontuario;            


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
                  

                    //if (i.Situacao==0)
                    //{
                    //    i.SituacaoStatus = "Não Preenchido";
                    //}
                    //else
                    //{
                    //    i.SituacaoStatus = "Preenchido";
                    //}
                    //i.nr_leito = dr1.IsDBNull(2) ? "" : dr1.GetString(2);
                    //i.nm_ala = dr1.IsDBNull(3) ? "" : dr1.GetString(3);
                    //i.nm_clinica = dr1.IsDBNull(4) ? "" : dr1.GetString(4);
                    //i.nm_unidade_funcional = dr1.IsDBNull(5) ? "" : dr1.GetString(5);
                    //i.nm_acomodacao = dr1.IsDBNull(6) ? "" : dr1.GetString(6);
                    //i.st_leito = dr1.IsDBNull(7) ? " " : dr1.GetString(7);
                    //i.dt_internacao = dr1.IsDBNull(8) ? "" : dr1.GetString(8);
                    //i.dt_entrada_setor = dr1.IsDBNull(9) ? "" : dr1.GetString(9);
                    //i.nm_especialidade = dr1.IsDBNull(10) ? "" : dr1.GetString(10);
                    //i.nm_medico = dr1.IsDBNull(11) ? "" : dr1.GetString(11);
                    //i.dt_ultimo_evento = dr1.IsDBNull(12) ? "" : dr1.GetString(12);
                    //i.nm_origem = dr1.IsDBNull(13) ? "" : dr1.GetString(13);
                    //i.sg_cid = dr1.IsDBNull(14) ? "" : dr1.GetString(14);
                    //i.tx_observacao = dr1.IsDBNull(15) ? "" : dr1.GetString(15);
                    //i.nr_convenio = dr1.IsDBNull(16) ? 0 : dr1.GetInt32(16);
                    //i.nr_plano = dr1.IsDBNull(17) ? 0 : dr1.GetInt32(17);
                    //i.nm_convenio_plano = dr1.IsDBNull(18) ? "" : dr1.GetString(18);
                    //i.nr_crm_profissional = dr1.IsDBNull(19) ? "" : dr1.GetString(19);
                    //i.nm_carater_internacao = dr1.IsDBNull(20) ? "" : dr1.GetString(20);
                    //i.nm_origem_internacao = dr1.IsDBNull(21) ? "" : dr1.GetString(21);
                    //i.nr_procedimento = dr1.IsDBNull(22) ? "" : dr1.GetString(22);
                    // i.dt_alta_medica = dr1.IsDBNull(23) ? "" : dr1.GetString(23);
                    //i.dt_saida_paciente = dr1.IsDBNull(24) ? "" : dr1.GetString(24);
                    //i.dc_tipo_alta_medica = dr1.IsDBNull(25) ? "" : dr1.GetString(25);
                    //i.nm_vinculo = dr1.IsDBNull(26) ? "" : dr1.GetString(26);
                    //i.nm_orgao = dr1.IsDBNull(27) ? "" : dr1.GetString(27);

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

    public static List<Internacao> GetListaInternacoeTodosUsuarios()
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
                                                 
                                                     FROM [Egressos].[dbo].[vw_dadosPacienteMovimentacao]";
                                                     


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
