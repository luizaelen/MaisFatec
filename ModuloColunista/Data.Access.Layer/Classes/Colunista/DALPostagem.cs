using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Data.Transfer.Object.Classes.Colunista;

namespace Data.Access.Layer.Classes.Colunista
{
    public class DALPostagem
    {
        public DTOPostagem Select(int codigo)
        {
            DTOPostagem postagem = null;
            DALComentario comentario = null;
            DALTema tema = null;
            List<DTOComentario> comentarios = new List<DTOComentario>();


            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objDataReader;
            objConexao = Mapped.Connection();
            objComando = Mapped.Command("SELECT * FROM tbl_postagem p INNER JOIN tbl_colunista u ON p.col_id = u.col_id INNER JOIN tbl_tipopostagem tp ON p.tip_id = tp.tip_id WHERE p.pos_id = ?codigo AND p.pos_ativo = true", objConexao);

            objComando.Parameters.Add(Mapped.Parameter("?codigo", codigo));
            objDataReader = objComando.ExecuteReader();
            while (objDataReader.Read())
            {
                postagem = new DTOPostagem();
                comentario = new DALComentario();
                tema = new DALTema();

                postagem.PostagemId = Convert.ToInt32(objDataReader["Pos_id"]);
                postagem.DataPostagem = Convert.ToDateTime(objDataReader["Pos_data"]);
                postagem.Titulo = Convert.ToString(objDataReader["Pos_titulo"]);
                postagem.Conteudo = Convert.ToString(objDataReader["Pos_conteudo"]);

                postagem.Usuario.UsuarioId = Convert.ToInt32(objDataReader["col_id"]);
                postagem.Usuario.Nome = Convert.ToString(objDataReader["col_nome"]);

                postagem.TipoPostagem.TipoPostagemId = Convert.ToInt32(objDataReader["tip_id"]);
                postagem.TipoPostagem.Tipo = Convert.ToString(objDataReader["tip_tipo"]);

                postagem.Comentarios = comentario.SelectAllById(codigo);
                postagem.Temas = tema.SelectTemasPostagem(codigo);

                postagem.Usuario.Perfil = null;
                postagem.Usuario.Postagens = null;
                postagem.Usuario.Comentarios = null;

            }

            objConexao.Close();
            objDataReader.Close();

            objComando.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();

            return postagem;

        }

        public int Update(DTOPostagem postagem)
        {
            int errNumber = 0;
            try
            {
                IDbConnection objConnnexao;
                IDbCommand objCommand;
                string sql = "UPDATE tbl_postagem SET tip_id = ?tipo, pos_data = ?data, pos_titulo = ?titulo, pos_conteudo = ?conteudo WHERE Pos_id = ?codigo and pos_ativo = true";

                //recebendo a conexão e executando o cmd
                objConnnexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConnnexao);

                //atribuindo os parametros da string sql
                objCommand.Parameters.Add(Mapped.Parameter("?codigo", postagem.PostagemId));
                objCommand.Parameters.Add(Mapped.Parameter("?tipo", postagem.TipoPostagem.TipoPostagemId));
                objCommand.Parameters.Add(Mapped.Parameter("?data", postagem.DataPostagem));
                objCommand.Parameters.Add(Mapped.Parameter("?titulo", postagem.Titulo));
                objCommand.Parameters.Add(Mapped.Parameter("?conteudo", postagem.Conteudo));
                //objCommand.Parameters.Add(Mapped.Parameter("?usuario", postagem.Usuario.UsuarioId));

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

        public int Insert(DTOPostagem postagem)
        {
            int errNumber = 0;
            try
            {

                IDbConnection objConexao;
                IDbCommand objCommand;
                string sql = "INSERT INTO tbl_postagem(pos_id, tip_id, pos_data,pos_titulo, pos_conteudo, col_id, pos_ativo) VALUES (?codigo, ?tipo, ?data, ?titulo, ?conteudo, ?usuario, true);select LAST_INSERT_ID();";//ultimo comando pega o id gerado no insert

                //recebendo a conexão e executando o cmd
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);

                //atribuindo os parametros da string sql
                objCommand.Parameters.Add(Mapped.Parameter("?codigo", null));
                objCommand.Parameters.Add(Mapped.Parameter("?tipo", postagem.TipoPostagem.TipoPostagemId));
                objCommand.Parameters.Add(Mapped.Parameter("?data", postagem.DataPostagem));
                objCommand.Parameters.Add(Mapped.Parameter("?titulo", postagem.Titulo));
                objCommand.Parameters.Add(Mapped.Parameter("?conteudo", postagem.Conteudo));
                objCommand.Parameters.Add(Mapped.Parameter("?usuario", postagem.Usuario.UsuarioId));

                //objCommand.ExecuteNonQuery();
                //apos executar o insert pego o id gerado na tabela com o comando abaixo
                int id = Convert.ToInt32(objCommand.ExecuteScalar());
                objConexao.Close();

                if (postagem.Temas.Count > 0)
                {
                    foreach (var item in postagem.Temas)
                    {
                        InsertTemasPostagem(id, item.TemaId);

                    }
                }

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

        public int Delete(int codigo)
        {
            int errNumber = 0;
            try
            {
                IDbConnection objConnnexao;
                IDbCommand objCommand;
                string sql = "UPDATE tbl_postagem SET pos_ativo = ?ativo WHERE Pos_id = ?codigo";

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

        public List<DTOPostagem> SelectAll()
        {

            List<DTOPostagem> postagens = new List<DTOPostagem>();
            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataReader objDataReader;

            try
            {
                objConexao = Mapped.Connection();
                string sql = "SELECT * FROM tbl_postagem p INNER JOIN tbl_colunista u ON p.col_id = u.col_id INNER JOIN tbl_tipopostagem tp ON p.tip_id = tp.tip_id WHERE p.pos_ativo = true ORDER BY p.pos_data DESC";
                objCommand = Mapped.Command(sql, objConexao);
                objDataReader = objCommand.ExecuteReader();

                while (objDataReader.Read())
                {
                    DTOPostagem postagem = new DTOPostagem();
                    DALComentario comentario = new DALComentario();
                    DALTema tema = new DALTema();

                    postagem.PostagemId = Convert.ToInt32(objDataReader["Pos_id"]);
                    postagem.DataPostagem = Convert.ToDateTime(objDataReader["Pos_data"]);
                    postagem.Titulo = Convert.ToString(objDataReader["Pos_titulo"]);
                    postagem.Conteudo = Convert.ToString(objDataReader["Pos_conteudo"]);

                    postagem.Usuario.UsuarioId = Convert.ToInt32(objDataReader["col_id"]);
                    postagem.Usuario.Nome = Convert.ToString(objDataReader["col_nome"]);

                    postagem.TipoPostagem.TipoPostagemId = Convert.ToInt32(objDataReader["tip_id"]);
                    postagem.TipoPostagem.Tipo = Convert.ToString(objDataReader["tip_tipo"]);

                    postagem.Comentarios = comentario.SelectAllById(postagem.PostagemId);
                    postagem.Temas = tema.SelectTemasPostagem(postagem.PostagemId);

                    postagem.Usuario.Perfil = null;
                    postagem.Usuario.Postagens = null;
                    postagem.Usuario.Comentarios = null;

                    postagens.Add(postagem);
                }

                objConexao.Close();
                objConexao.Dispose();
                objCommand.Dispose();

                return postagens;
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro ao selecionar os dados de postagems.");
            }
        }

        public List<DTOPostagem> SelectUltimas()
        {
            List<DTOPostagem> postagens = new List<DTOPostagem>();
            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataReader objDataReader;

            try
            {
                objConexao = Mapped.Connection();
                string sql = "SELECT * FROM tbl_postagem p INNER JOIN tbl_colunista u ON p.col_id = u.col_id INNER JOIN tbl_tipopostagem tp ON p.tip_id = tp.tip_id WHERE p.pos_ativo = true ORDER BY p.pos_data DESC LIMIT 4 ";
                objCommand = Mapped.Command(sql, objConexao);
                objDataReader = objCommand.ExecuteReader();

                while (objDataReader.Read())
                {
                    DTOPostagem postagem = new DTOPostagem();
                    DALComentario comentario = new DALComentario();
                    DALTema tema = new DALTema();


                    postagem.PostagemId = Convert.ToInt32(objDataReader["Pos_id"]);
                    postagem.DataPostagem = Convert.ToDateTime(objDataReader["Pos_data"]);
                    postagem.Titulo = Convert.ToString(objDataReader["Pos_titulo"]);
                    postagem.Conteudo = Convert.ToString(objDataReader["Pos_conteudo"]);

                    postagem.Usuario.UsuarioId = Convert.ToInt32(objDataReader["col_id"]);
                    postagem.Usuario.Nome = Convert.ToString(objDataReader["col_nome"]);

                    postagem.TipoPostagem.TipoPostagemId = Convert.ToInt32(objDataReader["tip_id"]);
                    postagem.TipoPostagem.Tipo = Convert.ToString(objDataReader["tip_tipo"]);

                    postagem.Comentarios = comentario.SelectAllById(postagem.PostagemId);
                    postagem.Temas = tema.SelectTemasPostagem(postagem.PostagemId);

                    postagem.Usuario.Perfil = null;
                    postagem.Usuario.Postagens = null;
                    postagem.Usuario.Comentarios = null;

                    postagens.Add(postagem);
                }

                objConexao.Close();
                objConexao.Dispose();
                objCommand.Dispose();

                return postagens;
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro ao selecionar os dados de postagems.");
            }
        }

        public List<DTOPostagem> SelectPostagensColunista(int codigo)
        {
            List<DTOPostagem> postagens = new List<DTOPostagem>();
            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataReader objDataReader;

            try
            {
                objConexao = Mapped.Connection();
                string sql = "SELECT * FROM tbl_postagem p INNER JOIN tbl_tipopostagem tp ON p.tip_id = tp.tip_id WHERE p.pos_ativo = true  AND p.col_id = ?codigo ORDER BY p.pos_data DESC ";

                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?codigo", codigo));
                objDataReader = objCommand.ExecuteReader();

                while (objDataReader.Read())
                {
                    DTOPostagem postagem = new DTOPostagem();

                    postagem.PostagemId = Convert.ToInt32(objDataReader["Pos_id"]);
                    postagem.DataPostagem = Convert.ToDateTime(objDataReader["Pos_data"]);
                    postagem.Titulo = Convert.ToString(objDataReader["Pos_titulo"]);
                    postagem.Conteudo = Convert.ToString(objDataReader["Pos_conteudo"]);

                    postagem.Usuario = null;

                    postagem.TipoPostagem.TipoPostagemId = Convert.ToInt32(objDataReader["tip_id"]);
                    postagem.TipoPostagem.Tipo = Convert.ToString(objDataReader["tip_tipo"]);

                    postagem.Comentarios = null;

                    postagens.Add(postagem);
                }

                objConexao.Close();
                objConexao.Dispose();
                objCommand.Dispose();

                return postagens;
            }
            catch (Exception e)
            {
                throw new Exception("Ocorreu um erro ao selecionar os dados de postagems.");
            }
        }

        public bool InsertTemasPostagem(int postagem, int tema)
        {
            bool erro = false;
            try
            {

                IDbConnection objConexao;
                IDbCommand objCommand;
                string sql = "INSERT INTO tbl_postagemtema (tem_id, pos_id) VALUES (?temaId, ?postagemId)";

                //recebendo a conexão e executando o cmd
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);

                //atribuindo os parametros da string sql
                objCommand.Parameters.Add(Mapped.Parameter("?temaId", tema));
                objCommand.Parameters.Add(Mapped.Parameter("?postagemId", postagem));

                objCommand.ExecuteNonQuery();
                objConexao.Close();

                //abrindo novamente conexão
                objConexao.Dispose();
                objCommand.Dispose();

            }//try
            catch (Exception ex)
            {
                erro = true;
            }

            return erro;
        }

    }
}
