<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <br />
    <br />
    <br />
    <br />
    <title>EGRESSOS</title>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <div>
            <div>
                <asp:Image ID="Image1" runat="server" ImageUrl="imagens/HSPM_LOGO.jpg"></asp:Image>
            </div>
            <div>
                <h2>
                    Sistema Egressos - Nepi</h2>
            </div>
        </div>
        <br />
        <br />
        <br />
        <br />
        <asp:Login ID="Login1" runat="server" class="form-control" DestinationPageUrl="CadastrarAltaPaciente/RhPesquisa.aspx">
        </asp:Login>
    </div>
    </form>
</body>
</html>
