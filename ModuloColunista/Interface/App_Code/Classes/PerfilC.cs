using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Perfil
/// </summary>
public class PerfilC
{

        private int _idPerfil;
        private String _nomePerfil;
        private String _sobrenomePerfil;
        private DateTime _dataNascimentoPerfil;
        private String _sexoPerfil;
        private String _relacionamentoPerfil;
        private String _fotoPerfil;
        private String _capaUm;
        private String _capaDois;
        private String _capaTres;
        private String _capaQuatro;
        private String _cidadeNatalPerfil;
        private String _cidadeAtualPerfil;
        private String _sobrePerfil;
        private String _urlPerfil;

        public PerfilC()
        {
            _idPerfil = 0;
            _nomePerfil = string.Empty;
            _sobrenomePerfil = string.Empty; ;
            _dataNascimentoPerfil = DateTime.MinValue;
            _sexoPerfil = "Masculino";
            _relacionamentoPerfil = "Solteiro";
            _fotoPerfil = string.Empty;
            _capaUm = string.Empty;
            _capaDois = string.Empty;
            _capaTres = string.Empty;
            _capaQuatro = string.Empty;
            _cidadeNatalPerfil = string.Empty;
            _cidadeAtualPerfil = string.Empty;
            _sobrePerfil = string.Empty;
            _urlPerfil = string.Empty;
        }
    
        public int IdPerfil
        {
            get { return _idPerfil; }
            set { _idPerfil = value; }
        }
        public String NomePerfil
        {
            get { return _nomePerfil; }
            set { _nomePerfil = value; }
        }    
        public String SobrenomePerfil
        {
            get { return _sobrenomePerfil; }
            set { _sobrenomePerfil = value; }
        }
        public DateTime DataNascimentoPerfil
        {
            get { return _dataNascimentoPerfil; }
            set { _dataNascimentoPerfil = value; }
        }
        public String SexoPerfil
        {
            get { return _sexoPerfil; }
            set { _sexoPerfil = value; }
        }
        public String RelacionamentoPerfil
        {
            get { return _relacionamentoPerfil; }
            set { _relacionamentoPerfil = value; }
        }
        public String FotoPerfil
        {
            get { return _fotoPerfil; }
            set { _fotoPerfil = value; }
        }
        public String CapaUm
        {
            get { return _capaUm; }
            set { _capaUm = value; }
        }
        public String CapaDois
        {
            get { return _capaDois; }
            set { _capaDois = value; }
        }
        public String CapaTres
        {
            get { return _capaTres; }
            set { _capaTres = value; }
        }
        public String CapaQuatro
        {
            get { return _capaQuatro; }
            set { _capaQuatro = value; }
        }
        public String CidadeNatalPerfil
        {
            get { return _cidadeNatalPerfil; }
            set { _cidadeNatalPerfil = value; }
        }
        public String CidadeAtualPerfil
        {
            get { return _cidadeAtualPerfil; }
            set { _cidadeAtualPerfil = value; }
        }
        public String SobrePerfil
        {
            get { return _sobrePerfil; }
            set { _sobrePerfil = value; }
        }
        public String UrlPerfil
        {
            get { return _urlPerfil; }
            set { _urlPerfil = value; }
        }

    }//class