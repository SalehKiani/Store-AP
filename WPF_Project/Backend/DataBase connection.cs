using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WPF_Project.Backend
{
    class DataBase_connection : DbContext
    {
        public DbSet<Admin> admins { get; set; }
        public DbSet<UserProps> users { get; set; }
        public DbSet<Product> products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=APdatabase;Trusted_Connection=True;");
        }
    }
}
