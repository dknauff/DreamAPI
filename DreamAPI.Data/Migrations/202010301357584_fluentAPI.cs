namespace DreamAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fluentAPI : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DreamCharacter", "CharacterId", "dbo.Character");
            DropForeignKey("dbo.DreamCharacter", "DreamId", "dbo.Dream");
            DropIndex("dbo.DreamCharacter", new[] { "DreamId" });
            DropIndex("dbo.DreamCharacter", new[] { "CharacterId" });
            CreateTable(
                "dbo.ChracterDream",
                c => new
                    {
                        CharacterRefId = c.Int(nullable: true),
                        DreamRefId = c.Int(nullable: true),
                    })
                .PrimaryKey(t => new { t.CharacterRefId, t.DreamRefId })
                .ForeignKey("dbo.Character", t => t.CharacterRefId, cascadeDelete: true)
                .ForeignKey("dbo.Dream", t => t.DreamRefId, cascadeDelete: true)
                .Index(t => t.CharacterRefId)
                .Index(t => t.DreamRefId);
            
            DropTable("dbo.DreamCharacter");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DreamCharacter",
                c => new
                    {
                        DreamId = c.Int(nullable: false),
                        CharacterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DreamId, t.CharacterId });
            
            DropForeignKey("dbo.ChracterDream", "DreamRefId", "dbo.Dream");
            DropForeignKey("dbo.ChracterDream", "CharacterRefId", "dbo.Character");
            DropIndex("dbo.ChracterDream", new[] { "DreamRefId" });
            DropIndex("dbo.ChracterDream", new[] { "CharacterRefId" });
            DropTable("dbo.ChracterDream");
            CreateIndex("dbo.DreamCharacter", "CharacterId");
            CreateIndex("dbo.DreamCharacter", "DreamId");
            AddForeignKey("dbo.DreamCharacter", "DreamId", "dbo.Dream", "DreamId", cascadeDelete: true);
            AddForeignKey("dbo.DreamCharacter", "CharacterId", "dbo.Character", "CharacterId", cascadeDelete: true);
        }
    }
}
