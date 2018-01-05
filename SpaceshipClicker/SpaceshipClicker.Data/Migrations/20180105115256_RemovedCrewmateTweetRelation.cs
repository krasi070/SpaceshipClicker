namespace SpaceshipClicker.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class RemovedCrewmateTweetRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tweets_Crew_CrewmateId",
                table: "Tweets");

            migrationBuilder.DropIndex(
                name: "IX_Tweets_CrewmateId",
                table: "Tweets");

            migrationBuilder.DropColumn(
                name: "CrewmateId",
                table: "Tweets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CrewmateId",
                table: "Tweets",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Tweets_CrewmateId",
                table: "Tweets",
                column: "CrewmateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tweets_Crew_CrewmateId",
                table: "Tweets",
                column: "CrewmateId",
                principalTable: "Crew",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
