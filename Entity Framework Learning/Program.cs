using System.Data;

namespace Entity_Framework_Learning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //addUser();
            ReadCSV readCSV = new ReadCSV();
            DataTable dataTable =  readCSV.GetDataTabletFromCSVFile("C:\\Users\\jvand\\source\\repos\\Entity Framework Learning\\input.csv");

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
