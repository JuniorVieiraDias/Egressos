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
/// Summary description for GravaProcedimentoCirEcids
/// </summary>
public class GravaProcedimentoCirEcids : System.Web.UI.Page
{
    //public static void GravaProcedimentoCirPaciente(Procedimento_Internacao procedimento)


    public static void AtualizaProcedimentoCirPaciente(Procedimento_Internacao procedimento)
    {
        string dataAtual = Convert.ToString(DateTime.Now);
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {

            try
            {
                string strQuery = @"UPDATE [Egressos].[dbo].[procedimento_internacao]
   SET [cod_procedimento1] = @cod_procedimento1
      ,[descricao_proc1] = @descricao_proc1
      ,[data_cir_1] = @data_cir_1
      ,[cod_procedimento2] = @cod_procedimento2
      ,[descricao_proc2] = @descricao_proc2
      ,[data_cir_2] = @data_cir_2
      ,[cod_procedimento3] = @cod_procedimento3
      ,[descricao_proc3] = @descricao_proc3
      ,[data_cir_3] = @data_cir_3
     ,[cod_procedimento4] = @cod_procedimento4
      ,[descricao_proc4] = @descricao_proc4
      ,[data_cir_4] = @data_cir_4
     ,[cod_procedimento5] = @cod_procedimento5
      ,[descricao_proc5] = @descricao_proc5
      ,[data_cir_5] = @data_cir_5
      ,[obs_proced_cir] = @obs_proced_cir
      ,[nome_funcionario_alterou] =@nome_funcionario_Alterou
      ,[data_alterou] = @data_alterou
 where nr_seq=" + procedimento.Nr_Seq;

                SqlCommand commd = new SqlCommand(strQuery, com);

                commd.Parameters.Add("@cod_procedimento1", SqlDbType.Int).Value = (object)procedimento.Cod_Procedimento1 ?? DBNull.Value;
                commd.Parameters.Add("@descricao_proc1", SqlDbType.VarChar).Value = (object)procedimento.Descr_Procedimento_Cir_1 ?? DBNull.Value;
                commd.Parameters.Add("@data_cir_1", SqlDbType.VarChar).Value = (object)procedimento.Data_Cir_1 ?? DBNull.Value;
                commd.Parameters.Add("@cod_procedimento2", SqlDbType.Int).Value = (object)procedimento.Cod_Procedimento2 ?? DBNull.Value;
                commd.Parameters.Add("@descricao_proc2", SqlDbType.VarChar).Value = (object)procedimento.Descr_Procedimento_Cir_2 ?? DBNull.Value;
                commd.Parameters.Add("@data_cir_2", SqlDbType.VarChar).Value = (object)procedimento.Data_Cir_2 ?? DBNull.Value;
                commd.Parameters.Add("@cod_procedimento3", SqlDbType.Int).Value = (object)procedimento.Cod_Procedimento3 ?? DBNull.Value;
                commd.Parameters.Add("@descricao_proc3", SqlDbType.VarChar).Value = (object)procedimento.Descr_Procedimento_Cir_3 ?? DBNull.Value;
                commd.Parameters.Add("@data_cir_3", SqlDbType.VarChar).Value = (object)procedimento.Data_Cir_3 ?? DBNull.Value;
                commd.Parameters.Add("@cod_procedimento4", SqlDbType.Int).Value = (object)procedimento.Cod_Procedimento4 ?? DBNull.Value;
                commd.Parameters.Add("@descricao_proc4", SqlDbType.VarChar).Value = (object)procedimento.Descr_Procedimento_Cir_4 ?? DBNull.Value;
                commd.Parameters.Add("@data_cir_4", SqlDbType.VarChar).Value = (object)procedimento.Data_Cir_4 ?? DBNull.Value;
                commd.Parameters.Add("@cod_procedimento5", SqlDbType.Int).Value = (object)procedimento.Cod_Procedimento5 ?? DBNull.Value;
                commd.Parameters.Add("@descricao_proc5", SqlDbType.VarChar).Value = (object)procedimento.Descr_Procedimento_Cir_5 ?? DBNull.Value;
                commd.Parameters.Add("@data_cir_5", SqlDbType.VarChar).Value = (object)procedimento.Data_Cir_5 ?? DBNull.Value;
                commd.Parameters.Add("@obs_proced_cir", SqlDbType.VarChar).Value = (object)procedimento.Obs_Proced_Cir ?? DBNull.Value;
                commd.Parameters.Add("@nome_funcionario_Alterou", SqlDbType.VarChar).Value = (object)procedimento.Nome_Funcionario_Cadastrou ?? DBNull.Value;
                commd.Parameters.Add("@data_alterou", SqlDbType.VarChar).Value = (object)dataAtual ?? DBNull.Value;

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


    public static void GravaProcedimentoCirPaciente(Procedimento_Internacao procedimento)
    {
        string dataAtual = Convert.ToString(DateTime.Now);
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {

            try
            {
                string strQuery = @"INSERT INTO [Egressos].[dbo].[procedimento_internacao]
           ([nr_seq]
           ,[cod_procedimento1]
           ,[descricao_proc1]
           ,[data_cir_1]
           ,[cod_procedimento2]
           ,[descricao_proc2]
           ,[data_cir_2]
           ,[cod_procedimento3]
           ,[descricao_proc3]
           ,[data_cir_3]
          ,[cod_procedimento4]
          ,[descricao_proc4]
          ,[data_cir_4]
          ,[cod_procedimento5]
          ,[descricao_proc5]
          ,[data_cir_5]
           ,[obs_proced_cir]
           ,[nome_funcionario_cadastrou]
           ,[data_cadastrou])"
           + "VALUES (@nr_seq,@cod_procedimento1,@descricao_proc1,@data_cir_1,@cod_procedimento2,@descricao_proc2,@data_cir_2,@cod_procedimento3,"
               + "@descricao_proc3,@data_cir_3,@cod_procedimento4,@descricao_proc4,@data_cir_4,@cod_procedimento5,@descricao_proc5,@data_cir_5,@obs_proced_cir,@nome_funcionario_cadastrou,@data_cadastrou)";

                SqlCommand commd = new SqlCommand(strQuery, com);
                commd.Parameters.Add("@nr_seq", SqlDbType.Int).Value = procedimento.Nr_Seq;
                commd.Parameters.Add("@cod_procedimento1", SqlDbType.Int).Value = (object)procedimento.Cod_Procedimento1 ?? DBNull.Value;
                commd.Parameters.Add("@descricao_proc1", SqlDbType.VarChar).Value = (object)procedimento.Descr_Procedimento_Cir_1 ?? DBNull.Value;
                commd.Parameters.Add("@data_cir_1", SqlDbType.VarChar).Value = (object)procedimento.Data_Cir_1 ?? DBNull.Value;
                commd.Parameters.Add("@cod_procedimento2", SqlDbType.Int).Value = (object)procedimento.Cod_Procedimento2 ?? DBNull.Value;
                commd.Parameters.Add("@descricao_proc2", SqlDbType.VarChar).Value = (object)procedimento.Descr_Procedimento_Cir_2 ?? DBNull.Value;
                commd.Parameters.Add("@data_cir_2", SqlDbType.VarChar).Value = (object)procedimento.Data_Cir_2 ?? DBNull.Value;
                commd.Parameters.Add("@cod_procedimento3", SqlDbType.Int).Value = (object)procedimento.Cod_Procedimento3 ?? DBNull.Value;
                commd.Parameters.Add("@descricao_proc3", SqlDbType.VarChar).Value = (object)procedimento.Descr_Procedimento_Cir_3 ?? DBNull.Value;
                commd.Parameters.Add("@data_cir_3", SqlDbType.VarChar).Value = (object)procedimento.Data_Cir_3 ?? DBNull.Value;
                commd.Parameters.Add("@cod_procedimento4", SqlDbType.Int).Value = (object)procedimento.Cod_Procedimento4 ?? DBNull.Value;
                commd.Parameters.Add("@descricao_proc4", SqlDbType.VarChar).Value = (object)procedimento.Descr_Procedimento_Cir_4 ?? DBNull.Value;
                commd.Parameters.Add("@data_cir_4", SqlDbType.VarChar).Value = (object)procedimento.Data_Cir_4 ?? DBNull.Value;
                commd.Parameters.Add("@cod_procedimento5", SqlDbType.Int).Value = (object)procedimento.Cod_Procedimento5 ?? DBNull.Value;
                commd.Parameters.Add("@descricao_proc5", SqlDbType.VarChar).Value = (object)procedimento.Descr_Procedimento_Cir_5 ?? DBNull.Value;
                commd.Parameters.Add("@data_cir_5", SqlDbType.VarChar).Value = (object)procedimento.Data_Cir_5 ?? DBNull.Value;
                commd.Parameters.Add("@obs_proced_cir", SqlDbType.VarChar).Value = (object)procedimento.Obs_Proced_Cir ?? DBNull.Value;
                commd.Parameters.Add("@nome_funcionario_cadastrou", SqlDbType.VarChar).Value = (object)procedimento.Nome_Funcionario_Cadastrou ?? DBNull.Value;
                commd.Parameters.Add("@data_cadastrou", SqlDbType.VarChar).Value = (object)dataAtual ?? DBNull.Value;

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

    public static bool GravaCidPaciente(CIDInternacao c)
    {
        bool sucesso;
        string dataAtual = Convert.ToString(DateTime.Now);

        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"INSERT INTO [Egressos].[dbo].[cid_intenacao]
            ([nr_seq]
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
           ,[data_cadastrou_cid])
                                      VALUES (@nr_seq,@cod_cid_Primario,@desc_cid_Primario,@cod_cid_Secundario,
                @desc_cid_Secundario,@cod_cid_Ass1,@desc_cid_Ass1,@cod_cid_Ass2,@desc_cid_Ass2,@cod_cid_Ass3,@desc_cid_Ass3,
   @cod_cid_CausaExterna,@desc_cid_CausaExterna,@nome_funcionario_cadastrou,@data_cadastrou_cid)";

                SqlCommand commd = new SqlCommand(strQuery, com);
                commd.Parameters.Add("@nr_seq", SqlDbType.Int).Value = c.Nr_Seq;
                commd.Parameters.Add("@cod_cid_Primario", SqlDbType.VarChar).Value = c.cod_cid_Primario;
                commd.Parameters.Add("@desc_cid_Primario", SqlDbType.VarChar).Value = c.desc_cid_Primario;
                commd.Parameters.Add("@cod_cid_Secundario", SqlDbType.VarChar).Value = c.cod_cid_Secundario;
                commd.Parameters.Add("@desc_cid_Secundario", SqlDbType.VarChar).Value = c.desc_cid_Secundario;
                commd.Parameters.Add("@cod_cid_Ass1", SqlDbType.VarChar).Value = c.cod_cid_Ass1;
                commd.Parameters.Add("@desc_cid_Ass1", SqlDbType.VarChar).Value = c.desc_cid_Ass1;
                commd.Parameters.Add("@cod_cid_Ass2", SqlDbType.VarChar).Value = c.cod_cid_Ass2;
                commd.Parameters.Add("@desc_cid_Ass2", SqlDbType.VarChar).Value = c.desc_cid_Ass2;
                commd.Parameters.Add("@cod_cid_Ass3", SqlDbType.VarChar).Value = c.cod_cid_Ass3;
                commd.Parameters.Add("@desc_cid_Ass3", SqlDbType.VarChar).Value = c.desc_cid_Ass3;
                commd.Parameters.Add("@cod_cid_CausaExterna", SqlDbType.VarChar).Value = c.cod_cid_CausaExterna;
                commd.Parameters.Add("@desc_cid_CausaExterna", SqlDbType.VarChar).Value = c.desc_cid_CausaExterna;
                commd.Parameters.Add("@nome_funcionario_cadastrou", SqlDbType.VarChar).Value = c.nome_funcionario_cadastrou;
                commd.Parameters.Add("@data_cadastrou_cid", SqlDbType.VarChar).Value = dataAtual;


                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                sucesso = true;
                com.Close();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                sucesso = false;
            }
        }
        return sucesso;
    }

    public static bool AtualizaCidPaciente(CIDInternacao c)
    {
        bool sucesso;
        string dataAtual = Convert.ToString(DateTime.Now);

        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"UPDATE [Egressos].[dbo].[cid_intenacao]
       SET            
            [cod_cid_Primario]=@cod_cid_Primario
           ,[desc_cid_Primario]=@desc_cid_Primario
           ,[cod_cid_Secundario]=@cod_cid_Secundario
           ,[desc_cid_Secundario]=@desc_cid_Secundario
           ,[cod_cid_Ass1]=@cod_cid_Ass1
           ,[desc_cid_Ass1]=@desc_cid_Ass1
           ,[cod_cid_Ass2]=@cod_cid_Ass2
           ,[desc_cid_Ass2]=@desc_cid_Ass2
           ,[cod_cid_Ass3]=@cod_cid_Ass3
           ,[desc_cid_Ass3]=@desc_cid_Ass3
           ,[cod_cid_CausaExterna]=@cod_cid_CausaExterna
           ,[desc_cid_CausaExterna]=@desc_cid_CausaExterna
           ,[nome_funcionario_alterou_cid]=@nome_funcionario_alterou_cid
           ,[data_alterou_cid]=@data_alterou_cid
      WHERE nr_seq=" + c.Nr_Seq + "";

                SqlCommand commd = new SqlCommand(strQuery, com);

                commd.Parameters.Add("@cod_cid_Primario", SqlDbType.VarChar).Value = c.cod_cid_Primario;
                commd.Parameters.Add("@desc_cid_Primario", SqlDbType.VarChar).Value = c.desc_cid_Primario;
                commd.Parameters.Add("@cod_cid_Secundario", SqlDbType.VarChar).Value = c.cod_cid_Secundario;
                commd.Parameters.Add("@desc_cid_Secundario", SqlDbType.VarChar).Value = c.desc_cid_Secundario;
                commd.Parameters.Add("@cod_cid_Ass1", SqlDbType.VarChar).Value = c.cod_cid_Ass1;
                commd.Parameters.Add("@desc_cid_Ass1", SqlDbType.VarChar).Value = c.desc_cid_Ass1;
                commd.Parameters.Add("@cod_cid_Ass2", SqlDbType.VarChar).Value = c.cod_cid_Ass2;
                commd.Parameters.Add("@desc_cid_Ass2", SqlDbType.VarChar).Value = c.desc_cid_Ass2;
                commd.Parameters.Add("@cod_cid_Ass3", SqlDbType.VarChar).Value = c.cod_cid_Ass3;
                commd.Parameters.Add("@desc_cid_Ass3", SqlDbType.VarChar).Value = c.desc_cid_Ass3;
                commd.Parameters.Add("@cod_cid_CausaExterna", SqlDbType.VarChar).Value = c.cod_cid_CausaExterna;
                commd.Parameters.Add("@desc_cid_CausaExterna", SqlDbType.VarChar).Value = c.desc_cid_CausaExterna;
                commd.Parameters.Add("@nome_funcionario_alterou_cid", SqlDbType.VarChar).Value = c.nome_funcionario_cadastrou;
                commd.Parameters.Add("@data_alterou_cid", SqlDbType.VarChar).Value = dataAtual;


                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                sucesso = true;
                com.Close();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
                sucesso = false;

            }

        }

        return sucesso;
    }

}
