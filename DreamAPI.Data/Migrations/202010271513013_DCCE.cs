namespace DreamAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DCCE : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Character",
                c => new
                    {
                        CharacterId = c.Int(nullable: false, identity: true),
                        OwnerId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Relationship = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CharacterId);
            
            CreateTable(
                "dbo.Emotion",
                c => new
                    {
                        EmotionId = c.Int(nullable: false, identity: true),
                        EmotionType = c.String(),
                        OwnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.EmotionId);
            
            AddColumn("dbo.Comment", "OwnerId", c => c.Guid(nullable: false));
            AlterColumn("dbo.Comment", "CommentDescription", c => c.String(nullable: false));
            DropColumn("dbo.Comment", "DreamId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comment", "DreamId", c => c.Int(nullable: false));
            AlterColumn("dbo.Comment", "CommentDescription", c => c.String());
            DropColumn("dbo.Comment", "OwnerId");
            DropTable("dbo.Emotion");
            DropTable("dbo.Character");
        }
    }
}
