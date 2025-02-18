﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="CadastraAlta_UPDATE.aspx.cs" Inherits="CadastrarAltaPaciente_CadastraAlta"
    Title="EGRESSOS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        input
        {
            text-align: left;
        }
    </style>
    <!-- Font Awesome -->
    <link href="../../vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet" />

    <script src="../../js/jquery.js" type="text/javascript"></script>  
    <script src="../../js/jquery.mask.js" type="text/javascript"></script>
    <script src="../../js/jquery-ui.js" type="text/javascript"></script>
    <link href="../../js/jquery-ui.css" rel="stylesheet" type="text/css" />
    
     <script type="text/javascript">
        $(document).ready(function() {
        $("#<%= TxtH_D.ClientID %>").autocomplete({
                source: function(request, response) {
                var param = { cid: $('#<%= TxtH_D.ClientID %>').val() };
                    $.ajax({
                    url: "CadastraAlta_UPDATE.aspx/getCid",
                        data: JSON.stringify(param),
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function(data) { return data; },
                        success: function(data) {
                            //console.log(JSON.stringify(data));
                            console.log("passando");
                            response($.map(data.d, function(item) {
                                return {
                                    name: item.Descricao,
                                    label: item.Cid_Numero,
                                    value: item.Cid_Numero
                                }
                            }))
                        },
                        error: function(XMLHttpRequest, textStatus, errorThrown) {
                            var err = eval("(" + XMLHttpRequest.responseText + ")");
                            alert(err.Message)
                        }
                    });
                },
                select: function(e, i) {
                $("[id$=txtDescricao").val(i.item.name);
                },
                minLength: 1 //This is the Char length of inputTextBox    
            });
        });  
    </script>

    <!-- fim do teste Procedimento-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
                 $('#<%=txtDtNasc.ClientID %>').mask("99/99/9999");
                 $('#<%= txtDtInternacao.ClientID %>').mask("99/99/9999");
                 $('#<%=txtDtEntradaSetor.ClientID %>').mask("99/99/9999");
                 $('#<%=txtDtUltimoEvento.ClientID %>').mask("99/99/9999");
                 $('#<%=txtDtAltaMedica.ClientID %>').mask("99/99/9999");
                 $('#<%=txtDtSaidaPaciente.ClientID %>').mask("99/99/9999");
                
    </script>
    <div class="container">
     <h5 class="text-center"> Alterar dados Cadastrados - Causa da Morte</h5>
     <div class="row">
            <asp:Label ID="pegaNomeLoginUsuario" runat="server" Visible="False"></asp:Label>
        </div>      
        <div class="row">
            <div class="col-1">
            Internação
                <asp:TextBox ID="txtSeqPaciente" runat="server" class="form-control" required></asp:TextBox>
                <!-- required serve para deixar o campo Obrigatório-->
            </div>            
            <div class="col-2">
            Nº RH
                <asp:TextBox ID="txtRhProntuario" runat="server" class="form-control" ReadOnly="True"></asp:TextBox>            
            </div>   
             <div class="col-8"> 
            Nome:
                <asp:TextBox ID="txtNome" runat="server" class="form-control " ReadOnly="false" 
                     MaxLength="100"></asp:TextBox>
            </div> 
           
             <div class="col-1">
            Sexo:
                <asp:TextBox ID="txtSexo" runat="server" class="form-control" ReadOnly="false" MaxLength="1"></asp:TextBox>               
            </div>        
        </div>
        <div class="row">
            <div class="col-2">
                Data Nascimento
                <asp:TextBox ID="txtDtNasc" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-2">
                Data Internação:
                <asp:TextBox ID="txtDtInternacao" runat="server" class="form-control" ReadOnly="false"></asp:TextBox>
            </div>
            <div class="col-2">
                Data Entrada no setor:
                <asp:TextBox ID="txtDtEntradaSetor" runat="server" class="form-control" ReadOnly="false"></asp:TextBox>
            </div>
            <div class="col-2">
                Data Ultimo Evento:
                <asp:TextBox ID="txtDtUltimoEvento" runat="server" class="form-control" ReadOnly="false"></asp:TextBox>
            </div>
            <div class="col-2">
                Data alta medica:
                <asp:TextBox ID="txtDtAltaMedica" runat="server" class="form-control" ReadOnly="false"></asp:TextBox>
            </div>
            <div class="col-2">
                Data Saida
                <asp:TextBox ID="txtDtSaidaPaciente" runat="server" class="form-control" ReadOnly="false"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-2">
                Origem:
                <asp:TextBox ID="txtOrigem" runat="server" class="form-control" ReadOnly="false"></asp:TextBox>
            </div>
            <div class="col-4">
                Unidade Funcional:
                <asp:TextBox ID="txtUnidadeFuncional" runat="server" class="form-control" ReadOnly="false"></asp:TextBox>
            </div>
            <div class="col-2">
                Ala:
                <asp:TextBox ID="txtAla" runat="server" class="form-control" ReadOnly="false"></asp:TextBox>
            </div>
            <div class="col-2">
                Quarto:
                <asp:TextBox ID="txtQuarto" runat="server" class="form-control" ReadOnly="false"></asp:TextBox>
            </div>
            <div class="col-2">
                Acomodação:
                <asp:TextBox ID="txtAcomodacao" runat="server" class="form-control" ReadOnly="false"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-4">
                Clinica:
                <asp:TextBox ID="txtClinica" runat="server" class="form-control" ReadOnly="false"></asp:TextBox>
            </div>
            <div class="col-2">
                Leito:
                <asp:TextBox ID="txtLeito" runat="server" class="form-control" ReadOnly="false"></asp:TextBox>
            </div>
            <div class="col-2">
                Enf. Leito:
                <asp:TextBox ID="txtEnfLeito" runat="server" class="form-control" ReadOnly="false"></asp:TextBox>
            </div>
            <div class="col-2">
                Carater-internacao:
                <asp:TextBox ID="txtCarater_internacao" runat="server" class="form-control" ReadOnly="false"></asp:TextBox>
            </div>
            <div class="col-2">
                Procedimento:
                <asp:TextBox ID="txtProcedimento" runat="server" class="form-control" ReadOnly="false"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-3">
                Especialidade:
                <asp:TextBox ID="txtEspecialidade" runat="server" class="form-control" ReadOnly="false"></asp:TextBox>
            </div>
            <div class="col-3">
                Medico:
                <asp:TextBox ID="txtNomeMedico" runat="server" class="form-control" ReadOnly="false"></asp:TextBox>
            </div>
            <div class="col-2">
                CRM-Profissional:
                <asp:TextBox ID="txtCRMprofissional" runat="server" class="form-control" ReadOnly="false"></asp:TextBox>
            </div>
            <div class="col-4">
                tx_observacao:
                <asp:TextBox ID="txt_txObservacao" runat="server" class="form-control" ReadOnly="false"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-1">
                Convenio:
                <asp:TextBox ID="txtConvenio" runat="server" class="form-control" ReadOnly="false"></asp:TextBox>
            </div>
            <div class="col-1">
                Plano:
                <asp:TextBox ID="txtPlano" runat="server" class="form-control" ReadOnly="false"></asp:TextBox>
            </div>
            <div class="col-2">
                Convenio-plano:
                <asp:TextBox ID="txtConvenioPlano" runat="server" class="form-control" ReadOnly="false"></asp:TextBox>
            </div>
            <div class="col-2">
                Vinculo:
                <asp:TextBox ID="txtVinculo" runat="server" class="form-control" ReadOnly="false"></asp:TextBox>
            </div>
            <div class="col-2">
                Orgao:
                <asp:TextBox ID="txtOrgao" runat="server" class="form-control" ReadOnly="false"></asp:TextBox>
            </div>
            <div class="col-4">
                Clinica Alta:
                <asp:DropDownList ID="DDLClinicaAlta" runat="server" class="form-control" DataSourceID="SqlDataSource1"
                    DataTextField="descricao" DataValueField="descricao">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:EgressosConnectionString %>" 
                    SelectCommand="SELECT [descricao] FROM [clinicaAlta]"></asp:SqlDataSource>
            </div>
        </div>
        <div class="row">
            <div class="col-4">
                Motivo da Saida
                <asp:DropDownList ID="DDLmotivoSaida" runat="server" class="form-control">
                    <asp:ListItem>ALTA MÉDICA</asp:ListItem>
                    <asp:ListItem>OBITO -24 HORAS</asp:ListItem>
                    <asp:ListItem>OBITO +24 HORAS</asp:ListItem>
                    <asp:ListItem>TRANSFERÊNCIA PARA OUTRO HOSPITAL</asp:ListItem>
                    <asp:ListItem>EVASÃO</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-1">
                H.D:
                <asp:TextBox ID="TxtH_D" runat="server" class="form-control" ReadOnly="false"></asp:TextBox>
            </div>
            <div class="col-7">
                Descrição:
                <asp:TextBox ID="txtDescricao" runat="server" class="form-control" ReadOnly="false"></asp:TextBox>
            </div>
        </div>
        <!-- fazer aqui o procedimento-->        
        <div class="row">
            <!--Button CADASTRAR-->
            <div class="col-6">
                <div class="nav justify-content-center m-4">
                    <asp:Button ID="btnAtualizar_UPDATE" runat="server" class="btn btn-primary" Text="Atualizar"
                        OnClick="btnAtualizar_UPDATE_Click" Height="34px" Width="100px" />
                </div>
            </div>
            <div class="col-6">
                <div class="nav justify-content-center m-4">
                    <asp:Button ID="btnProximo" runat="server" class="btn btn-primary" Text="Proximo"
                        OnClick="btnProximo_Click" Height="34px" Width="100px" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
