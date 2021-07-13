<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ProcedimentosCids_UPDATE.aspx.cs" Inherits="CadastrarAltaPaciente_ProcedimentosCids"
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

    <!-- <script src='<%= ResolveUrl("https://cdnjs.cloudflare.com/ajax/libs/jquery/2.2.4/jquery.js") %>'
        type="text/javascript"></script>-->

    <script src="../../js/jquery.mask.js" type="text/javascript"></script>

    <!--<script src='<%= ResolveUrl("https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.11/jquery.mask.js") %>'
        type="text/javascript"></script>-->
    <!-- copiar o link abrir no navegador, copiar o conteudo da pagina, depois criar uma pasta js clicar em add new item escolher javascrip dar o nome jquery-ui.js e arrastar para aqui-->

    <script src="../../js/jquery-ui.js" type="text/javascript"></script>

    <!-- <script type="text/javascript" src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.22/jquery-ui.js"></script>-->
    <!-- copiar o link abrir no navegador, copiar o conteudo da pagina, depois criar uma pasta js clicar em add new item escolher style sheet dar o nome jquery-ui.css e arrastar para aqui-->
    <link href="../../js/jquery-ui.css" rel="stylesheet" type="text/css" />
    <!-- <link rel="Stylesheet" href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.10/themes/redmond/jquery-ui.css" />-->
    <!-- teste Procedmento-->

    <script type="text/javascript">
        $(document).ready(function() {
            $("#<%= txtCodigoProcedimento1.ClientID %>").autocomplete({
                source: function(request, response) {
                    var param = { procCir: $('#<%= txtCodigoProcedimento1.ClientID %>').val() };
                    $.ajax({
                    url: "ProcedimentosCids_UPDATE.aspx/getProcCir",
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
                                    label: item.Procedimento,
                                    value: item.Procedimento
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
                    $("[id$=txtDescProcedimento1").val(i.item.name);
                },
                minLength: 1 //This is the Char length of inputTextBox    
            });
        });  
    </script>

    <!-- teste Procedmento2-->

    <script type="text/javascript">
        $(document).ready(function() {
            $("#<%= txtCodigoProcedimento2.ClientID %>").autocomplete({
                source: function(request, response) {
                    var param = { procCir: $('#<%= txtCodigoProcedimento2.ClientID %>').val() };
                    $.ajax({
                    url: "ProcedimentosCids_UPDATE.aspx/getProcCir",
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
                                    label: item.Procedimento,
                                    value: item.Procedimento
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
                    $("[id$=txtDescProcedimento2").val(i.item.name);
                },
                minLength: 1 //This is the Char length of inputTextBox    
            });
        });  
    </script>

    <!-- teste Procedmento3-->

    <script type="text/javascript">
        $(document).ready(function() {
            $("#<%= txtCodigoProcedimento3.ClientID %>").autocomplete({
                source: function(request, response) {
                    var param = { procCir: $('#<%= txtCodigoProcedimento3.ClientID %>').val() };
                    $.ajax({
                    url: "ProcedimentosCids_UPDATE.aspx/getProcCir",
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
                                    label: item.Procedimento,
                                    value: item.Procedimento
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
                    $("[id$=txtDescProcedimento3").val(i.item.name);
                },
                minLength: 1 //This is the Char length of inputTextBox    
            });
        });  
    </script>
    
      <!-- teste Procedmento4-->
    <script type="text/javascript">
        $(document).ready(function() {
            $("#<%= txtCodigoProcedimento4.ClientID %>").autocomplete({
                source: function(request, response) {
                    var param = { procCir: $('#<%= txtCodigoProcedimento4.ClientID %>').val() };
                    $.ajax({
                    url: "ProcedimentosCids_UPDATE.aspx/getProcCir",
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
                                    label: item.Procedimento,
                                    value: item.Procedimento
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
                    $("[id$=txtDescProcedimento4").val(i.item.name);
                },
                minLength: 1 //This is the Char length of inputTextBox    
            });
        });  
    </script>
    
    
    <!--Procedimento 5-->
    
    <script type="text/javascript">
        $(document).ready(function() {
            $("#<%= txtCodigoProcedimento5.ClientID %>").autocomplete({
                source: function(request, response) {
                    var param = { procCir: $('#<%= txtCodigoProcedimento5.ClientID %>').val() };
                    $.ajax({
                    url: "ProcedimentosCids_UPDATE.aspx/getProcCir",
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
                                    label: item.Procedimento,
                                    value: item.Procedimento
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
                    $("[id$=txtDescProcedimento5").val(i.item.name);
                },
                minLength: 1 //This is the Char length of inputTextBox    
            });
        });  
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        $('#<%=txtDtCirurgia1.ClientID %>').mask("99/99/9999");
        $('#<%=txtDtCirurgia2.ClientID %>').mask("99/99/9999");
        $('#<%=txtDtCirurgia3.ClientID %>').mask("99/99/9999");
        $('#<%=txtDtCirurgia4.ClientID %>').mask("99/99/9999");
        $('#<%=txtDtCirurgia5.ClientID %>').mask("99/99/9999");  
    
    </script>

    <div class="container">
         <h5 class="text-center">
            Alterar dados Cadastrados no sistema EGRESSOS</h5>
        <div class="row">
            <asp:Label ID="pegaNomeLoginUsuario" runat="server" Visible="False"></asp:Label>
        </div>
        <div class="row">
            <div class="col-2">
                Nº Internação:
                <asp:TextBox ID="txtSeqPaciente" runat="server" class="form-control" ReadOnly="True"></asp:TextBox>
                <!-- required serve para deixar o campo Obrigatório-->
            </div>
            <div class="col-8">
                Paciente
                <asp:TextBox ID="txtNomePaciente" runat="server" class="form-control" ReadOnly="True"></asp:TextBox>
            </div>
        </div>
        <hr />
        <div class="row">
        </div>
        <div class="row">
            <div class="col-2">
                Procedimento 1
                <asp:TextBox ID="txtCodigoProcedimento1" runat="server" class="form-control" required>
                </asp:TextBox>
            </div>
            <div class="col-8">
                Descrição
                <asp:TextBox ID="txtDescProcedimento1" runat="server" class="form-control" ReadOnly="False"
                    required>
                </asp:TextBox>
            </div>
            <div class="col-2">
                Data Cirurgia
                <asp:TextBox ID="txtDtCirurgia1" runat="server" class="form-control">
                </asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-2">
                Procedimento 2
                <asp:TextBox ID="txtCodigoProcedimento2" runat="server" class="form-control">
                </asp:TextBox>
            </div>
            <div class="col-8">
                Descrição
                <asp:TextBox ID="txtDescProcedimento2" runat="server" class="form-control" ReadOnly="False">
                </asp:TextBox>
            </div>
            <div class="col-2">
                Data Cirurgia
                <asp:TextBox ID="txtDtCirurgia2" runat="server" class="form-control">
                </asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-2">
                Procedimento 3
                <asp:TextBox ID="txtCodigoProcedimento3" runat="server" class="form-control">
                </asp:TextBox>
            </div>
            <div class="col-8">
                Descrição
                <asp:TextBox ID="txtDescProcedimento3" runat="server" class="form-control" ReadOnly="False">
                </asp:TextBox>
            </div>
            <div class="col-2">
                Data Cirurgia
                <asp:TextBox ID="txtDtCirurgia3" runat="server" class="form-control">
                </asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-2">
                Procedimento 4
                <asp:TextBox ID="txtCodigoProcedimento4" runat="server" class="form-control" required>
                </asp:TextBox>
            </div>
            <div class="col-8">
                Descrição
                <asp:TextBox ID="txtDescProcedimento4" runat="server" class="form-control" ReadOnly="False"
                    required>
                </asp:TextBox>
            </div>
            <div class="col-2">
                Data Cirurgia
                <asp:TextBox ID="txtDtCirurgia4" runat="server" class="form-control">
                </asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-2">
                Procedimento 5
                <asp:TextBox ID="txtCodigoProcedimento5" runat="server" class="form-control" required>
                </asp:TextBox>
            </div>
            <div class="col-8">
                Descrição
                <asp:TextBox ID="txtDescProcedimento5" runat="server" class="form-control" ReadOnly="False"
                    required>
                </asp:TextBox>
            </div>
            <div class="col-2">
                Data Cirurgia
                <asp:TextBox ID="txtDtCirurgia5" runat="server" class="form-control">
                </asp:TextBox>
            </div>
        </div>
        <!-- Fim aqui o procedimento-->
        <div class="row">
            <div class="col-1">
                <asp:Label ID="Label3" runat="server" Text="OBS:"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-10">
                <asp:TextBox ID="txtOBSprocCir" runat="server" class="form-control" MaxLength="256"></asp:TextBox>
            </div>
        </div>
        <hr />      
        <div class="row">
            <!--Button CADASTRAR-->
            <div class="col-6">
                <div class="nav justify-content-center m-2">
                    <asp:Button ID="btnAtualizar" runat="server" class="btn btn-primary" Text="Atualizar"
                        OnClick="btnAtualizar_Click" />
                </div>
            </div>
            <div class="col-6">
                <div class="nav justify-content-center m-2">
                    <asp:Button ID="btnProximo" runat="server" class="btn btn-primary" Text="Proximo"
                        OnClick="btnProximo_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
