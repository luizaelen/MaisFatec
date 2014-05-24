using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Access.Layer.Classes.Colunista;
using Data.Transfer.Object.Classes.Colunista;

namespace Business.Logic.Layer.Classes.Colunista
{
    /// <summary>
    /// Classe BLLPostagem referente a camada de Negócios
    /// Contém todos os metodos  encapsulados que fazem as transferencias dos objetos entre as camadas.
    /// </summary>
    public class BLLPostagem
    {
        public List<DTOPostagem> SelecionarPostagems()
        {
            DALPostagem DALobjeto = new DALPostagem();
            return DALobjeto.SelectAll();
        }

        public List<DTOPostagem> SelecionarPostagensColunista(int codigo)
        {
            DALPostagem DALobjeto = new DALPostagem();
            return DALobjeto.SelectPostagensColunista(codigo);
        }

        public List<DTOPostagem> SelecionarUltimasPostagens()
        {
            DALPostagem DALobjeto = new DALPostagem();
            return DALobjeto.SelectUltimas();
        }


        public DTOPostagem SelecionarPostagem(int codigo)
        {
            DALPostagem DALobjeto = new DALPostagem();
            return DALobjeto.Select(codigo);
        }


        public int AtualizarPostagem(DTOPostagem postagem)
        {
            DALPostagem DALobjeto = new DALPostagem();

            try
            {
                return DALobjeto.Update(postagem);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public int InserirPostagem(DTOPostagem postagem)
        {
            DALPostagem DALobjeto = new DALPostagem();

            try
            {
                return DALobjeto.Insert(postagem);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public int DeletarPostagem(int codigo)
        {
            DALPostagem DALobjeto = new DALPostagem();
            try
            {
                return DALobjeto.Delete(codigo);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
