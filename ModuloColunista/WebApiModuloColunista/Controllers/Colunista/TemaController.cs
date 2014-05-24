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
    public class TemaController : ApiController
    {
        // GET api/tema
        public List<DTOTema> Get()
        {
            BLLTema BLLobjeto = new BLLTema();
            return BLLobjeto.SelecionarTemas();
        }
        // GET api/tema/5
        public DTOTema Get(int id)
        {
            BLLTema BLLobjeto = new BLLTema();
            return BLLobjeto.SelecionarTema(id);
        }
        // POST api/tema
        public int Post(DTOTema tema)
        {
            BLLTema BLLobjeto = new BLLTema();
            return BLLobjeto.InserirTema(tema);
        }
        // PUT api/tema/5
        public int Put(DTOTema tema)
        {
            BLLTema BLLobjeto = new BLLTema();
            return BLLobjeto.AtualizarTema(tema);
        }
        // DELETE api/tema/5
        public int Delete(int id)
        {
            BLLTema BLLobjeto = new BLLTema();
            return BLLobjeto.DeletarTema(id);
        }
    }
}
