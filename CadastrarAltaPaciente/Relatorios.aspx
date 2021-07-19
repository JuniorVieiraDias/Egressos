<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Relatorios.aspx.cs" Inherits="Relatorios_Relatorios" Title="EGRESSOS-RELATORIOS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        input
        {
            text-align: left;
        }
    </style>

    <script src="../js/jquery.js" type="text/javascript"></script>

    <script src="../js/jquery.mask.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        $('#<%=txtDtInicio.ClientID %>').mask("99/99/9999");
        $('#<%= txtDtFim.ClientID %>').mask("99/99/9999"); 
                
    </script>

    <div class="container">
        <div>
            <br />
            <h4 class="text-center">
                Relatórios
            </h4>
        </div>
        <br />
        <div class="row">
            <div class="col-2">
            </div>
            <div class="col-2">
            </div>
            <div class="col-2">
                Data Inicial:
                <asp:TextBox ID="txtDtInicio" runat="server" class="form-control" required></asp:TextBox>
            </div>
            <div class="col-2">
                Data Final:
                <asp:TextBox ID="txtDtFim" runat="server" class="form-control" required></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="nav justify-content-center m-2">
            <asp:Button ID="btnImportar" runat="server" class="btn btn-success" Text="Importar Excel"
                OnClick="btnImportar_Click" />
        </div>
        <asp:GridView ID="GridViewRelTotal" runat="server">
        </asp:GridView>
    </div>
</asp:Content>
