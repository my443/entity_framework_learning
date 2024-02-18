using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Entity_Framework_Learning
{
    internal class DatabaseTable
    {
        public string createTable(string tableName, string[] columnNames) {
            string query = "";

            query = $"CREATE TABLE [{tableName}] (\n";
            query = query + $"[Id] INTEGER NOT NULL CONSTRAINT[PK_{tableName}] PRIMARY KEY AUTOINCREMENT,\n";

            foreach (string column in columnNames)
            {
                query = query + $"[{column}] TEXT NULL,\n";
            }

            query = query.Remove(query.Length - 2, 2) + ")"; // Remove takes off the last comma and newline characters.
            
            return query;
        }

        public string dropTable(string tableName)
        {
            string dropStatement = $"DROP TABLE {tableName};";
            return dropStatement;
        }

        public string truncateTable(string tableName)
        {
            string truncateStatement = $"TRUNCATE TABLE {tableName};";
            return truncateStatement;
        }
    }
}
