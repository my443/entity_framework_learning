using Csv;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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
        public DataTable GetDataTabletFromCSVFile(string csv_file_path)
        {
            DataTable csvData = new DataTable();

            string csv = File.ReadAllText(csv_file_path, Encoding.Latin1);

            IEnumerable<ICsvLine> csvEnumerable = CsvReader.ReadFromText(csv);

            string[] headers = csvEnumerable.ElementAt(0).Headers.ToArray();
            this.Headers = headers;

            //ICsvLine[] lines = CsvReader.ReadFromText(csv).ToArray();
            //string[] headers = lines[0].Headers;
            //Console.WriteLine(lines[0]);

            //getCSVHeaders(headers);

            return csvData;

        }

        public void printCSVHeaders()
        {
            string[] headers = this.Headers;
            foreach (var header in headers)
            {
                Console.WriteLine(header);
            }
        }
    }
}
