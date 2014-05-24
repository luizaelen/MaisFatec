var viewModel = new kendo.data.ObservableObject({
    ListaPostagens: [],
    Postagem: new Postagem(),
})


$(document).ready(function () {
    var usuario = Utilidades.Decrypt(localStorage.getItem("Usuario"));

    //METODO PARA RETORNAR TODAS AS POSTAGENS DO SERVIDOR


    if (usuario.Perfil.PerfilId == 1) {
        Modulo.Postagem.Geral(function (postagens) {
            if (postagens != null || postagens != undefined) {

                viewModel.set("ListaPostagens", postagens);
            }


            //INICIALIZA O LISTVIEW DE POSTAGENS
            $("#listPostagem").kendoListView({
                dataSource: viewModel.get("ListaPostagens"),
                selectable: true,
                change: function (e) {
                    var data = e.sender.dataSource.view();
                    var selecionado = $.map(e.sender.select(), function (item) {
                        return data[$(item).index()];
                    });

                    localStorage.setItem("Postagem", Utilidades.Encrypt(selecionado[0]));
                    location.href = "cadastro.aspx";
                },
                template: kendo.template($("#templateTema").html())
            });

            //INICIALIZA O PAGER
            $("#pagerPostagem").kendoPager({
                dataSource: viewModel.get("ListaPostagens")
            });

        },
            function (error) {
                toastr.error("Ocorreu um erro ao retornar as postagens");
            })

    } else if (usuario.Perfil.PerfilId == 2) {

        Modulo.Postagem.Colunista(usuario.UsuarioId,
            function (postagens) {
                if (postagens != null || postagens != undefined) {

                    viewModel.set("ListaPostagens", postagens);
                }


                //INICIALIZA O LISTVIEW DE POSTAGENS
                $("#listPostagem").kendoListView({
                    dataSource: viewModel.get("ListaPostagens"),
                    selectable: true,
                    change: function (e) {
                        var data = e.sender.dataSource.view();
                        var selecionado = $.map(e.sender.select(), function (item) {
                            return data[$(item).index()];
                        });

                        localStorage.setItem("Postagem", Utilidades.Encrypt(selecionado[0]));
                        location.href = "cadastro.aspx";
                    },
                    template: kendo.template($("#templateTema").html())
                });

                //INICIALIZA O PAGER
                $("#pagerPostagem").kendoPager({
                    dataSource: viewModel.get("ListaPostagens")
                });

            },
            function (error) {
                toastr.error("Ocorreu um erro ao retornar as postagens");
            });
    }


    //EVENTO PARA REDIRECIONAR PARA PAGINA DE CADASTRO.HTML
    $("#NovaPublicacao").click(function () {
        location.href = "cadastro.aspx";
        localStorage.setitem("Postagem", Utilidades.Encrypt(new Postagem()));

    });

    //EVENTO PARA REDIRECIONAR PARA PAGINA DE menu_principal.html
    $("#RetornarMenu").click(function () {
        location.href = "../menu_principal.aspx";
    });

    //EVENTO PARA REDIRECIONAR PARA PAGINA DE EDITAR_PUBLICACAO.HTML
    $("#EditarPublicacao").click(function () {
        localStorage.href = "editar_publicacao.aspx";
    });

    //REDIRECIONA PARA PAGINA DE DELETAR PUBLICACAO
    $("#ExcluirPublicacao").click(function () {
        location.href = "deletar.aspx";
    });


    kendo.bind($("#Content"), viewModel);

})