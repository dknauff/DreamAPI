namespace DreamAPI.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class table : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ChracterDream", newName: "CharacterDream");
            RenameColumn(table: "dbo.CharacterDream", name: "CharacterRefId", newName: "CharacterId");
            RenameColumn(table: "dbo.CharacterDream", name: "DreamRefId", newName: "DreamId");
            RenameIndex(table: "dbo.CharacterDream", name: "IX_CharacterRefId", newName: "IX_CharacterId");
            RenameIndex(table: "dbo.CharacterDream", name: "IX_DreamRefId", newName: "IX_DreamId");
            DropColumn("dbo.Character", "DreamId");
            DropColumn("dbo.Dream", "CharacterId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dream", "CharacterId", c => c.Int());
            AddColumn("dbo.Character", "DreamId", c => c.Int());
            RenameIndex(table: "dbo.CharacterDream", name: "IX_DreamId", newName: "IX_DreamRefId");
            RenameIndex(table: "dbo.CharacterDream", name: "IX_CharacterId", newName: "IX_CharacterRefId");
            RenameColumn(table: "dbo.CharacterDream", name: "DreamId", newName: "DreamRefId");
            RenameColumn(table: "dbo.CharacterDream", name: "CharacterId", newName: "CharacterRefId");
            RenameTable(name: "dbo.CharacterDream", newName: "ChracterDream");
        }
    }
}
