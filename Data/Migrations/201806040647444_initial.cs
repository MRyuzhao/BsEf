namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StoreManager",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CreateUserId = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        EditUserId = c.Int(),
                        EditTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Store",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StoreNo = c.String(nullable: false, maxLength: 50),
                        StoreName = c.String(nullable: false, maxLength: 50),
                        CreateUserId = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        EditUserId = c.Int(),
                        EditTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserNo = c.String(nullable: false, maxLength: 50),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Sex = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        DeleteState = c.Int(nullable: false),
                        CreateUserId = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        EditUserId = c.Int(),
                        EditTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SystemUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LoginName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        LastLoginDate = c.DateTime(nullable: false),
                        DeleteState = c.Int(nullable: false),
                        CreateUserId = c.Int(nullable: false),
                        CreateTime = c.DateTime(nullable: false),
                        EditUserId = c.Int(),
                        EditTime = c.DateTime(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Store_StoreManager_Relation",
                c => new
                    {
                        StoreManagerId = c.Int(nullable: false),
                        StoreManager_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.StoreManagerId, t.StoreManager_Id })
                .ForeignKey("dbo.Store", t => t.StoreManagerId, cascadeDelete: true)
                .ForeignKey("dbo.StoreManager", t => t.StoreManager_Id, cascadeDelete: true)
                .Index(t => t.StoreManagerId)
                .Index(t => t.StoreManager_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StoreManager", "UserId", "dbo.User");
            DropForeignKey("dbo.SystemUser", "UserId", "dbo.User");
            DropForeignKey("dbo.Store_StoreManager_Relation", "StoreManager_Id", "dbo.StoreManager");
            DropForeignKey("dbo.Store_StoreManager_Relation", "StoreManagerId", "dbo.Store");
            DropIndex("dbo.Store_StoreManager_Relation", new[] { "StoreManager_Id" });
            DropIndex("dbo.Store_StoreManager_Relation", new[] { "StoreManagerId" });
            DropIndex("dbo.SystemUser", new[] { "UserId" });
            DropIndex("dbo.StoreManager", new[] { "UserId" });
            DropTable("dbo.Store_StoreManager_Relation");
            DropTable("dbo.SystemUser");
            DropTable("dbo.User");
            DropTable("dbo.Store");
            DropTable("dbo.StoreManager");
        }
    }
}
