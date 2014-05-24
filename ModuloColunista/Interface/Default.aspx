<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="colunista/js/jquery-1.9.1.min.js"></script>
    <script src="colunista/js/kendo.all.min.js"></script>
    <script src="colunista/js/default.js"></script>

    <link href="colunista/css/estilo.css" rel="stylesheet" type="text/css" />
    <link href="colunista/kendo/styles/kendo.common.min.css" rel="stylesheet" />
    <link href="colunista/kendo/styles/kendo.default.min.css" rel="stylesheet" />
    <link href="colunista/css/kendo.default.min.css" rel="stylesheet" />
    <link href="colunista/css/colunistas.css" rel="stylesheet" />
    <script src="colunista/admin/js/Objetos.js"></script>
    <script type="text/javascript" src="colunista/js/index.js"></script>
    <script src="colunista/admin/js/Utils.js"></script>



    <div id="defTudo">
        <div id="defColEsq">
            <div id="defForum"></div>
            <div id="defSepForCol"></div>
            <div id="defColunas">

         <script type="text/x-kendo-tmpl" id="templatePostagem">
                    
             
           <div class="postagem_integracao">
                   <span id="conteudoPostagem"><label> #:Titulo# </label> </span>
           </div>



            </div>



        </script>
               
                <label><br /><br />&nbsp;&nbsp;&nbsp;<b>Últimas publicações:</b></label>
                
                <div id="ListaPostagens">
                    
                </div>

                <div id="banner_chamada_colunistas">
                    <a href="Colunista.aspx"><img src="colunista/images/banner_colunistas.jpg" /></a>
                </div>

            </div>


        </div>
        <div id="defColDir">
            <div id="defSepPerf"></div>
            <div id="defPerfil">
                <asp:TextBox ID="txtDefBuscaPerfil" runat="server" Width="300px" OnTextChanged="txtDefBuscaPerfil_TextChanged"></asp:TextBox>
                <br />
                <br />
                <div id="teste" runat="server">
                </div>



            </div>
        </div>
    </div>
</asp:Content>
