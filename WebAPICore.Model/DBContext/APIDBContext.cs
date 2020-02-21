using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICore.Model.Model;

namespace WebAPICore.Model.DBContext
{
    public class APIDBContext : DbContext
    {
        public APIDBContext()
        {
        }

        public APIDBContext(DbContextOptions<APIDBContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot config = builder.Build();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-VLLFDE5\\SQLEXPRESS;Initial Catalog=APIDB;Integrated Security=True;");
        }
        public virtual DbSet<User> User { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
