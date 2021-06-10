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
using System.Collections.Generic;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ProcedimentoCirRepositorio
/// </summary>
public class ProcedimentoCirRepository
{
    public static bool verificaSituacaoProcedimentoCir(int nrSeq, int codigoProcedimento)
    {
        bool valido;
        using (SqlConnection com = new SqlConnection(ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"SELECT [nr_seq],[cod_procedimento] FROM [Egressos].[dbo].[procedimento_internacao]
               where nr_seq = " + nrSeq + " and cod_procedimento=" + codigoProcedimento + " ";

                SqlCommand commd = new SqlCommand(strQuery, com);

                commd.CommandText = strQuery;
                com.Open();
                SqlDataReader dr = commd.ExecuteReader();

                valido = dr.Read();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                valido = false;
            }
        }
        return valido;
    }


    public static bool verificaSituacaoCid(int nrSeq, string numeroCid)
    {
        bool valido;
        using (SqlConnection com = new SqlConnection(ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"SELECT [nr_seq],[cod_cid] FROM [Egressos].[dbo].[cid_intenacao]
               where nr_seq = " + nrSeq + " and cod_cid='" + numeroCid + "' ";
                
                SqlCommand commd = new SqlCommand(strQuery, com);

                commd.CommandText = strQuery;
                com.Open();
                SqlDataReader dr = commd.ExecuteReader();
                              
                valido = dr.Read();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                valido = false;
            }
        }
        return valido;
    }
  
    public static List<ProcedimentoCir> GetAllProcedimentoCir()
    {

        var lista = new List<ProcedimentoCir>();

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {

            string sqlConsulta = "SELECT [Procedimento],[Descrição] FROM [Egressos].[dbo].[ProcedimentoCir] order by [Procedimento]";
            SqlCommand cmm = cnn.CreateCommand();
            cmm.CommandText = sqlConsulta;

            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();
                while (dr1.Read())
                {
                    ProcedimentoCir p = new ProcedimentoCir();
                    p.Procedimento = dr1.GetInt32(0);
                    p.Descricao = dr1.GetString(1);
                    lista.Add(p);
                }

            }
            catch (Exception ex)
            {

                string error = ex.Message;
            }

        }
        return lista;
    }

    public static ProcedimentoCir GetProcedimentoCirPorCodigo(int N_procedimentoCir)
    {
        ProcedimentoCir p = new ProcedimentoCir();
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {
            string sqlConsulta = "SELECT [Procedimento],[Descrição],[Compet] FROM [Egressos].[dbo].[ProcedimentoCir] where Procedimento = " + N_procedimentoCir + " ";

            SqlCommand cmm = cnn.CreateCommand();
            cmm.CommandText = sqlConsulta;

            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();

                if (dr1.Read())
                {
                    p.Procedimento = dr1.GetInt32(0);
                    p.Descricao = dr1.GetString(1);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;

            }

        }
        return p;
    }

    //criar excluir
    public static void GravaProcedimentoCirPaciente(Procedimento_Internacao procedimento)
    {
        
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {
         
            try
            {
                string strQuery = @"INSERT INTO [Egressos].[dbo].[procedimento_internacao]
           ([nr_seq]
           ,[cod_procedimento]
           ,[data_cir]
           ,[nome_funcionario_cadastrou])"
           + "VALUES (@nr_seq,@cod_procedimento,@data_cir,@nome_funcionario_cadastrou)";

                SqlCommand commd = new SqlCommand(strQuery, com);
                commd.Parameters.Add("@nr_seq", SqlDbType.Int).Value = procedimento.Nr_Seq;
                commd.Parameters.Add("@cod_procedimento", SqlDbType.Int).Value = procedimento.Cod_Procedimento;
                commd.Parameters.Add("@data_cir", SqlDbType.VarChar).Value = procedimento.Data_Cir;
                commd.Parameters.Add("@nome_funcionario_cadastrou", SqlDbType.VarChar).Value = procedimento.Nome_Funcionario_Cadastrou;

                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                string erro = ex.Message;

            }

        }

    }
    public static List<Procedimento_Internacao> CarregaProcedimentosInternacao(int nr_seq)
    {

        var lista = new List<Procedimento_Internacao>();
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {
            string sqlConsulta = "SELECT * FROM [Egressos].[dbo].[procedimento_internacao] WHERE nr_seq = " + nr_seq;
            SqlCommand cmm = cnn.CreateCommand();
            cmm.CommandText = sqlConsulta;

            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();

                while (dr1.Read())
                {
                    Procedimento_Internacao p = new Procedimento_Internacao();
                    p.Id = dr1.GetInt32(0);
                    p.Nr_Seq = dr1.GetInt32(1);
                    p.Cod_Procedimento = dr1.GetInt32(2);
                    p.Data_Cir = dr1.GetString(3);
                    p.Nome_Funcionario_Cadastrou = dr1.GetString(4);
                    lista.Add(p);
                }

            }
            catch (Exception ex)
            {

                string error = ex.Message;
            }

        }
        return lista;

    }

}