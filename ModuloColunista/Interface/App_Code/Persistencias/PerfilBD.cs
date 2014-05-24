using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Security;

public class PerfilBD
{
    public int Update(Usuario usr)
    {
        int erro = 0;
        try
        {
            IDbConnection objConexao;
            IDbCommand objComando;
            string sql = ("update tbl_perfil set perf_nome= ?perf_nome, perf_sobrenome = ?perf_sobrenome, perf_datanasc = ?perf_datanasc, perf_sexo = ?perf_sexo, perf_relacionamento = ?perf_relacionamento, perf_foto = ?perf_foto, perf_sobreVoce = ?perf_sobrevoce, perf_cidadeNatal = ?perf_cidadeNatal, perf_cidadeAtual = ?perf_cidadeAtual where usu_id = ?usu_id");
            objConexao = Mapped.Connection();
            objComando = Mapped.Command(sql, objConexao);
            objComando.Parameters.Add(Mapped.Parameter("?perf_nome", usr.PerfilC.NomePerfil));
            objComando.Parameters.Add(Mapped.Parameter("?perf_sobrenome", usr.PerfilC.SobrenomePerfil));
            objComando.Parameters.Add(Mapped.Parameter("?perf_datanasc", usr.PerfilC.DataNascimentoPerfil));
            objComando.Parameters.Add(Mapped.Parameter("?perf_sexo", usr.PerfilC.SexoPerfil));
            objComando.Parameters.Add(Mapped.Parameter("?perf_relacionamento", usr.PerfilC.RelacionamentoPerfil));
            objComando.Parameters.Add(Mapped.Parameter("?perf_foto", usr.PerfilC.FotoPerfil));
            objComando.Parameters.Add(Mapped.Parameter("?perf_sobreVoce", usr.PerfilC.SobrePerfil));
            objComando.Parameters.Add(Mapped.Parameter("?perf_cidadeNatal", usr.PerfilC.CidadeNatalPerfil));
            objComando.Parameters.Add(Mapped.Parameter("?perf_cidadeAtual", usr.PerfilC.CidadeAtualPerfil));
            objComando.Parameters.Add(Mapped.Parameter("?usu_id", usr.IdUsuario));

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


    public void InsertColunista(Usuario usuario)
    {


        IDbConnection objConexao;
        IDbCommand objCommand;
        string sql = "INSERT INTO tbl_colunista(col_id, col_nome, col_ativo, tcol_id, perf_id) VALUES (?codigo, ?nome, true, ?tipo, ?perfil)";

        //recebendo a conexão e executando o cmd
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command(sql, objConexao);

        //atribuindo os parametros da string sql
        objCommand.Parameters.Add(Mapped.Parameter("?codigo", null));
        objCommand.Parameters.Add(Mapped.Parameter("?nome", usuario.PerfilC.NomePerfil));
        objCommand.Parameters.Add(Mapped.Parameter("?tipo", 3));
        objCommand.Parameters.Add(Mapped.Parameter("?perfil", usuario.PerfilC.IdPerfil));

        objCommand.ExecuteNonQuery();


        objConexao.Close();
        objConexao.Dispose();
        objCommand.Dispose();

    }//insert

    public void Insert(Usuario usuario)
    {
        IDbConnection objConection;
        IDbCommand objComando;
        string sql = "insert into tbl_perfil(usu_id, perf_nome, perf_sobrenome, perf_datanasc, perf_sexo, perf_relacionamento, perf_foto, perf_sobreVoce, perf_capa1, perf_capa2, perf_capa3, perf_capa4, perf_cidadeNatal, perf_cidadeAtual, perf_url) values (?usu_id, ?perf_nome, ?perf_sobrenome, ?perf_datanasc, ?perf_sexo, ?perf_relacionamento, ?perf_foto, ?perf_sobreVoce, ?perf_capa1, ?perf_capa2, ?perf_capa3, ?perf_capa4, ?perf_cidadeNatal, ?perf_cidadeAtual, ?perf_url);select LAST_INSERT_ID();";
        objConection = Mapped.Connection();
        objComando = Mapped.Command(sql, objConection);
        objComando.Parameters.Add(Mapped.Parameter("?usu_id", usuario.IdUsuario));
        objComando.Parameters.Add(Mapped.Parameter("?perf_nome", usuario.PerfilC.NomePerfil));
        objComando.Parameters.Add(Mapped.Parameter("?perf_sobrenome", usuario.PerfilC.SobrenomePerfil));
        objComando.Parameters.Add(Mapped.Parameter("?perf_datanasc", usuario.PerfilC.DataNascimentoPerfil));
        objComando.Parameters.Add(Mapped.Parameter("?perf_sexo", usuario.PerfilC.SexoPerfil));
        objComando.Parameters.Add(Mapped.Parameter("?perf_relacionamento", usuario.PerfilC.RelacionamentoPerfil));
        objComando.Parameters.Add(Mapped.Parameter("?perf_foto", usuario.PerfilC.FotoPerfil));
        objComando.Parameters.Add(Mapped.Parameter("?perf_sobreVoce", usuario.PerfilC.SobrePerfil));
        objComando.Parameters.Add(Mapped.Parameter("?perf_capa1", usuario.PerfilC.CapaUm));
        objComando.Parameters.Add(Mapped.Parameter("?perf_capa2", usuario.PerfilC.CapaDois));
        objComando.Parameters.Add(Mapped.Parameter("?perf_capa3", usuario.PerfilC.CapaTres));
        objComando.Parameters.Add(Mapped.Parameter("?perf_capa4", usuario.PerfilC.CapaQuatro));
        objComando.Parameters.Add(Mapped.Parameter("?perf_cidadeNatal", usuario.PerfilC.CidadeNatalPerfil));
        objComando.Parameters.Add(Mapped.Parameter("?perf_cidadeAtual", usuario.PerfilC.CidadeAtualPerfil));
        objComando.Parameters.Add(Mapped.Parameter("?perf_url", usuario.PerfilC.UrlPerfil));

        //objComando.ExecuteNonQuery();
        //executo este comando para pegar o id do perfil acima
        //por isso o comando comentado acima noa é necessario.
        int id = Convert.ToInt32(objComando.ExecuteScalar());
        objConection.Close();
        //seto o id do perfil no objeto de usuario 
        usuario.PerfilC.IdPerfil = id;
        //insiro as informação na tabela colunista
        InsertColunista(usuario);


        objConection.Dispose();
        objComando.Dispose();
    }

    public List<PerfilC> SelectBusca(String nome)
    {

        IDbConnection objConexao;
        IDbCommand objComando;
        IDataReader objReader;
        List<PerfilC> perfilLst = new List<PerfilC>();
        nome = "%" + nome + "%";

        string sql = "select perf_nome, perf_sobrenome, perf_foto, perf_url from tbl_perfil where perf_nome like ?perf_nome";

        objConexao = Mapped.Connection();
        objComando = Mapped.Command(sql, objConexao);

        objComando.Parameters.Add(Mapped.Parameter("?perf_nome", nome));
        objReader = objComando.ExecuteReader();
        while (objReader.Read())
        {
            PerfilC perfil = new PerfilC();
            perfil.NomePerfil = Convert.ToString(objReader["perf_nome"]);
            perfil.SobrenomePerfil = Convert.ToString(objReader["perf_sobrenome"]);
            perfil.FotoPerfil = Convert.ToString(objReader["perf_foto"]);
            perfil.UrlPerfil = Convert.ToString(objReader["perf_url"]);
            perfilLst.Add(perfil);
        }

        return perfilLst;
    }

    public PerfilC Select(int usu_id)
    {

        IDbConnection objConexao;
        IDbCommand objComando;
        IDataReader objReader;
        PerfilC perfil = null;

        string sql = "select perf_id, perf_nome, perf_sobrenome, perf_datanasc, perf_sexo, perf_relacionamento, perf_foto, perf_sobreVoce, perf_capa1, perf_capa2, perf_capa3, perf_capa4, perf_cidadeNatal, perf_cidadeAtual, perf_url from tbl_perfil where usu_id =?usu_id";

        objConexao = Mapped.Connection();
        objComando = Mapped.Command(sql, objConexao);

        objComando.Parameters.Add(Mapped.Parameter("?usu_id", usu_id));
        objReader = objComando.ExecuteReader();
        while (objReader.Read())
        {
            perfil = new PerfilC();
            perfil.IdPerfil = Convert.ToInt32(objReader["perf_id"]);
            perfil.NomePerfil = Convert.ToString(objReader["perf_nome"]);
            perfil.SobrenomePerfil = Convert.ToString(objReader["perf_sobrenome"]);
            try
            {
                perfil.DataNascimentoPerfil = Convert.ToDateTime(objReader["perf_datanasc"]);
            }
            catch (Exception)
            {
            }
            perfil.SexoPerfil = Convert.ToString(objReader["perf_sexo"]);
            perfil.RelacionamentoPerfil = Convert.ToString(objReader["perf_relacionamento"]);
            perfil.FotoPerfil = Convert.ToString(objReader["perf_foto"]);
            perfil.SobrePerfil = Convert.ToString(objReader["perf_sobreVoce"]);
            perfil.CapaUm = Convert.ToString(objReader["perf_capa1"]);
            perfil.CapaDois = Convert.ToString(objReader["perf_capa2"]);
            perfil.CapaTres = Convert.ToString(objReader["perf_capa3"]);
            perfil.CapaQuatro = Convert.ToString(objReader["perf_capa4"]);
            perfil.CidadeNatalPerfil = Convert.ToString(objReader["perf_cidadeNatal"]);
            perfil.CidadeAtualPerfil = Convert.ToString(objReader["perf_cidadeAtual"]);
            perfil.UrlPerfil = Convert.ToString(objReader["perf_url"]);
        }

        return perfil;
    }

    public PerfilC SelectOutro(String perf_url)
    {

        IDbConnection objConexao;
        IDbCommand objComando;
        IDataReader objReader;
        PerfilC perfil = null;

        string sql = "select perf_id, perf_nome, perf_sobrenome, perf_datanasc, perf_sexo, perf_relacionamento, perf_foto, perf_sobreVoce, perf_capa1, perf_capa2, perf_capa3, perf_capa4, perf_cidadeNatal, perf_cidadeAtual, perf_url from tbl_perfil where perf_url =?perf_url";

        objConexao = Mapped.Connection();
        objComando = Mapped.Command(sql, objConexao);

        objComando.Parameters.Add(Mapped.Parameter("?perf_url", perf_url));
        objReader = objComando.ExecuteReader();
        while (objReader.Read())
        {
            perfil = new PerfilC();
            perfil.IdPerfil = Convert.ToInt32(objReader["perf_id"]);
            perfil.NomePerfil = Convert.ToString(objReader["perf_nome"]);
            perfil.SobrenomePerfil = Convert.ToString(objReader["perf_sobrenome"]);
            try
            {
                perfil.DataNascimentoPerfil = Convert.ToDateTime(objReader["perf_datanasc"]);
            }
            catch (Exception)
            {
            }
            perfil.SexoPerfil = Convert.ToString(objReader["perf_sexo"]);
            perfil.RelacionamentoPerfil = Convert.ToString(objReader["perf_relacionamento"]);
            perfil.FotoPerfil = Convert.ToString(objReader["perf_foto"]);
            perfil.SobrePerfil = Convert.ToString(objReader["perf_sobreVoce"]);
            perfil.CapaUm = Convert.ToString(objReader["perf_capa1"]);
            perfil.CapaDois = Convert.ToString(objReader["perf_capa2"]);
            perfil.CapaTres = Convert.ToString(objReader["perf_capa3"]);
            perfil.CapaQuatro = Convert.ToString(objReader["perf_capa4"]);
            perfil.CidadeNatalPerfil = Convert.ToString(objReader["perf_cidadeNatal"]);
            perfil.CidadeAtualPerfil = Convert.ToString(objReader["perf_cidadeAtual"]);
            perfil.UrlPerfil = Convert.ToString(objReader["perf_url"]);
        }

        return perfil;
    }

    public DataSet SelectEditar(int id, string parametro)
    {
        DataSet ds = new DataSet();
        IDbConnection objConexao;
        IDbCommand objComando;
        IDataAdapter adp;

        objConexao = Mapped.Connection();
        objComando = Mapped.Command("select ?parametro from tbl_perfil where perf_id = ?id", objConexao);
        adp = Mapped.Adapter(objComando);
        objComando.Parameters.Add(Mapped.Parameter("?parametro", parametro));
        objComando.Parameters.Add(Mapped.Parameter("?id", id));
        adp.Fill(ds);
        objConexao.Close();
        objConexao.Dispose();
        objComando.Dispose();

        return ds;

    }

}