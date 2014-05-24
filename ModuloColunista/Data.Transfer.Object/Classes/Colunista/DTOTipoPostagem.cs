using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Transfer.Object.Classes.Colunista
{
    public class DTOTipoPostagem
    {
        public int TipoPostagemId { get; set; }
        public string Tipo { get; set; }

        public DTOTipoPostagem()
        {
            TipoPostagemId = 0;
            Tipo = "";
        }
    }
}
