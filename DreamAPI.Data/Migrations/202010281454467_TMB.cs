namespace DreamAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TMB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comment", "DreamId", c => c.Int(nullable: true));
            CreateIndex("dbo.Comment", "DreamId");
            AddForeignKey("dbo.Comment", "DreamId", "dbo.Dream", "DreamId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "DreamId", "dbo.Dream");
            DropIndex("dbo.Comment", new[] { "DreamId" });
            DropColumn("dbo.Comment", "DreamId");
        }
    }
}
