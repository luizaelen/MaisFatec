using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class MiniCv
{
    private PerfilC perfilC;
    private int _miniCvId;
    private String _miniCvDescricao;
    private String _miniCvTipo;
    private String _miniCvInstituicao;
    private DateTime _miniCvDataTermino;

    public MiniCv()
    {
        _miniCvId = 0;
        _miniCvDescricao = string.Empty;
        _miniCvTipo = string.Empty;
        _miniCvInstituicao = string.Empty;
        _miniCvDataTermino = DateTime.MinValue;
    }

    public global::PerfilC PerfilC
    {
        get { return perfilC; }
        set { perfilC = value; }
    }
    public int MiniCvId
    {
        get { return _miniCvId; }
        set { _miniCvId = value; }
    }
    public String MiniCvDescricao
    {
        get { return _miniCvDescricao; }
        set { _miniCvDescricao = value; }
    }
    public String MiniCvTipo
    {
        get { return _miniCvTipo; }
        set { _miniCvTipo = value; }
    }
    public String MiniCvInstituicao
    {
        get { return _miniCvInstituicao; }
        set { _miniCvInstituicao = value; }
    }
    public DateTime MiniCvDataTermino
    {
        get { return _miniCvDataTermino; }
        set { _miniCvDataTermino = value; }
    }

}//class