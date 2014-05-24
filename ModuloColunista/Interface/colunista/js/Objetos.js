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


var Comentario = function () {
    this.ComentarioId = null;
    this.Conteudo = "";
    this. DataComentario = null // precisa enviar string;
    this.Usuario = new Usuario();
    this.Postagem = new Postagem();
}




