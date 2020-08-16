using EshopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EshopSolution.Data.EF
{
    public class EshopDbContext :DbContext
    {
        public EshopDbContext(DbContextOptions options) : base (options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
