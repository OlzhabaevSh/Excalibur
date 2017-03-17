namespace Core.Admin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateIdBack : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicationRolesApplications", "Application_Id", "dbo.Applications");
            DropForeignKey("dbo.ApplicationLists", "ApplicationId", "dbo.Applications");
            DropPrimaryKey("dbo.Applications");
            AlterColumn("dbo.Applications", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Applications", "Id");
            AddForeignKey("dbo.ApplicationRolesApplications", "Application_Id", "dbo.Applications", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ApplicationLists", "ApplicationId", "dbo.Applications", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationLists", "ApplicationId", "dbo.Applications");
            DropForeignKey("dbo.ApplicationRolesApplications", "Application_Id", "dbo.Applications");
            DropPrimaryKey("dbo.Applications");
            AlterColumn("dbo.Applications", "Id", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Applications", "Id");
            AddForeignKey("dbo.ApplicationLists", "ApplicationId", "dbo.Applications", "Id");
            AddForeignKey("dbo.ApplicationRolesApplications", "Application_Id", "dbo.Applications", "Id", cascadeDelete: true);
        }
    }
}
