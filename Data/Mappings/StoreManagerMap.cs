using System.Data.Entity.ModelConfiguration;
using BsEf.Entities;

namespace Data.Mappings
{
    public class StoreManagerMap : EntityTypeConfiguration<StoreManager>
    {
        public StoreManagerMap()
        {
            HasKey(t => t.Id);
            Property(t => t.UserId).IsRequired();
            Property(t => t.CreateUserId).IsRequired();
            Property(t => t.CreateTime).IsRequired();
            Property(t => t.EditUserId).IsOptional();
            Property(t => t.EditTime).IsOptional();
            ToTable("StoreManager");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.UserId).HasColumnName("UserId");
            Property(t => t.CreateUserId).HasColumnName("CreateUserId");
            Property(t => t.CreateTime).HasColumnName("CreateTime");
            Property(t => t.EditUserId).HasColumnName("EditUserId");
            Property(t => t.EditTime).HasColumnName("EditTime");

            HasRequired(x=>x.User).WithMany(y=>y.StoreManagers)
                .HasForeignKey(z=>z.UserId).WillCascadeOnDelete(true);
        }
    }
}