using Data.Access.Layer.Classes.Colunista;
using Data.Transfer.Object.Classes.Colunista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Logic.Layer.Colunista
{
    public class BLLTipoPostagem
    {
        public List<DTOTipoPostagem> SelecionarPostagems()
        {
            DALTipoPostagem DALobjeto = new DALTipoPostagem();
            return DALobjeto.SelectAll();
        }

        

        public DTOTipoPostagem SelecionarPostagem(int codigo)
        {
            DALTipoPostagem DALobjeto = new DALTipoPostagem();
            return DALobjeto.Select(codigo);
        }


        public bool AtualizarPostagem(DTOTipoPostagem postagem)
        {
            DALTipoPostagem DALobjeto = new DALTipoPostagem();

            try
            {
                return DALobjeto.Update(postagem);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public bool InserirPostagem(DTOTipoPostagem postagem)
        {
            DALTipoPostagem DALobjeto = new DALTipoPostagem();

            try
            {
                return DALobjeto.Insert(postagem);
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
