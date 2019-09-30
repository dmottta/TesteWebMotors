using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Web.Configuration;


public class Dados
{
    /// <summary>
    /// Retorna a sqlConnection que está no web.config
    /// </summary>
    /// <returns></returns>
    private static SqlConnection getConnection()
    {
        SqlConnection connection = new SqlConnection("Data Source=bssp-44;Initial Catalog=AdventureWorks2012;Persist Security Info=True;User ID=admdelphi;Password=xx77jb61");
        //SqlConnection connection = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = teste_webmotors; Integrated Security = True; Connect Timeout = 60; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
        return connection;
    }

    /// <summary>
    /// Retorna a sqlConnection que está no web.config, com parâmetro uma string de conexão
    /// </summary>
    /// <returns></returns>
    private static SqlConnection getConnection(string conexao)
    {
        SqlConnection connection = new SqlConnection(conexao);
        return connection;
    }

    
    /// <summary>
    /// Executa um comando SQL e retorna um data table, recebe um sqlcomando como parâmetro
    /// </summary>
    /// <param name="sqlCommand"></param>
    /// <returns></returns>
    public static DataTable ExecuteQuery(SqlCommand sqlCommand)
    {
        SqlConnection connection = getConnection();
        sqlCommand.Connection = connection;//getConnection();

        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dt = new DataTable("Tabela");
        sqlDataAdapter.Fill(dt);
        connection.Close();

        return dt;        
    }

    /// <summary>
    /// Executa um comando SQL e retorna um data table, recebe um sqlcomando como parâmetro
    /// </summary>
    /// <param name="sqlCommand"></param>
    /// <returns></returns>
    public static DataTable ExecuteQuery(SqlCommand sqlCommand, string conexao)
    {
        SqlConnection connection = getConnection(conexao);
        sqlCommand.Connection = connection;

        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dt = new DataTable("Tabela");
        sqlDataAdapter.Fill(dt);
        connection.Close();

        return dt;
    }

    /// <summary>
    /// Executa um comando SQL e retorna um data table, recebe um comando em string
    /// </summary>
    /// <param name="sqlCommand"></param>
    /// <returns></returns>
    public static DataTable ExecuteQuery(string query)
    {
        SqlConnection connection = getConnection();

        SqlCommand sqlCommand = new SqlCommand(query);
        sqlCommand.CommandType = CommandType.Text;
        sqlCommand.Connection = getConnection();        

        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        DataTable dt = new DataTable("Nivel1");
        sqlDataAdapter.Fill(dt);
        connection.Close();

        return dt;
    }

    /// <summary>
    /// Executa um comando SQL que não retorna dados, recebe um sqlcomando como parâmetro
    /// </summary>
    /// <param name="sqlCommand"></param>
    /// <returns></returns>
    public static int ExecuteNonQuery (SqlCommand sqlCommand)
    {
        SqlConnection connection = getConnection();
        connection.Open();
        sqlCommand.Connection = connection;        
        int result = sqlCommand.ExecuteNonQuery();
        
        connection.Close();

        return result;
    }


    /// <summary>
    /// Executa um comando SQL que retorna uma única informação
    /// </summary>
    /// <param name="sqlCommand"></param>
    /// <returns></returns>
    public static object ExecuteScalar(SqlCommand sqlCommand)
    {
        SqlConnection connection = getConnection();
        sqlCommand.Connection = connection;
        connection.Open();

        object result = sqlCommand.ExecuteScalar();

        connection.Close();

        return result;
    }

}
