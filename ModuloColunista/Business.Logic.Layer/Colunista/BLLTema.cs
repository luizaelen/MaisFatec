using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Access.Layer.Classes.Colunista;
using Data.Transfer.Object.Classes.Colunista;

namespace Business.Logic.Layer.Classes.Colunista
{
    /// <summary>
    /// Classe BLLTema referente a camada de Negócios
    /// Contém todos os metodos  encapsulados que fazem as transferencias dos objetos entre as camadas.
    /// </summary>
    public class BLLTema
    {
        public List<DTOTema> SelecionarTemas()
        {
            DALTema DALobjeto = new DALTema();
            return DALobjeto.SelectAll();
        }


        public DTOTema SelecionarTema(int codigo)
        {
            DALTema DALobjeto = new DALTema();
            return DALobjeto.Select(codigo);
        }


        public int AtualizarTema(DTOTema tema)
        {
            DALTema DALobjeto = new DALTema();
            return DALobjeto.Update(tema);
        }


        public int InserirTema(DTOTema tema)
        {
            DALTema DALobjeto = new DALTema();
            return DALobjeto.Insert(tema);
        }


        public int DeletarTema(int codigo)
        {
            DALTema DALobjeto = new DALTema();
            return DALobjeto.Delete(codigo);
        }
    }
}
