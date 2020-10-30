namespace DreamAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class one : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Character", "DreamId", c => c.Int());
            AlterColumn("dbo.Dream", "CharacterId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Dream", "CharacterId", c => c.Int(nullable: false));
            AlterColumn("dbo.Character", "DreamId", c => c.Int(nullable: false));
        }
    }
}
