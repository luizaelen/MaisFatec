var wnd;
var Tema;
var listaPager;
var viewModel = new kendo.data.ObservableObject({
    ListaTemas: [],
    Tema: new Tema(),


    ///METODO PARA EXCLUIR A POSTAGEMM
    Excluir: function () {
        
        Modulo.Tema.Deletar(viewModel.get("Tema.TemaId"),
            function (sucesso) {

                var listaTemas = viewModel.get("ListaTemas");
                var novalista = new Array();

                //ESTOU VARRENDO MINHA LISTA DE POSTAGEM
                for (var i = 0; i < listaTemas.length; i++) {

                    //SE O ID DA POSTAGEM SELECIONADA FOR IGUAL A 1 DOS IDS QUE EU TENHO NA LISTA, ENTAO EU RETORNO ESSE OBJETO DA LISTA
                    if (listaTemas[i].TemaId != viewModel.get("Tema.TemaId")) {
                        novalista.push(listaTemas[i]);
                    }
                }

                //FECHO MINHA WINDOW
                wnd.close();
                //E ADICIONO NA LISTA DE POSTAGENS, MINHA NOVA LISTA, COM 1 POSTAGEM A MENOS
                viewModel.set("ListaTemas", novalista);
                $("#listTemas").kendoListView({
                    dataSource: viewModel.get("ListaTemas"),
                    selectable: true,
                    change: function (e) {
                        var data = e.sender.dataSource.view();
                        var selecionado = $.map(e.sender.select(), function (item) {
                            return data[$(item).index()];
                        });
                        viewModel.set("Tema", selecionado[0]);
                        wnd.open().center();
                        kendo.bind($("#window"), viewModel);

                    },
                    template: kendo.template($("#templateTema").html())
                });

                $("#pagerPostagem").kendoPager({
                    dataSource: viewModel.get("ListaTemas")
                });

                toastr.success("Tema excluído com sucesso!");

            },
            function (erro) {
                toastr.error("Ocorreu um erro ao deletar o tema selecionado.");

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
        Modulo.Tema.Geral(function (temas) {
            if (temas != null || temas != undefined) {

                //METODO PARA FILTRAR APENAS AS POSTAGENS DO COLUNISTA LOGADO
                //if (postagem.Colunista.Usuario.ColunistaId == usuario.UsuarioId) {
                viewModel.set("ListaTemas", temas);
                //}


            }

            //INICIALIZA O PAGER
            $("#pagerTema").kendoPager({
                dataSource: viewModel.get("ListaTemas")
            });

            //INICIALIZA O LISTVIEW DE POSTAGENS
            $("#listTemas").kendoListView({
                dataSource: viewModel.get("ListaTemas"),
                selectable: true,
                change: function (e) {
                    var data = e.sender.dataSource.view();
                    var selecionado = $.map(e.sender.select(), function (item) {
                        return data[$(item).index()];
                    });
                    viewModel.set("Tema", selecionado[0]);
                    wnd.open().center();
                    kendo.bind($("#window"), viewModel);

                },
                template: kendo.template($("#templateTema").html())
            });

        },
            function (error) {
                toastr.error("Ocorreu um erro ao retornar as postagens");
            })

          } else if (usuario.Perfil.PerfilId == 1) {

        //METODO PARA RETORNAR TODAS AS POSTAGENS DO SERVIDOR
        Modulo.Tema(Tema.TemaId,
            function (temas) {
                if (temas != null || temas != undefined) {

                    //METODO PARA FILTRAR APENAS AS POSTAGENS DO COLUNISTA LOGADO
                    //if (postagem.Colunista.Usuario.ColunistaId == usuario.UsuarioId) {
                    viewModel.set("ListaTemas", temas);
                    //}


                }

                //INICIALIZA O PAGER
                $("#pagerTemas").kendoPager({
                    dataSource: viewModel.get("ListaTemas")
                });

                //INICIALIZA O LISTVIEW DE POSTAGENS
                $("#listTema").kendoListView({
                    dataSource: viewModel.get("ListaTemas"),
                    selectable: true,
                    change: function (e) {
                        var data = e.sender.dataSource.view();
                        var selecionado = $.map(e.sender.select(), function (item) {
                            return data[$(item).index()];
                        });
                        viewModel.set("Tema", selecionado[0]);
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
    $("#NovoTema").click(function () {
        location.href = "cadastro.aspx";
        localStorage.setItem("Tema", Utilidades.Encrypt(new Postagem()))
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