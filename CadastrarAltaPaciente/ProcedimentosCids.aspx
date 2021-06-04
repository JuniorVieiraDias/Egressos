<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ProcedimentosCids.aspx.cs" Inherits="CadastrarAltaPaciente_ProcedimentosCids"
    Title="Untitled Page" %>

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

    <script type="text/javascript">
            $(document).ready(function() {
                $("#<%= txbcid.ClientID %>").autocomplete({
                    source: function(request, response) {
                    var param = { cid: $('#<%= txbcid.ClientID %>').val() };
                        $.ajax({
                            url: "ProcedimentosCids.aspx/getCid",
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
                        $("[id$=txbDescricao").val(i.item.name);
                    },
                    minLength: 1 //This is the Char length of inputTextBox    
                });
            });  
    </script>

    <!-- teste Procedmento-->

    <script type="text/javascript">
            $(document).ready(function() {
                $("#<%= txtCodigoProcedimento.ClientID %>").autocomplete({
                    source: function(request, response) {
                    var param = { procCir: $('#<%= txtCodigoProcedimento.ClientID %>').val() };
                        $.ajax({
                            url: "ProcedimentosCids.aspx/getProcCir",
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
                        $("[id$=txtDescProcedimento").val(i.item.name);
                    },
                    minLength: 1 //This is the Char length of inputTextBox    
                });
            });  
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <div class="row">
            <div class="col-2">
                <asp:Label ID="Label2" class="control-label" runat="server" Text="Nº Internação:"></asp:Label>
            </div>
            <div class="col-2">
                <asp:Label ID="Label9" class="control-label" runat="server" Text="Paciente"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-2">
                <asp:TextBox ID="txtSeqPaciente" runat="server" class="form-control" ReadOnly="True"></asp:TextBox>
                <!-- required serve para deixar o campo Obrigatório-->
            </div>
            <div class="col-6">
                <asp:TextBox ID="txtNomePaciente" runat="server" class="form-control" ReadOnly="True"></asp:TextBox>
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-2">
                <asp:Label ID="Label4" class="control-label" runat="server" Text="Procedimento:"></asp:Label>
            </div>
            <div class="col-4">
                <asp:Label ID="Label5" class="control-label" runat="server" Text="Descrição"></asp:Label>
            </div>
            <div class="col-2">
                <asp:Label ID="Label6" class="control-label" runat="server" Text="Data Cirurgia"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-2">
                <asp:TextBox ID="txtCodigoProcedimento" runat="server" class="form-control">
                </asp:TextBox>
            </div>
            <div class="col-4">
                <asp:TextBox ID="txtDescProcedimento" runat="server" class="form-control" ReadOnly="True">
                </asp:TextBox>
            </div>
            <div class="col-2">
                <asp:TextBox ID="txtDtCirurgia" runat="server" class="form-control">
                </asp:TextBox>
            </div>
            <div class="col-1">
                <asp:Button ID="btnPesquisarProcedimento" runat="server" Text="Gravar" class="btn btn-success"
                    OnClick="btnPesquisarProcedimento_Click" UseSubmitBehavior="False" />
            </div>
            <%--<div class="col-1">
                <asp:TextBox ID="txtRemoveProcedimento" runat="server"></asp:TextBox>
            </div>--%>
            <div class="col-1">
                <!-- botao aqui-->
            </div>
        </div>
        <div id="GridProcedimentos">
            <asp:GridView ID="gvProcedimento" AutoGenerateColumns="False" DataKeyNames="Id" runat="server"
                OnRowCommand="grdProcedimentoCir_RowCommand" ForeColor="#333333" CssClass="table table-sm table-striped table-bordered">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Código" SortExpression="Id" ItemStyle-CssClass="hidden-xs"
                        HeaderStyle-CssClass="hidden-xs" />
                    <asp:BoundField DataField="Nr_Seq" HeaderText="Internação" SortExpression="Nr_Seq"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                    <asp:BoundField DataField="Cod_Procedimento" HeaderText="Procedimento" SortExpression="cod_procedimento"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                    <asp:BoundField DataField="Data_Cir" HeaderText="Data Cirurgia" SortExpression="data_cir"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                    <asp:BoundField DataField="Nome_Funcionario_Cadastrou" HeaderText="Usuário" SortExpression="Usuario"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                    <asp:TemplateField HeaderStyle-CssClass="sorting_disabled" HeaderText="Ações">
                        <ItemTemplate>
                            <div class="form-inline">
                                <asp:LinkButton ID="lbDeleta" CommandName="deletaProcedimento" CommandArgument='<%#((GridViewRow)Container).RowIndex%>'
                                    CssClass="btn btn-danger" runat="server">
                                <i class="fa fa-trash-o" title="Excluir"></i> 
                                </asp:LinkButton>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <!-- Fim aqui o procedimento-->
        <hr />
        <!-- bloco cadastrar cid-->
        <div class="row">
            <div class="col-2">
                <asp:Label ID="lbCID" class="control-label" runat="server" Text="CID:"></asp:Label>
            </div>
            <div class="col-3">
                <asp:Label ID="Label1" class="control-label" runat="server" Text="Descrição"></asp:Label>
            </div>
            <%--<div class="col-2">
            <asp:Label ID="Label6" class="control-label" runat="server" Text="TIPO (primario, secundário, terciário)"></asp:Label>
        </div>--%>
        </div>
        <div class="row">
            <div class="col-2">
                <asp:TextBox ID="txbcid" runat="server" class="form-control">
                </asp:TextBox>
            </div>
            <div class="col-4">
                <asp:TextBox ID="txbDescricao" runat="server" class="form-control" ReadOnly="True">
                </asp:TextBox>
            </div>
            <div class="col-2">
                <asp:DropDownList ID="DDLTipoCid" runat="server" class="form-control">
                    <asp:ListItem>Primario</asp:ListItem>
                    <asp:ListItem>Secundario</asp:ListItem>
                    <asp:ListItem>Associado 1</asp:ListItem>
                    <asp:ListItem>Associado 2</asp:ListItem>
                    <asp:ListItem>Associado 3</asp:ListItem>
                    <asp:ListItem>Causa Externa</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="col-1">
                <asp:Button ID="pesquisarCid" runat="server" Text="Gravar" OnClick="GravarCid_Click"
                    class="btn btn-success" />
            </div>
        </div>
        <!--</div>-->
        <div id="gridCirurgias">
            <asp:GridView ID="gvListaCID" AutoGenerateColumns="False" DataKeyNames="Id" runat="server"
                OnRowCommand="grdMain_RowCommand" ForeColor="#333333" CssClass="table table-sm table-striped table-bordered">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Código" SortExpression="Id" ItemStyle-CssClass="hidden-xs"
                        HeaderStyle-CssClass="hidden-xs" />
                    <asp:BoundField DataField="Nr_Seq" HeaderText="Internação" SortExpression="Nr_Seq"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                    <asp:BoundField DataField="Cod_Cid" HeaderText="Cid" SortExpression="Cod_Cid" ItemStyle-CssClass="hidden-xs"
                        HeaderStyle-CssClass="hidden-xs" />
                    <asp:BoundField DataField="Tipo" HeaderText="Tipo" SortExpression="Tipo" ItemStyle-CssClass="hidden-xs"
                        HeaderStyle-CssClass="hidden-xs" />
                    <asp:BoundField DataField="Usuario" HeaderText="Usuário" SortExpression="Usuario"
                        ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs" />
                    <asp:TemplateField HeaderStyle-CssClass="sorting_disabled" HeaderText="Ações">
                        <ItemTemplate>
                            <div class="form-inline">
                                <asp:LinkButton ID="lbDeleta" CommandName="deletaCid" CommandArgument='<%#((GridViewRow)Container).RowIndex%>'
                                    CssClass="btn btn-danger" runat="server">
                                                    <i class="fa fa-trash-o" title="Excluir"></i> 
                                </asp:LinkButton>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <hr />
        <div class="row">
            <div class="col-5">
                <div class="nav justify-content-center m-2">
                    <asp:Button ID="btnFinalizar" runat="server" class="btn btn-success" 
                        Text="Finalizar" onclick="btnFinalizar_Click" />
                </div>
            </div>
            <div class="col-5">
                <div class="nav justify-content-center m-2">
                    <asp:Button ID="btnCadastrarObito" runat="server" class="btn btn-primary" 
                        Text="Obito" onclick="btnCadastrarObito_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
