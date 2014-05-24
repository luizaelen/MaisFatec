using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Configuration;
using Security.Layer.Encryption;
//using System.Web.Configuration;


namespace Data.Access.Layer
{
    public class Mapped
    {

        /// <summary>
        /// Método que implementa a Interface de conexão com o banco de dados.
        /// </summary>
        /// <returns>Retorna uma conexão com o banco de
        /// dados baseado em uma String de Conexão.
        /// </returns>
        public static IDbConnection Connection()
        {
            MySqlConnection objConexao = new MySqlConnection(Encrypt.DecryptString(ConfigurationManager.ConnectionStrings["strConexao"].ConnectionString));
            objConexao.Open();
            return objConexao;
        }

        /// <summary>
        /// Método que implementa a Interface de comando.
        /// </summary>
        /// <param name="query">Comando em SQL que será executado no banco.</param>
        /// <param name="objConexao">Define qual conexão será usada para executar o comando.</param>
        /// <returns>Comando a ser executado no banco já preparado.</returns>
        public static IDbCommand Command(string query, IDbConnection objConnexao)
        {
            IDbCommand command = objConnexao.CreateCommand();
            command.CommandText = query;
            return command;
        }

        /// <summary>
        /// Executa o comando no Banco de Dados.
        /// </summary>
        /// <param name="command">Comando já preparado para ser executado no banco.</param>
        /// <returns>Retorna um DataAdapter com os dados do Banco.</returns>
        public static IDataAdapter Adapter(IDbCommand command)
        {
            IDbDataAdapter adap = new MySqlDataAdapter();
            adap.SelectCommand = command;
            return adap;
        }

        /// <summary>
        /// Cria um parâmetro à ser executado em uma SQL.
        /// </summary>
        /// <param name="nomeParametro">Nome do parâmetro a ser passado para SQL.</param>
        /// <param name="valor">Valor do parâmetro a ser passado para SQL.</param>
        /// <returns></returns>
        public static IDbDataParameter Parameter(string nomeparametro, object valor)
        {
            return new MySqlParameter(nomeparametro, valor);
        }

    }
}
