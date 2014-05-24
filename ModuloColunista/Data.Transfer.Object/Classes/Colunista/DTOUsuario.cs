using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Transfer.Object.Classes.Colunista
{
    /// <summary>
    /// Objeto base de transferência entre as camadas
    /// </summary>
    public class DTOUsuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public DTOPerfil Perfil { get; set; }
        public List<DTOPostagem> Postagens { get; set; }
        //public List<DTOTema> Temas { get; set; }
        public List<DTOComentario> Comentarios { get; set; }


        //31338233
        //

        /// <summary>
        /// Método construtor onde ao iniciar a aplicação todas as variáveis
        /// serão instânciadas com seus respectivos valores
        /// </summary>
        public DTOUsuario()
        {
            UsuarioId = 0;
            Nome = "";
            Perfil = new DTOPerfil();
            Postagens = new List<DTOPostagem>();
            //Temas = new List<DTOTema>();
            Comentarios = new List<DTOComentario>();
        }
    }

}
