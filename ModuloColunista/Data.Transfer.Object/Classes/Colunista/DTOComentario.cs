using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Transfer.Object.Classes.Colunista
{

    /// <summary>
    /// Objeto base de transferência entre as camadas
    /// </summary>
    public class DTOComentario
    {
        public int ComentarioId { get; set; }
        public string Conteudo { get; set; }
        public DateTime DataComentario { get; set; }
        public DTOUsuario Usuario { get; set; }
        public DTOPostagem Postagem { get; set; }

        /// <summary>
        /// Método construtor onde ao iniciar a aplicação todas as variáveis
        /// serão instânciadas com seus respectivos valores
        /// </summary>
        public DTOComentario()
        {
            ComentarioId = 0;
            DataComentario = new DateTime();
            Conteudo = "";
            Usuario = new DTOUsuario();
            Postagem = new DTOPostagem();
        }
    }
}
