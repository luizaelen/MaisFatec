using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Data.Transfer.Object.Classes.Colunista;

namespace Data.Access.Layer.Classes.Colunista
{
    public class DALPerfil
    {
        public DTOPerfil Select(int codigo)
        {
            DTOPerfil perfil = new DTOPerfil();
            List<DTOUsuario> usuarios = new List<DTOUsuario>();

            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objDataReader;
            objConexao = Mapped.Connection();
            objComando = Mapped.Command("SELECT * FROM tbl_tipocolunista p inner join tbl_colunista u on p.tcol_id = u.tcol_id WHERE p.tcol_id = ?codigo AND u.col_ativo = true", objConexao);

            objComando.Parameters.Add(Mapped.Parameter("?codigo", codigo));
            objDataReader = objComando.ExecuteReader();
            while (objDataReader.Read())
            {
                DTOUsuario usuario = new DTOUsuario();

                perfil.PerfilId = Convert.ToInt32(objDataReader["tcol_id"]);
                perfil.Nome = Convert.ToString(objDataReader["tcol_nome"]);

                usuario.UsuarioId = Convert.ToInt32(objDataReader["col_id"]);
                usuario.Nome = Convert.ToString(objDataReader["col_nome"]);

                perfil.Usuarios.Add(usuario);

            }

            objConexao.Close();
            objDataReader.Close();

            objComando.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();

            return perfil;

        }

        public int Update(DTOPerfil perfil)
        {
            int errNumber = 0;
            try
            {
                IDbConnection objConnnexao;
                IDbCommand objCommand;
                string sql = "UPDATE tbl_tipocolunista SET tcol_nome = ?tipo WHERE tcol_id = ?codigo";

                //recebendo a conexão e executando o cmd
                objConnnexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConnnexao);

                //atribuindo os parametros da string sql
                objCommand.Parameters.Add(Mapped.Parameter("?codigo", perfil.PerfilId));
                objCommand.Parameters.Add(Mapped.Parameter("?tipo", perfil.Nome));


                objCommand.ExecuteNonQuery();
                objConnnexao.Close();

                //abrindo novamente conexão
                objConnnexao.Dispose();
                objCommand.Dispose();
            }//try
            catch (Exception ex)
            {
                errNumber = -2;
            }

            return errNumber;

        }//metodo update

        public int Insert(DTOPerfil perfil)
        {
            int errNumber = 0;
            try
            {

                IDbConnection objConexao;
                IDbCommand objCommand;
                string sql = "INSERT INTO tbl_tipocolunista(tcol_id, tcol_nome) VALUES (?codigo, ?tipo)";

                //recebendo a conexão e executando o cmd
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);

                //atribuindo os parametros da string sql
                objCommand.Parameters.Add(Mapped.Parameter("?codigo", null));
                objCommand.Parameters.Add(Mapped.Parameter("?tipo", perfil.Nome));

                objCommand.ExecuteNonQuery();
                objConexao.Close();

                //abrindo novamente conexão
                objConexao.Dispose();
                objCommand.Dispose();
            }//try
            catch (Exception ex)
            {
                errNumber = -2;
            }

            return errNumber;
        }//insert        


        public List<DTOPerfil> SelectAll()
        {
            List<DTOPerfil> perfis = new List<DTOPerfil>();
            //DTOPerfil perfil = new DTOPerfil();
            List<DTOUsuario> usuarios = new List<DTOUsuario>();

            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataReader objDataReader;

            try
            {
                objConexao = Mapped.Connection();
                string sql = "SELECT * FROM tbl_tipocolunista p inner join tbl_colunista u on p.tcol_id = u.tcol_id WHERE u.col_ativo = true";
                objCommand = Mapped.Command(sql, objConexao);
                objDataReader = objCommand.ExecuteReader();

                while (objDataReader.Read())
                {
                    DTOUsuario usuario = new DTOUsuario();
                    DTOPerfil perfil = new DTOPerfil();

                    perfil.PerfilId = Convert.ToInt32(objDataReader["tcol_id"]);
                    perfil.Nome = Convert.ToString(objDataReader["tcol_nome"]);

                    usuario.UsuarioId = Convert.ToInt32(objDataReader["col_id"]);
                    usuario.Nome = Convert.ToString(objDataReader["col_nome"]);

                    perfil.Usuarios.Add(usuario);

                    perfis.Add(perfil);
                }

                objConexao.Close();
                objConexao.Dispose();
                objCommand.Dispose();

                return perfis;
            }
            catch (Exception)
            {

                throw new Exception("Ocorreu um erro ao selecionar os dados de colunistas.");
            }
        }
    }
}
