using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using BsEf.Entities;
using Data.Mappings;
using Data.Migrations;

namespace Data
{
    public class BsEfDbContext : DbContext
    {
        public BsEfDbContext():base("name=BsEfDbContextString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BsEfDbContext, Configuration>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<SystemUser> SystemUsers { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<StoreManager> StoreManagers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new SystemUserMap());
            modelBuilder.Configurations.Add(new StoreMap());
            modelBuilder.Configurations.Add(new StoreManagerMap());
        }
    }
}