<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="AlterarCadastro.aspx.cs" Inherits="publico_AlterarCadastro" Title="EGRESSOS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <br />
        <br />
        <br />
          <div class="nav justify-content-center m-2">
          <h3>
                Atualização de Login</h3>
                </div>
                
      
        <div class="nav justify-content-center m-2">
         
          
                <div class="row">
            <asp:Label ID="lbMsg" ForeColor="maroon" runat="server" /><br />
            <table cellpadding="3" border="0">
                <tr>
                    <td>
                        Usuário Antigo:
                    </td>
                    <td>
                        <asp:TextBox ID="LoginAntigoTextBox" MaxLength="128" Columns="30" runat="server" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="EmailRequiredValidator" runat="server" ControlToValidate="LoginAntigoTextBox"
                            ForeColor="red" Display="Static" ErrorMessage="Required" />
                    </td>
                </tr>
                <tr>
                    <td>
                        Usuário Novo:
                    </td>
                    <td>
                        <asp:TextBox ID="LoginNovoTextBox" MaxLength="128" Columns="30" runat="server" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="LoginNovoTextBox"
                            ForeColor="red" Display="Static" ErrorMessage="Required" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="UpdateUserButton" Text="Atualizar Login" OnClick="UpdateUserNameButton_OnClick"
                            runat="server" class="btn btn-primary" />
                    </td>
                </tr>
            </table>
            </div>
        </div>
    </div>
</asp:Content>
