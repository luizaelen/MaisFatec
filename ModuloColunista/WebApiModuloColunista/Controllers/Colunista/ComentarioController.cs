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
    public class ComentarioController : ApiController
    {
        // GET api/comentario
        public List<DTOComentario> Get()
        {
            BLLComentario BLLobjeto = new BLLComentario();
            return BLLobjeto.SelecionarComentarios();
        }

        // GET api/comentario/5
        public List<DTOComentario> Get(int id)
        {
            BLLComentario BLLobjeto = new BLLComentario();
            return BLLobjeto.SelecionarComentario(id);
        }

        // GET api/comentario/5
        [AcceptVerbs("gets")]
        public DTOComentario GetId(int id)
        {
            BLLComentario BLLobjeto = new BLLComentario();
            return BLLobjeto.SelecionarComentarioId(id);
        }

        // POST api/comentario
        public int Post(DTOComentario comentario)
        {
            BLLComentario BLLobjeto = new BLLComentario();
            return BLLobjeto.InserirComentario(comentario);
        }

        // PUT api/comentario/5
        public int Put(DTOComentario comentario)
        {
            BLLComentario BLLobjeto = new BLLComentario();
            return BLLobjeto.AtualizarComentario(comentario);
        }

        // DELETE api/comentario/5
        public int Delete(int id)
        {
            BLLComentario BLLobjeto = new BLLComentario();
            return BLLobjeto.DeletarComentario(id);
        }
    }
}
