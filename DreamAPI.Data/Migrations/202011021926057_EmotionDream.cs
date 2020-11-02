namespace DreamAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmotionDream : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Dream", "EmotionId", "dbo.Emotion");
            DropIndex("dbo.Dream", new[] { "EmotionId" });
            CreateTable(
                "dbo.EmotionDream",
                c => new
                    {
                        EmotionId = c.Int(nullable: true),
                        DreamId = c.Int(nullable: true),
                        OwnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmotionId, t.DreamId })
                .ForeignKey("dbo.Dream", t => t.DreamId, cascadeDelete: true)
                .ForeignKey("dbo.Emotion", t => t.EmotionId, cascadeDelete: true)
                .Index(t => t.EmotionId)
                .Index(t => t.DreamId);
            
            DropColumn("dbo.Dream", "EmotionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dream", "EmotionId", c => c.Int(nullable: false));
            DropForeignKey("dbo.EmotionDream", "EmotionId", "dbo.Emotion");
            DropForeignKey("dbo.EmotionDream", "DreamId", "dbo.Dream");
            DropIndex("dbo.EmotionDream", new[] { "DreamId" });
            DropIndex("dbo.EmotionDream", new[] { "EmotionId" });
            DropTable("dbo.EmotionDream");
            CreateIndex("dbo.Dream", "EmotionId");
            AddForeignKey("dbo.Dream", "EmotionId", "dbo.Emotion", "EmotionId", cascadeDelete: true);
        }
    }
}
