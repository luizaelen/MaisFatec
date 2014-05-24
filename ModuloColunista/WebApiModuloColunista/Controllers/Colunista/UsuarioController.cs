using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Business.Logic.Layer.Classes.Colunista;
using Data.Transfer.Object.Classes.Colunista;

namespace WebApiModuloColunista.Controllers.Colunista
{
    public class UsuarioController : ApiController
    {
        // GET api/usuario
        public List<DTOUsuario> Get()
        {
            BLLUsuario BLLobjeto = new BLLUsuario();
            return BLLobjeto.SelecionarUsuarios();
        }

        // GET api/usuario/5
        public DTOUsuario Get(int id)
        {
            BLLUsuario BLLobjeto = new BLLUsuario();
            return BLLobjeto.SelecionarUsuario(id);
        }

        // GET api/usuario/5
        [AcceptVerbs("gets")]
        public DTOUsuario Gets(int id)
        {
            BLLUsuario BLLobjeto = new BLLUsuario();
            return BLLobjeto.SelecionarUsuarioId(id);
        }

        // POST api/usuario
        public bool Post(int Id)
        {
            BLLUsuario BLLobjeto = new BLLUsuario();
            return BLLobjeto.InserirUsuario(Id);
        }

        // PUT api/usuario/5
        public bool Put(DTOUsuario usuario)
        {
            BLLUsuario BLLobjeto = new BLLUsuario();
            return BLLobjeto.AtualizarUsuario(usuario);
        }

        // DELETE api/usuario/5
        public bool Delete(int id)
        {
            BLLUsuario BLLobjeto = new BLLUsuario();
            return BLLobjeto.DeletarUsuario(id);
        }
    }
}
