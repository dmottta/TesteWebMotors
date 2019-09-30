using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for ModelBLL
/// </summary>

[DataObjectAttribute]
public class ModelBLL
{

    class Model
    {
        public int id { get; set; }
        public int makeId { get; set; }        
        public string name { get; set; }

    }


    /// <summary>
    /// Exibe todos os Models
    /// </summary>    
    /// <returns></returns>
    public static DataTable GetModel(int makeId)
    {
        var jsonData = "";

        try
        {
            using (WebClient wc = new WebClient())
            {
                string url = "http://desafioonline.webmotors.com.br/api/OnlineChallenge/Model?MakeID=" + makeId.ToString();
                jsonData = wc.DownloadString(url);
            }

        }
        catch (Exception ex)
        {
            ex.ToString();            
        }

        DataTable dt = new DataTable();
        dt.Columns.Add("Id");
        dt.Columns.Add("MakeId");        
        dt.Columns.Add("Name");
        DataRow dr = null;

        var list = JsonConvert.DeserializeObject<List<Model>>(jsonData);
        foreach (var item in list)
        {
            dr = dt.NewRow(); // have new row on each iteration
            dr["Id"] = item.id;
            dr["MakeId"] = item.makeId;
            dr["Name"] = item.name;
            dt.Rows.Add(dr);
        }

        return dt;
    }

    /// <summary>
    /// Exibe todos os Models
    /// </summary>    
    /// <returns></returns>
    public static string GetModelStr(int makeId)
    {
        var result = "";
        var jsonData = "";

        try
        {
            using (WebClient wc = new WebClient())
            {
                string url = "http://desafioonline.webmotors.com.br/api/OnlineChallenge/Model?MakeID=" + makeId.ToString();
                jsonData = wc.DownloadString(url);
            }

        }
        catch (Exception ex)
        {
            result = ex.ToString();
        }


        var list = JsonConvert.DeserializeObject<List<Model>>(jsonData);
        foreach (var item in list)
        {            
            result += item.name;
        }

        return result;
    }

}