using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Interesses : PerfilC
{
    private int _idInteresse;
    private string _interessesDescricao;
    private string _interessesTipo;
    private int _indexInteresse;
    private PerfilC _perfilC;

    public int IdInteresse
    {
        get { return _idInteresse; }
        set { _idInteresse = value; }
    }
    public string InteressesDescricao
    {
        get { return _interessesDescricao; }
        set { _interessesDescricao = value; }
    }
    public string InteressesTipo
    {
        get { return _interessesTipo; }
        set { _interessesTipo = value; }
    }
    public int IndexInteresse
    {
        get { return _indexInteresse; }
        set { _indexInteresse = value; }
    }
    public global::PerfilC PerfilC
    {
        get { return _perfilC; }
        set { _perfilC = value; }
    }

}//class