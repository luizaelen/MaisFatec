var Postagem = function(){
    this.PostagemId = null;
    this.Tipo = "";
    this.DataPostagem = null; // tem que enviar string
    this.Titulo = "";
    this.Conteudo = "";
    this.Colunista = new Colunista();

}

var Colunista = function (){
    this.ColunistaId = null;
    this.Usuario = new Usuario();
    this.Foto = "";

}

var Usuario = function () {
    this.UsuarioId = null;
    this.Nome = "";

}

var Comentario = function () {
    this.ComentarioId = null;
    this. DataComentario = null // precisa enviar string;
    this.Usuario = new Usuario();
    this.Postagem = new Postagem();

}

var Tema = function () {
    this.TemaId = null;
    this.DataTema = null; // precisa enviar string;
    this.Temas = "";
    this.Postagem = new Postagem();
}

