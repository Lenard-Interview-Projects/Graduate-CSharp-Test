namespace CustomerRelationshipManager
{
    class Program
    {
        static void Main(string[] args)
        {
            DataStorage storage = new DataStorage();
            storage.Initialize();

            MainMenu.ShowMenu();
        }
    }
}