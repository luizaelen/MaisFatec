using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Access.Layer.Classes.Colunista;
using Data.Transfer.Object.Classes.Colunista;

namespace Business.Logic.Layer.Classes.Colunista
{
    /// <summary>
    /// Classe BLLComentario referente a camada de Negócios
    /// Contém todos os metodos  encapsulados que fazem as transferencias dos objetos entre as camadas.
    /// </summary>
    public class BLLComentario
    {
        public List<DTOComentario> SelecionarComentarios()
        {
            DALComentario DALCom = new DALComentario();
            return DALCom.SelectAll();
        }


        public List<DTOComentario> SelecionarComentario(int idPostagem)
        {
            DALComentario DALCom = new DALComentario();
            return DALCom.SelectAllById(idPostagem);
        }

        public DTOComentario SelecionarComentarioId(int id)
        {
            DALComentario DALCom = new DALComentario();
            return DALCom.SelectById(id);
        }

        

        public int AtualizarComentario(DTOComentario comentario)
        {
            DALComentario DALCom = new DALComentario();

            try
            {
                return DALCom.Update(comentario);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public int InserirComentario(DTOComentario comentario)
        {
            DALComentario DALCom = new DALComentario();

            try
            {
                return DALCom.Insert(comentario);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public int DeletarComentario(int codigo)
        {
            DALComentario DALCom = new DALComentario();
            try
            {
                return DALCom.Delete(codigo);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
