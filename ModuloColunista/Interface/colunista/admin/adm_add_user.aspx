<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adm_add_user.aspx.cs" Inherits="colunista_admin_adm_add_user" %>

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

<link href="../kendo/styles/kendo.silver.min.css" rel="stylesheet" />
<link href="../kendo/styles/kendo.common.min.css" rel="stylesheet" />
<link href="css/toastr.css" rel="stylesheet" />

<link href="css/estilo.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="js/kendo.all.min.js"></script>
    <script type="text/javascript" src="js/Plugins/toastr.js"></script>
    <script type="text/javascript" src="js/Utils.js"></script>
    <script type="text/javascript" src="js/Colecao.js"></script>
    <script type="text/javascript" src="js/Objetos.js"></script>
    <script type="text/javascript" src="js/Controller/AdicionarColunista.js"></script>
</head>

<body>

<div id="Content">

<!--topo -->
<div id="titulo" title="Painel de Controle">
  <div id="logo_painel">
  	<img src="images/logomarca.png" />
  </div>
  <div id="painel_de_controle">
  	Painel Administrativo do Módulo | Definir Colunistas
  </div>
</div>
<div id="barrinha_vermelha"></div>
<!--topo -->

<div id="menu">
	
    <div id="opcao">
    	<table width="150" border="0">
  			<tr>
    			<td width="32px"><img src="images/tools/add_user.png" width="32" height="32" /></td>
   			  <td><a href="adm_add_user.aspx" class="opcao">Novo Colunista</a></td>
  			</tr>
		</table>
    </div>
    
    <div id="Div1">
    	<table width="150" border="0">
  			<tr>
    			<td width="32px"><img src="images/tools/remove_user.png" width="32" height="32" /></td>
   			  <td><a href="adm_disable_user.aspx" class="opcao">Desativar Colunista</a></td>
  			</tr>
		</table>
    </div>
    
    <div id="Div2">
    	<table width="150" border="0">
  			<tr>
    			<td width="32px">&nbsp;</td>
    			<td>&nbsp;</td>
		  </tr>
		</table>
    </div>
    
    <div id="Div3">
    	<table width="150" border="0">
  			<tr>
    			<td width="32px"><a href="menu_principal.aspx"><img src="images/return.png" border="0" /></a></td>
    			<td><a href="menu_principal.aspx" class="opcao">Retornar ao menu de opções</a></td>
		  </tr>
		</table>
    </div>

</div> <!--fim da área de menu -->

<!--área de postagem -->
<div id="conteudo">
	
        
<!--formulario de publicacao -->
    <div id="publicar">
        
        <label>Definir usuário como Colunista:<br /></label>

        <label> </label><input type="text" id="Usuarios" size="60" class="k-textbox" /><br /><br />
         <input type="button" id="Enviar" class="k-button" data-bind="events: {click: Salvar}" value="Definir Colunista"  /> 
        <br />

    </div>
    <!--formulario de publicacao -->

    
</div>
<!--área de postagem -->

</div>

</body>


</html>

