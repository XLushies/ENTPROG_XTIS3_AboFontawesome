using Microsoft.EntityFrameworkCore;
using ENTPROG_XTIS3_Abo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTPROG_XTIS3_Abo
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        public DbSet<Supplier> SuppliersINV { get; set; }
        public DbSet<Products> ProductsINV { get; set; }
    }
}
