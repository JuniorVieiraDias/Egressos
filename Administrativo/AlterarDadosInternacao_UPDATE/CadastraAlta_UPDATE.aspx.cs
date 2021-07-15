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
using System.Collections.Generic;
using System.Web.Services;


public partial class CadastrarAltaPaciente_CadastraAlta : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            string nrSeq = Request.QueryString["nrSeq"];
            txtSeqPaciente.Text = nrSeq;
            BindDados(Convert.ToInt32(nrSeq));
            txtSeqPaciente.Enabled = false;
            pegaNomeLoginUsuario.Text = User.Identity.Name;
        }

    }


    private void BindDados(int p)
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {
            try
            {
                string strQuery = "";
                SqlCommand commd = new SqlCommand(strQuery, com);
                strQuery = @"SELECT [prontuario] ,[nome] ,[sexo] ,[dtNascimento]      
      ,[quarto],[leito],[ala],[clinica],[unidade_funcional]
      ,[acomodacao],[st_leito],[dt_internacao],[dt_entrada_setor],[especialidade]
      ,[medico],[dt_ultimo_evento],[origem],[sg_cid],[tx_observacao],[convenio]
      ,[plano],[convenio_plano],[crm_profissional],[carater_internacao]
      ,[origem_internacao],[procedimento],[dt_alta_medica],[dt_saida_paciente]
      ,[tipo_alta_medica],[clinica_alta_medica],[vinculo],[orgao]
      
  FROM [Egressos].[dbo].[vw_dadosPacienteMovimentacao]
                                    where nr_seq=" + p + "";

                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                SqlDataReader dr = commd.ExecuteReader();
                if (dr.Read())
                {
                    txtRhProntuario.Text = Convert.ToString(dr.GetInt32(0));
                    txtNome.Text = dr.IsDBNull(1) ? null : dr.GetString(1);
                    txtSexo.Text = dr.IsDBNull(2) ? null : dr.GetString(2);
                    txtDtEntradaSetor.Text = dr.IsDBNull(12) ? null : dr.GetString(12);//dt_internacao
                    txtDtInternacao.Text = dr.GetString(11);
                    txtDtSaidaPaciente.Text = Convert.ToString(dr.GetDateTime(27));// string campo
                    txtDtAltaMedica.Text = dr.GetString(26);
                    TxtH_D.Text = dr.GetString(17);//sg_cid
                    string codigoCid = TxtH_D.Text.Replace(".", "");
                    BuscaDescCid(codigoCid); // chama a função que carrega a descrição do H.D                  
                    // BuscaDescCid(TxtH_D.Text); // chama a função que carrega a descrição do H.D                  
                    txtClinica.Text = dr.GetString(7);
                    txtLeito.Text = dr.IsDBNull(5) ? null : dr.GetString(5);
                    txtEnfLeito.Text = dr.IsDBNull(10) ? null : dr.GetString(10);
                    txtDtNasc.Text = dr.IsDBNull(3) ? null : dr.GetString(3);
                    txtQuarto.Text = dr.IsDBNull(4) ? null : dr.GetString(4);
                    txtAla.Text = dr.IsDBNull(6) ? null : dr.GetString(6);
                    txtUnidadeFuncional.Text = dr.IsDBNull(8) ? null : dr.GetString(8);
                    txtAcomodacao.Text = dr.IsDBNull(9) ? null : dr.GetString(9);
                    txtEspecialidade.Text = dr.IsDBNull(13) ? null : dr.GetString(13);
                    txtNomeMedico.Text = dr.IsDBNull(14) ? null : dr.GetString(14);
                    txtDtUltimoEvento.Text = dr.IsDBNull(15) ? null : dr.GetString(15);
                    txtOrigem.Text = dr.IsDBNull(16) ? null : dr.GetString(16);
                    txt_txObservacao.Text = dr.IsDBNull(18) ? null : dr.GetString(18);
                    txtConvenio.Text = dr.IsDBNull(19) ? null : Convert.ToString(dr.GetInt32(19));
                    txtPlano.Text = dr.IsDBNull(20) ? null : Convert.ToString(dr.GetInt32(20));
                    txtConvenioPlano.Text = dr.IsDBNull(21) ? null : dr.GetString(21);
                    txtCRMprofissional.Text = dr.IsDBNull(22) ? null : dr.GetString(22);
                    txtCarater_internacao.Text = dr.IsDBNull(23) ? null : dr.GetString(23);
                    txtOrigem.Text = dr.IsDBNull(24) ? null : dr.GetString(24);
                    txtProcedimento.Text = dr.IsDBNull(25) ? null : dr.GetString(25);
                    DDLmotivoSaida.SelectedItem.Text = dr.IsDBNull(28) ? null : dr.GetString(28);
                    DDLClinicaAlta.Text = dr.IsDBNull(29) ? null : dr.GetString(29);
                    txtVinculo.Text = dr.IsDBNull(30) ? null : dr.GetString(30);
                    txtOrgao.Text = dr.IsDBNull(31) ? null : dr.GetString(31);

                }
                com.Close();
            }
            catch (Exception ex)
            {
                string erro = ex.Message;
            }
        }

    }

    private void BuscaDescCid(string p)//Função que carrega a descriçãodo H.D
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {
            try
            {
                string strQuery = "";
                SqlCommand commd = new SqlCommand(strQuery, com);
                strQuery = @"SELECT [descricao_cid]
                                FROM [Egressos].[dbo].[cid_obito]
                                     Where [cid_numero] = '" + p + "'";
                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                SqlDataReader dr = commd.ExecuteReader();
                if (dr.Read())
                {
                    txtDescricao.Text = dr.GetString(0);
                }
            }

            catch (Exception ex)
            {
                string erro = ex.Message;
            }
            //return txbDescricao.Text;
            com.Close();
        }

    }


    protected void btnAtualizar_UPDATE_Click(object sender, EventArgs e)
    {
        AtualizarDadosPessoaisPaciente(txtRhProntuario.Text);
        AtualizaDadosMovimentacaoDoPaciente(txtSeqPaciente.Text);

    }
    private void AtualizarDadosPessoaisPaciente(string prontuario)// Atualiza 
    {
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {
            int prontuarioRh = Convert.ToInt32(prontuario);
            try
            {
                string strQuery = "";

                SqlCommand commd = new SqlCommand(strQuery, com);
                strQuery = @"update [Egressos].[dbo].[paciente]           
                                   set [nome] =@nomeP_UPDATE,[sexo] =@sexoP,[dtNascimento] =@dtNascimentoP  where prontuario=" + prontuarioRh + "";
                commd.Parameters.Add("@nomeP_UPDATE", SqlDbType.VarChar).Value = txtNome.Text;
                commd.Parameters.Add("@sexoP", SqlDbType.VarChar).Value = txtSexo.Text;
                commd.Parameters.Add("@dtNascimentoP", SqlDbType.VarChar).Value = txtDtNasc.Text;
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

    private void AtualizaDadosMovimentacaoDoPaciente(string nrSeq)
    {
        string dataAtual = Convert.ToString(DateTime.Now);
        using (SqlConnection com = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["EgressosConnectionString"].ToString()))
        {

            try
            {
                int nr_seq = Convert.ToInt32(nrSeq);
                string strQuery = @"UPDATE [Egressos].[dbo].[movimentacao_paciente]
   SET [quarto] = @quarto
      ,[leito] =@leito
      ,[ala] = @ala
      ,[clinica] = @clinica
      ,[unidade_funcional] = @unidade_funcional
      ,[acomodacao] = @acomodacao
      ,[st_leito] = @st_leito
      ,[dt_internacao] = @dt_internacao
      ,[dt_entrada_setor] = @dt_entrada_setor
      ,[especialidade] = @especialidade
      ,[medico] = @medico
      ,[dt_ultimo_evento] = @dt_ultimo_evento
      ,[origem] = @origem
      ,[sg_cid] = @sg_cid
      ,[tx_observacao] = @tx_observacao
      ,[convenio] = @convenio
      ,[plano] = @plano
      ,[convenio_plano] = @convenio_plano
      ,[crm_profissional] = @crm_profissional
      ,[carater_internacao] = @carater_internacao
      ,[origem_internacao] = @origem_internacao
      ,[procedimento] = @procedimento
      ,[dt_alta_medica] = @dt_alta_medica
      ,[dt_saida_paciente] = @dt_saida_paciente
      ,[tipo_alta_medica] = @tipo_alta_medica
      ,[clinica_alta_medica] = @clinica_alta_medica
      ,[vinculo] = @vinculo
      ,[orgao] = @orgao      
      ,[nome_funcionario_alterou] = @nome_funcionario_alterou
      ,[data_alterou] = @data_alterou
 WHERE [prontuario_paciente]= " + nr_seq + " ";

                SqlCommand commd = new SqlCommand(strQuery, com);

                commd.Parameters.Add("@quarto", SqlDbType.VarChar).Value = txtQuarto.Text == "" ? "" : txtQuarto.Text;
                commd.Parameters.Add("@leito", SqlDbType.VarChar).Value = txtLeito.Text == "" ? "" : txtLeito.Text;
                commd.Parameters.Add("@ala", SqlDbType.VarChar).Value = txtAla.Text == "" ? "" : txtAla.Text;
                commd.Parameters.Add("@clinica", SqlDbType.VarChar).Value = txtClinica.Text == "" ? "" : txtClinica.Text;
                commd.Parameters.Add("@unidade_funcional", SqlDbType.VarChar).Value = txtUnidadeFuncional.Text == "" ? "" : txtUnidadeFuncional.Text;
                commd.Parameters.Add("@acomodacao", SqlDbType.VarChar).Value = txtAcomodacao.Text == "" ? "" : txtAcomodacao.Text;
                commd.Parameters.Add("@st_leito", SqlDbType.VarChar).Value = txtEnfLeito.Text == "" ? "" : txtEnfLeito.Text;
                commd.Parameters.Add("@dt_internacao", SqlDbType.VarChar).Value = txtDtInternacao.Text == "" ? "" : txtDtInternacao.Text;
                commd.Parameters.Add("@dt_entrada_setor", SqlDbType.VarChar).Value = txtDtEntradaSetor.Text == "" ? "" : txtDtEntradaSetor.Text;
                commd.Parameters.Add("@especialidade", SqlDbType.VarChar).Value = txtEspecialidade.Text == "" ? "" : txtEspecialidade.Text;
                commd.Parameters.Add("@medico", SqlDbType.VarChar).Value = txtNomeMedico.Text == "" ? "" : txtNomeMedico.Text;
                commd.Parameters.Add("@dt_ultimo_evento", SqlDbType.VarChar).Value = txtDtUltimoEvento.Text == "" ? "" : txtDtUltimoEvento.Text;
                commd.Parameters.Add("@origem", SqlDbType.VarChar).Value = txtOrigem.Text == "" ? "" : txtOrigem.Text;
                commd.Parameters.Add("@sg_cid", SqlDbType.VarChar).Value = TxtH_D.Text == "" ? "" : TxtH_D.Text;
                commd.Parameters.Add("@tx_observacao", SqlDbType.VarChar).Value = txt_txObservacao.Text == "" ? "" : txt_txObservacao.Text;
                commd.Parameters.Add("@convenio_plano", SqlDbType.VarChar).Value = txtConvenioPlano.Text == "" ? "" : txtConvenioPlano.Text;
                commd.Parameters.Add("@crm_profissional", SqlDbType.VarChar).Value = txtCRMprofissional.Text == "" ? "" : txtCRMprofissional.Text;
                commd.Parameters.Add("@carater_internacao", SqlDbType.VarChar).Value = txtCarater_internacao.Text == "" ? "" : txtCarater_internacao.Text;
                commd.Parameters.Add("@convenio", SqlDbType.Int).Value = txtConvenio.Text == "" ? 0 : Convert.ToInt32(txtConvenio.Text);
                commd.Parameters.Add("@plano", SqlDbType.Int).Value = txtPlano.Text == "" ? 0 : Convert.ToInt32(txtPlano.Text);
                commd.Parameters.Add("@origem_internacao", SqlDbType.VarChar).Value = txtOrigem.Text == "" ? "" : txtOrigem.Text;
                commd.Parameters.Add("@procedimento", SqlDbType.VarChar).Value = txtProcedimento.Text == "" ? "" : txtProcedimento.Text;
                commd.Parameters.Add("@dt_alta_medica", SqlDbType.VarChar).Value = txtDtAltaMedica.Text == "" ? "" : txtDtAltaMedica.Text;
                commd.Parameters.Add("@dt_saida_paciente", SqlDbType.Date).Value = txtDtSaidaPaciente.Text == "" ? "" : txtDtSaidaPaciente.Text;
                commd.Parameters.Add("@tipo_alta_medica", SqlDbType.VarChar).Value = DDLmotivoSaida.Text == "" ? "" : DDLmotivoSaida.Text;
                commd.Parameters.Add("@clinica_alta_medica", SqlDbType.VarChar).Value = DDLClinicaAlta.Text == "" ? "" : DDLClinicaAlta.Text;
                commd.Parameters.Add("@vinculo", SqlDbType.VarChar).Value = txtVinculo.Text == "" ? "" : txtVinculo.Text;
                commd.Parameters.Add("@orgao", SqlDbType.VarChar).Value = txtOrgao.Text == "" ? "" : txtOrgao.Text;
                commd.Parameters.Add("@nome_funcionario_alterou", SqlDbType.VarChar).Value = pegaNomeLoginUsuario.Text == "" ? "" : pegaNomeLoginUsuario.Text;
                commd.Parameters.Add("@data_alterou", SqlDbType.Date).Value = dataAtual == "" ? "" : dataAtual;

                commd.CommandText = strQuery;
                com.Open();
                commd.ExecuteNonQuery();
                com.Close();

            }

            catch (Exception ex)
            {
                string erro = ex.Message;
                throw;
            }

        }

    }


    protected void btnProximo_Click(object sender, EventArgs e)
    {

    }

}
