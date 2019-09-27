using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for ModeloBLL
/// </summary>
[DataObjectAttribute]
public class ModeloBLL
{
    public ModeloBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary>
    /// Exibe todos os Modelos
    /// </summary>    
    /// <returns></returns>
    public static DataTable GetModelo()
    {
        return Dados.ExecuteQuery("SELECT Cod_Modelo, Des_Modelo from Modelo");
    }



    /// <summary>
    /// Pesquisa um Modelo
    /// </summary>
    /// <returns></returns>
    public static string GetModelo(int cod_Modelo)
    {
        if (cod_Modelo != 0)
            return (Dados.ExecuteQuery("SELECT Des_Modelo from Modelo where Cod_Modelo=" + cod_Modelo.ToString()).Rows[0]["Des_Modelo"].ToString());
        else
            return "";
    }


    /// <summary>
    /// Retorna o próximo código de Modelo
    /// </summary>    
    /// <returns></returns>
    public static int GetProximoCod()
    {
        return Convert.ToInt32(Dados.ExecuteQuery("SELECT IsNull(Max(Cod_Modelo),0)+1 from Modelo").Rows[0][0]);
    }

    /// <summary>
    /// Retorna os nomes das colunas que devem ser gravadas (Usuário e data)
    /// </summary>    
    /// <returns></returns>
    public static string GetColunas(int cod_Modelo)
    {
        return Dados.ExecuteQuery("SELECT Des_Colunas from Modelo where Cod_Modelo=" + cod_Modelo.ToString()).Rows[0]["Cod_Modelo"].ToString();
    }

    /// <summary>
    /// Verifica se já existe o modelo
    /// </summary>
    /// <returns></returns>
    public static bool ExisteModelo(int cod_Modelo)
    {
        DataTable dt = Dados.ExecuteQuery("SELECT top 1 1 from Modelo where Cod_Modelo = " + cod_Modelo.ToString());
        return dt.Rows.Count > 0;
    }


    /// <summary>
    /// Inclui um Modelo no banco de dados.
    /// </summary>
    /// <returns></returns>
    public static int Incluir(string des_Modelo)
    {
        int cod_Modelo = GetProximoCod();

        //if (ExisteModelo(cod_Modelo))
        //{
        //    return 0;
        //}

        StringBuilder query = new StringBuilder();
        query.AppendLine("INSERT INTO Modelo(Cod_Modelo, Des_Modelo");
        query.AppendLine(")");

        query.AppendLine("VALUES(@cod_Doc, @cod_Unidade");
        query.AppendLine(")");

        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = query.ToString();
        cmd.Parameters.AddWithValue("@cod_Modelo", cod_Modelo);
        if (des_Modelo != "" && des_Modelo != null) cmd.Parameters.AddWithValue("@des_Modelo", des_Modelo); else cmd.Parameters.AddWithValue("@des_Modelo", DBNull.Value);

        return Convert.ToInt16(Dados.ExecuteScalar(cmd));
    }

    /// <summary>
    /// Alterar um Modelo no banco de dados.
    /// </summary>
    /// <returns></returns>
    public static int Alterar(int cod_Modelo, string nom_Modelo)
    {
        StringBuilder query = new StringBuilder();
        query.AppendLine("UPDATE Modelo ");
        query.AppendLine("SET nom_Modelo = @nom_Modelo ");
        query.AppendLine("WHERE cod_Modelo = @cod_Modelo");

        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = query.ToString();
        cmd.Parameters.AddWithValue("@cod_Modelo", cod_Modelo);
        cmd.Parameters.AddWithValue("@nom_Modelo", nom_Modelo);
        return Convert.ToInt32(Dados.ExecuteScalar(cmd));
    }

    /// <summary>
    /// Exclui um Modelo
    /// </summary>
    /// <returns></returns>
    public static int Excluir(int cod_Modelo)
    {
        SqlCommand cmd = new SqlCommand("DELETE from Modelo where cod_Modelo = " + cod_Modelo.ToString());
        return Convert.ToInt32(Dados.ExecuteNonQuery(cmd));
    }

}