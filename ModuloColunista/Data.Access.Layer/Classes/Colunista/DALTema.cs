using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Data.Transfer.Object.Classes.Colunista;

namespace Data.Access.Layer.Classes.Colunista
{
    public class DALTema
    {
        public DTOTema Select(int codigo)
        {
            DTOTema tema = null;
            DALPostagem postagem = null;

            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objDataReader;
            objConexao = Mapped.Connection();
            objComando = Mapped.Command("SELECT * FROM tbl_tema WHERE tem_id = ?codigo AND tem_ativo = true", objConexao);

            objComando.Parameters.Add(Mapped.Parameter("?codigo", codigo));
            objDataReader = objComando.ExecuteReader();
            while (objDataReader.Read())
            {
                tema = new DTOTema();
                postagem = new DALPostagem();

                tema.TemaId = Convert.ToInt32(objDataReader["tem_id"]);
                tema.DataTema = Convert.ToDateTime(objDataReader["tem_data"]);
                tema.Nome = Convert.ToString(objDataReader["tem_nome"]);
                //tema.Postagens = postagem.Select(Convert.ToInt32(objDataReader["pos_id"]));
            }

            objConexao.Close();
            objDataReader.Close();

            objComando.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();

            return tema;

        }

        public List<DTOTema> SelectTemasPostagem(int idpostagem)
        {

            List<DTOTema> temas = new List<DTOTema>();
            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataReader objDataReader;

            try
            {
                objConexao = Mapped.Connection();
                //string sql = "SELECT * FROM tbl_tema t INNER JOIN tbl_postagemtema pt ON t.tem_id = pt.tem_id WHERE pt.pos_id = ?codigo and tem_ativo = true order by tem_nome asc;";
                string sql = "SELECT * FROM tbl_tema t INNER JOIN tbl_postagemtema pt ON t.tem_id = pt.tem_id WHERE pt.pos_id = ?codigo and tem_ativo = true;";
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?codigo", idpostagem));
                objDataReader = objCommand.ExecuteReader();

                while (objDataReader.Read())
                {
                    DTOTema tema = new DTOTema();

                    tema.TemaId = Convert.ToInt32(objDataReader["tem_id"]);
                    tema.DataTema = Convert.ToDateTime(objDataReader["tem_data"]);
                    tema.Nome = Convert.ToString(objDataReader["tem_nome"]);

                    tema.Postagens = null;

                    temas.Add(tema);
                }

                objConexao.Close();
                objConexao.Dispose();
                objCommand.Dispose();

                return temas;
            }
            catch (Exception)
            {

                throw new Exception("Ocorreu um erro ao selecionar os dados de temas.");
            }

        }

        public int Update(DTOTema tema)
        {
            int errNumber = 0;
            try
            {
                IDbConnection objConnnexao;
                IDbCommand objCommand;
                string sql = "UPDATE tbl_tema SET tem_nome = ?nome, tem_data = ?data, pos_id = ?postagem WHERE tem_id = ?codigo, tem_ativo = true";

                //recebendo a conexão e executando o cmd
                objConnnexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConnnexao);

                //atribuindo os parametros da string sql
                objCommand.Parameters.Add(Mapped.Parameter("?codigo", tema.TemaId));
                objCommand.Parameters.Add(Mapped.Parameter("?nome", tema.Nome));
                objCommand.Parameters.Add(Mapped.Parameter("?data", tema.DataTema));
                //objCommand.Parameters.Add(Mapped.Parameter("?postagem", tema.Postagens.PostagemId));

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

        public int Insert(DTOTema tema)
        {
            int errNumber = 0;
            try
            {

                IDbConnection objConexao;
                IDbCommand objCommand;
                string sql = "INSERT INTO tbl_tema(tem_id, col_id, tem_nome, tem_data, tem_ativo) VALUES (?codigo, ?usuario, ?nome, ?data, true)";

                //recebendo a conexão e executando o cmd
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);

                //atribuindo os parametros da string sql
                objCommand.Parameters.Add(Mapped.Parameter("?codigo", null));
                objCommand.Parameters.Add(Mapped.Parameter("?usuario", 2));
                objCommand.Parameters.Add(Mapped.Parameter("?nome", tema.Nome));
                objCommand.Parameters.Add(Mapped.Parameter("?data", tema.DataTema));



                //objCommand.Parameters.Add(Mapped.Parameter("?postagem", tema.Postagens.PostagemId));

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

        public int Delete(int codigo)
        {
            int errNumber = 0;
            try
            {
                IDbConnection objConnnexao;
                IDbCommand objCommand;
                string sql = "UPDATE tbl_tema SET tem_ativo = ?ativo WHERE tem_id = ?codigo";

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

        public List<DTOTema> SelectAll()
        {
            DTOTema tema = null;
            DALPostagem postagem = null;

            List<DTOTema> temas = new List<DTOTema>();
            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataReader objDataReader;

            try
            {
                objConexao = Mapped.Connection();
                string sql = "SELECT * FROM tbl_tema WHERE tem_ativo = true order by tem_nome asc";
                objCommand = Mapped.Command(sql, objConexao);
                objDataReader = objCommand.ExecuteReader();

                while (objDataReader.Read())
                {
                    tema = new DTOTema();
                    postagem = new DALPostagem();

                    tema.TemaId = Convert.ToInt32(objDataReader["tem_id"]);
                    tema.DataTema = Convert.ToDateTime(objDataReader["tem_data"]);
                    tema.Nome = Convert.ToString(objDataReader["tem_nome"]);
                    //tema.Postagens = postagem.Select(Convert.ToInt32(objDataReader["pos_id"]));

                    temas.Add(tema);
                }

                objConexao.Close();
                objConexao.Dispose();
                objCommand.Dispose();

                return temas;
            }
            catch (Exception)
            {

                throw new Exception("Ocorreu um erro ao selecionar os dados de temas.");
            }
        }
    }
}
