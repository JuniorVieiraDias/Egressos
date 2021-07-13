<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Permissao.aspx.cs" Inherits="Restrito_Permissao" Title="EGRESSOS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <!-- iCheck -->
    <link href="../vendors/iCheck/skins/flat/green.css" rel="stylesheet" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- page content -->
    <div class="container">
    <div class="x_title">
        <h3>
            Cadastro de Permissões de Usuários</h3>
        <div class="clearfix">
        </div>
    </div>
    <div class="x_content">
        <div class="row">
            <div class="col-md-6 col-sm-12 col-xs-12 form-group">
                <label>
                    Nome <span class="required">*</span></label>
                <asp:DropDownList ID="DropDownList1" class="form-control" runat="server"
                    AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
        </div>
        <div class="row">
        <div >
                           <label>Permissões <span class="required">*</span></label>
        </div>
        </div>
        
        <div class="row">
            <div class="col-md-6 col-sm-12 col-xs-12 form-group">
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged"
                    RepeatLayout="Flow" CssClass="flat">
                </asp:CheckBoxList>
                 </div>
        </div>
        <div class="row">
        <div class="form-group">
            <div class="col-md-9 col-sm-9 col-xs-12">
                <asp:Button ID="btnCad" runat="server" Text="Cadastrar" class="btn btn-primary" OnClick="btnCad_Click" /></td>
            </div>
        </div>
        </div>
    </div>
    </div>
</asp:Content>
