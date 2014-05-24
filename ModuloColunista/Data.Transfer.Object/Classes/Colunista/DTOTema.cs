using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Transfer.Object.Classes.Colunista
{
    /// <summary>
    /// Objeto base de transferência entre as camadas
    /// </summary>
    public class DTOTema
    {
        public int TemaId { get; set; }
        public DateTime DataTema { get; set; }
        public string Nome { get; set; }
        public List<DTOPostagem> Postagens { get; set; }

        /// <summary>
        /// Método construtor onde ao iniciar a aplicação todas as variáveis
        /// serão instânciadas com seus respectivos valores
        /// </summary>
        public DTOTema()
        {
            TemaId = 0;
            DataTema = new DateTime();
            Nome = "";
            Postagens = new List<DTOPostagem>();
        }
    }
}
