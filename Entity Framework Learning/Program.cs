using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Reflection.Emit;
using System.Reflection;
using System.Xml;
using System;
using Microsoft.Data.SqlClient;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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

            DataTable dataTable =  readCSV.GetDataTableFromCSVFile(csvFileName);

            //Console.WriteLine(readCSV.Headers);
            //readCSV.printCSVHeaders();

            string query = table.createTable("something", readCSV.Headers);
            //Console.WriteLine(query);

            // Custom DataType Class - if you want to run this to try it. 
            //CustomDataTypeClass customDataTypeClass = new CustomDataTypeClass();
            //customDataTypeClass.createMyType();

            Console.WriteLine("Success!");
        }

        /// <summary>
        /// Adds a user to the database. 
        /// </summary>
        private static void addUser()
        {
            ApplicationContext context = new ApplicationContext();
            User user = new User();
            user.Name = "John";
            user.Email = "john@johnv.ca";

            context.Users.Add(user);
            context.SaveChanges();
        }
        
        /// <summary>
        /// An example of an anonymous Object.
        /// </summary>
        private static void anonymousObject()
        {
            //https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/object-and-collection-initializers
            var pet = new { Age = 10, Name = "Fluffy" };
            ApplicationContext context = new ApplicationContext();

            var record = new  { BN = "11234", FPE = "id123" };
        }


    }
}
