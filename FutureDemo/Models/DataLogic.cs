using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FutureDemo.Models
{
    public class DataLogic
    {
        public static List<UserData> ReadFromJsonFile()
        {
            List<UserData> dataList = new List<UserData>();
            try
            {
                var fileName = HttpContext.Current.Server.MapPath("~/App_Data/Data.json");
                var json = File.ReadAllText(fileName);
                if (json.Length > 0)
                {
                    var jobj = JArray.Parse(json);
                    dataList = JsonConvert.DeserializeObject<List<UserData>>(json);
                }
            }
            finally
            {

            }
            return dataList;
        }
        public static void SaveToJsonFile(List<UserData> dataList)
        {
            string json = JsonConvert.SerializeObject(dataList);

            var fileName = HttpContext.Current.Server.MapPath("~/App_Data/Data.json");
            System.IO.File.WriteAllText(fileName, json);
        }
    }

    public class UserData
    {
        public float Data { get; set; }
        public bool Display { get; set; }
        public string AddDate { get; set; }
    }
}