<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="RhPesquisa.aspx.cs" Inherits="RhPesquisa" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        input
        {
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="jumbotron">
        <div class="row">
            <div class="col-2">
                Digite o RH do Paciente:
            </div>
            <div class="col-2">
                <asp:TextBox ID="rh_Paciente" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-2">
                <asp:Label ID="Label1" runat="server" class="control-label" Text=""></asp:Label>
                <asp:Button ID="btnPesquisar" runat="server" class="btn btn-success" Text="Pesquisar"
                    OnClick="btnPesquisar_Click" />
                <%--<input id="btnPesquisar" type="button" onclick="gerarTabela()" class="btn btn-success"
                    value="Pesquisar" />--%>
            </div>
        </div>
    </div>
    <hr />
    <div>
        <asp:GridView ID="GridViewDadosPaciente" AutoGenerateColumns="False" DataKeyNames="nr_seq"
            runat="server" OnRowCommand="grdDadosPacienteSGH_RowCommand" ForeColor="#333333"
            CssClass="table table-sm table-striped table-bordered">
            <Columns>
                <asp:BoundField DataField="nr_seq" HeaderText="Internação" SortExpression="nr_seq"
                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="cd_prontuario" HeaderText="Prontuario" SortExpression="cd_prontuario"
                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="nm_paciente" HeaderText="Nome" SortExpression="nm_paciente"
                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="dt_internacao" HeaderText="Data Internação" SortExpression="dt_internacao"
                    ItemStyle-CssClass="hidden-xs" HeaderStyle-CssClass="hidden-xs">
                    <HeaderStyle CssClass="hidden-xs"></HeaderStyle>
                    <ItemStyle CssClass="hidden-xs"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderStyle-CssClass="sorting_disabled" HeaderText="Ações">
                    <ItemTemplate>
                        <div class="form-inline">
                            <asp:LinkButton ID="lbDadosPaciente" CommandName="deletaProcedimento" CommandArgument='<%#((GridViewRow)Container).RowIndex%>'
                                CssClass="btn alert-info" runat="server"> <!-- Text="Selecionar" -->
                                 Selecionar
                            </asp:LinkButton>
                        </div>
                    </ItemTemplate>
                    <HeaderStyle CssClass="sorting_disabled"></HeaderStyle>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
