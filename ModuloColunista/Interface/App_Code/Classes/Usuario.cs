using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Usuario
/// </summary>
public class Usuario
{
        private int _idUsuario;
        private string _senhaUsuario;
        private string _loginUsuario;
        private string _emailUsuario;
        private string _hashidUsuario;
        private string _rgUsuario;
        private string _registroUsuario;
        private PerfilC perfilC;
        private Permissoes permissoes;

        public int IdUsuario
        {
            get { return _idUsuario; }
            set { _idUsuario = value; }
        }
        public string SenhaUsuario
        {
            get { return _senhaUsuario; }
            set { _senhaUsuario = value; }
        }
        public string LoginUsuario
        {
            get { return _loginUsuario; }
            set { _loginUsuario = value; }
        }
        public string EmailUsuario
        {
            get { return _emailUsuario; }
            set { _emailUsuario = value; }
        }
        public string HashidUsuario
        {
            get { return _hashidUsuario; }
            set { _hashidUsuario = value; }
        }
        public string RgUsuario
        {
            get { return _rgUsuario; }
            set { _rgUsuario = value; }
        }
        public string RegistroUsuario
        {
            get { return _registroUsuario; }
            set { _registroUsuario = value; }
        }
        public global::PerfilC PerfilC
        {
            get { return perfilC; }
            set { perfilC = value; }
        }
        public global::Permissoes Permissoes
        {
            get { return permissoes; }
            set { permissoes = value; }
        }

}//class