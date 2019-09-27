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
/// Summary description for MakeBLL
/// </summary>

[DataObjectAttribute]
public class MakeBLL
{

    class Make
    {
        public int id { get; set; }
        public string name { get; set; }

    }


    /// <summary>
    /// Exibe todos os Makes
    /// </summary>    
    /// <returns></returns>
    public static DataTable GetMake()
    {
        var jsonData = "";

        try
        {
            using (WebClient wc = new WebClient())
            {
                string url = "http://desafioonline.webmotors.com.br/api/OnlineChallenge/Make";
                jsonData = wc.DownloadString(url);
            }

        }
        catch (Exception ex)
        {
            ex.ToString();            
        }

        DataTable dt = new DataTable();
        dt.Columns.Add("Id");
        dt.Columns.Add("Name");
        DataRow dr = null;

        var list = JsonConvert.DeserializeObject<List<Make>>(jsonData);
        foreach (var item in list)
        {
            dr = dt.NewRow(); // have new row on each iteration
            dr["Id"] = item.id;
            dr["Name"] = item.name;
            dt.Rows.Add(dr);
        }

        return dt;
    }

    /// <summary>
    /// Exibe todos os Makes
    /// </summary>    
    /// <returns></returns>
    public static string GetMakeStr()
    {
        var result = "";
        var jsonData = "";

        try
        {
            using (WebClient wc = new WebClient())
            {
                string url = "http://desafioonline.webmotors.com.br/api/OnlineChallenge/Make";
                jsonData = wc.DownloadString(url);
            }

        }
        catch (Exception ex)
        {
            result = ex.ToString();
        }


        var list = JsonConvert.DeserializeObject<List<Make>>(jsonData);
        foreach (var item in list)
        {            
            result += item.name;
        }

        return result;
    }

}