namespace DreamAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ids : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Character", "DreamId", c => c.Int(nullable: true));
            AddColumn("dbo.Dream", "CharacterId", c => c.Int(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dream", "CharacterId");
            DropColumn("dbo.Character", "DreamId");
        }
    }
}
