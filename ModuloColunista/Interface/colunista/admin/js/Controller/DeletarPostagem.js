var wnd;
var Postagens;
var listaPager;
var viewModel = new kendo.data.ObservableObject({
    ListaPostagens: [],
    Postagem: new Postagem(),


    ///METODO PARA EXCLUIR A POSTAGEMM
    Excluir: function () {
        
        Modulo.Postagem.Deletar(viewModel.get("Postagem.PostagemId"),
            function (sucesso) {

                var listaPostagem = viewModel.get("ListaPostagens");
                var novalista = new Array();

                //ESTOU VARRENDO MINHA LISTA DE POSTAGEM
                for (var i = 0; i < listaPostagem.length; i++) {

                    //SE O ID DA POSTAGEM SELECIONADA FOR IGUAL A 1 DOS IDS QUE EU TENHO NA LISTA, ENTAO EU RETORNO ESSE OBJETO DA LISTA
                    if (listaPostagem[i].PostagemId != viewModel.get("Postagem.PostagemId")) {
                        novalista.push(listaPostagem[i]);
                    }
                }

                //FECHO MINHA WINDOW
                wnd.close();
                //E ADICIONO NA LISTA DE POSTAGENS, MINHA NOVA LISTA, COM 1 POSTAGEM A MENOS
                viewModel.set("ListaPostagens", novalista);
                $("#listPostagem").kendoListView({
                    dataSource: viewModel.get("ListaPostagens"),
                    selectable: true,
                    change: function (e) {
                        var data = e.sender.dataSource.view();
                        var selecionado = $.map(e.sender.select(), function (item) {
                            return data[$(item).index()];
                        });
                        viewModel.set("Postagem", selecionado[0]);
                        wnd.open().center();
                        kendo.bind($("#window"), viewModel);

                    },
                    template: kendo.template($("#templateTema").html())
                });

                $("#pagerPostagem").kendoPager({
                    dataSource: viewModel.get("ListaPostagens")
                });

                toastr.success("Postagem Excluida com sucesso !");

            },
            function (erro) {
                toastr.error("Ocorreu um erro ao deletar a postagem selecionada");

            });
        //NESSA PARTE ESTOU RETORNANDO MINHA LISTA DE POSTAGEM QUE ESTA NA VIEWMODEL
     


    },
    NaoExcluir: function () {
        wnd.close();
    }
})


$(document).ready(function () {
    var usuario = Utilidades.Decrypt(localStorage.getItem("Usuario"));

    if (usuario.Perfil.PerfilId == 1) {
        Modulo.Postagem.Geral(function (postagens) {
            if (postagens != null || postagens != undefined) {

                //METODO PARA FILTRAR APENAS AS POSTAGENS DO COLUNISTA LOGADO
                //if (postagem.Colunista.Usuario.ColunistaId == usuario.UsuarioId) {
                viewModel.set("ListaPostagens", postagens);
                //}


            }

            //INICIALIZA O PAGER
            $("#pagerPostagem").kendoPager({
                dataSource: viewModel.get("ListaPostagens")
            });

            //INICIALIZA O LISTVIEW DE POSTAGENS
            $("#listPostagem").kendoListView({
                dataSource: viewModel.get("ListaPostagens"),
                selectable: true,
                change: function (e) {
                    var data = e.sender.dataSource.view();
                    var selecionado = $.map(e.sender.select(), function (item) {
                        return data[$(item).index()];
                    });
                    viewModel.set("Postagem", selecionado[0]);
                    wnd.open().center();
                    kendo.bind($("#window"), viewModel);

                },
                template: kendo.template($("#templateTema").html())
            });

        },
            function (error) {
                toastr.error("Ocorreu um erro ao retornar as postagens");
            })

          } else if (usuario.Perfil.PerfilId == 2) {

        //METODO PARA RETORNAR TODAS AS POSTAGENS DO SERVIDOR
        Modulo.Postagem.Colunista(usuario.UsuarioId,
            function (postagens) {
                if (postagens != null || postagens != undefined) {

                    //METODO PARA FILTRAR APENAS AS POSTAGENS DO COLUNISTA LOGADO
                    //if (postagem.Colunista.Usuario.ColunistaId == usuario.UsuarioId) {
                    viewModel.set("ListaPostagens", postagens);
                    //}


                }

                //INICIALIZA O PAGER
                $("#pagerPostagem").kendoPager({
                    dataSource: viewModel.get("ListaPostagens")
                });

                //INICIALIZA O LISTVIEW DE POSTAGENS
                $("#listPostagem").kendoListView({
                    dataSource: viewModel.get("ListaPostagens"),
                    selectable: true,
                    change: function (e) {
                        var data = e.sender.dataSource.view();
                        var selecionado = $.map(e.sender.select(), function (item) {
                            return data[$(item).index()];
                        });
                        viewModel.set("Postagem", selecionado[0]);
                        wnd.open().center();
                        kendo.bind($("#window"), viewModel);

                    },
                    template: kendo.template($("#templateTema").html())
                });

            },
            function (error) {
                toastr.error("Ocorreu um erro ao retornar as postagens");
            });
    }


    //EVENTO QUE QUANDO A ESTRUTURA HTML COM ID #NovaPublicacao FOR SELECIONADA, VAI DISPARAR UMA FUNCAO
    $("#NovaPublicacao").click(function () {
        location.href = "cadastro.aspx";
        localStorage.setItem("Postagem", Utilidades.Encrypt(new Postagem()))
    });
    //EVENTO QUE QUANDO A ESTRUTURA HTML COM ID #RetornarMenu FOR SELECIONADA, VAI DISPARAR UMA FUNCAO

    $("#RetornarMenu").click(function () {
        location.href = "../menu_principal.aspx";
    });
    //EVENTO QUE QUANDO A ESTRUTURA HTML COM ID #EditarPublicacao FOR SELECIONADA, VAI DISPARAR UMA FUNCAO PRA REDIRECIONAR PRA PAGINA EDITAR.HTML
    $("#EditarPublicacao").click(function () {
        location.href = "editar.aspx";
    })

    $("#ExcluirPublicacao").click(function () {
        location.href = "deletar.aspx";
    });

    wnd = $("#window").kendoWindow({
        modal: true,
        visible: false,
        resizable: false,
        hight: "5%"
    }).data("kendoWindow");

    kendo.bind($("#Content"), viewModel);

})