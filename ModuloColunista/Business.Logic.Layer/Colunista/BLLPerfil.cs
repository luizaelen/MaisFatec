using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Access.Layer.Classes.Colunista;
using Data.Transfer.Object.Classes.Colunista;

namespace Business.Logic.Layer.Classes.Colunista
{
    /// <summary>
    /// Classe BLLColunista referente a camada de Negócios
    /// Contém todos os metodos  encapsulados que fazem as transferencias dos objetos entre as camadas.
    /// </summary>
    public class BLLPerfil
    {
        public List<DTOPerfil> SelecionarColunistas()
        {
            DALPerfil DALCom = new DALPerfil();
            return DALCom.SelectAll();
        }


        public DTOPerfil SelecionarColunista(int codigo)
        {
            DALPerfil DALCom = new DALPerfil();
            return DALCom.Select(codigo);
        }


        public int AtualizarColunista(DTOPerfil colunista)
        {
            DALPerfil DALCom = new DALPerfil();

            try
            {
                return DALCom.Update(colunista);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public int InserirColunista(DTOPerfil colunista)
        {
            DALPerfil DALCom = new DALPerfil();

            try
            {
                return DALCom.Insert(colunista);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
