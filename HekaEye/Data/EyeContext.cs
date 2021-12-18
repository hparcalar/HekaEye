using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HekaEye.Data
{
    public class EyeContext : DbContext
    {
        public EyeContext()
            : base("name=EyeContext")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public virtual DbSet<Inspection> Inspection { get; set; }
        public virtual DbSet<MatchHistory> MatchHistory { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Recipe> Recipe { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<RegionProperties> RegionProperties { get; set; }
        public virtual DbSet<RegionPath> RegionPath { get; set; }
    }
}
