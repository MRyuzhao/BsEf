using System;
using System.Data.Entity.Migrations;
using System.Linq;
using BsEf.Common;
using BsEf.Entities;

namespace Data.Migrations
{
    public class Configuration : DbMigrationsConfiguration<BsEfDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(BsEfDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            if (!context.Users.Any(x => x.UserNo == "Admin"))
            {
                context.Users.Add(new User
                {
                    Id = 1,
                    UserNo = "Admin",
                    UserName= "系统管理员",
                    Sex= Enums.Sex.男,
                    Age=1,
                    DeleteState= Enums.DeleteStatus.未删除,
                    CreateUserId=1,
                    CreateTime=DateTime.Now,
                    SystemUser = new SystemUser
                    {
                        Id = 1,
                        LoginName = "Admin",
                        LastLoginDate = DateTime.Now,
                        DeleteState = Enums.DeleteStatus.未删除,
                        CreateUserId = 1,
                        CreateTime = DateTime.Now,
                        Password = "$2a$05$K6ZDWkLCKSRFCyUUUYxKDOuccTBVWLLakE1CjARK7cqF5.hHMOz32"//Password1
                    }
                });
            }
        }
    }
}