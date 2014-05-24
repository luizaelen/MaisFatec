using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


public class InteressesBD
{
    public List<Interesses> Select(int perf_id)
    {
        IDbConnection objConexao;
        IDbCommand objComando;
        IDataReader objReader;
        Interesses interesses = null;
        List<Interesses> lstInteresses = new List<Interesses>();

        string sql = "select int_id, int_descricao, int_tipo, int_index from tbl_interesses where perf_id =?perf_id order by int_tipo";

        objConexao = Mapped.Connection();
        objComando = Mapped.Command(sql, objConexao);

        objComando.Parameters.Add(Mapped.Parameter("?perf_id", perf_id));
        objReader = objComando.ExecuteReader();
        while (objReader.Read())
        {
            interesses = new Interesses();
            interesses.IdInteresse = Convert.ToInt32(objReader["int_id"]);
            interesses.InteressesDescricao = Convert.ToString(objReader["int_descricao"]);
            interesses.InteressesTipo = Convert.ToString(objReader["int_tipo"]);
            interesses.IndexInteresse = Convert.ToInt32(objReader["int_index"]);
            lstInteresses.Add(interesses);
        }
            return lstInteresses;
    }

    public int Insert(List<Interesses> interessesLst)
    {
        int erro = 0;

        try
        {
            IDbConnection objConection = null;
            IDbCommand objComando = null;
            foreach (Interesses element in interessesLst)
            {
                Interesses interesses = new Interesses();
                interesses = element;
                string sql = "insert into tbl_interesses(int_descricao, int_tipo, perf_id, int_index) values (?int_descricao, ?int_tipo, ?perf_id, ?int_index)";
                objConection = Mapped.Connection();
                objComando = Mapped.Command(sql, objConection);
                objComando.Parameters.Add(Mapped.Parameter("?int_descricao", interesses.InteressesDescricao));
                objComando.Parameters.Add(Mapped.Parameter("?int_tipo", interesses.InteressesTipo));
                objComando.Parameters.Add(Mapped.Parameter("?perf_id", interesses.IdPerfil));
                objComando.Parameters.Add(Mapped.Parameter("?int_index", interesses.IndexInteresse));
                objComando.ExecuteNonQuery();
            }
            objConection.Close();
            objConection.Dispose();
            objComando.Dispose();
        }
        catch (Exception)
        {

            erro = -2;
        }
        return erro;
    }//insert


    public int Update(List<Interesses> interessesLst)
    {
        int erro = 0;
        try
        {
            IDbConnection objConexao = null;
            IDbCommand objComando = null;
            foreach (Interesses element in interessesLst)
            {
                Interesses interesses = new Interesses();
                interesses = element;
                string sql = ("update tbl_interesses set int_descricao = ?int_descricao where int_id = ?int_id");
                objConexao = Mapped.Connection();
                objComando = Mapped.Command(sql, objConexao);
                objComando.Parameters.Add(Mapped.Parameter("?int_descricao", interesses.InteressesDescricao));
                objComando.Parameters.Add(Mapped.Parameter("?int_id", interesses.IdInteresse));
                objComando.ExecuteNonQuery();
            }
            objConexao.Close();
            objConexao.Dispose();
            objComando.Dispose();

        }
        catch (Exception e)
        {
            erro = -2;
        }

        return erro;
    }


}//class