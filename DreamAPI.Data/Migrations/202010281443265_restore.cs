namespace DreamAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class restore : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comment", "DreamId", "dbo.Dream");
            DropIndex("dbo.Comment", new[] { "DreamId" });
            DropColumn("dbo.Comment", "DreamId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comment", "DreamId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comment", "DreamId");
            AddForeignKey("dbo.Comment", "DreamId", "dbo.Dream", "DreamId", cascadeDelete: true);
        }
    }
}
