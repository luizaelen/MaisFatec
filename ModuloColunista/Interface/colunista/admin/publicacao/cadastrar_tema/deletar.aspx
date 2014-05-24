﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="deletar.aspx.cs" Inherits="colunista_admin_publicacao_deletar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Painel de Controle - Publicações</title>

<link href="../../../kendo/styles/kendo.silver.min.css" rel="stylesheet" />
<link href="../../../kendo/styles/kendo.common.min.css" rel="stylesheet" />
<link href="../../../kendo/styles/kendo.common.min.button.css" rel="stylesheet" />
<link href="../../css/toastr.css" rel="stylesheet" />

<link href="../../css/estilo_lista_postagem.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../../js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="../../js/kendo.all.min.js"></script>
    <script type="text/javascript" src="../../js/Plugins/toastr.js"></script>
    <script type="text/javascript" src="../../js/Utils.js"></script>
    <script type="text/javascript" src="../../js/Colecao.js"></script>
    <script type="text/javascript" src="../../js/Objetos.js"></script>
    <script type="text/javascript" src="../../js/Controller/DeletarTemas.js"></script>
    
</head>

<body>



<!--topo -->
<div id="titulo" title="Painel de Controle">
  <div id="logo_painel">
  	<img src="../../images/logomarca.png" />
  </div>
  <div id="painel_de_controle">
  	  PAINEL DE CONTROLE - Excluir Temas&nbsp;
  </div>
</div>
<div id="barrinha_vermelha">

</div>
<!--topo -->
    <div id="Content">    

    <div id="menu">
	
    <div id="NovoTema" class="opcao">
    	<table width="180" border="0">
  			<tr>
    			<td width="32px"><img src="../../images/add.png" title="Adicinar nova publicação" /></td>
    			<td><label>Novo tema</label></td>
  			</tr>
		</table>
    </div>
    
       
    <div id="ExcluirTema" class="opcao">
    	<table width="180" border="0">
  			<tr>
    			<td width="32px"><img src="../../images/del.png" title="Excluir esta publicação"/></td>
    			<td><label>Excluir tema</label></td>
  			</tr>
		</table>
    </div>
    
    
</div>
     <!--fim da área de menu -->
    <div id="conteudo">  
          <label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Selecione um tema para excluir:</b></label>
              <div id="listTemas"></div>

         <div id="pagerPostagem" class="k-pager-wrap k-widget"></div>
   </div>

    <div id="window">
       <div style="text-align:center;"><strong><span style="font-family:Verdana, Geneva, sans-serif;font-size:medium;">Deseja realmente excluir esta publica&ccedil;&atilde;o?</span></strong></div>
        <br />
         <input type="button" id="excluir"class="k-button"  data-bind="events: {click: Excluir}" value="Sim" />
          <input type="button" id="nao_excluir" class="k-button" data-bind="events: {click: NaoExcluir}" value="Não"  />
    </div>

    <script type="text/x-kendo-tmpl" id="templateTema">
                   <div class="postagem"> <%-- esta linha é somente para exibir com formatação--%> 
                   <span id="listTemas"><label><img src="../../images/del_publicacao_small.png" /> #:Nome# </label> </span>
                    </div>
    </script>

    </div>

    
</body>
</html>
