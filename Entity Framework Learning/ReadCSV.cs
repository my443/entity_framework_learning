using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework_Learning
{
    public class ReadCSV
    {
        /// <summary>
        /// A function that reads a csv file into a DataTable.
        /// 
        /// </summary>
        /// <param name="csv_file_path"></param>
        /// <returns></returns>
        public DataTable GetDataTabletFromCSVFile(string csv_file_path) { 
            DataTable csvData = new DataTable();
            
            string csv = File.ReadAllText(csv_file_path);
            Console.WriteLine(csv);

            return csvData;
        
        }
    }
}
