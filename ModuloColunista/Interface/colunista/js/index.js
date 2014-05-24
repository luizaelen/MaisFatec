var viewModel = new kendo.data.ObservableObject({
    Comentario: new Comentario(),
    ListaPostagem: [],
    conteudoComentario: "",
    Usuarios: function () {
        localStorage.setItem("Usuario", Utilidades.Encrypt(Utilidades.getCookie('UserID')));
    },
    NovaPostagem: function () {
        localStorage.setItem("Postagem", Utilidades.Encrypt(new Postagem()));
        //window.location.href = "colunista/admin/publicacao/cadastro.aspx";
        window.location.href = "colunista/admin/menu_principal.aspx";
    }

})
var DataSourcePostagem;
var Colunistas;
var wnd;

var UsuarioLogado = Utilidades.Decrypt(localStorage.getItem("Usuario"));

function timedRefresh() {
    setTimeout("location.reload(true);", 1000);
}

function filtrar(valor) {

    document.getElementById("listPostagem").style.display = "block";
    document.getElementById("pagerPostagem").style.display = "block";
    document.getElementById("postagemAqui").style.display = "none";
    document.getElementById("comentariosPostagem").style.display = "none";
    var base = viewModel.get("ListaPostagem");
    var dataSourceFiltro = new kendo.data.DataSource({
        data: base,
        filter: { field: "Titulo", operator: "contains", value: valor },
        sort: [{ field: "Titulo", dir: "asc" }]
    });
    dataSourceFiltro.fetch(function () {
        var view = dataSourceFiltro.view();
        DataSourcePostagem.data(view);
    });

    $("#pagerPostagem").data("kendoPager").dataSource.page(1);


}

function filtrarColunista(id) {
    var postagens = viewModel.get("ListaPostagem");

    var newArray = new Array();
    for (var i = 0; i < postagens.length; i++) {
        if (postagens[i].Usuario.UsuarioId == id) {
            newArray.push(postagens[i]);

        }


    }
    DataSourcePostagem.data(newArray);

    $("#pagerPostagem").data("kendoPager").dataSource.page(1);
    document.getElementById("listPostagem").style.display = "block";
    document.getElementById("pagerPostagem").style.display = "block";
    document.getElementById("postagemAqui").style.display = "none";
    document.getElementById("comentariosPostagem").style.display = "none";
}



function deletarComentario(id) {
    Modulo.Comentario.Excluir(id, function (sucesso) {

        Modulo.Comentario.ComentarioPostagem(viewModel.get("Postagem.PostagemId"), function (comentarios) {
            viewModel.set("Postagem.Comentarios", comentarios);
            AtualizarPostagem(viewModel.get("Postagem"));

            $("#listaComentarios").kendoListView({
                dataSource: viewModel.get("Postagem.Comentarios"),
                selectable: true,
                change: function (e) {
                    var data = e.sender.dataSource.view();
                    var selecionado = $.map(e.sender.select(), function (item) {
                        return data[$(item).index()];
                    });

                },
                template: kendo.template($("#comentarioPostagem").html())
            });

        }, function (error) {
            toastr.error("Ocorreu um erro ao retornar os comentários");
        });


    }, function (erro) {

        toastr.error("Ocorreu um erro ao excluir este comentario.");
    })
}


function editarComentario(id) {
    var uid = $(this).attr("id");
    //var elem = listView.dataSource.getByUid(uid);
    //kendo.bind($("#modalEditar"), elem);
    kendo.bind($("#modalEditar"), viewModel);
    //document.getElementById("modalEditar").style.display = "block";
    $('#modalEditar').kendoWindow({
        actions: {}, /*from Vlad's answer*/
        draggable: true,        
        height: "100px",
        modal: true,
        resizable: false,        
        width: "100px",
        title: "Editar Comentário",
        visible: false
    });
    $('#modalEditar').data('kendoWindow').open().center();
}


function confirmarEdicaoComentario() {
    $('#modalEditar').data('kendoWindow').close();      
    //document.getElementById("modalEditar").style.display = "none";
    var novosComentarios = viewModel.get("Comentario");
    var novoConteudo = $("#comentarioTxt").val();    
    console.log(novoConteudo);
    novosComentarios.Conteudo = novoConteudo;    

    Modulo.Comentario.Editar(novosComentarios, function (retorno) {
        toastr.success("Editado com sucesso");
        AtualizarPostagem(viewModel.get("Postagem"));
        Modulo.Comentario.ComentarioPostagem(viewModel.get("Postagem.PostagemId"), function (comentarios) {
            viewModel.set("Postagem.Comentarios", comentarios);
            AtualizarPostagem(viewModel.get("Postagem"));

            $("#listaComentarios").kendoListView({
                dataSource: viewModel.get("Postagem.Comentarios"),
                selectable: true,
                change: function (e) {
                    var data = e.sender.dataSource.view();
                    var selecionado = $.map(e.sender.select(), function (item) {
                        return data[$(item).index()];
                    });

                },
                template: kendo.template($("#comentarioPostagem").html())
            });

        }, function (error) {
            toastr.error("Ocorreu um erro ao retornar os comentários");
        });
        comentario = "";
        novoConteudo = "";
        //timedRefresh();
    }, function (retorno) {
        toastr.error("Ocorreu um erro ao editar os comentários");
    });
}



$(document).ready(function () {
    //  var url = "http://api.everlive.com/v1/eA9DgzMTcA6Adsgo/";
    var url = "http://localhost:3716/api/"

    setTimeout(function () {
        //metodo que traz todos os colunista e depois traz todos os administradores
        //para exibir as fotos deles no painel colunista
        Modulo.Colunista.Geral(2, function (data) {
            var Usuarios = [];
            for (var i = 0; i < data.Usuarios.length; i++) {
                Usuarios.push(data.Usuarios[i]);
            }
            
            Modulo.Colunista.Geral(1, function (data2) {
                for (var i = 0; i < data2.Usuarios.length; i++) {
                    Usuarios.push(data2.Usuarios[i]);

                    if (i == data2.Usuarios.length - 1) {
                        var dataSource = new kendo.data.DataSource({
                            data: Usuarios,
                            pageSize: 4,

                        });

                        $("#pager").kendoPager({
                            dataSource: dataSource
                        });

                        $("#listView").kendoListView({
                            dataSource: dataSource,

                            template: kendo.template($("#template").html())
                        });
                    }
                }
            },
            function (error) {
                toastr.error("Ocorreu um erro ao retornar os Administradores");
            })
        },
        function (error) {
            toastr.error("Ocorreu um erro ao retornar os colunistas");
        });
    }), 100;

    setTimeout(function () {
        $.ajax({
            url: url + "Tema",
            type: "GET",
            success: function (data) {
                var Tema = { Nome: "Todos" }
                data.unshift(Tema);
                var dataSource = new kendo.data.DataSource({
                    data: data,

                });

                $("#menu_temas").kendoListView({
                    dataSource: dataSource,
                    selectable: true,
                    change: function (e) {
                        var data = e.sender.dataSource.view();
                        var selecionado = $.map(e.sender.select(), function (item) {
                            return data[$(item).index()];
                        });
                        var postagens = viewModel.get("ListaPostagem");
                        if (selecionado[0].Nome == "Todos") {
                            DataSourcePostagem.data(viewModel.get("ListaPostagem"));
                        } else {
                            var newArray = new Array();
                            for (var i = 0; i < postagens.length; i++) {
                                for (var x = 0; x < postagens[i].Temas.length; x++) {
                                    if (postagens[i].Temas[x].TemaId == selecionado[0].TemaId) {
                                        newArray.push(postagens[i]);
                                    }
                                }


                            }
                            DataSourcePostagem.data(newArray);
                            $("#pagerPostagem").data("kendoPager").dataSource.page(1);
                        }
                        document.getElementById("listPostagem").style.display = "block";
                        document.getElementById("pagerPostagem").style.display = "block";
                        document.getElementById("postagemAqui").style.display = "none";
                        document.getElementById("comentariosPostagem").style.display = "none";

                        //Colunistas.refresh();
                    },
                    template: kendo.template($("#templateTema").html())
                });

            },
            error: function (error) {
                toastr.error("Ocorreu um erro ao retornar os temas");
            }
        });

    }, 100);

    setTimeout(function () {
        $.ajax({
            url: url + "Postagem",
            type: "GetAll",
            success: function (data) {

                viewModel.set("ListaPostagem", data);
                DataSourcePostagem = new kendo.data.DataSource({
                    data: viewModel.get("ListaPostagem"),
                    pageSize: 5
                });
                $("#listPostagem").kendoListView({
                    dataSource: DataSourcePostagem,
                    selectable: true,
                    change: function (e) {
                        var data = e.sender.dataSource.view();
                        var selecionado = $.map(e.sender.select(), function (item) {
                            return data[$(item).index()];
                        });
                        viewModel.set("Postagem", selecionado[0])
                        document.getElementById("listPostagem").style.display = "none";
                        document.getElementById("pagerPostagem").style.display = "none";
                        document.getElementById("postagemAqui").style.display = "block";
                        document.getElementById("tituloAqui").style.display = "block";
                        document.getElementById("usuarioPostagem").style.display = "block";
                        document.getElementById("comentariosPostagem").style.display = "block";
                        //$("#postagemAqui").html(selecionado[0].Titulo + '<br><br>' + '<label id="tituloAqui">'+selecionado[0].Conteudo+'</span>');
                        $("#tituloAqui").html(selecionado[0].Titulo);
                        $("#usuarioPostagem").html(selecionado[0].Usuario.Nome);
                        $("#postagemAqui").html(selecionado[0].Conteudo);


                        $("#listaComentarios").kendoListView({
                            dataSource: viewModel.get("Postagem.Comentarios"),
                            selectable: true,
                            change: function (e) {
                                var data = e.sender.dataSource.view();
                                var selecionado = $.map(e.sender.select(), function (item) {
                                    //kendo.bind($("#modalEditarComentario"), viewModel);
                                    //document.getElementById("modalEditarComentario").style.display = "block";
                                    console.log(data[$(item).index()]);
                                    viewModel.set("Comentario", data[$(item).index()]);
                                    viewModel.set("Conteudo", data[$(item).index()].Conteudo);
                                    //return data[$(item).index()];
                                });

                            },
                            template: kendo.template($("#comentarioPostagem").html())
                        });


                        //document.getElementById("window").innerHTML = selecionado[0].Conteudo;
                        //    wnd.open().center()


                    },
                    template: kendo.template($("#templatePostagem").html())
                });

                $("#pagerPostagem").kendoPager({
                    dataSource: DataSourcePostagem
                });

            },
            error: function (error) {
                toastr.error("Ocorreu um erro ao retornar as postagens");
            }
        });

    }, 100);

    $("#txtComentario").keyup(function (event) {

        if (event.charCode == 13 || event.keyCode == 13) {

            var comentario = viewModel.get("Comentario");
            comentario.Postagem = viewModel.get("Postagem");
            comentario.Usuario = Utilidades.Decrypt(localStorage.getItem("Usuario"));
            Modulo.Comentario.Salvar(comentario,
                function (sucesso) {
                    Modulo.Comentario.ComentarioPostagem(viewModel.get("Postagem.PostagemId"),
                        function (comentarios) {
                            viewModel.set("Postagem.Comentarios", comentarios);
                            AtualizarPostagem(viewModel.get("Postagem"));

                            $("#listaComentarios").kendoListView({
                                dataSource: viewModel.get("Postagem.Comentarios"),
                                selectable: true,
                                change: function (e) {
                                    var data = e.sender.dataSource.view();
                                    var selecionado = $.map(e.sender.select(), function (item) {
                                        return data[$(item).index()];
                                    });

                                },
                                template: kendo.template($("#comentarioPostagem").html())
                            });

                        }, function (error) {
                            toastr.error("Ocorreu um erro ao retornar os comentários");
                        });
                }, function (error) {

                    toastr.error("Ocorreu um erro ao inserir o comentário");
                }
                );



            viewModel.set("Comentario", new Comentario());
            $("#listaComentarios").kendoListView({
                dataSource: viewModel.get("Postagem.Comentarios"),
                selectable: true,
                change: function (e) {
                    var data = e.sender.dataSource.view();
                    var selecionado = $.map(e.sender.select(), function (item) {
                        return data[$(item).index()];
                    });

                },
                template: kendo.template($("#comentarioPostagem").html())
            });


        }
    });

    if (UsuarioLogado.Perfil.PerfilId == 2 || UsuarioLogado.Perfil.PerfilId == 1) {
        document.getElementById("Nova_Postagem").style.display = "block";
    } else if (UsuarioLogado.Perfil.PerfilId == 3) {
        document.getElementById("Nova_Postagem").style.display = "none";
    }

    kendo.bind($("#Content"), viewModel);
    kendo.bind($("#mod_pesq"), viewModel);       
    //kendo.bind($("#modalEditarComentario"), viewModel);
});


function AtualizarPostagem(postagem) {
    var listaPostagem = viewModel.get("ListaPostagem");
    for (var i = 0; i < listaPostagem.length; i++) {
        if (listaPostagem[i].PostagemId == postagem.PostagemId) {
            listaPostagem[i] = postagem;
        }
    }
}