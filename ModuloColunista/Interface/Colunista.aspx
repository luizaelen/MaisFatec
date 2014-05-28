<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Colunista.aspx.cs" Inherits="Colunista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <header>
        <meta http-equiv="cache-control" content="max-age=0" />
        <meta http-equiv="cache-control" content="no-cache" />
        <meta http-equiv="expires" content="0" />
        <meta http-equiv="expires" content="Tue, 01 Jan 1980 1:00:00 GMT" />
        <meta http-equiv="pragma" content="no-cache" />

        <style>
            .modalDialog {
                position: fixed;
                font-family: Arial, Helvetica, sans-serif;
                top: 0;
                right: 0;
                bottom: 0;
                left: 0;
                background: rgba(0,0,0,0.8);
                z-index: 99999;
                opacity: 0;
                -webkit-transition: opacity 400ms ease-in;
                -moz-transition: opacity 400ms ease-in;
                transition: opacity 400ms ease-in;
                pointer-events: none;
            }

                .modalDialog:target {
                    opacity: 1;
                    pointer-events: auto;
                }

                .modalDialog > div {
                    width: 400px;
                    position: relative;
                    margin: 10% auto;
                    padding: 5px 20px 13px 20px;
                    border-radius: 10px;
                    background: #fff;
                    background: -moz-linear-gradient(#fff, #999);
                    background: -webkit-linear-gradient(#fff, #999);
                    background: -o-linear-gradient(#fff, #999);
                }

            .close {
                color: #000000;
                line-height: 25px;
                position: inherit;
                right: -12px;
                text-align: center;
                top: -10px;
                width: 24px;
                text-decoration: none;
                font-weight: bold;
            }

                .close:hover {
                    background: #00d9ff;
                }
        </style>

    </header>
    <link href="colunista/css/estilo.css" rel="stylesheet" type="text/css" />

    <link href="colunista/kendo/styles/kendo.common.min.css" rel="stylesheet" />
    <link href="colunista/kendo/styles/kendo.common.min.button.css" rel="stylesheet" />
    <link href="colunista/kendo/styles/kendo.default.min.css" rel="stylesheet" />
    <link href="colunista/css/kendo.default.min.css" rel="stylesheet" />
    <link href="colunista/admin/css/toastr.css" rel="stylesheet" />
    <link href="colunista/css/colunistas.css" rel="stylesheet" />

    <script type="text/javascript" src="colunista/js/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="colunista/js/kendo.all.min.js"></script>
    <script src="colunista/admin/js/Plugins/toastr.js"></script>
    <script src="colunista/admin/js/Utils.js"></script>
    <script src="colunista/admin/js/Objetos.js"></script>
    <script type="text/javascript" src="colunista/js/index.js"></script>
    <script src="colunista/admin/js/Utils.js"></script>

    <!-- barra de título do módulo e área de pesquisa !-->
    <div id="mod_pesq">
        <div id="modulo">
            <div id="nome_modulo" title="Você está no módulo: Temas">
                <label>Temas</label>
            </div>
            <div id="texto_modulo"></div>
        </div>

        <div id="pesquisa" title="Campo de pesquisa">
            <form action="" method="get">
                <label>Filtrar: &nbsp;</label><input name="" type="text" title="Digite aqui o que procura" placeholder="Filtrar postagens..." onkeyup="filtrar(this.value)" />
                <div id="Nova_Postagem">
                    <input type="button" id="btn_Nova_Postagem" class="k-button" value="Painel Administrativo" data-bind="events: { click: NovaPostagem }" />
                </div>
                <!--   	<button type="submit">Buscar</button>-->
            </form>
        </div>

    </div>
    <!-- barra de título do módulo e área de pesquisa !-->

    <!-- conteudo principal !-->
    <div id="content">

        <div id="menu_temas"></div>

        <div id="ultimas_postagens" title="Últimas publicações dos Colunistas">
            <!-- POSTAGENS !-->



            <div id="listPostagem"></div>

            <%-- aqui está o nome de quem publicou e a data da publicação --%>
            <div id="tituloAqui" style="display: none; font-size: 18px; font-weight: bold; margin-left: 30px"></div>
            <%--  --%>
            <div>
                <br />
                <br />
            </div>
            <div id="postagemAqui" style="display: none"></div>


            <div id="comentariosPostagem" style="display: none">
                <%--                <div id="modalEditarComentario" style="display: none;">
                        <label>Conteúdo</label>
                        <%--<input type="text" data-bind="value: ConteudoComentario"></input>--%>
                <%--<input type="text" placeholder="Digite seu comentário" class="k-input" data-bind="value: ConteudoComentario" />
                        <input type="button" value="Editar" data-bind="click: editarComentario" />
                    </div>--%>
                <br />
                <br />
                <label>Comentarios:</label>
                <div id="listaComentarios"></div>
                <input type="text" id="txtComentario" placeholder="Digite seu comentário e pressione ENTER" class="k-input" data-bind="value: Comentario.Conteudo" />
            </div>

            <div id="pagerPostagem" class="k-pager-wrap"></div>

        </div>
        <!-- FIM POSTAGENS !-->


        <div id="fotos_colunistas" title="Conheça os colunistas do Mais Fatec">
            Colunistas do Mais Fatec:
            <div id="example" class="k-content" style="width: 255px;">

                <div class="k-dropzone-hovered">
                    <div id="listView"></div>
                    <div id="pager" class="k-pager-wrap">
                    </div>
                </div>


                <%--    <div id="window" style="display:none">
        <div id ="conteudoPostagem"></div>
    </div>--%>
                <script>
                    function imprime(objeto) {
                        return console.log(JSON.stringify(objeto))
                    }
                </script>

                <script type="text/x-kendo-tmpl" id="template">
                   <%--     <div class="product" onclick="filtrarColunista(${UsuarioId})"> --%>                  
                     <%--     <img src="colunista/images/colunistas/foto${UsuarioId}.jpg" /> --%>     
                     <div class="product" onclick="filtrarColunista(${UsuarioId})">                  
                     <img src="/FotosPerfil/${UsuarioId}.jpg" />
                        <h3>#:Nome#</h3>
                    </div>                   
                     
                </script>

                <script type="text/x-kendo-tmpl" id="templateTema">
                <div class="temas" Title="#:Nome#">  <label>#:Nome#</label></div>

            </div>
                </script>

                <script type="text/x-kendo-tmpl" id="templatePostagem">
                   <div class="postagem">
                       <span id="usuarioPostagem"><label>por  #:Usuario.Nome# em #:ConversaoData(DataPostagem)# </label> </span>
                       <span id="conteudoPostagem"><label> #:Titulo# </label> </span>
                   </div>
                </script>


                <script type="text/x-kendo-tmpl" id="comentarioPostagem">
                   <div class="comentario">
               
                 
                   <span id="UsuarioComentario">#:Usuario.Nome # </span>
                    #if(UsuarioLogado.UsuarioId == Usuario.UsuarioId || UsuarioLogado.Perfil.PerfilId == 1 || UsuarioLogado.UsuarioId == viewModel.Postagem.Usuario.UsuarioId) {#
     
                    <button id="button_del_comentario" type="button" class ="k-button" onclick="deletarComentario(${ComentarioId})" >Excluir</button>
                    <button id="button_edit_comentario" type="button" class ="k-button" onclick="editarComentario(${ComentarioId})" >Editar</button>
                    <%--<button id="button_edit_comentario" type="button" class ="k-button" onclick="editarComentario(${ComentarioId})" ><a href="#openModal">Editar</button>--%>
                    
                    
                    <%--<a href="http://localhost:5724/map.html" class="k-button"><font color = 'black'>See All Center</fonts></a>--%>

                    <%--<button type="button"><a href="#openModal">Editar</a></button>--%>
                                        
       
                    #}#
                   <span id="conteudoComentario"><label> #:Conteudo# </label> </span>
                   <span id="dataComentario"><label> #:ConversaoData(DataComentario)# </label></span>
                    </div>

                    

            </div>
                    
                </script>



            </div>

        </div>

    </div>
    <!-- conteudo principal !-->

    <%--<div id="modalEditarComentario" class="modalDialog">
	    <div>
		    <label>Conteúdo: </label>
		    <input type="text" data-bind="value: Conteudo"></input>
		    <p>
		    <button type="button" data-bind="click: editarComentario"><a href="#close" title="Close" class="close">Editar</a></button>
				
	    </div>
    </div>--%>

    <div id="modalEditar" data-role="window" data-modal="true" data-width="800px" data-resizable="false">
        <%--style="display: none;">--%>
        <label>Conteúdo</label>
        <input id="comentarioTxt" type="text" placeholder="Digite seu comentário" class="k-input" />
        <%--<input type="text" placeholder="Digite seu comentário" class="k-input" data-bind="text: Comentario.Conteudo" />--%>

        <input type="button" value="Editar" onclick="confirmarEdicaoComentario()" id="${uid}" />

    </div>

    </script>


</asp:Content>

