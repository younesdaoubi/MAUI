using System;
using Microsoft.EntityFrameworkCore;
using MyApp.Model;
namespace MyApp.Service;

public class DataAccessService : DbContext
{
    #region TABLES
    public DbSet<Feline> Felines { get; set; }
    public DbSet<FelineCollector> FelineCollectors { get; set; }
 

    #endregion

    #region CONSTRUCTOR
    public DataAccessService(DbContextOptions<DataAccessService> options) : base(options)
    {
        
            Database.EnsureCreated();
        
    }
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {


        modelBuilder.Entity<Feline>()
            .HasKey(x => x.Id);


        modelBuilder.Entity<FelineCollector>()
            .HasKey(x => x.Id_Collector);

        modelBuilder.Entity<Feline>()
            .HasOne(e => e.MyFelineCollector)
            .WithMany(e => e.MyFelines)
            .HasForeignKey(e => e.FelineCollectorId)
            .HasPrincipalKey(e => e.Id_Collector);

    }
}
