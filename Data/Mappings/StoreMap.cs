using System.Data.Entity.ModelConfiguration;
using BsEf.Entities;

namespace Data.Mappings
{
    public class StoreMap : EntityTypeConfiguration<Store>
    {
        public StoreMap()
        {
            HasKey(t => t.Id);
            Property(t => t.StoreNo).IsRequired().HasMaxLength(50);
            Property(t => t.StoreName).IsRequired().HasMaxLength(50);
            Property(t => t.CreateUserId).IsRequired();
            Property(t => t.CreateTime).IsRequired();
            Property(t => t.EditUserId).IsOptional();
            Property(t => t.EditTime).IsOptional();
            ToTable("Store");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.StoreNo).HasColumnName("StoreNo");
            Property(t => t.StoreName).HasColumnName("StoreName");
            Property(t => t.CreateUserId).HasColumnName("CreateUserId");
            Property(t => t.CreateTime).HasColumnName("CreateTime");
            Property(t => t.EditUserId).HasColumnName("EditUserId");
            Property(t => t.EditTime).HasColumnName("EditTime");

            HasMany(x => x.StoreManagers).WithMany(y => y.Stores).Map(z =>
            {
                z.MapLeftKey("StoreId");
                z.MapLeftKey("StoreManagerId");
                z.ToTable("Store_StoreManager_Relation");
            });
        }
    }
}