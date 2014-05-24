using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Security.Layer.Encryption;

namespace WebApiModuloColunista.Controllers.Security
{
    public class SecurityController : ApiController
    {
        [HttpPost]        
        //[Authorize(Users="ADMINISTRADOR")]
        public Retorno Encrypts(Envio sec)
        {
            Retorno retorno = new Retorno();

            retorno.texto = sec.texto;
            retorno.ASCIIencript = Encrypt.EncryptString(sec.texto);
            //retorno.Md5encript = Encrypt.EncryptStringMd5(sec.texto);
            //retorno.Md5Strongencript = Encrypt.EncryptStrong(sec.texto);
            //retorno.Sha256encript = Encrypt.EncryptStringSha256(sec.texto);

            return retorno;
        }       

    }
}
