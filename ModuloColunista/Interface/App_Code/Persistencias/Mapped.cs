using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

/// <summary>
/// Summary description for Mapped
/// </summary>
public class Mapped
{
    public Mapped()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //metodo de conexão com o banco de dados 
    //acesso direto ao webconfig, appsettings
    public static IDbConnection Connection()
    {
        MySqlConnection objConexao = new MySqlConnection(ConfigurationManager.AppSettings["strConexao"]);
        objConexao.Open();
        return objConexao;
    }
    //Executa comandos sql a partir das classes
    // de persistencia
    public static IDbCommand Command(string query, IDbConnection objConexao)
    {
        IDbCommand command = objConexao.CreateCommand();
        command.CommandText = query;
        return command;
    }

    // parametriza os valores de entrada.
    // Parametro passado atraves do metodoDB
    // evita SQLInjection...
    public static IDbDataParameter Parameter(string nomeparametro, object valor)
    {
        return new MySqlParameter(nomeparametro, valor);
    }

    // collection
    // container armazenando os valores vindo do
    //obj Command
    public static IDataAdapter Adapter(IDbCommand command)
    {
        IDbDataAdapter adap = new MySqlDataAdapter();
        adap.SelectCommand = command;
        return adap;
    }
}