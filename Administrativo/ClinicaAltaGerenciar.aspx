<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ClinicaAltaGerenciar.aspx.cs" Inherits="ClinicaAltaGerenciar" Title="Untitled Page" %>

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
                Digite o nome da clinica:
            </div>
            <div class="col-4">                
                <asp:TextBox ID="txtAddClinica" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col">
                <asp:Button ID="CadastrarClinica" runat="server" class="btn btn-success" 
                    Text="Cadastrar" onclick="CadastrarClinica_Click" />
            </div>
        </div>
        
    </div>
</asp:Content>
