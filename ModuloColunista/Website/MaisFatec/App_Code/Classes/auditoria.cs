using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class auditoria
{
    private int aud_id;
    private int usu_id;
    private string aud_local;
    private int aud_tipo;
    private DateTime aud_datahora;
    private string aud_dado;

    public int Aud_id
    {
        get { return aud_id; }
        set { aud_id = value; }
    }
    
    public int Usu_id
    {
        get { return usu_id; }
        set { usu_id = value; }
    }
    
    public string Aud_local
    {
        get { return aud_local; }
        set { aud_local = value; }
    }
    
    public int Aud_tipo
    {
        get { return aud_tipo; }
        set { aud_tipo = value; }
    }

    public DateTime Aud_datahora
    {
        get { return aud_datahora; }
        set { aud_datahora = value; }
    }

    public string Aud_dado
    {
        get { return aud_dado; }
        set { aud_dado = value; }
    }
}