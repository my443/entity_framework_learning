using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Entity_Framework_Learning
{
    internal class DatabaseTable
    {
        public string CreateTable(string tableName, string[] columnNames) {
            string query = "";

            query = $"CREATE TABLE [{tableName}] AS (\n";
            query = query + $"[Id] INTEGER NOT NULL CONSTRAINT[PK_{tableName}] PRIMARY KEY AUTOINCREMENT,\n";

            foreach (string column in columnNames)
            {
                query = query + $"{column} TEXT NULL\n";
            }

            query = query + ")";
            
            return query;
        }
    }
}
