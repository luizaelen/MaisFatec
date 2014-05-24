var Utilidades = (function () {
    var Conexao = "http://localhost:3716/Api/";
    return {
        Ajax: {
            Buscar: function (Verbo, Parametro, Sucesso, Erro) {
                $.ajax({
                    url: Conexao + Parametro,
                    type: Verbo,
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: Sucesso,
                    error: Erro
                });

            },

            Salvar: function (Parametro, Objeto, Sucesso, Erro) {
                $.ajax({
                    url: Conexao + Parametro,
                    type: "POST",
                    data: JSON.stringify(Objeto),
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: Sucesso,
                    error: Erro
                });
            },

            Editar: function (Parametro, Objeto, Sucesso, Erro) {

                $.ajax({
                    url: Conexao + Parametro,
                    type: "PUT",
                    data: JSON.stringify(Objeto),
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: Sucesso,
                    error: Erro
                });

            },

            Deletar: function (Parametro, Sucesso, Erro) {
                $.ajax({
                    url: Conexao + Parametro,
                    type: "DELETE",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: Sucesso,
                    error: Erro
                });

            },

        },

        ChecarNulo: function (parametro) {
            if (parametro === null || parametro === undefined || parametro == "")
                return true;

            return false;

        },

        Decrypt: function (param) {
            if (param != null && param != undefined)
                return JSON.parse(atob(atob(param)));
            else
                return "";
        },

        Encrypt: function (obj) {
            if (obj != null && obj != undefined)
                return btoa(btoa(JSON.stringify(obj)));
            else
                return "";
        },


        OnLoad: function () {
            var userId = getCookie('UserdID');
            if (userId == null)
                window.location = "http://localhost:53566/Default.aspx";
        },

        getCookie: function (cookieName) {
            var cookieValue = document.cookie;
            var cookieStart = cookieValue.indexOf(" " + cookieName + "=");
            if (cookieStart == -1) {
                cookieStart = cookieValue.indexOf("=");
            }
            if (cookieStart == -1) {
                cookieValue = null;
            }
            else {
                cookieStart = cookieValue.indexOf("=", cookieStart) + 1;
                var cookieEnd = cookieValue.indexOf(";", cookieStart);
                if (cookieEnd == -1) {
                    cookieEnd = cookieValue.length;
                }
                cookieValue = unescape(cookieValue.substring(cookieStart, cookieEnd));
            }
            return cookieValue;
        }

        //var userId = Utilidades.getCookie('UserdID');
        //console.log(userId);
    }
})();

//FUNCOES PARA ORGANIZACAO E REUTILIZACAO DE METODOS
//EM VEZ DE CRIAR O MESMO CODIGO EM VARIOS LUGARES, CENTRALIZEI TODO O PROCESSO, E AGORA FACO CHAMADAS AOS METODOS
//EXEMPLO:  Modulo.Colunista.Salvar() E CADA METODO POSSUI OS PARAMETROS DAS FUNCOES (que vao entre os parenteses)

var Modulo = (function (Ajax) {

    return {

        Usuario: {
            Geral: function (Sucesso, Erro) {
                //verificar pois tem 2 metodos um como verbo GETS e outro com GET
                Ajax.Buscar("GET", "Perfil/3", Sucesso, Erro);

            },

            Salvar: function (Objeto, Sucesso, Erro) {
                Ajax.Salvar("Usuario", Objeto, Sucesso, Erro);
            },

            Buscar: function (Id, Sucesso, Erro) {

                Ajax.Buscar("Usuario/" + Id, Sucesso, Erro);
            },

            Editar: function (Objeto, Sucesso, Erro) {
                Ajax.Editar("Usuario", Objeto, Sucesso, Erro);
            },

            Deletar: function (Id, Sucesso, Erro) {
                Ajax.Deletar("Usuario/" + Id, Sucesso, Erro);
            }


        },

        Colunista: {

            Geral: function (id, Sucesso, Erro) {
                //1 - administrador  , 2 - colunista , 3 - usuario comum
                Ajax.Buscar("GET", "Perfil/" +id, Sucesso, Erro);

            },

            Salvar: function (id, Sucesso, Erro) {
                Ajax.Buscar("POST", "Usuario/" + id, Sucesso, Erro);
            },

            Buscar: function (Id, Sucesso, Erro) {

                Ajax.Buscar("Usuario/" + Id, Sucesso, Erro);
            },

            Editar: function (Objeto, Sucesso, Erro) {
                Ajax.Editar("Usuario", Objeto, Sucesso, Erro);
            },

            Deletar: function (Id, Sucesso, Erro) {
                Ajax.Deletar("Usuario/" + Id, Sucesso, Erro);
            }

        },

        Postagem: {
            Geral: function (Sucesso, Erro) {
                Ajax.Buscar("GetAll", "Postagem", Sucesso, Erro);
            },

            Colunista: function (idColunista, sucesso, erro) {

                Ajax.Buscar("POST", "Postagem/" + idColunista, sucesso, Error);

            },

            Salvar: function (Objeto, Sucesso, Erro) {
                Ajax.Salvar("Postagem", Objeto, Sucesso, Erro);
            },

            Buscar: function (Id, Sucesso, Erro) {
                Ajax.Buscar("GET", "Postagem/" + Id, Sucesso, Erro);
            },

            Editar: function (Objeto, Sucesso, Erro) {
                Ajax.Editar("Postagem", Objeto, Sucesso, Erro);
            },

            Deletar: function (Id, Sucesso, Erro) {
                Ajax.Deletar("Postagem/" + Id, Sucesso, Erro);
            }


        },

        Tema: {
            Geral: function (Sucesso, Erro) {
                Ajax.Buscar("GET", "Tema", Sucesso, Erro);
            },

            Salvar: function (Objeto, Sucesso, Erro) {
                Ajax.Salvar("Tema", Objeto, Sucesso, Erro);
            },

            Buscar: function (Id, Sucesso, Erro) {
                Ajax.Buscar("Tema/" + Id, Sucesso, Erro);
            },

            Editar: function (Objeto, Sucesso, Erro) {
                Ajax.Editar("Tema", Objeto, Sucesso, Erro);
            },

            Deletar: function (Id, Sucesso, Erro) {
                Ajax.Deletar("Tema/" + Id, Sucesso, Erro);
            }


        },

        Comentario: {

            Salvar: function (objeto, sucesso, erro) {

                Ajax.Salvar("Comentario", objeto, sucesso, erro);
            },

            Excluir: function (idComentario, sucesso, erro) {
                Ajax.Deletar("Comentario/" + idComentario, sucesso, erro);
            },

            Buscar: function (Id, Sucesso, Erro) {
                Ajax.Buscar("Gets","Comentario/" + Id, Sucesso, Erro);
            },

            ComentarioPostagem: function (idPostagem, sucesso, erro) {

                Ajax.Buscar("GET", "Comentario/" + idPostagem, sucesso, erro);
            },


            Editar: function (Comentario, sucesso, erro) {
                Ajax.Editar("Comentario", Comentario, sucesso, erro);
            }
        },

        TipoPostagem: {

            BuscarTodos: function (sucesso, erro) {
                Ajax.Buscar("GET", "TipoPostagem", sucesso, erro)
            }

        }
    }



})(Utilidades.Ajax);


function ConversaoData(data) {
    data = new Date(data);

    return data.getDate() + "/" + data.getMonth() + "/" + data.getFullYear();

}

function RetornarHora(data) {
    data = new Date(data);

    return data.getHours() + ":" + data.getMinutes();
}