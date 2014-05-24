using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Data.Transfer.Object.Classes.Colunista;

namespace Data.Access.Layer.Classes.Colunista
{
    public class DALComentario
    {
        public DTOComentario Select(int codigo)
        {
            DTOComentario comentario = null;
            DALPostagem postagem = null;
            DALUsuario usuario = null;

            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objDataReader;
            objConexao = Mapped.Connection();
            objComando = Mapped.Command("SELECT * FROM tbl_comentario WHERE com_id = ?codigo AND com_ativo = true", objConexao);

            objComando.Parameters.Add(Mapped.Parameter("?codigo", codigo));
            objDataReader = objComando.ExecuteReader();
            while (objDataReader.Read())
            {
                comentario = new DTOComentario();
                postagem = new DALPostagem();
                usuario = new DALUsuario();

                comentario.ComentarioId = Convert.ToInt32(objDataReader["com_id"]);
                comentario.Conteudo = Convert.ToString(objDataReader["com_conteudo"]);
                comentario.DataComentario = Convert.ToDateTime(objDataReader["com_data"]);
                //comentario.Postagem = postagem.Select(Convert.ToInt32(objDataReader["pos_id"]));
                //comentario.Usuario = usuario.Select(Convert.ToInt32(objDataReader["col_id"]));


            }

            objConexao.Close();
            objDataReader.Close();

            objComando.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();

            return comentario;

        }


        public List<DTOComentario> SelectAllById(int idpostagem)
        {

            List<DTOComentario> comentarios = new List<DTOComentario>();

            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objDataReader;
            objConexao = Mapped.Connection();
            objComando = Mapped.Command("SELECT * FROM tbl_comentario c INNER JOIN tbl_colunista u on c.col_id = u.col_id WHERE c.pos_id = ?codigo and c.com_ativo = true ORDER BY c.com_data ASC", objConexao);

            objComando.Parameters.Add(Mapped.Parameter("?codigo", idpostagem));
            objDataReader = objComando.ExecuteReader();
            while (objDataReader.Read())
            {
                DTOComentario comentario = new DTOComentario();
                DTOUsuario usuario = new DTOUsuario();

                comentario.ComentarioId = Convert.ToInt32(objDataReader["com_id"]);
                comentario.Conteudo = Convert.ToString(objDataReader["com_conteudo"]);
                comentario.DataComentario = Convert.ToDateTime(objDataReader["com_data"]);
                comentario.Postagem = null;

                usuario.UsuarioId = Convert.ToInt32(objDataReader["col_id"]);
                usuario.Nome = Convert.ToString(objDataReader["col_nome"]);
                usuario.Perfil = null;
                usuario.Comentarios = null;
                usuario.Postagens = null;

                comentario.Usuario = usuario;

                comentarios.Add(comentario);

            }

            objConexao.Close();
            objDataReader.Close();

            objComando.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();

            return comentarios;

        }

        public DTOComentario SelectById(int id)
        {

            DTOComentario comentario = new DTOComentario();

            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objDataReader;
            objConexao = Mapped.Connection();
            objComando = Mapped.Command("SELECT * FROM tbl_comentario c INNER JOIN tbl_colunista u on c.col_id = u.col_id WHERE c.pos_id = ?codigo and c.com_ativo = true", objConexao);

            objComando.Parameters.Add(Mapped.Parameter("?codigo", id));
            objDataReader = objComando.ExecuteReader();
            
            while (objDataReader.Read())
            {
                
                DTOUsuario usuario = new DTOUsuario();

                comentario.ComentarioId = Convert.ToInt32(objDataReader["com_id"]);
                comentario.Conteudo = Convert.ToString(objDataReader["com_conteudo"]);
                comentario.DataComentario = Convert.ToDateTime(objDataReader["com_data"]);
                comentario.Postagem = null;

                usuario.UsuarioId = Convert.ToInt32(objDataReader["col_id"]);
                usuario.Nome = Convert.ToString(objDataReader["col_nome"]);
                usuario.Perfil = null;
                usuario.Comentarios = null;
                usuario.Postagens = null;

                comentario.Usuario = usuario;               

            }

            objConexao.Close();
            objDataReader.Close();

            objComando.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();

            return comentario;

        }

        // vefiricar algo com a luiza 
        public int Update(DTOComentario comentario)
        {
            int errNumber = 0;
            try
            {
                IDbConnection objConnnexao;
                IDbCommand objCommand;
                //string sql = "UPDATE tbl_comentario SET  = com_conteudo = ?conteudo, com_data = ?data, pos_id = ?postagem, col_id = ?usuario WHERE com_id = ?codigo, com_ativo = true";
                string sql = "UPDATE tbl_comentario SET  com_conteudo = ?conteudo, com_data = ?data WHERE com_id = ?codigo";


                //recebendo a conexão e executando o cmd
                objConnnexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConnnexao);

                //atribuindo os parametros da string sql
                objCommand.Parameters.Add(Mapped.Parameter("?codigo", comentario.ComentarioId));
                objCommand.Parameters.Add(Mapped.Parameter("?conteudo", comentario.Conteudo));
                objCommand.Parameters.Add(Mapped.Parameter("?data", comentario.DataComentario));
                objCommand.Parameters.Add(Mapped.Parameter("?ativo", true));
                //objCommand.Parameters.Add(Mapped.Parameter("?postagem", comentario.Postagem.PostagemId));
                //objCommand.Parameters.Add(Mapped.Parameter("?usuario", comentario.Usuario.UsuarioId));


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

        public int Insert(DTOComentario comentario)
        {
            int errNumber = 0;
            try
            {

                IDbConnection objConexao;
                IDbCommand objCommand;
                string sql = "INSERT INTO  tbl_comentario(com_id, com_conteudo, com_data, pos_id, col_id, com_ativo) VALUES (?codigo, ?conteudo,?data, ?postagem, ?usuario, true)";

                //recebendo a conexão e executando o cmd
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);

                //atribuindo os parametros da string sql
                objCommand.Parameters.Add(Mapped.Parameter("?codigo", null));
                objCommand.Parameters.Add(Mapped.Parameter("?conteudo", comentario.Conteudo));
                objCommand.Parameters.Add(Mapped.Parameter("?data", DateTime.Now));
                objCommand.Parameters.Add(Mapped.Parameter("?postagem", comentario.Postagem.PostagemId));
                objCommand.Parameters.Add(Mapped.Parameter("?usuario", comentario.Usuario.UsuarioId));


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

        //public int Delete(int codigo)
        //{
        //    int errNumber = 0;
        //    try
        //    {
        //        IDbConnection objConexao;
        //        IDbCommand objCommand;
        //        string sql = "DELETE FROM tbl_comentario WHERE  com_id= ?codigo";

        //        //recebendo a conexão e executando o cmd
        //        objConexao = Mapped.Connection();
        //        objCommand = Mapped.Command(sql, objConexao);

        //        //atribuindo os parametros da string sql
        //        objCommand.Parameters.Add(Mapped.Parameter("?codigo", codigo));

        //        objCommand.ExecuteNonQuery();
        //        objConexao.Close();

        //        //abrindo novamente conexão
        //        objConexao.Dispose();
        //        objCommand.Dispose();



        //    }
        //    catch (Exception ex)
        //    {
        //        errNumber = -2;
        //    }

        //    return errNumber;
        //}//delete

        public int Delete(int codigo)
        {
            int errNumber = 0;
            try
            {
                IDbConnection objConnnexao;
                IDbCommand objCommand;
                string sql = "UPDATE tbl_comentario SET com_ativo = ?ativo WHERE com_id = ?codigo";

                //recebendo a conexão e executando o cmd
                objConnnexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConnnexao);

                //atribuindo os parametros da string sql
                objCommand.Parameters.Add(Mapped.Parameter("?codigo", codigo));
                objCommand.Parameters.Add(Mapped.Parameter("?ativo", false));


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
        }//delete

        public List<DTOComentario> SelectAll()
        {
            DTOComentario comentario = null;
            DALPostagem postagem = null;
            DALUsuario usuario = null;

            List<DTOComentario> comentarios = new List<DTOComentario>();
            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataReader objDataReader;

            try
            {
                objConexao = Mapped.Connection();
                string sql = "SELECT * FROM tbl_comentario WHERE com_ativo = true";
                objCommand = Mapped.Command(sql, objConexao);
                objDataReader = objCommand.ExecuteReader();

                while (objDataReader.Read())
                {
                    comentario = new DTOComentario();
                    postagem = new DALPostagem();
                    usuario = new DALUsuario();

                    comentario.ComentarioId = Convert.ToInt32(objDataReader["com_id"]);
                    comentario.Conteudo = Convert.ToString(objDataReader["com_conteudo"]);
                    comentario.DataComentario = Convert.ToDateTime(objDataReader["com_data"]);
                    //comentario.Postagem = postagem.Select(Convert.ToInt32(objDataReader["pos_id"]));
                    //comentario.Usuario = usuario.Select(Convert.ToInt32(objDataReader["col_id"]));

                    comentarios.Add(comentario);
                }

                objConexao.Close();
                objConexao.Dispose();
                objCommand.Dispose();

                return comentarios;
            }
            catch (Exception)
            {

                throw new Exception("Ocorreu um erro ao selecionar os dados de comentarios.");
            }
        }
    }
}
