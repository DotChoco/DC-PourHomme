
namespace DC_PourHomme.Backend
{
    using Models;
    using System.Data;

    public class Backend
    {

        public const string SUCCESFUL_LOG = "SUCCESFUL";
        public const string FAIL_LOG = "FAIL";
        public DataBase? dataBase { get; } = new();
        

        public Backend() => dataBase.Create();
        public Tuple<Parfum, string> SearchItem(string Name) => SearchAnItem(Name);
        public void AddItem(Parfum Parfum) => AddAnItem(Parfum);
        public void DeleteItem(string Name) => DeleteAnItem(Name);
        public void UpdateItem(Parfum Parfum) => UpdateAnItem(Parfum);



        Tuple<Parfum, string> SearchAnItem(string name)
        {
            Parfum? parfum = dataBase.Parfums.Find(x => x.Name == name);
            if (parfum != null )
                return new(parfum, SUCCESFUL_LOG);
            return new(new(), FAIL_LOG);
        }

        void DeleteAnItem(string name)
        {
            Parfum? parfum = dataBase.Parfums.Find(x => x.Name == name);
            if(parfum != null)
                dataBase.Parfums.Remove(parfum);
            dataBase.Update();
        }

        void UpdateAnItem(Parfum parfum)
        {
            Parfum? oldParfum = dataBase.Parfums.Find(x => x.Name == parfum.Name);
            if (oldParfum != null)
            {
                int index = dataBase.Parfums.IndexOf(oldParfum);
                dataBase.Parfums[index] = parfum;
                dataBase.Update();
            }
        }

        void AddAnItem(Parfum parfum)
        {
            dataBase.Parfums.Add(parfum);
            dataBase.Update();
        }
    }
}
