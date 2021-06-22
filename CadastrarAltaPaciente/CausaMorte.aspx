<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="CausaMorte.aspx.cs" Inherits="CausaMorte" Title="Causa da Morte" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        input
        {
            text-align: left;
        }
    </style>
    <!-- Font Awesome -->
    <link href="../vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet" />    

    <script src="../js/jquery.js" type="text/javascript"></script>
    <!-- <script src='<%= ResolveUrl("https://cdnjs.cloudflare.com/ajax/libs/jquery/2.2.4/jquery.js") %>'
        type="text/javascript"></script>-->

    <script src="../js/jquery.mask.js" type="text/javascript"></script>

    <!--<script src='<%= ResolveUrl("https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.11/jquery.mask.js") %>'
        type="text/javascript"></script>-->
    <!-- copiar o link abrir no navegador, copiar o conteudo da pagina, depois criar uma pasta js clicar em add new item escolher javascrip dar o nome jquery-ui.js e arrastar para aqui-->

    <script src="../js/jquery-ui.js" type="text/javascript"></script>

    <!-- <script type="text/javascript" src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.22/jquery-ui.js"></script>-->
    <!-- copiar o link abrir no navegador, copiar o conteudo da pagina, depois criar uma pasta js clicar em add new item escolher style sheet dar o nome jquery-ui.css e arrastar para aqui-->
    <link href="../js/jquery-ui.css" rel="stylesheet" type="text/css" />
    <!-- <link rel="Stylesheet" href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.10/themes/redmond/jquery-ui.css" />-->
    <!-- txtCausaDaMorteA  Precisa ser refatorada mas ainda não sei como-->
    <!--Todo Do: Fazer a mesma função em javaScript ser usada em todos os campos que chamam o metodo carregar cid-->
    <!-- causadamorteA-->

    <script type="text/javascript">
        $(document).ready(function() {
            $("#<%= txtCausaMorteA.ClientID %>").autocomplete({
                source: function(request, response) {
                    var param = { cid: $('#<%= txtCausaMorteA.ClientID %>').val() };
                    $.ajax({
                        url: "CausaMorte.aspx/getCid",
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
                    $("[id$=txtDescricaoCausaMorteA").val(i.item.name);
                },
                minLength: 1 //This is the Char length of inputTextBox    
            });
        });  
    </script>

    <!-- causadamorteB-->

    <script type="text/javascript">
        $(document).ready(function() {
            $("#<%= txtCausaMorteB.ClientID %>").autocomplete({
                source: function(request, response) {
                    var param = { cid: $('#<%= txtCausaMorteB.ClientID %>').val() };
                    $.ajax({
                        url: "CausaMorte.aspx/getCid",
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
                    $("[id$=txtDescricaoCausaMorteB").val(i.item.name);
                },
                minLength: 1 //This is the Char length of inputTextBox    
            });
        });  
    </script>

    <!-- causaDaMorteC-->

    <script type="text/javascript">
        $(document).ready(function() {
            $("#<%= txtCausaMorteC.ClientID %>").autocomplete({
                source: function(request, response) {
                    var param = { cid: $('#<%= txtCausaMorteC.ClientID %>').val() };
                    $.ajax({
                        url: "CausaMorte.aspx/getCid",
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
                    $("[id$=txtDescricaoCausaMorteC").val(i.item.name);
                },
                minLength: 1 //This is the Char length of inputTextBox    
            });
        });  
    </script>

    <!-- causaDaMorteD-->

    <script type="text/javascript">
        $(document).ready(function() {
            $("#<%= txtCausaMorteD.ClientID %>").autocomplete({
                source: function(request, response) {
                    var param = { cid: $('#<%= txtCausaMorteD.ClientID %>').val() };
                    $.ajax({
                        url: "CausaMorte.aspx/getCid",
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
                    $("[id$=txtDescricaoCausaMorteD").val(i.item.name);
                },
                minLength: 1 //This is the Char length of inputTextBox    
            });
        });  
    </script>

    <!-- txtCausaMorteParte2A-->

    <script type="text/javascript">
        $(document).ready(function() {
            $("#<%= txtCausaMorteParte2A.ClientID %>").autocomplete({
                source: function(request, response) {
                    var param = { cid: $('#<%= txtCausaMorteParte2A.ClientID %>').val() };
                    $.ajax({
                        url: "CausaMorte.aspx/getCid",
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
                    $("[id$=txtDescricaoCausaMorteParte2A").val(i.item.name);
                },
                minLength: 1 //This is the Char length of inputTextBox    
            });
        });  
    </script>

    <!-- txtCausaMorteParte2B-->

    <script type="text/javascript">
        $(document).ready(function() {
            $("#<%= txtCausaMorteParte2B.ClientID %>").autocomplete({
                source: function(request, response) {
                    var param = { cid: $('#<%= txtCausaMorteParte2B.ClientID %>').val() };
                    $.ajax({
                        url: "CausaMorte.aspx/getCid",
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
                    $("[id$=txtDescricaoCausaMorteParte2B").val(i.item.name);
                },
                minLength: 1 //This is the Char length of inputTextBox    
            });
        });  
    </script>

    <!-- Causa Provavel Obito-->

    <script type="text/javascript">
        $(document).ready(function() {
            $("#<%= txtCausaProvObito.ClientID %>").autocomplete({
                source: function(request, response) {
                    var param = { cid: $('#<%= txtCausaProvObito.ClientID %>').val() };
                    $.ajax({
                        url: "CausaMorte.aspx/getCid",
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
                    $("[id$=txtDescricaoCausaProvObito").val(i.item.name);
                },
                minLength: 1 //This is the Char length of inputTextBox    
            });
        });  
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
     <asp:ScriptManager ID="ScriptManager1"
                EnablePartialRendering="true"
                runat="server">
            </asp:ScriptManager>
        <h4 class="text-center">
            Causa da Morte</h4>
        <asp:Label ID="pegaNomeLoginUsuario" runat="server" Text="" Visible="False"></asp:Label>
        <div class="row-cols-1">
            <h6>
                Parte I</h6>
        </div>
        <div class="row">
            <div class="col-2">
                <asp:TextBox ID="txtSeqPaciente" runat="server" class="form-control" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="col-6">
                <asp:TextBox ID="txtNomePaciente" runat="server" class="form-control" ReadOnly="True"></asp:TextBox>
            </div>
        </div>
        <!--Causa da Morte-->
        <div class="row">
            <div class="col-2">
                A:
                <asp:TextBox ID="txtCausaMorteA" runat="server" class="form-control" required></asp:TextBox>
            </div>
            <div class="col-6">
                <asp:Label ID="Label13" runat="server" Text="Descrição"></asp:Label>
                <asp:TextBox ID="txtDescricaoCausaMorteA" runat="server" class="form-control" 
                    ReadOnly="True"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-2">
                B:
                <asp:TextBox ID="txtCausaMorteB" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-6">
                <asp:Label ID="Label14" runat="server" Text="Descrição"></asp:Label>
                <asp:TextBox ID="txtDescricaoCausaMorteB" runat="server" class="form-control" 
                    ReadOnly="True"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-2">
                C:
                <asp:TextBox ID="txtCausaMorteC" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-6">
                <asp:Label ID="Label15" runat="server" Text="Descrição"></asp:Label>
                <asp:TextBox ID="txtDescricaoCausaMorteC" runat="server" class="form-control" 
                    ReadOnly="True"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-2">
                D:
                <asp:TextBox ID="txtCausaMorteD" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-6">
                <asp:Label ID="Label16" runat="server" Text="Descrição"></asp:Label>
                <asp:TextBox ID="txtDescricaoCausaMorteD" runat="server" class="form-control" 
                    ReadOnly="True"></asp:TextBox>
            </div>
        </div>
        <div class="row-cols-1">
            <h6>
                Parte II</h6>
        </div>
        <div class="row">
            <div class="col-2">
                A:
                <asp:TextBox ID="txtCausaMorteParte2A" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-6">
                <asp:Label ID="Label17" runat="server" Text="Descrição"></asp:Label>
                <asp:TextBox ID="txtDescricaoCausaMorteParte2A" runat="server" 
                    class="form-control" ReadOnly="True"></asp:TextBox>
            </div>
        </div>
        <div class="row mb-2">
            <div class="col-2">
                B:
                <asp:TextBox ID="txtCausaMorteParte2B" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-6">
                <asp:Label ID="Label18" runat="server" Text="Descrição"></asp:Label>
                <asp:TextBox ID="txtDescricaoCausaMorteParte2B" runat="server" 
                    class="form-control" ReadOnly="True"></asp:TextBox>
            </div>
        </div>
        <div class="row mb-2">
            <div class="col-3">
                ENCAMINHAMENTO DO CADÁVER:
            </div>
            <div class="col-2">
                <asp:DropDownList ID="DDLencaminhamentoCadaver" runat="server" class="form-control">
                    <asp:ListItem>Bem definido</asp:ListItem>
                    <asp:ListItem>IML</asp:ListItem>
                    <asp:ListItem>SVO</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
            <div class="col-2">
                <asp:Label ID="Label2" class="control-label" runat="server" Text="CAUSA PROV. ÓBITO:"></asp:Label>
            </div>
            <div class="col-3">
                <asp:Label ID="Label9" class="control-label" runat="server" Text="DESC. CAUSA PROV. ÓBITO:"></asp:Label>
            </div>
        </div>
        <div class="row mb-2">
            <div class="col-2">
                <asp:TextBox ID="txtCausaProvObito" runat="server" class="form-control"></asp:TextBox>
            </div>
           
            <div class="col-6">
                <asp:TextBox ID="txtDescricaoCausaProvObito" runat="server" 
                    class="form-control" ReadOnly="True"></asp:TextBox>
            </div>
        </div>
        <div class="row mb-2">
          <div class="col-2">
                <asp:Label ID="Label1" class="control-label" runat="server" Text="OBSERVAÇÃO:"></asp:Label>
            </div>
        </div>
        <div class="row mb-2">
                    <div class="col-8">
                <asp:TextBox ID="txtObservacaoCausaObito" runat="server" class="form-control"></asp:TextBox>
            </div>
        </div>
        <!--Button CADASTRAR-->
        <div class="nav justify-content-center m-2">
            <asp:Button ID="btnCadastrarCausaMorte" runat="server" class="btn btn-primary" Text="Cadastrar"
                OnClick="btnCadastrarCausaMorte_Click" />
        </div>
    </div>
</asp:Content>
