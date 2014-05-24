using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Access.Layer.Classes.Colunista;
using Data.Transfer.Object.Classes.Colunista;

namespace Business.Logic.Layer.Classes.Colunista
{
    /// <summary>
    /// Classe BLLUsuario referente a camada de Negócios
    /// Contém todos os metodos  encapsulados que fazem as transferencias dos objetos entre as camadas.
    /// </summary>
    public class BLLUsuario
    {
        public List<DTOUsuario> SelecionarUsuarios()
        {
            DALUsuario DALobjeto = new DALUsuario();
            return DALobjeto.SelectAll();
        }


        public DTOUsuario SelecionarUsuario(int codigo)
        {
            DALUsuario DALobjeto = new DALUsuario();
            return DALobjeto.Select(codigo);
        }

        public DTOUsuario SelecionarUsuarioId(int codigo)
        {
            DALUsuario DALobjeto = new DALUsuario();
            return DALobjeto.SelectId(codigo);
        }


        public bool AtualizarUsuario(DTOUsuario usuario)
        {
            DALUsuario DALobjeto = new DALUsuario();
            return DALobjeto.Update(usuario);

        }


        public bool InserirUsuario(int usuarioId)
        {
            DALUsuario DALobjeto = new DALUsuario();
            return DALobjeto.Insert(usuarioId);

        }


        public bool DeletarUsuario(int codigo)
        {
            DALUsuario DALobjeto = new DALUsuario();
            return DALobjeto.Delete(codigo);

        }
    }

}
