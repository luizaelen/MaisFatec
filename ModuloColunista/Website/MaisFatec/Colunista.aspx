<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Colunista.aspx.cs" Inherits="Colunista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="colunista/css/estilo.css" rel="stylesheet" type="text/css" />
        
    <link href="colunista/kendo/styles/kendo.common.min.css" rel="stylesheet" />
    <link href="colunista/kendo/styles/kendo.default.min.css" rel="stylesheet" />
    <link href="colunista/css/kendo.default.min.css" rel="stylesheet" />

    <link href="colunista/css/colunistas.css" rel="stylesheet" />
    <script type="text/javascript" src="colunista/js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="colunista/js/kendo.all.min.js"></script>
    <script  type ="text/javascript" src="colunista/js/index.js"></script>

        <!-- barra de título do módulo e área de pesquisa !-->
    <div id="mod_pesq">
    	<div id="modulo">
   	    	<div id="nome_modulo" title="Você está no módulo: Temas"><label>Temas</label></div>
            <div id="texto_modulo"></div>
        </div>

        <div id="pesquisa" title="Campo de pesquisa">
        	<form action="" method="get">
            	<label>Filtrar: &nbsp;</label><input name="" type="text" title="Digite aqui o que procura" placeholder ="Filtrar postagens..." onkeyup="filtrar(this.value)"/>
         <!--   	<button type="submit">Buscar</button>-->
            </form>
        </div>

    </div>
    <!-- barra de título do módulo e área de pesquisa !-->

    <!-- conteudo principal !-->
    <div id="content">

            <div id="menu_temas"></div> 

            <div id="ultimas_postagens" title="Últimas publicações dos Colunistas"><!-- POSTAGENS !-->

                <div id="listPostagem"></div>
                <div id="pagerPostagem" class="k-pager-wrap"></div>

           	</div><!-- FIM POSTAGENS !-->


            <div id="fotos_colunistas" title="Conheça os colunistas do Mais Fatec">
            	
                <div id="example" class="k-content" style="width:255px;">

    <div class="k-dropzone-hovered">
        <div id="listView"></div>
        <div id="pager" class="k-pager-wrap"></div>
    </div>
    <div id="window" style="display:none">
        <div id ="conteudoPostagem"></div>
    </div>
    <script type="text/x-kendo-tmpl" id="template">
                    <div class="product">
                        <img src="${Foto}" />
                        <h3>#:Nome#</h3>
                        <p>#:Tema#</p>
                    </div>
                </script>

   <script type="text/x-kendo-tmpl" id="templateTema">
                <div class="temas" Title="#:Nome#">  <label>#:Nome#</label></div>

            </div>
        </script>
                <script type="text/x-kendo-tmpl" id="templatePostagem">
                    <div class="postagem">
                   <span id="conteudoPostagem"><label> #:Titulo# </label> </span>
                    </div>

            </div>
        </script>



    </div>

            </div>

    </div>
    <!-- conteudo principal !-->
</asp:Content>

