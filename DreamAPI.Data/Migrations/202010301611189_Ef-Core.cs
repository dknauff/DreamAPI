namespace DreamAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EfCore : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CharacterDream", newName: "DreamCharacter");
            RenameColumn(table: "dbo.DreamCharacter", name: "CharacterId", newName: "Character_CharacterId");
            RenameColumn(table: "dbo.DreamCharacter", name: "DreamId", newName: "Dream_DreamId");
            RenameIndex(table: "dbo.DreamCharacter", name: "IX_DreamId", newName: "IX_Dream_DreamId");
            RenameIndex(table: "dbo.DreamCharacter", name: "IX_CharacterId", newName: "IX_Character_CharacterId");
            DropPrimaryKey("dbo.DreamCharacter");
            CreateTable(
                "dbo.CharacterDream",
                c => new
                    {
                        CharacterId = c.Int(nullable: true),
                        DreamId = c.Int(nullable: true),
                        OwnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.CharacterId, t.DreamId })
                .ForeignKey("dbo.Character", t => t.CharacterId, cascadeDelete: true)
                .ForeignKey("dbo.Dream", t => t.DreamId, cascadeDelete: true)
                .Index(t => t.CharacterId)
                .Index(t => t.DreamId);
            
            AddPrimaryKey("dbo.DreamCharacter", new[] { "Dream_DreamId", "Character_CharacterId" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CharacterDream", "DreamId", "dbo.Dream");
            DropForeignKey("dbo.CharacterDream", "CharacterId", "dbo.Character");
            DropIndex("dbo.CharacterDream", new[] { "DreamId" });
            DropIndex("dbo.CharacterDream", new[] { "CharacterId" });
            DropPrimaryKey("dbo.DreamCharacter");
            DropTable("dbo.CharacterDream");
            AddPrimaryKey("dbo.DreamCharacter", new[] { "CharacterId", "DreamId" });
            RenameIndex(table: "dbo.DreamCharacter", name: "IX_Character_CharacterId", newName: "IX_CharacterId");
            RenameIndex(table: "dbo.DreamCharacter", name: "IX_Dream_DreamId", newName: "IX_DreamId");
            RenameColumn(table: "dbo.DreamCharacter", name: "Dream_DreamId", newName: "DreamId");
            RenameColumn(table: "dbo.DreamCharacter", name: "Character_CharacterId", newName: "CharacterId");
            RenameTable(name: "dbo.DreamCharacter", newName: "CharacterDream");
        }
    }
}
