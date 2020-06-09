using System;
using System.Collections.Generic;
using System.Text;
using Dalal.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dalal.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Products>  Products { get; set; }
        public DbSet<ProductCatagory> ProductCatagories { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }


    }
}
