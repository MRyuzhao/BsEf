using System.Data.Entity.ModelConfiguration;
using BsEf.Entities;

namespace Data.Mappings
{
    public class SystemUserMap : EntityTypeConfiguration<SystemUser>
    {
        public SystemUserMap()
        {
            HasKey(t => t.Id);
            Property(t => t.LoginName).IsRequired().HasMaxLength(50);
            Property(t => t.Password).IsRequired().HasMaxLength(100);
            Property(t => t.LastLoginDate).IsRequired();
            Property(t => t.DeleteState).IsRequired();
            Property(t => t.CreateUserId).IsRequired();
            Property(t => t.CreateTime).IsRequired();
            Property(t => t.EditUserId).IsOptional();
            Property(t => t.EditTime).IsOptional();
            ToTable("SystemUser");
            Property(t => t.Id).HasColumnName("Id");
            Property(t => t.LoginName).HasColumnName("LoginName");
            Property(t => t.Password).HasColumnName("Password");
            Property(t => t.LastLoginDate).HasColumnName("LastLoginDate");
            Property(t => t.DeleteState).HasColumnName("DeleteState");
            Property(t => t.CreateUserId).HasColumnName("CreateUserId");
            Property(t => t.CreateTime).HasColumnName("CreateTime");
            Property(t => t.EditUserId).HasColumnName("EditUserId");
            Property(t => t.EditTime).HasColumnName("EditTime");

            HasRequired(fc => fc.User).WithOptional(us => us.SystemUser).Map(m=>m.MapKey("UserId"));
        }
    }
}