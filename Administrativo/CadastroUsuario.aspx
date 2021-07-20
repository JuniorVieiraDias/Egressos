<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="CadastroUsuario.aspx.cs" Inherits="Restrito_CadastroUsuario" Title="EGRESSOS-USUARIOS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
    <br />
    <br />
    <br />
    <br />
    <div class="nav justify-content-center m-2">
        <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" 
            Email="sem@email.com" 
            ContinueDestinationPageUrl="~/Administrativo/Permissao.aspx" 
            FinishDestinationPageUrl="~/Administrativo/Permissao.aspx">
            <WizardSteps>
                <asp:CreateUserWizardStep runat="server">
                </asp:CreateUserWizardStep>
                <asp:CompleteWizardStep runat="server" AllowReturn="False">
                    <ContentTemplate>
                        <table border="0">
                            <tr>
                                <td align="center" colspan="2">
                                    Complete
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Your account has been successfully created.
                                </td>
                            </tr>
                            <tr>
                            <script>
                                window.location = "Permissao.aspx"
                                        </script>
                                <td align="right" colspan="2">
                                    <asp:Button ID="ContinueButton" CssClass="btn btn-success" runat="server" CausesValidation="False"
                                        CommandName="Continue" Text="Continue" ValidationGroup="CreateUserWizard1"/>
                                        
                                        
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:CompleteWizardStep>
            </WizardSteps>
        </asp:CreateUserWizard>
    </div>
    </div>
</asp:Content>
