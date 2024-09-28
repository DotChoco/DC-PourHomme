
using DC_PourHomme.Models;
using System.Text.Json;

namespace DC_PourHomme.Backend
{
    public class DataBase
    {
        public List<Parfum>? Parfums { get; set; } = new();
        const string pathFolder = "D:/DCPH/";
        const string fileName = "PH.dcf";
        const string fullPath = pathFolder + fileName;
        public DataBase() => CreateDB();


        public void Create() => CreateDB();
        public void Read() => ReadDB();
        public void Update() => UpdateDB();

        void CreateDB()
        {
            if (!Directory.Exists(pathFolder))
                Directory.CreateDirectory(pathFolder);
            if (!File.Exists(fullPath))
            {
                StreamWriter sw = new(fullPath);
                sw.Write(string.Empty);
                sw.Close();
                return;
            }
            else
                ReadDB();

        }

        void ReadDB()
        {
            Parfums.Clear();
            StreamReader sr = new(fullPath);
            string data = sr.ReadToEnd();
            if(data != null && data != string.Empty)
                Parfums = JsonSerializer.Deserialize<List<Parfum>>(sr.ReadToEnd());
        }

        void UpdateDB()
        {
            StreamWriter sw = new(fullPath);
            sw.Write(JsonSerializer.Serialize(Parfums));
            sw.Close();
        }

    }
}
