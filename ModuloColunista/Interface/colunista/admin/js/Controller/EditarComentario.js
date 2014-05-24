var viewModel = new kendo.data.ObservableObject({
    ListaPostagens: [],
    Comentario: new Comentario(),
})


$(document).ready(function () {
    var usuario = Utilidades.Decrypt(localStorage.getItem("Usuario"));

    //METODO PARA RETORNAR TODAS AS POSTAGENS DO SERVIDOR


    if (usuario.Perfil.PerfilId == 1) {
        Modulo.Comentario.Geral(function (comentarios) {
            if (comentarios != null || comentarios != undefined) {

                viewModel.set("ListaComentarios", comentarios);
            }


            //INICIALIZA O LISTVIEW DE POSTAGENS
            $("#listComentario").kendoListView({
                dataSource: viewModel.get("ListaComentarios"),
                selectable: true,
                change: function (e) {
                    var data = e.sender.dataSource.view();
                    var selecionado = $.map(e.sender.select(), function (item) {
                        return data[$(item).index()];
                    });

                    localStorage.setItem("Comentario", Utilidades.Encrypt(selecionado[0]));
                    location.href = "cadastro.aspx";
                },
                template: kendo.template($("#templateTema").html())
            });

            //INICIALIZA O PAGER
            $("#pagerComentario").kendoPager({
                dataSource: viewModel.get("ListaComentarios")
            });

        },
            function (error) {
                toastr.error("Ocorreu um erro ao retornar o comentário");
            })

    } else if (usuario.Perfil.PerfilId == 2) {

        Modulo.Comentario.Colunista(usuario.UsuarioId,
            function (comentarios) {
                if (comentarios != null || comentarios != undefined) {

                    viewModel.set("ListaComentarios", comentarios);
                }


                //INICIALIZA O LISTVIEW DE POSTAGENS
                $("#listComentario").kendoListView({
                    dataSource: viewModel.get("ListaComentario"),
                    selectable: true,
                    change: function (e) {
                        var data = e.sender.dataSource.view();
                        var selecionado = $.map(e.sender.select(), function (item) {
                            return data[$(item).index()];
                        });

                        localStorage.setItem("Comentario", Utilidades.Encrypt(selecionado[0]));
                        location.href = "cadastro.aspx";
                    },
                    template: kendo.template($("#templateTema").html())
                });

                //INICIALIZA O PAGER
                $("#pagerComentario").kendoPager({
                    dataSource: viewModel.get("ListaComentarios")
                });

            },
            function (error) {
                toastr.error("Ocorreu um erro ao retornar o comentário");
            });
    }


    //EVENTO PARA REDIRECIONAR PARA PAGINA DE CADASTRO.HTML
    $("#NovoComentario").click(function () {
        location.href = "cadastro.aspx";
        localStorage.setitem("Comentario", Utilidades.Encrypt(new Postagem()));

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