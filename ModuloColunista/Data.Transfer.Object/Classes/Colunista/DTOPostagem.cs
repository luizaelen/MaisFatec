using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Transfer.Object.Classes.Colunista
{
    /// <summary>
    /// Objeto base de transferência entre as camadas
    /// </summary>
    public class DTOPostagem
    {
        public int PostagemId { get; set; }
        public DateTime DataPostagem { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public DTOUsuario Usuario { get; set; }
        public List<DTOTema> Temas { get; set; }
        public DTOTipoPostagem TipoPostagem { get; set; }
        public List<DTOComentario> Comentarios { get; set; }
        
        /// <summary>
        /// Método construtor onde ao iniciar a aplicação todas as variáveis
        /// serão instânciadas com seus respectivos valores
        /// </summary>
        public DTOPostagem()
        {
            PostagemId = 0;
            DataPostagem = new DateTime();
            Titulo = "";
            Conteudo = "";
            Comentarios = new List<DTOComentario>();
            Usuario = new DTOUsuario();
            TipoPostagem = new DTOTipoPostagem();
            Temas = new List<DTOTema>();
        }
    }
}
