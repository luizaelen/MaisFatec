using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Log
/// </summary>
public class Log
{
    private Usuario usuario;
    private int _idLog;
    private DateTime _logData;
    private String _logTipo;
    private String _logCampo;
    private String _logModificacao;

    public global::Usuario Usuario
    {
        get { return usuario; }
        set { usuario = value; }
    }
    public int IdLog
    {
        get { return _idLog; }
        set { _idLog = value; }
    }
    public DateTime LogData
    {
        get { return _logData; }
        set { _logData = value; }
    }
    public String LogTipoModificacao
    {
        get { return _logTipo; }
        set { _logTipo = value; }
    }
    public String LogCampo
    {
        get { return _logCampo; }
        set { _logCampo = value; }
    }
    public String LogModificacao
    {
        get { return _logModificacao; }
        set { _logModificacao = value; }
    }

}//class