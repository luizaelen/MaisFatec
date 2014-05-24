using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ViewFatec
/// </summary>
public class ViewFatec
{
    private int _idViewFAtec;

    public int IdViewFAtec
    {
        get { return _idViewFAtec; }
        set { _idViewFAtec = value; }
    }
    private String _nomeViewFatec;

    public String NomeViewFatec
    {
        get { return _nomeViewFatec; }
        set { _nomeViewFatec = value; }
    }
    private String _sobrenomeViewFatec;

    public String SobrenomeViewFatec
    {
        get { return _sobrenomeViewFatec; }
        set { _sobrenomeViewFatec = value; }
    }
    private DateTime _dataNascimentoViewFatec;

    public DateTime DataNascimentoViewFatec
    {
        get { return _dataNascimentoViewFatec; }
        set { _dataNascimentoViewFatec = value; }
    }
        private String _rgViewFatec;

        public String RgViewFatec
        {
            get { return _rgViewFatec; }
            set { _rgViewFatec = value; }
        }
        private String _registroViewFatec;

        public String RegistroViewFatec
        {
            get { return _registroViewFatec; }
            set { _registroViewFatec = value; }
        }

        public ViewFatec()
        {
            IdViewFAtec = 0;
            NomeViewFatec = string.Empty;
            SobrenomeViewFatec = string.Empty;
            DataNascimentoViewFatec = DateTime.MinValue;
            RgViewFatec = string.Empty;
            RegistroViewFatec = string.Empty;
        }
    
}//class