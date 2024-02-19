using Csv;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data.SQLite;

namespace Entity_Framework_Learning
{
    public class ReadCSV
    {
        public string[] Headers { get; set; }

        /// <summary>
        /// A function that reads a csv file into a DataTable.
        /// 
        /// </summary>
        /// <param name="csv_file_path"></param>
        /// <returns></returns>
        public DataTable GetDataTableFromCSVFile(string csv_file_path)
        {
            DataTable csvDataTable = new DataTable();

            string csv = File.ReadAllText(csv_file_path, Encoding.Latin1);

            IEnumerable<ICsvLine> csvEnumerable = CsvReader.ReadFromText(csv);

            string[] headers = csvEnumerable.ElementAt(0).Headers.ToArray();
            this.Headers = headers;

            // Add the columns to the DataTable
            csvDataTable = addColumnsToDataTable(csvDataTable, headers);

            foreach (var line in csvEnumerable)
            {
               csvDataTable.Rows.Add(line);
            }

            //ICsvLine[] lines = CsvReader.ReadFromText(csv).ToArray();
            //string[] headers = lines[0].Headers;
            //Console.WriteLine(lines[0]);

            //getCSVHeaders(headers);

            return csvDataTable;

        }

        public void printCSVHeaders()
        {
            string[] headers = this.Headers;
            foreach (var header in headers)
            {
                Console.WriteLine(header);
            }
        }

        /// <summary>
        /// Adds columns to the DataTable.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        private DataTable addColumnsToDataTable(DataTable table, string[] headers)
        {
            // Add Each Header as a column
            foreach (var header in headers)
            {
                table.Columns.Add(header);
            }

            return table;
        }


        private static void dataTableToDatabase()
        {
            String connectionString = @"Data Source=C:\Users\jvand\source\repos\users.db";

            System.Data.SQLite.SQLiteConnection connection = new System.Data.SQLite.SQLiteConnection(connectionString);
            System.Data.SQLite.SQLiteCommand cmd = new System.Data.SQLite.SQLiteCommand("select * from table");
            cmd.Connection = connection;

            // Note if you have SQLServer you will use the SqlDataAdapter here.
            SQLiteDataAdapter myAdapter = new SQLiteDataAdapter("SELECT DeptNo, DName FROM Dept", connection);

            // TODO
            // 1. Add the columns and the select statement. 
            // 2. Attach the DataTable to the SQL statement 
            // 3. Write the DataTable to the database. 
            
        }
    }
}
