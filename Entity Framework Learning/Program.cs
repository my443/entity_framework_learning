using System.Data;

namespace Entity_Framework_Learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //addUser();
            //string csvFileName = "C:\\Users\\jvand\\source\\repos\\Entity Framework Learning\\input.csv";
            string csvFileName = @"C:\Projects\2024-02-11 T3010 Project\T3010_Data_Files\schedule_2_goods_2021.csv";

            ReadCSV readCSV = new ReadCSV();
            DatabaseTable table = new DatabaseTable();

            DataTable dataTable =  readCSV.GetDataTabletFromCSVFile(csvFileName);
            //Console.WriteLine(readCSV.Headers);
            readCSV.printCSVHeaders();

            string query = table.createTable("something", readCSV.Headers);
            Console.WriteLine(query);

            //https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers
            var pet = new { Age = 10, Name = "Fluffy" };

            Console.WriteLine("Success!");
        }

        private static void addUser()
        {
            ApplicationContext context = new ApplicationContext();
            User user = new User();
            user.Name = "John";
            user.Email = "john@johnv.ca";

            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
