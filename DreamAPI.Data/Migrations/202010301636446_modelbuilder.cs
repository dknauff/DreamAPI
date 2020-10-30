namespace DreamAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelbuilder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DreamCharacter", "Dream_DreamId", "dbo.Dream");
            DropForeignKey("dbo.DreamCharacter", "Character_CharacterId", "dbo.Character");
            DropIndex("dbo.DreamCharacter", new[] { "Dream_DreamId" });
            DropIndex("dbo.DreamCharacter", new[] { "Character_CharacterId" });
            DropTable("dbo.DreamCharacter");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DreamCharacter",
                c => new
                    {
                        Dream_DreamId = c.Int(nullable: false),
                        Character_CharacterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Dream_DreamId, t.Character_CharacterId });
            
            CreateIndex("dbo.DreamCharacter", "Character_CharacterId");
            CreateIndex("dbo.DreamCharacter", "Dream_DreamId");
            AddForeignKey("dbo.DreamCharacter", "Character_CharacterId", "dbo.Character", "CharacterId", cascadeDelete: true);
            AddForeignKey("dbo.DreamCharacter", "Dream_DreamId", "dbo.Dream", "DreamId", cascadeDelete: true);
        }
    }
}
