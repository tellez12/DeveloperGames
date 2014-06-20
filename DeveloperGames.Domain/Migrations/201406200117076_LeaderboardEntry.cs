namespace DeveloperGames.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LeaderboardEntry : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Leaderboards", "GameId", "dbo.Games");
            DropForeignKey("dbo.Leaderboards", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Leaderboards", new[] { "UserId" });
            DropIndex("dbo.Leaderboards", new[] { "GameId" });
            RenameColumn(table: "dbo.MatchResults", name: "User1_Id", newName: "User1Id");
            RenameColumn(table: "dbo.MatchResults", name: "User2_Id", newName: "User2Id");
            RenameIndex(table: "dbo.MatchResults", name: "IX_User1_Id", newName: "IX_User1Id");
            RenameIndex(table: "dbo.MatchResults", name: "IX_User2_Id", newName: "IX_User2Id");
            AddColumn("dbo.Leaderboards", "Name", c => c.String());
            AddColumn("dbo.Leaderboards", "Code", c => c.String());
            AddColumn("dbo.Leaderboards", "IsPrivate", c => c.Boolean(nullable: false));
            AddColumn("dbo.Leaderboards", "CreatedDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Leaderboards", "UserId");
            DropColumn("dbo.Leaderboards", "GameId");
            DropColumn("dbo.Leaderboards", "Wins");
            DropColumn("dbo.Leaderboards", "Ties");
            DropColumn("dbo.Leaderboards", "Losses");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Leaderboards", "Losses", c => c.Int(nullable: false));
            AddColumn("dbo.Leaderboards", "Ties", c => c.Int(nullable: false));
            AddColumn("dbo.Leaderboards", "Wins", c => c.Int(nullable: false));
            AddColumn("dbo.Leaderboards", "GameId", c => c.Int(nullable: false));
            AddColumn("dbo.Leaderboards", "UserId", c => c.String(maxLength: 128));
            DropColumn("dbo.Leaderboards", "CreatedDate");
            DropColumn("dbo.Leaderboards", "IsPrivate");
            DropColumn("dbo.Leaderboards", "Code");
            DropColumn("dbo.Leaderboards", "Name");
            RenameIndex(table: "dbo.MatchResults", name: "IX_User2Id", newName: "IX_User2_Id");
            RenameIndex(table: "dbo.MatchResults", name: "IX_User1Id", newName: "IX_User1_Id");
            RenameColumn(table: "dbo.MatchResults", name: "User2Id", newName: "User2_Id");
            RenameColumn(table: "dbo.MatchResults", name: "User1Id", newName: "User1_Id");
            CreateIndex("dbo.Leaderboards", "GameId");
            CreateIndex("dbo.Leaderboards", "UserId");
            AddForeignKey("dbo.Leaderboards", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Leaderboards", "GameId", "dbo.Games", "Id", cascadeDelete: true);
        }
    }
}
