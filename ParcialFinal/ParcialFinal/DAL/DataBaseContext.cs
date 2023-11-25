using ParcialFinal.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace ParcialFinal.DAL
{
    public class DataBaseContext : DbContext
    {
        
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceRequest> ServiceRequest { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Service>().HasIndex(t => t.Id);
            //modelBuilder.Entity<ServiceRequest>().HasIndex(t => t.Id);
        }
    }
}