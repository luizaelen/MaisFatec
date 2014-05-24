var wnd;
var viewModel = new kendo.data.ObservableObject({
    Postagem: new Postagem(),
    TiposPostagens: [],
    Tema: new Tema(),
    ListaTemas: [],
    Salvar: Salvar,
    PreVisualizar: PreVisualizar,
    Voltar: Voltar,

    deletarTema: function (data) {
        var tema = data.sender.dataItem(data.item.index());
        var listaTemasPostagem = this.Postagem.Temas;
        var help = [];;
        for (var i = 0; i < listaTemasPostagem.length; i++) {
            if (listaTemasPostagem[i].TemaId !== tema.TemaId)
                help.push(listaTemasPostagem[i]);

        }
        viewModel.set("Postagem.Temas", help);
    }

})

//EVENTO PARA SALVAR NOVA POSTAGEM
function Salvar() {

    //ESTOU ADICIONANDO UMA DATA DA POSTAGEM, QUE É A DATA DE AGORA

    // novas validações para todos os campos
    function validaCampos() {
        var tmpstring = $("#temapostagem").val();
        if (tmpstring == null || tmpstring == "") {
            //alert('Preencha o Tema da publicação!');
            toastr.error("Preencha o tema da publicação");
            return false;
        }


        var tmpstring = $("#editor").val();
        if (tmpstring.length < 12) {
            toastr.error('Publicação muito curta.');
            return false;
        }

        var tmpstring = $("#titulo_postagem").val();
        if (tmpstring == null || tmpstring == "") {
            toastr.error('Preencha o Título da publicação');
            return false;
        }

        var tmpstring = $("#tipo_postagem").val();
        if (tmpstring == null || tmpstring == "") {
            toastr.error('Preencha o tipo da publicação!');
            return false;
        }
        //retorno da função
        return true;
    }

    if (validaCampos()) {
        //METODO PARA ENVIAR POSTAGEM DA VIEWMODEL PARA O SERVIDOR
        if (viewModel.get("Postagem.PostagemId") == null) {
            var novaPostagem = viewModel.get("Postagem");
            novaPostagem.Temas.push(viewModel.get("TemaId"));
            novaPostagem.DataPostagem = new Date();
            novaPostagem.Usuario = Utilidades.Decrypt(localStorage.getItem("Usuario"));
            console.log(JSON.stringify(novaPostagem));
            viewModel.set("Postagem", novaPostagem);

            //salvar postagem
            Modulo.Postagem.Salvar(novaPostagem, function (sucesso) {
                if (sucesso == 0) {

                    //FUNCAO DISPARADA CASO O SERVIDOR RESPONDA QUE CONSEGUIU SALVAR
                    viewModel.set("Postagem", new Postagem());
                    toastr.success("Postagem enviada com sucesso");
                    Voltar();
                } else {
                    toastr.error("Aconteceu um erro ao inserir a postagem");
                }
            },
                 function (error) {
                     toastr.error("Aconteceu um erro ao inserir a postagem");
                 });
        } else {

            //editar postagem;
            Modulo.Postagem.Editar(viewModel.get("Postagem"), function (sucesso) {
                if (sucesso == 0 || sucesso == true) {
                    toastr.success("Postagem editada com sucesso");
                }

            },
            function (error) {
                toastr.error("Erro ao editar postagem");
            });
        }
    }
}

function Voltar() {
    document.getElementById("conteudo").style.display = "block";
    document.getElementById("Pre_Visualizar").style.display = "none";

}



function PreVisualizar() {

    document.getElementById("Pre_Visualizar").style.display = "block";

    wnd.open().center();
    $("#PrePostagem").html(viewModel.get("Postagem.Conteudo"));


}

//remove caracteres especiais e espaços da palavra
function retiraAcento(palavra) {
    comAcento = "áàãâäéèêëíìîïóòõôöúùûüçÁÀÃÂÄÉÈÊËÍÌÎÏÓÒÕÖÔÚÙÛÜÇ";
    semAcento = "aaaaaeeeeiiiiooooouuuucAAAAAEEEEIIIIOOOOOUUUUC";
    var palavraSemAcento = "";
    for (var i = 0; i < palavra.length; i++) {
        if (comAcento.indexOf(palavra.charAt(i)) != -1) {
            palavraSemAcento += semAcento.substr(comAcento.search(palavra.substr(i, 1)), 1);
        } else {
            palavraSemAcento += palavra.substr(i, 1);
        }
    }
    return palavraSemAcento.replace(/ /g, '').toUpperCase();
}

//verifica se o tema ja existe na lista de temas da view model
function checarTemaNome(temaNome) {
    var listaTema = viewModel.get("ListaTemas");
    var retorno = false

    for (var i = 0; i < listaTema.length; i++) {
        if (retiraAcento(listaTema[i].Nome) == retiraAcento(temaNome)) {
            retorno = true;
            break;
        }
    }

    return retorno;
}

//verifica se o id do tema ja existe
function checarTema(temaId) {
    var listaTema = viewModel.get("ListaTemas");
    var retorno = false
    for (var i = 0; i < listaTema.length; i++) {
        if (listaTema[i].TemaId == temaId) {
            retorno = true;
            break;
        }
    }
    return retorno;
}

$(document).ready(function () {

    //METODO PARA INICIALIZAR O EDITOR DE TEXTO
    $("#editor").kendoEditor({
        tools: [
                "bold",
                "italic",
                "underline",
                "strikethrough",
                "justifyLeft",
                "justifyCenter",
                "justifyRight",
                "justifyFull",
                "insertUnorderedList",
                "insertOrderedList",
                "indent",
                "outdent",
                "createLink",
                "unlink",
                //"insertImage",
                "subscript",
                "superscript",
                "createTable",
                "addRowAbove",
                "addRowBelow",
                "addColumnLeft",
                "addColumnRight",
                "deleteRow",
                "deleteColumn",
                "viewHtml",
                "formatting",
                "fontName",
                "fontSize",
                "foreColor",
                "backColor"
        ]

    });


    //REDIRECIONA PARA NOVA PUBLICACAO
    $("#NovaPublicacao").click(function () {
        viewModel.set("Postagem", new Postagem());
        localStorage.setItem("Postagem", Utilidades.Encrypt(new Postagem()));

    });

    //REDIRECIONA PARA O MENU PRINCIPAL
    $("#RetornarMenu").click(function () {
        location.href = "../menu_principal.aspx";
    });

    //REDIRECIONA PARA EDITAR PUBLICACAO
    $("#EditarPublicacao").click(function () {
        location.href = "editar.aspx";
    });


    //REDIRECIONA PARA DELETAR PUBLICACAO
    $("#ExcluirPublicacao").click(function () {
        location.href = "deletar.aspx";
    });

    Modulo.TipoPostagem.BuscarTodos(function (tipos) {
        viewModel.set("TiposPostagens", tipos);
    }, function (erro) {
        toastr.error("Erro ao retornar os tipos  de postagens.");
    })


    Modulo.Tema.Geral(function (temas) {
        viewModel.set("ListaTemas", temas);

        $("#tema_postagem").kendoAutoComplete({
            dataTextField: "Nome",
            dataSource: viewModel.get("ListaTemas"),
            filter: "startswith",
            placeholder: "Cadastrar um Tema",
            select: function (data) {

                var tema = data.sender.dataItem(data.item.index());
                if (tema.Nome.length == 0)
                    toastr.error("Você não digitou um tema.");
                else
                if (!checarTemaNome(tema.Nome) || !checarTema(tema.TemaId)) {
                    viewModel.get("Postagem.Temas").push(tema);
                    toastr.success("Tema cadastrado com sucesso.");
                } else {
                    toastr.success("Tema já Existe.");
                }
            }

        });

    }, function (erro) {
        toastr.error("Erro ao retornar os temas  de postagens.");
    })

    wnd = $("#PrePostagem").kendoWindow({
        title: "",
        modal: true,
        visible: false,
        resizable: false,
        width: 600
    }).data("kendoWindow");


    $("#tema_postagem").keyup(function (event) {

        if (event.keyCode == 13) {
            var tema = viewModel.get("Tema");
            if (tema.Nome.length == 0)
                toastr.error("Você não digitou um tema.");
            else
            if (checarTemaNome(tema.Nome) || checarTema(tema.TemaId)) {
                toastr.error("Tema já cadastrado!");
            } else if (tema.TemaId == null || tema.TemaId == "" || tema.TemaId || undefined) {

                Modulo.Tema.Salvar(tema, function (sucesso) {
                    if (sucesso == 0 || sucesso == true) {
                        Modulo.Tema.Geral(function (temas) {
                            viewModel.set("ListaTemas", temas);
                            //Mostra a mensagem de que o tema foi cadastrado no banco de dados com sucesso.
                            toastr.success("Tema cadastrado com sucesso!");
                            viewModel.set("Nome", "");

                            //$("#tema_postagem").kendoAutoComplete({
                            //    dataTextField: "Nome",
                            //    dataSource: viewModel.get("ListaTemas"),
                            //    filter: "startswith",
                            //    placeholder: "Busque um tema",
                            //    select: function (data) {

                            //        var tema = data.sender.dataItem(data.item.index());
                            //        if (!checarTema(tema.TemaId))
                            //            viewModel.get("Postagem.Temas").push(tema);
                            //    }

                            //});

                            for (var i = 0; i < temas.length; i++) {
                                if (temas[i].Nome === viewModel.Tema.Nome) {
                                    if (!checarTema(temas[i].TemaId))
                                        viewModel.get("Postagem.Temas").push(temas[i]);
                                    break;
                                }
                            }

                        }, function () {

                        })

                    }
                }, function (error) {

                });
            }
        }


    });



    var postagem = Utilidades.Decrypt((localStorage.getItem("Postagem")));
    if (postagem !== null && postagem !== undefined) {
        viewModel.set("Postagem", postagem);
    } else {
        viewModel.set("Postagem", new Postagem());
        localStorage.setItem("Postagem", Utilidades.Encrypt(new Postagem()));
    }


    kendo.bind($("#Content"), viewModel);
});
