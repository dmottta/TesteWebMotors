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
/// Summary description for VersionBLL
/// </summary>

[DataObjectAttribute]
public class VersionBLL
{

    class Version
    {
        public int id { get; set; }
        public int modelId { get; set; }        
        public string name { get; set; }

    }


    /// <summary>
    /// Exibe todos os Versions
    /// </summary>    
    /// <returns></returns>
    public static DataTable GetVersion(int modelId)
    {
        var jsonData = "";

        try
        {
            using (WebClient wc = new WebClient())
            {
                string url = "http://desafioonline.webmotors.com.br/api/OnlineChallenge/Version?ModelId=" + modelId.ToString();
                jsonData = wc.DownloadString(url);
            }

        }
        catch (Exception ex)
        {
            ex.ToString();            
        }

        DataTable dt = new DataTable();
        dt.Columns.Add("Id");
        dt.Columns.Add("ModelId");        
        dt.Columns.Add("Name");
        DataRow dr = null;

        var list = JsonConvert.DeserializeObject<List<Version>>(jsonData);
        foreach (var item in list)
        {
            dr = dt.NewRow(); // have new row on each iteration
            dr["Id"] = item.id;
            dr["ModelId"] = item.modelId;
            dr["Name"] = item.name;
            dt.Rows.Add(dr);
        }

        return dt;
    }

    /// <summary>
    /// Exibe todos os Versions
    /// </summary>    
    /// <returns></returns>
    public static string GetVersionStr(int modelId)
    {
        var result = "";
        var jsonData = "";

        try
        {
            using (WebClient wc = new WebClient())
            {
                string url = "http://desafioonline.webmotors.com.br/api/OnlineChallenge/Version?ModelId=" + modelId.ToString();
                jsonData = wc.DownloadString(url);
            }

        }
        catch (Exception ex)
        {
            result = ex.ToString();
        }


        var list = JsonConvert.DeserializeObject<List<Version>>(jsonData);
        foreach (var item in list)
        {            
            result += item.name;
        }

        return result;
    }

}