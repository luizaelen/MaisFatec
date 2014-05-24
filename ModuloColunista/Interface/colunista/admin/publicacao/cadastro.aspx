<%@ Page Language="C#" AutoEventWireup="true" CodeFile="cadastro.aspx.cs" Inherits="colunista_admin_publicacao_cadastro" %>

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
<link href="../../kendo/styles/kendo.common.min.button.css" rel="stylesheet" />
<link href="../css/toastr.css" rel="stylesheet" />
<link rel="stylesheet" type="text/css" href="../css/estilo.css">

<script type="text/javascript" src="../js/jquery-1.9.1.min.js"></script>
<script type="text/javascript" src="../../kendo/js/kendo.all.min.js"></script> 
<script type="text/javascript" src="../js/Plugins/toastr.js"></script>
<script type="text/javascript" src="../js/Utils.js"></script>
<script type="text/javascript" src="../js/Objetos.js"></script>
<script type="text/javascript" src="../js/Colecao.js"></script>
<script type="text/javascript" src="../js/Controller/Postagem.js"></script>
<link href="../css/estilo.css" rel="stylesheet" type="text/css" />
</head>

<body>
<div id="Content">

<!--topo -->
<div id="titulo" title="Painel de Controle">
  <div id="logo_painel">
  	<img src="../images/logomarca.png" />
  </div>
  <div id="painel_de_controle">
  	PAINEL DE CONTROLE - Cadastro de Publicações
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

        <div id="SolicitarTema" class="opcao">
    	<table width="180" border="0">
  			<tr>
    			<td width="32px"><a href="javascript:window.open('solicitar_tema/contato.aspx',null,'resizable=no,toolbar=no,scrollbars=no,menubar=no,status=no,width=400,height=330');"><img src="../images/email.png" title="Excluir esta publicação"/></td>
    			<td><a href="javascript:window.open('solicitar_tema/contato.aspx',null,'resizable=no,toolbar=no,scrollbars=no,menubar=no,status=no,width=400,height=330');"><label>Solicitar cadastro de temas</label></td>
  			</tr>
		</table>
    </div>
    
    <div id="RetornarMenu" class="opcao">
    	<table width="180" border="0">
  			<tr>
    			<td width="32px"><img src="../images/return.png" /></td>
    			<td><label>Retornar ao menu</label></td>
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
            <%--<input type="text" id="tema_postagem" data-bind="value: Tema.Nome" />--%><br />
            <input id="temapostagem" data-role="combobox" data-text-field="Nome" placeholder="Tema da publicação" data-value-field="TemaId" data-bind=" source:ListaTemas, value:TemaId"/><br />
            <input id="tipo_postagem" data-role="combobox" data-text-field="Tipo" placeholder="Tipo da publicação" data-value-field="TipoPostagemId" data-bind=" source:TiposPostagens, value:Postagem.TipoPostagem" />
        </div>
        <div id="public_posts_right">
            <br /><br />
<%--        <input id="cbx_temas"  data-role="combobox" data-text-field="Nome" placeholder="Remover Tema" size="100"  data-value-field="Nome" data-bind=" source:Postagem.Temas, events:{select: deletarTema}" />--%>
            <input  id="titulo_postagem" placeholder="Título " data-bind="value: Postagem.Titulo" class="k-textbox" />
        </div>
    </div>

    <div id="editor_postagem">
        <textarea name="editor" cols="30" rows="10" id="editor" style="width:740px;height:440px" data-bind="value: Postagem.Conteudo"></textarea>

    </div>
      
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
    <p>
    
    <!--Salvar, Pré-visualizar e Cancelar -->
    <input type="button" id="btn_pre_visualizar" class="k-button"  data-bind="events: {click: PreVisualizar}" value="Pré-Visualizar" />
    <input type="button" id="btn_salvar" class="k-button" data-bind="events: {click: Salvar}" value="Salvar"  />
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
