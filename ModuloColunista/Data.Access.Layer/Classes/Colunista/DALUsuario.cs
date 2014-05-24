using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Data.Transfer.Object.Classes.Colunista;

namespace Data.Access.Layer.Classes.Colunista
{
    public class DALUsuario
    {
        public DTOUsuario Select(int codigo)
        {
            DTOUsuario usuario = new DTOUsuario();
            //DALPerfil perfil =  null;
            //List<DTOComentario> comentarios = new List<DTOComentario>();

            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objDataReader;
            objConexao = Mapped.Connection();
            objComando = Mapped.Command("SELECT * FROM tbl_colunista u inner join tbl_tipocolunista pe on u.tcol_id = pe.tcol_id inner join tbl_comentario c on u.col_id = c.col_id inner join tbl_postagem p on u.col_id = p.col_id WHERE u.col_id = ?codigo", objConexao);

            //SELECT * FROM tbl_colunista u inner join tbl_comentario c on u.col_id = c.col_id inner join tbl_postagem p on u.col_id = p.col_id inner join tbl_tipopostagem tp on p.tip_id = tp.tip_id WHERE u.col_id = 1;

            objComando.Parameters.Add(Mapped.Parameter("?codigo", codigo));
            objDataReader = objComando.ExecuteReader();
            while (objDataReader.Read())
            {
                //perfil = new DALPerfil();
                DTOComentario comentario = new DTOComentario();
                DTOPostagem postagem = new DTOPostagem();

                usuario.UsuarioId = Convert.ToInt32(objDataReader["col_id"]);
                usuario.Nome = (objDataReader["col_nome"]).ToString();

                usuario.Perfil.PerfilId = Convert.ToInt32(objDataReader["tcol_id"]);
                usuario.Perfil.Nome = Convert.ToString(objDataReader["tcol_nome"]);

                comentario.ComentarioId = Convert.ToInt32(objDataReader["com_id"]);
                comentario.Conteudo = Convert.ToString(objDataReader["com_conteudo"]);
                comentario.DataComentario = Convert.ToDateTime(objDataReader["com_data"]);

                usuario.Comentarios.Add(comentario);

                postagem.PostagemId = Convert.ToInt32(objDataReader["pos_id"]);
                postagem.Conteudo = Convert.ToString(objDataReader["pos_conteudo"]);
                postagem.DataPostagem = Convert.ToDateTime(objDataReader["pos_data"]);
                postagem.Titulo = Convert.ToString(objDataReader["pos_titulo"]);

                usuario.Postagens.Add(postagem);


            }

            objConexao.Close();
            objDataReader.Close();

            objComando.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();

            return usuario;

        }

        public DTOUsuario SelectId(int codigo)
        {
            DTOUsuario usuario = new DTOUsuario();
            //DALPerfil perfil =  null;
            //List<DTOComentario> comentarios = new List<DTOComentario>();

            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objDataReader;
            objConexao = Mapped.Connection();
            objComando = Mapped.Command("SELECT * FROM tbl_colunista u inner join tbl_tipocolunista pe on u.tcol_id = pe.tcol_id WHERE u.perf_id = ?codigo", objConexao);

            //SELECT * FROM tbl_colunista u inner join tbl_comentario c on u.col_id = c.col_id inner join tbl_postagem p on u.col_id = p.col_id inner join tbl_tipopostagem tp on p.tip_id = tp.tip_id WHERE u.col_id = 1;

            objComando.Parameters.Add(Mapped.Parameter("?codigo", codigo));
            objDataReader = objComando.ExecuteReader();
            while (objDataReader.Read())
            {

                usuario.UsuarioId = Convert.ToInt32(objDataReader["col_id"]);
                usuario.Nome = (objDataReader["col_nome"]).ToString();

                usuario.Perfil.PerfilId = Convert.ToInt32(objDataReader["tcol_id"]);
                usuario.Perfil.Nome = Convert.ToString(objDataReader["tcol_nome"]);

            }

            objConexao.Close();
            objDataReader.Close();

            objComando.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();

            return usuario;

        }

        public bool Update(DTOUsuario usuario)
        {
            bool err = true;
            try
            {
                IDbConnection objConnnexao;
                IDbCommand objCommand;
                string sql = "UPDATE tbl_colunista SET col_nome = ?nome WHERE col_id = ?codigo";

                //recebendo a conexão e executando o cmd
                objConnnexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConnnexao);

                //atribuindo os parametros da string sql
                //objCommand.Parameters.Add(Mapped.Parameter("?codigo", usuario.UsuarioId));
                objCommand.Parameters.Add(Mapped.Parameter("?nome", usuario.Nome));

                objCommand.ExecuteNonQuery();
                objConnnexao.Close();

                //abrindo novamente conexão
                objConnnexao.Dispose();
                objCommand.Dispose();
            }//try
            catch (Exception ex)
            {
                err = false;
            }

            return err;

        }//metodo update

        public bool Insert(int usuarioId)
        {
            bool err = true;
            try
            {

                IDbConnection objConexao;
                IDbCommand objCommand;
                string sql = "UPDATE tbl_colunista SET tcol_id = ?perfil where col_id = ?codigo";

                //recebendo a conexão e executando o cmd
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);

                //atribuindo os parametros da string sql
                objCommand.Parameters.Add(Mapped.Parameter("?codigo", usuarioId));//o campo id na tabela deve ser autoincremente para nao haver conflitos ao inserir
                objCommand.Parameters.Add(Mapped.Parameter("?perfil", 2));

                objCommand.ExecuteNonQuery();
                objConexao.Close();

                //abrindo novamente conexão
                objConexao.Dispose();
                objCommand.Dispose();
            }//try
            catch (Exception ex)
            {
                err = false;
            }

            return err;
        }//insert

        public bool Delete(int codigo)
        {
            bool err = true;
            try
            {
                IDbConnection objConexao;
                IDbCommand objCommand;
                string sql = "UPDATE tbl_colunista SET  tcol_id = ?perfil WHERE  col_id = ?codigo";

                //recebendo a conexão e executando o cmd
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);

                //atribuindo os parametros da string sql
                objCommand.Parameters.Add(Mapped.Parameter("?codigo", codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?perfil", 3));

                objCommand.ExecuteNonQuery();
                objConexao.Close();

                //abrindo novamente conexão
                objConexao.Dispose();
                objCommand.Dispose();



            }
            catch (Exception ex)
            {
                err = false;
            }

            return err;
        }//delete

        public List<DTOUsuario> SelectAll()
        {
            List<DTOUsuario> usuarios = new List<DTOUsuario>();
            DALPerfil perfil = null;


            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataReader objDataReader;

            try
            {
                objConexao = Mapped.Connection();
                string sql = "SELECT * FROM tbl_colunista u INNER JOIN tbl_tipocolunista p ON u.tcol_id = p.tcol_id WHERE u.col_ativo = true";
                objCommand = Mapped.Command(sql, objConexao);
                objDataReader = objCommand.ExecuteReader();

                while (objDataReader.Read())
                {
                    DTOUsuario usuario = new DTOUsuario();

                    perfil = new DALPerfil();

                    usuario.Nome = Convert.ToString(objDataReader["col_Nome"]);
                    usuario.UsuarioId = Convert.ToInt32(objDataReader["col_id"]);
                    usuario.Perfil.PerfilId = Convert.ToInt32(objDataReader["tcol_id"]);
                    usuario.Perfil.Nome = Convert.ToString(objDataReader["tcol_nome"]);

                    usuario.Perfil.Usuarios = null;
                    usuario.Comentarios = null;
                    usuario.Postagens = null;
                    usuario.Comentarios = null;

                    usuarios.Add(usuario);
                }

                objConexao.Close();
                objConexao.Dispose();
                objCommand.Dispose();

                return usuarios;
            }
            catch (Exception)
            {

                throw new Exception("Ocorreu um erro ao selecionar os dados de usuarios.");
            }
        }
    }
}
