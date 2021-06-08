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
/// Summary description for CidRepository
/// </summary>
public class CidRepository
{

    public static List<CID> GetAllCID()
    {
        var lista = new List<CID>();

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {

            string sqlConsulta = "SELECT *  FROM [Egressos].[dbo].[cid_obito] ORDER BY cid_numero";
            SqlCommand cmm = cnn.CreateCommand();
            cmm.CommandText = sqlConsulta;
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();

                while (dr1.Read())
                {
                    CID c = new CID();

                    c.Cid_Numero = dr1.GetString(0);
                    c.Descricao = dr1.GetString(1);
                    lista.Add(c);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        return lista;
    }

    public static CID GetCIDPorCodigo(string cid)
    {
        CID c = new CID();
        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {

            string sqlConsulta = "SELECT *  FROM [Egressos].[dbo].[cid_obito] WHERE cid_numero = '" + cid + "'";

            SqlCommand cmm = cnn.CreateCommand();
            cmm.CommandText = sqlConsulta;
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();

                if (dr1.Read())
                {

                    c.Cid_Numero = dr1.GetString(0);
                    c.Descricao = dr1.GetString(1);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        return c;
    }

    public static void GravaCidPaciente(CIDInternacao c)
    {

        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"INSERT INTO [Egressos].[dbo].[cid_intenacao]
                                    ([nr_seq],[cod_cid],[tipo],[nome_funcionario_cadastrou])"
                                    + " VALUES (@nr_seq,@cod_cid,@tipo,@nome_funcionario_cadastrou)";

                SqlCommand commd = new SqlCommand(strQuery, com);
                commd.Parameters.Add("@nr_seq", SqlDbType.Int).Value = c.Nr_Seq;
                commd.Parameters.Add("@cod_cid", SqlDbType.VarChar).Value = c.Cod_CID;
                commd.Parameters.Add("@tipo", SqlDbType.VarChar).Value = c.Tipo;
                commd.Parameters.Add("@nome_funcionario_cadastrou", SqlDbType.VarChar).Value = c.Usuario;

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

    //Grava Cid Obito
    public static void GravaCidObitoPaciente(CIDInternacao c)
    {

        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {
            try
            {
                
                string strQuery = @"INSERT INTO [Egressos].[dbo].[causaMorte]
           ([nr_seq_causaMorte],[obito_p1_a],[obito_p1_b],[obito_p1_c],[obito_p1_d],[obito_p2_a],[obito_p2_b],[enc_cadaver]
           ,[causa_prov_obito],[obs],[dt_cir_1],[dt_cir_2],[dt_cir_3],[descr_cc],[cid_associado_1],[cid_associado_2],[hipotese_diagnostica]
           ,[funcionarioCadastrou])"

            + @"VALUES (@nr_seq_causaMorte,@obito_p1_a,@obito_p1_b,@obito_p1_c,@obito_p1_d,@obito_p2_a,@obito_p2_b,@enc_cadaver
              ,@causa_prov_obito,@obs,@dt_cir_1,@dt_cir_2,@dt_cir_3,@descr_cc,@cid_associado_1,@cid_associado_2,@hipotese_diagnostica
              ,@funcionarioCadastrou)";

                SqlCommand commd = new SqlCommand(strQuery, com);
                commd.Parameters.Add("@nr_seq_causaMorte", SqlDbType.Int).Value = c.Nr_Seq;
                commd.Parameters.Add("@obito_p1_a", SqlDbType.VarChar).Value = c.Cod_CID;
                commd.Parameters.Add("@obito_p1_b", SqlDbType.VarChar).Value = c.Tipo;
                commd.Parameters.Add("@obito_p1_c", SqlDbType.VarChar).Value = c.Usuario;
                commd.Parameters.Add("@obito_p1_d", SqlDbType.VarChar).Value = c.Usuario;
                commd.Parameters.Add("@obito_p2_a", SqlDbType.VarChar).Value = c.Usuario;
                commd.Parameters.Add("@obito_p2_b", SqlDbType.VarChar).Value = c.Usuario;
                commd.Parameters.Add("@enc_cadaver", SqlDbType.VarChar).Value = c.Usuario;
                commd.Parameters.Add("@causa_prov_obito", SqlDbType.VarChar).Value = c.Usuario;
                commd.Parameters.Add("@obs", SqlDbType.VarChar).Value = c.Usuario;
                commd.Parameters.Add("@dt_cir_1", SqlDbType.VarChar).Value = c.Usuario;
                commd.Parameters.Add("@dt_cir_2", SqlDbType.VarChar).Value = c.Usuario;
                commd.Parameters.Add("@dt_cir_3", SqlDbType.VarChar).Value = c.Usuario;
                commd.Parameters.Add("@descr_cc", SqlDbType.VarChar).Value = c.Usuario;
                commd.Parameters.Add("@cid_associado_1", SqlDbType.VarChar).Value = c.Usuario;
                commd.Parameters.Add("@cid_associado_2", SqlDbType.VarChar).Value = c.Usuario; 
                commd.Parameters.Add("@hipotese_diagnostica", SqlDbType.Int).Value = c.Nr_Seq;
                commd.Parameters.Add("@funcionarioCadastrou", SqlDbType.VarChar).Value = c.Usuario;
                


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

    //Fim grava Cid Obito







    public static void RemoverProcedimentoPaciente(int id)
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {
            try
            {
                string strQuery = @"DELETE FROM [Egressos].[dbo].[procedimento_internacao]
                                     WHERE id= " + id + "";

                SqlCommand commd = new SqlCommand(strQuery, com);
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

    public static void RemoverCidPaciente(int id)
    {

        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {
            try
            {                
                string strQuery = @"DELETE FROM [Egressos].[dbo].[cid_intenacao]
                                  WHERE id= " + id + "";
                SqlCommand commd = new SqlCommand(strQuery, com);

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

    public static List<CIDInternacao> CarregaCIDInternacao(int nr_seq)
    {
        var lista = new List<CIDInternacao>();

        using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {

            string sqlConsulta = "SELECT * FROM [Egressos].[dbo].[cid_intenacao] WHERE nr_seq = " + nr_seq;
            SqlCommand cmm = cnn.CreateCommand();
            cmm.CommandText = sqlConsulta;
            try
            {
                cnn.Open();
                SqlDataReader dr1 = cmm.ExecuteReader();

                while (dr1.Read())
                {
                    CIDInternacao p = new CIDInternacao();
                    p.Id = dr1.GetInt32(0);
                    p.Nr_Seq = dr1.GetInt32(1);
                    p.Cod_CID = dr1.GetString(2);
                    p.Tipo = dr1.GetString(3);
                    p.Usuario = dr1.GetString(4);
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
