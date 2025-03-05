using Microsoft.EntityFrameworkCore;
using SaleProject.ConsloeApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaleProject.ConsloeApp
{
    public class AppDBContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source=WINDOWS-1ISKG05\\SQLEXPRESS;Initial Catalog=F9DB;Trusted_Connection=True;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionString);
        }
       public DbSet<SaleEFCoreModel> Sales {  get; set; }
    }
}
