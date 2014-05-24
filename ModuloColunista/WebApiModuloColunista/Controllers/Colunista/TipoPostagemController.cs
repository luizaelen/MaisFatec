using Business.Logic.Layer.Colunista;
using Data.Transfer.Object.Classes.Colunista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiModuloColunista.Controllers.Colunista
{
    public class TipoPostagemController : ApiController
    {
        // GET api/TipoPostagem        
        public List<DTOTipoPostagem> Get()
        {
            BLLTipoPostagem BLLobjeto = new BLLTipoPostagem();
            return BLLobjeto.SelecionarPostagems();
        }


        // GET api/TipoPostagem/5        
        public DTOTipoPostagem Get(int id)
        {
            BLLTipoPostagem BLLobjeto = new BLLTipoPostagem();
            return BLLobjeto.SelecionarPostagem(id);
        }

        // POST api/TipoPostagem        
        public bool Post(DTOTipoPostagem postagem)
        {
            BLLTipoPostagem BLLobjeto = new BLLTipoPostagem();
            return BLLobjeto.InserirPostagem(postagem);
        }

        // PUT api/TipoPostagem/5        
        public bool Put(DTOTipoPostagem postagem)
        {
            BLLTipoPostagem BLLobjeto = new BLLTipoPostagem();
            return BLLobjeto.AtualizarPostagem(postagem);
        }

    }
}
