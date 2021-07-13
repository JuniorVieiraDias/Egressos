<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Codificado_EXCLUIR.aspx.cs" Inherits="Administrativo_AlterarDadosInternacao_UPDATE_CadastraAlta_UPDATE"
    Title="EGRESSOS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
      
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

  

    <!-- <div class="jumbotron">-->
    <div class="container">
        <h5 class="text-center">
           Exclui internação no sistema EGRESSOS</h5>
        <div class="row">
            <asp:Label ID="pegaNomeLoginUsuario" runat="server" Visible="False"></asp:Label>
        </div>
        <div class="row">
            <div class="col-2">
                Internação
                <asp:TextBox ID="txtSeqPaciente" runat="server" class="form-control" required ReadOnly="True"></asp:TextBox>
                <!-- required serve para deixar o campo Obrigatório-->
            </div>
                     
            
        </div>
            
        <!-- fazer aqui o procedimento-->
        <hr />
        <div class="row">
            <!--Button CADASTRAR-->
            <div class="col-6">
                <div class="nav justify-content-center m-2">
                    <asp:Button ID="btnCadastrar" runat="server" class="btn btn-primary" Text="Excluir"
                        OnClick="btnCadastrar_Click" />
                </div>
            </div>            
        </div>
    </div>
</asp:Content>
