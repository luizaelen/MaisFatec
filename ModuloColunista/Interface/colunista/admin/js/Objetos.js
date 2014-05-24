//ESTE ARQUIVO É PARA CRIAR AS FUNCOES CONSTRUTORAS, QUE QUANDO CRIARMOS OS OBJETOS SERÃO IGUAIS AO SERVIDOR.


//funcao construtora de postagem
var Postagem = function () {
    this.PostagemId = null;
    this.TipoPostagem = {
        TipoPostagemId: null,
        Tipo: ""
    }
    this.DataPostagem = null; // tem que enviar string
    this.Titulo = "";
    this.Conteudo = "";
    this.Usuario = new Usuario();
    this.Temas = [];
    this.Comentarios = [];

}




//funcao construtora de Usuario
var Usuario = function () {
    this.UsuarioId = null;
    this.Nome = "";
    this.Perfil = new Perfil();
    this.Postagens = [];
    this.Comentarios =  [];

}



var Comentario = function () {
    this.ComentarioId = null;
    this.Conteudo = "";
    this.DataComentario = null // precisa enviar string;
    this.Usuario = new Usuario();
    this.Postagem = new Postagem();

}



//funcao construtora de Tema

var Tema = function () {
    this.TemaId = null;
    this.DataTema = null; // precisa enviar string;
    this.Nome = "";

}

var TipoPostagem = function () {
    this.TipoPostagemId = null;
    this.Tipo = "";
   
}

var Perfil = function () {
    this.Usuarios = [];
    this.Nome = "";
    this.PerfilId = null;

}


