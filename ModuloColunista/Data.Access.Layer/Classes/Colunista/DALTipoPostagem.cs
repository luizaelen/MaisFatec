using Data.Transfer.Object.Classes.Colunista;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Data.Access.Layer.Classes.Colunista
{
    public class DALTipoPostagem
    {
        public DTOTipoPostagem Select(int codigo)
        {
            DTOTipoPostagem tipopostagem = new DTOTipoPostagem();
            //DALPerfil perfil =  null;
            //List<DTOComentario> comentarios = new List<DTOComentario>();

            IDbConnection objConexao;
            IDbCommand objComando;
            IDataReader objDataReader;
            objConexao = Mapped.Connection();
            objComando = Mapped.Command("SELECT * FROM tbl_tipopostagem WHERE tip_id = ?codigo", objConexao);

            objComando.Parameters.Add(Mapped.Parameter("?codigo", codigo));
            objDataReader = objComando.ExecuteReader();
            while (objDataReader.Read())
            {
                tipopostagem.TipoPostagemId = Convert.ToInt32(objDataReader["tip_id"]);
                tipopostagem.Tipo = Convert.ToString(objDataReader["tip_tipo"]);
            }

            objConexao.Close();
            objDataReader.Close();

            objComando.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();

            return tipopostagem;


        }

        public bool Update(DTOTipoPostagem tipoPostagem)
        {
            bool err = true;
            try
            {
                IDbConnection objConnnexao;
                IDbCommand objCommand;
                string sql = "UPDATE tbl_tipopostagem SET tip_tipo = ?nome WHERE tip_id = ?codigo";

                //recebendo a conexão e executando o cmd
                objConnnexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConnnexao);

                //atribuindo os parametros da string sql
                objCommand.Parameters.Add(Mapped.Parameter("?codigo", tipoPostagem.TipoPostagemId));
                objCommand.Parameters.Add(Mapped.Parameter("?nome", tipoPostagem.Tipo));

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

        public bool Insert(DTOTipoPostagem tipoPostagem)
        {
            bool err = true;
            try
            {

                IDbConnection objConexao;
                IDbCommand objCommand;
                string sql = "INSERT INTO tbl_tipopostagem(tip_id, tip_tipo) VALUES(?codigo, ?nome)";

                //recebendo a conexão e executando o cmd
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);

                //atribuindo os parametros da string sql
                objCommand.Parameters.Add(Mapped.Parameter("?codigo", null));//o campo id na tabela deve ser autoincremente para nao haver conflitos ao inserir
                objCommand.Parameters.Add(Mapped.Parameter("?nome", tipoPostagem.Tipo));

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

        public List<DTOTipoPostagem> SelectAll()
        {
            List<DTOTipoPostagem> tipopostagens = new List<DTOTipoPostagem>();

            IDbConnection objConexao;
            IDbCommand objCommand;
            IDataReader objDataReader;

            try
            {
                objConexao = Mapped.Connection();
                string sql = "SELECT * FROM tbl_tipopostagem";
                objCommand = Mapped.Command(sql, objConexao);
                objDataReader = objCommand.ExecuteReader();

                while (objDataReader.Read())
                {
                    DTOTipoPostagem tipopostagem = new DTOTipoPostagem();

                    tipopostagem.TipoPostagemId = Convert.ToInt32(objDataReader["tip_id"]);
                    tipopostagem.Tipo = Convert.ToString(objDataReader["tip_tipo"]);

                    tipopostagens.Add(tipopostagem);
                }

                objConexao.Close();
                objConexao.Dispose();
                objCommand.Dispose();

                return tipopostagens;
            }
            catch (Exception)
            {

                throw new Exception("Ocorreu um erro ao selecionar os dados de tipoPostagems.");
            }
        }
    }
}
