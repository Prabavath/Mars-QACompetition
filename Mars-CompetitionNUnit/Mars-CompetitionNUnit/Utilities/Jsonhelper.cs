using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_CompetitionNUnit.Utilities
{
    public class Jsonhelper
    {
        public static List<T> ReadTestDataFromJson<T>(string jsonFilePath)
        {
            string jsonContent = File.ReadAllText(jsonFilePath);
            #pragma warning disable CS8600
            List<T> testData = JsonConvert.DeserializeObject<List<T>>(jsonContent);
            #pragma warning disable CS8603
            return testData;

        }
    }

}

