using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EshopSolution.Data.EF
{
    public class EshopDbContextFactory : IDesignTimeDbContextFactory<EshopDbContext>
    {
        public EshopDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var ConnectionString = configuration.GetConnectionString("EshopSolutionDB");
            var optionsBuilder = new DbContextOptionsBuilder<EshopDbContext>();
            optionsBuilder.UseSqlServer(ConnectionString);

            return new EshopDbContext(optionsBuilder.Options);
        }
    }
}
