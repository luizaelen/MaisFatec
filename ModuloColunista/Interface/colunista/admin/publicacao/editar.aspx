<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editar.aspx.cs" Inherits="colunista_admin_publicacao_editar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="cache-control" content="max-age=0" />
<meta http-equiv="cache-control" content="no-cache" />
<meta http-equiv="expires" content="0" />
<meta http-equiv="expires" content="Tue, 01 Jan 1980 1:00:00 GMT" />
<meta http-equiv="pragma" content="no-cache" />

<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Painel de Controle - Publicações</title>

<link href="../../kendo/styles/kendo.silver.min.css" rel="stylesheet" />
<link href="../../kendo/styles/kendo.common.min.css" rel="stylesheet" />
<link href="../css/toastr.css" rel="stylesheet" />

<link href="../css/estilo_lista_postagem.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="../js/kendo.all.min.js"></script>
    <script type="text/javascript" src="../js/Plugins/toastr.js"></script>
    <script type="text/javascript" src="../js/Utils.js"></script>
    <script type="text/javascript" src="../js/Colecao.js"></script>
    <script type="text/javascript" src="../js/Objetos.js"></script>
    <script type="text/javascript" src="../js/Controller/EditarPostagem.js"></script>
</head>

<body>

<div id="Content">    

<!--topo -->
<div id="titulo" title="Painel de Controle">
  <div id="logo_painel">
  	<img src="../images/logomarca.png" />
  </div>
  <div id="painel_de_controle">
  	PAINEL DE CONTROLE - Editar Publicações
  </div>
</div>
<div id="barrinha_vermelha"></div>
<!--topo -->

      <div id="menu">
	
    <div id="NovaPublicacao" class="opcao">
    	<table width="180" border="0">
  			<tr>
    			<td width="32px"><img src="../images/add.png" title="Adicinar nova publicação" /></td>
    			<td><label>Nova publicação</label></td>
  			</tr>
		</table>
    </div>
    
    <div id="EditarPublicacao" class ="opcao">
    	<table width="180" border="0">
  			<tr>
    			<td width="32px"><img src="../images/edit.png" title="Editar publicação" /></td>
    			<td><label>Editar publicação</label></td>
  			</tr>
		</table>
    </div>
    
    <div id="ExcluirPublicacao" class="opcao">
    	<table width="180" border="0">
  			<tr>
    			<td width="32px"><img src="../images/del.png" title="Excluir esta publicação"/></td>
    			<td><label>Excluir publicação</label></td>
  			</tr>
		</table>
    </div>
    
    <div id="RetornarMenu" class="opcao">
    	<table width="180" border="0">
  			<tr>
    			<td width="32px"><img src="../images/return.png" /></td>
    			<td><label>Retornar ao menu de opções</label></td>
  			</tr>
		</table>
    </div>

</div>
     <!--fim da área de menu -->
    <div id="conteudo">     <div class="k-dropzone-hovered">

        <label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>Selecione uma publicação para editar:</b></label>

         <div id="listPostagem"></div>
        <div id="pagerPostagem" class="k-pager-wrap"></div>
    </div>
   </div>

    <script type="text/x-kendo-tmpl" id="templateTema">
                    <div class="postagem">
                   <span id="conteudoPostagem"><label><img src="../images/edit-icon.png" /> #:Titulo# </label> </span>
                    </div>

            </div>
    </script>

    </div>
</body>
</html>
