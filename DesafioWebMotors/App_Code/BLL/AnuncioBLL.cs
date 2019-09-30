using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for AnuncioBLL
/// </summary>
[DataObjectAttribute]
public class AnuncioBLL
{
    public AnuncioBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary>
    /// Exibe todos os Anúncios
    /// </summary>    
    /// <returns></returns>
    public static DataTable GetAnuncio()
    {
        return Dados.ExecuteQuery("SELECT * from tb_AnuncioWebmotors");
    }


    /// <summary>
    /// Lista um Anúncio
    /// </summary>    
    /// <returns></returns>
    public static DataTable GetAnuncio(int id)
    {
        return Dados.ExecuteQuery("SELECT * from tb_AnuncioWebmotors where id = " + id.ToString());
    }


    /// <summary>
    /// Inclui um Anúncio no BD, fácil
    /// </summary>
    /// <returns></returns>
    public static int IncluirFacil()
    {
        StringBuilder query = new StringBuilder();
        query.AppendLine("INSERT INTO tb_AnuncioWebmotors(marca, modelo, versao, ano, quilometragem, observacao");
        query.AppendLine(")");

        query.AppendLine("VALUES('MARCA', 'MODELO', 'VERSAO', 0, 0, '*** NOVO ANÚNCIO'");
        query.AppendLine(")");

        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = query.ToString();       

        return Convert.ToInt16(Dados.ExecuteScalar(cmd));
    }


    /// <summary>
    /// Inclui um Anúncio no BD, fácil
    /// </summary>
    /// <returns></returns>
    public static int Incluir(string marca, string modelo, string versao, string ano, string quilometragem, string observacao)
    {
        StringBuilder query = new StringBuilder();
        query.AppendLine("INSERT INTO tb_AnuncioWebmotors(marca, modelo, versao, ano, quilometragem, observacao)");        
        query.AppendLine("VALUES(@marca, @modelo, @versao,  @ano,  @quilometragem,  @observacao) ");

        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = query.ToString();        
        cmd.Parameters.AddWithValue("@marca", marca);
        cmd.Parameters.AddWithValue("@modelo", modelo);
        cmd.Parameters.AddWithValue("@versao", versao);
        cmd.Parameters.AddWithValue("@ano", ano);
        cmd.Parameters.AddWithValue("@quilometragem", quilometragem);
        cmd.Parameters.AddWithValue("@observacao", observacao);

        return Convert.ToInt16(Dados.ExecuteScalar(cmd));
    }

    /// <summary>
    /// Alterar um Anúncio
    /// </summary>
    /// <returns></returns>
    public static int Alterar(int id, string marca, string modelo, string versao, int ano, int quilometragem, string observacao)
    {
        StringBuilder query = new StringBuilder();
        query.AppendLine("UPDATE tb_AnuncioWebmotors ");
        query.AppendLine("SET marca = @marca, modelo = @modelo, versao= @versao, ano = @ano, quilometragem = @quilometragem, observacao = @observacao ");
        query.AppendLine("WHERE id = @id");

        SqlCommand cmd = new SqlCommand();
        cmd.CommandText = query.ToString();
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@marca", marca);
        cmd.Parameters.AddWithValue("@modelo", modelo);
        cmd.Parameters.AddWithValue("@versao", versao);
        cmd.Parameters.AddWithValue("@ano", ano);
        cmd.Parameters.AddWithValue("@quilometragem", quilometragem);
        cmd.Parameters.AddWithValue("@observacao", observacao);

        return Convert.ToInt32(Dados.ExecuteScalar(cmd));
    }

    /// <summary>
    /// Exclui um Anúncio
    /// </summary>
    /// <returns></returns>
    public static int Excluir(int id)
    {
        SqlCommand cmd = new SqlCommand("DELETE from tb_AnuncioWebmotors where ID = " + id.ToString());
        return Convert.ToInt32(Dados.ExecuteNonQuery(cmd));
    }
}