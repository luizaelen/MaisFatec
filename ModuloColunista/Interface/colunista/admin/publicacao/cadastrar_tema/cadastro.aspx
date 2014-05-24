﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cadastro.aspx.cs" Inherits="colunista_admin_publicacao_cadastro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Painel de Controle - Publicações</title>
<link href="../../../kendo/styles/kendo.silver.min.css" rel="stylesheet" />
<link href="../../../kendo/styles/kendo.common.min.css" rel="stylesheet" />
<link href="../../../kendo/styles/kendo.common.min.button.css" rel="stylesheet" />
<link href="../../css/toastr.css" rel="stylesheet" />
<link rel="stylesheet" type="text/css" href="../../css/estilo.css">

<script type="text/javascript" src="../../js/jquery-1.9.1.min.js"></script>
<script type="text/javascript" src="../../../kendo/js/kendo.all.min.js"></script> 
<script type="text/javascript" src="../../js/Plugins/toastr.js"></script>
<script type="text/javascript" src="../../js/Utils.js"></script>
<script type="text/javascript" src="../../js/Objetos.js"></script>
<script type="text/javascript" src="../../js/Colecao.js"></script>
<script type="text/javascript" src="../../js/Controller/Postagem.js"></script>
<link href="../../css/estilo.css" rel="stylesheet" type="text/css" />
</head>

<body>
<div id="Content">

<!--topo -->
<div id="titulo" title="Painel de Controle">
  <div id="logo_painel">
  	<img src="../../images/logomarca.png" />
  </div>
  <div id="painel_de_controle">
  	PAINEL DE CONTROLE - Cadastro de Temas</div>
</div>
<div id="barrinha_vermelha"></div>
<!--topo -->


<div id="menu">
	
    <div id="NovaPublicacao" class="opcao">
    	<table width="180" border="0">
  			<tr>
    			<td width="32px"><img src="../../images/add.png" title="Adicinar nova publicação" /></td>
    			<td><label>Novo tema</label></td>
  			</tr>
		</table>
    </div>
    
    <div id="ExcluirPublicacao" class ="opcao">
    	<table width="180" border="0">
  			<tr>
    			<td width="32px"><img src="../../images/del.png" title="Excluir esta publicação"/></td>
    			<td><label>Excluir tema</label></td>
  			</tr>
		</table>
    </div>
    
    
    </div><!--fim da área de menu -->

<!--área de postagem -->
<div id="conteudo">
	
    <!--ferramentas -->
    <!--ferramentas -->
    
    <!--formulario de publicacao -->
  <div id="publicar">
    
      
    <div id="public_posts">
        <div id="public_posts_left">
            <input type="text" id="tema_postagem" data-bind="value: Tema.Nome" /><br />
            &nbsp;</div>
        <label>&nbsp;Digite um nome para o tema e pressione ENTER</label></div>

<%--      <table width="713" border="0" cellspacing="4" cellpadding="4">
      <tr>--%>
        <%--<td width="100"><input type="text" id="tema_postagem" data-bind="value: Tema.Nome" /></td>
        <td width="540"><input  id="titulo_postagem" placeholder="Título " data-bind="value: Postagem.Titulo" size="60" class="--k-textbox" />	</td>%>
       </tr>
      <tr>
<%--            <td colspan="2"><input data-role="combobox" data-text-field="Tipo" placeholder="Tipo da postagem"  data-value-field="TipoPostagemId" data-bind=" source:TiposPostagens ,value:Postagem.TipoPostagem" />--%>
    <%--  <br />
          <br />
          <textarea name="editor" cols="30" rows="10" id="editor" style="width:740px;height:440px" data-bind="value: Postagem.Conteudo">                
          </textarea>
          <p></p>
        <!--formulario de publicacao --></td>
      </tr>--%>
<%--    </table>--%>
</div>
<!--área de postagem -->
<div id="Pre_Visualizar"style="display:none">

    <div id="PrePostagem">


    </div>
    
      
</div>
</div>

    </div>
</body>


</html>
