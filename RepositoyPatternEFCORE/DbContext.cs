using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryClassLibrary.netCore.models;
using Microsoft.Extensions.Configuration;

namespace RepositoyPatternEFCORE
{
    public class AppDbContext:DbContext
    {

        public DbSet<Author>authors { get; set; }
        public DbSet<Books>Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var config = new ConfigurationBuilder().AddJsonFile("jsconfig1.json").Build();
            var constr = config.GetSection("constr").Value;
            optionsBuilder.UseSqlServer(constr);
        }

    }
}
