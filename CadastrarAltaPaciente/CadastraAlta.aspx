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

    

    <!-- fim do teste Procedimento-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
                 $('#<%=txtDtNasc.ClientID %>').mask("99/99/9999");   
                 $('#<%= txtDtEntrada.ClientID %>').mask("99/99/9999");              
                 $('#<%=txtDtSaida.ClientID %>').mask("99/99/9999");                
               
                
    </script>

    <!-- <div class="jumbotron">-->
    <div class="container">
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
                <asp:Label ID="Label2" class="control-label" runat="server" Text="Nº Internação:"></asp:Label>
            </div>
            <div class="col-2">
                <asp:Label ID="Label9" class="control-label" runat="server" Text="Nº RH"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-2">
                <asp:TextBox ID="txtSeqPaciente" runat="server" class="form-control" required>
                </asp:TextBox>
                <!-- required serve para deixar o campo Obrigatório-->
            </div>
            
            <div class="col-2">
                <asp:TextBox ID="txtRhProntuario" runat="server" class="form-control" ReadOnly="True"></asp:TextBox>
            
            </div>
            
        </div>
        <div class="row">
            <div class="col-6">
                <!-- <div class="col-6"> define a largura da coluna -->
                <asp:Label ID="Label" class="control-label" runat="server" Text="Nome:"></asp:Label>
                <asp:TextBox ID="txtNome" runat="server" class="form-control " ReadOnly="True">
                </asp:TextBox>
            </div>
            <div class="col-2">
                <asp:Label ID="Label3" runat="server" class="control-label" Text="Data Nascimento:"></asp:Label>
                <asp:TextBox ID="txtDtNasc" runat="server" class="form-control" required>
                </asp:TextBox>
            </div>
            <div class="col-2">
                <asp:Label ID="Label7" runat="server" class="control-label" Text="Sexo"></asp:Label>
                <asp:TextBox ID="txtSexo" runat="server" class="form-control" ReadOnly="True"></asp:TextBox>
                <%--<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>--%>
            </div>
        </div>
        <div class="row">
            <div class="col-2">
                Data Entrada:
                <asp:TextBox ID="txtDtEntrada" runat="server" class="form-control" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="col-2">
                Data Saida
                <asp:TextBox ID="txtDtSaida" runat="server" class="form-control" ReadOnly="True"></asp:TextBox>
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
            <div class="col-2">
                H.D:
                <asp:TextBox ID="TxtH_D" runat="server" class="form-control" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="col-4">
                <asp:Label ID="Label8" runat="server" class="control-label" Text="Descrição:"></asp:Label>
                <asp:TextBox ID="txtDescricao" runat="server" class="form-control" ReadOnly="True"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-4">
                Clinica:
                <asp:TextBox ID="txtClinica" runat="server" class="form-control" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="col-2">
                Leito:
                <asp:TextBox ID="txtLeito" runat="server" class="form-control" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="col-2">
                Enf. Leito:
                <asp:TextBox ID="txtEnfLeito" runat="server" class="form-control" ReadOnly="True"></asp:TextBox>
            </div>
            <div class="col-4">
                Clinica Alta:
                <asp:DropDownList ID="DDLClinicaAlta" runat="server" class="form-control"
                    DataSourceID="SqlDataSource2" DataTextField="descricao" 
                    DataValueField="idClinica">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:EgressosConnectionString3 %>" 
                    SelectCommand="SELECT [idClinica], [descricao] FROM [clinicaAlta]">
                </asp:SqlDataSource>
            </div>
        </div>
        <!-- fazer aqui o procedimento-->
        <hr />
        
        <hr />
        <!--Button CADASTRAR-->
        <div class="nav justify-content-center m-2">
            <asp:Button ID="btnCadastrar" runat="server" class="btn btn-primary" Text="Cadastrar"
                OnClick="Button2_Click" />
        </div>
    </div>
</asp:Content>
