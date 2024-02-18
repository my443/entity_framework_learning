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
            DataTable dataTable =  readCSV.GetDataTabletFromCSVFile(csvFileName);

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
