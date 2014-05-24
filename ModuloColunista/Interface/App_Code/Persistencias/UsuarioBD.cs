using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Security.Cryptography;
using System.Globalization;

public class UsuarioBD
{

    public DataSet UsuarioAdm()
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objComando;
        IDataAdapter adp;
        objConexao = Mapped.Connection();
        objComando = Mapped.Command("select u.usu_id, pf.perf_nome, p.perm_administrador from tbl_usuario u inner join tbl_permissoes p on u.usu_id = p.usu_id inner join tbl_perfil pf on u.usu_id = pf.usu_id order by pf.perf_nome", objConexao);
        adp = Mapped.Adapter(objComando);
        adp.Fill(ds);
        objConexao.Close();
        objComando.Dispose();
        objConexao.Dispose();
        return ds;
    }

    public PerfilC ValidaCadastro(string registro, string rg)
    {

        IDbConnection objConexao;
        IDbCommand objComando;
        IDataReader objReader;
        PerfilC usr = null;

        string sql = "select fatec_nome, fatec_sobrenome, fatec_dtnasc from view_fatec where fatec_registro =?fatec_registro and fatec_rg = ?fatec_rg";

        objConexao = Mapped.Connection();
        objComando = Mapped.Command(sql, objConexao);
        objComando.Parameters.Add(Mapped.Parameter("?fatec_registro", registro));
        objComando.Parameters.Add(Mapped.Parameter("?fatec_rg", rg));
        objReader = objComando.ExecuteReader();
        while (objReader.Read())
        {
            usr = new PerfilC();
            usr.NomePerfil = Convert.ToString(objReader["fatec_nome"]);
            usr.SobrenomePerfil = Convert.ToString(objReader["fatec_sobrenome"]);
            usr.DataNascimentoPerfil = Convert.ToDateTime(objReader["fatec_dtnasc"]);
        }

        return usr;
    }

    public int RetornaID(string login, string senha)
    {

        IDbConnection objConexao;
        IDbCommand objComando;
        IDataReader objReader;
        int id = 0;

        string sql = "select usu_id from tbl_usuario where usu_login = ?usu_login and usu_senha = ?usu_senha";

        objConexao = Mapped.Connection();
        objComando = Mapped.Command(sql, objConexao);
        objComando.Parameters.Add(Mapped.Parameter("?usu_login", login));
        objComando.Parameters.Add(Mapped.Parameter("?usu_senha", senha));
        objReader = objComando.ExecuteReader();
        while (objReader.Read())
        {
            id = Convert.ToInt32(objReader["usu_id"]);
        }

        return id;
    }

    public string HashValue(string value)
    {
        UnicodeEncoding encoding = new UnicodeEncoding();
        byte[] hashBytes;
        using (HashAlgorithm hash = SHA256.Create())
            hashBytes = hash.ComputeHash(encoding.GetBytes(value));

        StringBuilder hashValue = new StringBuilder(hashBytes.Length * 2);
        foreach (byte b in hashBytes)
        {
            hashValue.AppendFormat(CultureInfo.InvariantCulture, "{0:X2}", b);
        }

        return hashValue.ToString();
    }


    public void Insert(Usuario usu)
    {
        IDbConnection objConexao;
        IDbCommand objComando;
        PerfilBD perfilbd = new PerfilBD();

        string sql = "Insert into tbl_usuario(usu_login, usu_senha, usu_email, usu_hashid, usu_rg, usu_registro) values (?usu_login, ?usu_senha, ?usu_email, 0, ?usu_rg, ?usu_registro)";
        objConexao = Mapped.Connection();
        objComando = Mapped.Command(sql, objConexao);
        objComando.Parameters.Add(Mapped.Parameter("?usu_login", usu.LoginUsuario));
        objComando.Parameters.Add(Mapped.Parameter("?usu_senha", usu.SenhaUsuario));
        objComando.Parameters.Add(Mapped.Parameter("?usu_email", usu.EmailUsuario));
        objComando.Parameters.Add(Mapped.Parameter("?usu_rg", usu.RgUsuario));
        objComando.Parameters.Add(Mapped.Parameter("?usu_registro", usu.RegistroUsuario));
        objComando.ExecuteNonQuery();

        usu.IdUsuario = RetornaID(usu.LoginUsuario, usu.SenhaUsuario);
        usu.HashidUsuario = HashValue(usu.IdUsuario.ToString());
        usu.SenhaUsuario = HashValue(usu.SenhaUsuario.ToString());
        usu.PerfilC.UrlPerfil = usu.HashidUsuario;
        perfilbd.Insert(usu);
        Update(usu);

        objConexao.Close();
        objConexao.Dispose();
        objComando.Dispose();

    }

    private int Update(Usuario usu)
    {
        int erro = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            string sql = "update tbl_usuario set usu_login = ?usu_login, usu_senha = ?usu_senha, usu_email = ?usu_email, usu_hashid = ?usu_hashid where usu_id = ?usu_id";
            objConexao = Mapped.Connection();
            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?usu_login", usu.LoginUsuario));
            objComando.Parameters.Add(Mapped.Parameter("?usu_senha", usu.SenhaUsuario));
            objComando.Parameters.Add(Mapped.Parameter("?usu_email", usu.EmailUsuario));
            objComando.Parameters.Add(Mapped.Parameter("?usu_id", usu.IdUsuario));
            objComando.Parameters.Add(Mapped.Parameter("?usu_hashid", usu.HashidUsuario));
            objComando.ExecuteNonQuery();
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

    public Usuario ValidaUsuario(string login, string senha)
    {

        IDbConnection objConexao;
        IDbCommand objComando;
        IDataReader objReader;
        Usuario usuario = null;

        string sql = "select usu_id from tbl_usuario where usu_login =?usu_login and usu_senha = ?usu_senha";

        objConexao = Mapped.Connection();
        objComando = Mapped.Command(sql, objConexao);

        objComando.Parameters.Add(Mapped.Parameter("?usu_login", login));
        objComando.Parameters.Add(Mapped.Parameter("?usu_senha", senha));
        objReader = objComando.ExecuteReader();
        while (objReader.Read())
        {
            usuario = new Usuario();
            usuario.IdUsuario = Convert.ToInt32(objReader["usu_id"]);
            PerfilBD perfilbd = new PerfilBD();
            usuario.PerfilC = perfilbd.Select(Convert.ToInt32(objReader["usu_id"]));
            PermissoesBD permissoesbd = new PermissoesBD();
            usuario.Permissoes = permissoesbd.Select(Convert.ToInt32(objReader["usu_id"]));
        }

        return usuario;
    }

    public Usuario VerificaUsuarioExiste(string registro, string rg)
    {

        IDbConnection objConexao;
        IDbCommand objComando;
        IDataReader objReader;
        Usuario usuario = null;

        string sql = "select usu_id from tbl_usuario where usu_registro =?usu_registro and usu_rg = ?usu_rg";

        objConexao = Mapped.Connection();
        objComando = Mapped.Command(sql, objConexao);

        objComando.Parameters.Add(Mapped.Parameter("?usu_registro", registro));
        objComando.Parameters.Add(Mapped.Parameter("?usu_rg", rg));
        objReader = objComando.ExecuteReader();
        while (objReader.Read())
        {
            usuario = new Usuario();
            usuario.IdUsuario = Convert.ToInt32(objReader["usu_id"]);
        }

        return usuario;
    }


}