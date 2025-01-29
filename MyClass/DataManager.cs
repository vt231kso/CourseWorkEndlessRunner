using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace MyClass
{
    public class Data
    {
        public int LastScore { get; set; } = 0;
        public int MaxScore { get; set; } = 0;
        public int Coins { get; set; } = 0;
        public int Volume {  get; set; } = 50;
        public List<string> Skins { get; set; } = new List<string>();
    }
    public static class DataManager
    {
        public static Data LoadData()
        {

            if (File.Exists("data.json"))
            {
                string textData = File.ReadAllText(@"./data.json");
                var data = JsonSerializer.Deserialize<Data>(textData);
                return data;
            }
            else
            {
                var data = new Data();
                string json = JsonSerializer.Serialize(data);

                File.WriteAllText(@"./data.json", json);
                return data;
            }

        }
        public static void EditData(Data data)
        {
            if (File.Exists("data.json"))
            {
                string json = JsonSerializer.Serialize(data);

                File.WriteAllText(@"./data.json", json);
            }
        }
    }
  


}
