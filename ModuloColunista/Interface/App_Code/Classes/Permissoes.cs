using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Permissoes
/// </summary>
public class Permissoes
{
        
        int _idPermissao;
        private Boolean _permissaoColunista;
        private Boolean _moderadorForum;
        private Boolean _forumPostagem;
        private Boolean _forumResponder;
        private Boolean _colunaResponder;
        private DateTime _dataPermissao;
        private String _motivoPermissao;
        private int _tempoPermissao;

        public Permissoes()
        {
            _idPermissao = 0;
            _permissaoColunista = false;
            _moderadorForum = false;
            _forumPostagem = false;
            _forumResponder = false;
            _colunaResponder = false;
            _dataPermissao = DateTime.MinValue;
            _motivoPermissao = string.Empty;
            _tempoPermissao = 0;

        }

        public int IdPermissao
        {
            get { return _idPermissao; }
            set { _idPermissao = value; }
        }
        public Boolean PermissaoColunista
        {
            get { return _permissaoColunista; }
            set { _permissaoColunista = value; }
        }
        public Boolean ModeradorForum
        {
            get { return _moderadorForum; }
            set { _moderadorForum = value; }
        }
        public Boolean ForumPostagem
        {
            get { return _forumPostagem; }
            set { _forumPostagem = value; }
        }
        public Boolean ForumResponder
        {
            get { return _forumResponder; }
            set { _forumResponder = value; }
        }
        public Boolean ColunaResponder
        {
            get { return _colunaResponder; }
            set { _colunaResponder = value; }
        }
        public DateTime DataPermissao
        {
            get { return _dataPermissao; }
            set { _dataPermissao = value; }
        }
        public String MotivoPermissao
        {
            get { return _motivoPermissao; }
            set { _motivoPermissao = value; }
        }
        public int TempoPermissao
        {
            get { return _tempoPermissao; }
            set { _tempoPermissao = value; }
        }
    }