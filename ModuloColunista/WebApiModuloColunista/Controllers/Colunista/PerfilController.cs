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
    public class PerfilController : ApiController
    {
        // GET api/colunista
        public List<DTOPerfil> Get()
        {
            BLLPerfil BLLobjeto = new BLLPerfil();
            return BLLobjeto.SelecionarColunistas();
        }

        // GET api/colunista/5
        public DTOPerfil Get(int id)
        {
            BLLPerfil BLLobjeto = new BLLPerfil();
            return BLLobjeto.SelecionarColunista(id);
        }

        // POST api/colunista
        public int Post(DTOPerfil perfil)
        {
            BLLPerfil BLLobjeto = new BLLPerfil();
            return BLLobjeto.InserirColunista(perfil);
        }

        // PUT api/colunista/5
        public int Put(DTOPerfil colunista)
        {
            BLLPerfil BLLobjeto = new BLLPerfil();
            return BLLobjeto.AtualizarColunista(colunista);
        }

        
    }
}
