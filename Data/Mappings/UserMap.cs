using System.Data.Entity.ModelConfiguration;
using BsEf.Entities;

namespace Data.Mappings
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            HasKey(t => t.Id);
            Property(t => t.UserNo).IsRequired().HasMaxLength(50);
            Property(t => t.UserName).IsRequired().HasMaxLength(50);
            Property(t => t.Sex).IsRequired();
            Property(t => t.Age).IsRequired();
            Property(t => t.DeleteState).IsRequired();
            Property(t => t.CreateUserId).IsRequired();
            Property(t => t.CreateTime).IsRequired();
            Property(t => t.EditUserId).IsOptional();
            Property(t => t.EditTime).IsOptional();
            ToTable("User");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.UserNo).HasColumnName("UserNo");
            Property(t => t.UserName).HasColumnName("UserName");
            Property(t => t.Sex).HasColumnName("Sex");
            Property(t => t.Age).HasColumnName("Age");
            Property(t => t.DeleteState).HasColumnName("DeleteState");
            Property(t => t.CreateUserId).HasColumnName("CreateUserId");
            Property(t => t.CreateTime).HasColumnName("CreateTime");
            Property(t => t.EditUserId).HasColumnName("EditUserId");
            Property(t => t.EditTime).HasColumnName("EditTime");
        }
    }
}