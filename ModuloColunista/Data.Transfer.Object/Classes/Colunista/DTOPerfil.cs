using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Transfer.Object.Classes.Colunista
{
    /// <summary>
    /// Objeto base de transferência entre as camadas
    /// </summary>
    public class DTOPerfil
    {
        public List<DTOUsuario> Usuarios { get; set; }
        public string Nome { get; set; }
        public int PerfilId { get; set; }

        /// <summary>
        /// Método construtor onde ao iniciar a aplicação todas as variáveis
        /// serão instânciadas com seus respectivos valores
        /// </summary>
        public DTOPerfil()
        {
            Usuarios = new List<DTOUsuario>();
            Nome = "";
            PerfilId = 0;
        }
    }

}
