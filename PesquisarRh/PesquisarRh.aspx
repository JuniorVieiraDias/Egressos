<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="PesquisarRh.aspx.cs" Inherits="PesquisarRh" Title="EGRESSOS-PESQUISA-RH" %>

<script runat="server">
   
  
</script>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   <%-- <link href="bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />--%>
    <link href="../bootstrap/css/bootstrap.css" rel="stylesheet" type="text/css" />

    <%--<script src='<%= ResolveUrl("https://cdnjs.cloudflare.com/ajax/libs/jquery/2.2.4/jquery.min.js") %>'
        type="text/javascript"></script>--%>

    <script src="../js/jquery.js" type="text/javascript"></script>

    <script src="../js/jquery.mask.js" type="text/javascript"></script>

    <%--<script src='<%= ResolveUrl("https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.11/jquery.mask.min.js") %>'
        type="text/javascript"></script>--%>

    <style type="text/css">
        .table
        {
            width: 100%;
            white-space: nowrap;
        }
    </style>
    <%--    <script type="text/javascript">
 
    alert("Teste Jquery")    
 
    </script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="jumbotron">
        <div class="row">
            <div class="col-2">
                Digite o RH do Paciente:
            </div>
            <div class="col-1">
                RH:
                <asp:TextBox ID="rh_Paciente" runat="server" class="form-control"></asp:TextBox>
            </div>
            <div class="col-2">
                <asp:Label ID="Label1" runat="server" class="control-label" Text=""></asp:Label>
                <input id="btnPesquisar" type="button" onclick="gerarTabela()" class="btn btn-success"
                    value="Pesquisar" />
            </div>
        </div>
    </div>
    <%--Ó que estva aqui para baixo joguei um bloco de notas--%>
    <div class="container">
    </div>
    <div class="clearfix">
        <table id="tdata1" runat="server" class="table">
            <thead class="thead-dark">
                <tr>
                    <th>
                        Prontuario
                    </th>
                    <th>
                        Nome
                    </th>
                    <th>
                        dt_internacao
                    </th>
                    <th>
                        Ação
                    </th>
                </tr>
            </thead>
            <tbody id="tdata">
            </tbody>
        </table>
    </div>

    <script type="text/javascript">
    
//        $("#dtIni, #dtFim").mask("00/00/0000");
        
        function gerarTabela() {
            //var rhPaciente = formataData(document.getElementById('<%=rh_Paciente.ClientID %>'));
            var rhPaciente = parseInt(document.getElementById('<%=rh_Paciente.ClientID%>').value);
            //
              debugger;
              $.ajax({
            async: false
                ,url: '<%= ResolveUrl("http://10.48.21.64:5000/hspmsgh-api/internacoes/paciente/'+rhPaciente+'") %>'
                , crossDomain: true
                , type: 'GET'
                , contentType: 'application/json; charset=utf-8'
                , dataType: 'json'
                , success: function(data) {
                                    data.forEach(function(dt) {
                                        $("#<%=tdata1.ClientID%> tbody").append("<tr>" +
                                            "<td>" + dt.cd_prontuario + "</td>" +
                                            "<td>" + dt.nm_paciente + "</td>" +
                                            "<td>" + dt.dt_internacao + "</td>" +                             
                                           "<td> <a href='Default.aspx?prontuario="+dt.cd_prontuario+ "&nomePaciente="+dt.nm_paciente+
                                           "&sexoPaciente="+dt.in_sexo+"&idadePaciente="+dt.nr_idade+"&dataEntrada="+dt.dt_internacao+"'>selecionar</a> </td>" +                                            
                                           
                                         "</tr>"
                                        );
                                    });

                                }
                                , error: function(xhr, er) {
                                    console.log("deu erro");
                                    console.log(er);
                                    $("#lbMsg").html('<p> Erro ' + xhr.staus + ' - ' + xhr.statusText + ' - <br />Tipo de erro:  ' + er + '</p>');
                                }
            });  
        }   

    </script>

</asp:Content>
