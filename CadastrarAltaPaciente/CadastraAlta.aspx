<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="CadastraAlta.aspx.cs" Inherits="CadastrarAltaPaciente_CadastraAlta"
    Title="Cadastar Alta Paciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        input
        {
            text-align: left;
        }
    </style>
    <!-- Font Awesome -->
    <link href="../vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet" />

    <script src='<%= ResolveUrl("https://cdnjs.cloudflare.com/ajax/libs/jquery/2.2.4/jquery.js") %>'
        type="text/javascript"></script>

    <script src='<%= ResolveUrl("https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.11/jquery.mask.js") %>'
        type="text/javascript"></script>
     
    
    <script type="text/javascript" src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.22/jquery-ui.js"></script>

    <link rel="Stylesheet" href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.10/themes/redmond/jquery-ui.css" />
        
        <script type="text/javascript">
            $(document).ready(function() {
                $("#<%= txbcid.ClientID %>").autocomplete({
                    source: function(request, response) {
                    var param = { cid: $('#<%= txbcid.ClientID %>').val() };
                        $.ajax({
                            url: "CadastraAlta.aspx/getCid",
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

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
                 $('#<%=txtDtNasc.ClientID %>').mask("99/99/9999");   
                 $('#<%= txtDtEntrada.ClientID %>').mask("99/99/9999");              
                 $('#<%=txtDtSaida.ClientID %>').mask("99/99/9999");                
                 $('#<%=txtDtCirurgia.ClientID %>').mask("99/99/9999"); 
    </script>

    <div class="jumbotron">
        <!-- Form alinhado -->
        <%--<div class="row">
            <asp:Label ID="Label4" class="form-label" runat="server" Text="Digite RH:"></asp:Label>
            <div class="col-sm-2">
                <asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox>
            </div>
            <asp:Button ID="Button3" class="btn btn-success" runat="server" Text="Pesquisar" />
        </div>--%>
        <!-- Fim -->
        <!-- <div class="p-3 mb-2 bg-light text-dark"> -->
        <!-- <div class="shadow p-3 mb-5 bg-white rounded"> -->
        <div class="row">
            <div class="col-2">
                <asp:Label ID="Label2" class="control-label" runat="server" Text="Digite Nº Internação:"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-2">
                <asp:TextBox ID="txtSeqPaciente" runat="server" class="form-control" required></asp:TextBox>
                <!-- required serve para deixar o campo Obrigatório-->
            </div>
        </div>
        <div class="row">
            <div class="col-6">
                <!-- <div class="col-6"> define a largura da coluna -->
                <asp:Label ID="Label" class="control-label" runat="server" Text="Nome:"></asp:Label>
                <asp:TextBox ID="txtNome" runat="server" class="form-control " ReadOnly="True"></asp:TextBox>
            </div>
            <div class="col-2">
                <asp:Label ID="Label3" runat="server" class="control-label" Text="Data Nascimento:"></asp:Label>
                <asp:TextBox ID="txtDtNasc" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-2">
                <asp:Label ID="Label7" runat="server" class="control-label" Text="Sexo"></asp:Label>
                <asp:TextBox ID="txtSexo" runat="server" class="form-control"></asp:TextBox>
                <%--<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>--%>
            </div>
        </div>
        <div class="row">
            <div class="col-2">
                Data Entrada:
                <asp:TextBox ID="txtDtEntrada" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-2">
                Data Saida
                <asp:TextBox ID="txtDtSaida" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-2">
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
                <asp:TextBox ID="TxtH_D" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-3">
                <asp:Label ID="Label8" runat="server" class="control-label" Text="Descrição:"></asp:Label>
                <asp:TextBox ID="txtDescricao" runat="server" class="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-4">
                Clinica:
                <asp:TextBox ID="txtClinica" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-2">
                Leito:
                <asp:TextBox ID="txtLeito" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-1">
                Enf. Leito:
                <asp:TextBox ID="txtEnfLeito" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-4">
                Clinica Alta:
                <asp:DropDownList ID="DDLClinicaAlta" runat="server" class="form-control" DataSourceID="SqlDataSource2"
                    DataTextField="descricao" DataValueField="idClinica">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:EgressosConnectionString %>"
                    SelectCommand="SELECT [descricao], [idClinica] FROM [clinicaAlta] ORDER BY [descricao]">
                </asp:SqlDataSource>
            </div>
        </div>
        <!-- fazer aqui o procedimento-->
        <hr />
        <div class="row">
            <div class="col-1">
                <asp:Label ID="Label4" class="control-label" runat="server" Text="Procedimento:"></asp:Label>
            </div>
            <div class="col-2">
                <asp:Label ID="Label5" class="control-label" runat="server" Text="Data Cirurgia"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-1">
                <asp:TextBox ID="txtCodigoProcedimento" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-2">
                <asp:TextBox ID="txtDtCirurgia" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-1">
                <asp:Button ID="btnPesquisarProcedimento" runat="server" Text="Pesquisar" class="btn btn-success"
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
            <div class="col-1">
                <asp:Label ID="lbCID" class="control-label" runat="server" Text="CID:"></asp:Label>
            </div>
            <div class="col-3">
                <asp:Label ID="Label1" class="control-label" runat="server" Text="Descrição"></asp:Label>
            </div>
            <div class="col-2">
                <asp:Label ID="Label6" class="control-label" runat="server" Text="TIPO (primario, secundário, terciário)"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-1">
                <asp:TextBox ID="txbcid" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-3">
                <asp:TextBox ID="txbDescricao" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-2">
                <asp:TextBox ID="txtDtCir_1" runat="server" class="form-control"></asp:TextBox>
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
        <!--Button CADASTRAR-->
        <div class="nav justify-content-center m-2">
            <asp:Button ID="btnCadastrar" runat="server" class="btn btn-primary" Text="Cadastrar"
                OnClick="Button2_Click" />
        </div>
    </div>
</asp:Content>
