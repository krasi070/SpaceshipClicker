namespace SpaceshipClicker.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class RemovedCrushAndEmotionColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crew_Crew_CrushId",
                table: "Crew");

            migrationBuilder.DropIndex(
                name: "IX_Crew_CrushId",
                table: "Crew");

            migrationBuilder.DropColumn(
                name: "Emotion",
                table: "CrewmateEmails");

            migrationBuilder.DropColumn(
                name: "CrushId",
                table: "Crew");

            migrationBuilder.DropColumn(
                name: "Emotion",
                table: "Crew");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Emotion",
                table: "CrewmateEmails",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CrushId",
                table: "Crew",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Emotion",
                table: "Crew",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Crew_CrushId",
                table: "Crew",
                column: "CrushId");

            migrationBuilder.AddForeignKey(
                name: "FK_Crew_Crew_CrushId",
                table: "Crew",
                column: "CrushId",
                principalTable: "Crew",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
