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
    public class PostagemController : ApiController
    {
        // GET api/postagem        
        [HttpGet]
        [AcceptVerbs("GetAll")]
        public List<DTOPostagem> GetGeral()
        {
            BLLPostagem BLLobjeto = new BLLPostagem();
            return BLLobjeto.SelecionarPostagems();
        }

        [HttpPost]
        public List<DTOPostagem> GetPostagemColunista(int id)
        {
            BLLPostagem BLLobjeto = new BLLPostagem();
            return BLLobjeto.SelecionarPostagensColunista(id);
        }

        [HttpGet]       
        [AcceptVerbs("gets")]
        public List<DTOPostagem> Ultimas()
        {
            BLLPostagem BLLobjeto = new BLLPostagem();
            return BLLobjeto.SelecionarUltimasPostagens();
        }

        // GET api/postagem/5        
        public DTOPostagem Get(int id)
        {
            BLLPostagem BLLobjeto = new BLLPostagem();
            return BLLobjeto.SelecionarPostagem(id);
        }

        // POST api/postagem        
        public int Post(DTOPostagem postagem)
        {
            BLLPostagem BLLobjeto = new BLLPostagem();
            return BLLobjeto.InserirPostagem(postagem);
        }

        // PUT api/postagem/5        
        public int Put(DTOPostagem postagem)
        {
            BLLPostagem BLLobjeto = new BLLPostagem();
            return BLLobjeto.AtualizarPostagem(postagem);
        }

        // DELETE api/postagem/5        
        public int Delete(int id)
        {
            BLLPostagem BLLobjeto = new BLLPostagem();
            return BLLobjeto.DeletarPostagem(id);
        }
    }
}
