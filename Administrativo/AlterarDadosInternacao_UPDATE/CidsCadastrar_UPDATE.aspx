<%@ Page Title="EGRESSOS" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="CidsCadastrar_UPDATE.aspx.cs" Inherits="CadastrarAltaPaciente_CidsCadastrar" %>

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
    <!-- Cid-->

    <script type="text/javascript">
        $(document).ready(function() {
            $("#<%= txbcid1.ClientID %>").autocomplete({
                source: function(request, response) {
                    var param = { cid: $('#<%= txbcid1.ClientID %>').val() };
                    $.ajax({
                        url: "CidsCadastrar_UPDATE.aspx/getCid",
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
                    $("[id$=txbDescricaoCid1").val(i.item.name);
                },
                minLength: 1 //This is the Char length of inputTextBox    
            });
        });  
    </script>

    <!-- Cid secundario-->

    <script type="text/javascript">
        $(document).ready(function() {
            $("#<%= txbcid2.ClientID %>").autocomplete({
                source: function(request, response) {
                    var param = { cid: $('#<%= txbcid2.ClientID %>').val() };
                    $.ajax({
                        url: "CidsCadastrar_UPDATE.aspx/getCid",
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
                    $("[id$=txbDescricaoCid2").val(i.item.name);
                },
                minLength: 1 //This is the Char length of inputTextBox    
            });
        });  
    </script>

    <!-- Cid ass1-->

    <script type="text/javascript">
        $(document).ready(function() {
            $("#<%= txbcidA1.ClientID %>").autocomplete({
                source: function(request, response) {
                    var param = { cid: $('#<%= txbcidA1.ClientID %>').val() };
                    $.ajax({
                        url: "CidsCadastrar_UPDATE.aspx/getCid",
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
                    $("[id$=txbDescricaoCidA1").val(i.item.name);
                },
                minLength: 1 //This is the Char length of inputTextBox    
            });
        });  
    </script>

    <!-- Cid ass2-->

    <script type="text/javascript">
        $(document).ready(function() {
            $("#<%= txbcidA2.ClientID %>").autocomplete({
                source: function(request, response) {
                    var param = { cid: $('#<%= txbcidA2.ClientID %>').val() };
                    $.ajax({
                        url: "CidsCadastrar_UPDATE.aspx/getCid",
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
                    $("[id$=txbDescricaoCidA2").val(i.item.name);
                },
                minLength: 1 //This is the Char length of inputTextBox    
            });
        });  
    </script>

    <!-- Cid ass3-->

    <script type="text/javascript">
        $(document).ready(function() {
            $("#<%= txbcidA3.ClientID %>").autocomplete({
                source: function(request, response) {
                    var param = { cid: $('#<%= txbcidA3.ClientID %>').val() };
                    $.ajax({
                        url: "CidsCadastrar_UPDATE.aspx/getCid",
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
                    $("[id$=txbDescricaoCidA3").val(i.item.name);
                },
                minLength: 1 //This is the Char length of inputTextBox    
            });
        });  
    </script>

    <!-- Cid causa externa-->

    <script type="text/javascript">
        $(document).ready(function() {
            $("#<%= txbcidCausaEx.ClientID %>").autocomplete({
                source: function(request, response) {
                    var param = { cid: $('#<%= txbcidCausaEx.ClientID %>').val() };
                    $.ajax({
                        url: "CidsCadastrar_UPDATE.aspx/getCid",
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
                    $("[id$=txbDescricaoCidCausaEx").val(i.item.name);
                },
                minLength: 1 //This is the Char length of inputTextBox    
            });
        });  
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
            <div class="col-10">
                Paciente
                <asp:TextBox ID="txtNomePaciente" runat="server" class="form-control" ReadOnly="True"></asp:TextBox>
            </div>
        </div>
        <hr />
        <!-- bloco cadastrar cid-->
        <div class="row">
            <div class="col-2">
                CID:Primario
                <asp:TextBox ID="txbcid1" runat="server" class="form-control" required>
                </asp:TextBox>
            </div>
            <div class="col-10">
                Descrição:
                <asp:TextBox ID="txbDescricaoCid1" runat="server" class="form-control" ReadOnly="False"
                    required>
                </asp:TextBox>
            </div>
        </div>
        <!--</div>-->
        <div class="row">
            <div class="col-2">
                CID: Secundario
                <asp:TextBox ID="txbcid2" runat="server" class="form-control">
                </asp:TextBox>
            </div>
            <div class="col-10">
                Descrição:
                <asp:TextBox ID="txbDescricaoCid2" runat="server" class="form-control" ReadOnly="False">
                </asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-2">
                CID:Associado 1
                <asp:TextBox ID="txbcidA1" runat="server" class="form-control">
                </asp:TextBox>
            </div>
            <div class="col-10">
                Descrição:
                <asp:TextBox ID="txbDescricaoCidA1" runat="server" class="form-control" ReadOnly="False">
                </asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-2">
                CID:Associado2
                <asp:TextBox ID="txbcidA2" runat="server" class="form-control">
                </asp:TextBox>
            </div>
            <div class="col-10">
                Descrição:
                <asp:TextBox ID="txbDescricaoCidA2" runat="server" class="form-control" ReadOnly="False">
                </asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-2">
                CID:Associado 3
                <asp:TextBox ID="txbcidA3" runat="server" class="form-control">
                </asp:TextBox>
            </div>
            <div class="col-10">
                Descrição:
                <asp:TextBox ID="txbDescricaoCidA3" runat="server" class="form-control" ReadOnly="False">
                </asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-2">
                CID:Causa Externa
                <asp:TextBox ID="txbcidCausaEx" runat="server" class="form-control">
                </asp:TextBox>
            </div>
            <div class="col-10">
                Descrição:
                <asp:TextBox ID="txbDescricaoCidCausaEx" runat="server" class="form-control" ReadOnly="False">
                </asp:TextBox>
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-6">
                <div class="nav justify-content-center m-2">
                    <asp:Button ID="btnFinalizar" runat="server" class="btn btn-success" Text="Atualizar"
                        OnClick="btnFinalizar_Click" Width="130px" />
                </div>
            </div>
            <div class="col-6">
                <div class="nav justify-content-center m-2">
                    <asp:Button ID="btnCadastrarObito" runat="server" class="btn btn-primary" Text="Proximo/Obito"
                        OnClick="btnCadastrarObito_Click" Height="35px" Width="130px" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
