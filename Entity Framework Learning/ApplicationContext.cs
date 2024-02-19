using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity_Framework_Learning
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserAccess> UsersAccess { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MyDb;Trusted_Connection=True;");
            optionsBuilder.UseSqlite(@"Data Source=C:\Users\jvand\source\repos\users.db");
        }

        internal object Set(Type type)
        {
            throw new NotImplementedException();
        }
    }
}
