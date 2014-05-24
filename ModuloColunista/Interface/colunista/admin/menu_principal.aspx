<%@ Page Language="C#" AutoEventWireup="true" CodeFile="menu_principal.aspx.cs" Inherits="colunista_admin_menu_principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="cache-control" content="max-age=0" />
<meta http-equiv="cache-control" content="no-cache" />
<meta http-equiv="expires" content="0" />
<meta http-equiv="expires" content="Tue, 01 Jan 1980 1:00:00 GMT" />
<meta http-equiv="pragma" content="no-cache" />

<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Painel Administrativo - Módulo Colunistas - Mais FATEC</title>
<link href="css/estilo.css" rel="stylesheet" type="text/css" />
    <script src="js/jquery-1.9.1.min.js"></script>
    <script src="js/Utils.js"></script>
<script src="js/Controller/Menu.js"></script>
    <style type="text/css">
        .auto-style1 {
            width: 140px;
        }
    </style>
</head>

<body>

<!--topo -->
<div id="titulo" title="Painel de Controle">
  <div id="logo_painel">
  	<img src="images/logomarca.png" />
  </div>
  <div id="painel_de_controle">
  	PAINEL DE CONTROLE - Módulo Colunistas
  </div>
</div>
<div id="barrinha_vermelha"></div>
<!--topo -->


<div id="menu_principal">
<!--ferramentas -->
  <div id="ferramentas_post_menu_principal">
    
   	<div id="adm_colunista" style="display:none">
<table align="right">
<tr>
                	<td width="82"><div align="center"><a href="adm_add_user.aspx" class="link_icones_menu"><img src="images/tools/64px/perfil.png" width="64" height="64" border="0" class="icones_menu" /></a></div></td>
              </tr>
               	<tr>
                	<td><a href="adm_add_user.aspx">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Ativar/Desativar &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Colunistas</a></td>
        </tr>
            </table>
    </div>
        
        
        <div id="adm_publicacoes">
         <table align="center">
    <tr>
               <td><div align="center"><a href="publicacao/cadastro.aspx" class="link_icones_menu"><img src="images/tools/64px/posts.png" width="64" height="64" border="0" class="icones_menu"/></a></div></td>
              	</tr>
               	<tr>
                	<td><a href="publicacao/cadastro.aspx" class="link_icones_menu">Gerenciar&nbsp;Publicações</a></td>
              </tr>
             <tr>
                	<td>&nbsp;</td>
              </tr>
         </table>
    </div>
     <div id="adm_retornar">

         <%-- div do botão cadastrar temas - SOMENTE USUARIO ADMINISTRADOR PODERÁ FAZÊ-LO --%>

                 <div id="cadastrar_temas">


         <table align="center">
    <tr>
               <td><div align="center"><a href="javascript:window.open('publicacao/cadastrar_tema/cadastro.aspx',null,'resizable=no,toolbar=no,scrollbars=no,menubar=no,status=no,width=1000,height=600');" class="link_icones_menu"><img src="images/tools/64px/temas.png" width="64" height="64" border="0" class="icones_menu"/></a></div></td>
              	</tr>
               	<tr>
                  	<td><a href="javascript:window.open('publicacao/cadastrar_tema/cadastro.aspx',null,'resizable=no,toolbar=no,scrollbars=no,menubar=no,status=no,width=1000,height=600');" class="link_icones_menu">Cadastrar Temas</a></td>
              </tr>
             <tr>
                	<td>&nbsp;</td>
              </tr>
         </table>



    </div>
     


        <%-- FIM DO BOTÃO CADASTRAR TEMAS --%>

         <table>
    <tr>
               <td class="auto-style1"><div align="center"><a href="../../Colunista.aspx" class="link_icones_menu"><img src="images/tools/64px/return.png" width="64" height="64" border="0" class="icones_menu"/></a></div></td>
              	</tr>
               	<tr>
                	<td class="auto-style1" style text-align="center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <a href="../../Colunista.aspx">Página principal</a></td>
              </tr>
             <tr>
                	<td class="auto-style1">&nbsp;</td>
              </tr>
         </table>
    </div>
        
  </div>
	<!--ferramentas -->
</div>


</body>
</html>
