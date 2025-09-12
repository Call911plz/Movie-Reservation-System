using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class PlayLengthToStringAndSeatsGiveRowAndCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_SeatRow_SeatRowId",
                table: "Seat");

            migrationBuilder.DropTable(
                name: "SeatRow");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seat",
                table: "Seat");

            migrationBuilder.DropIndex(
                name: "IX_Seat_SeatRowId",
                table: "Seat");

            migrationBuilder.DropColumn(
                name: "SeatRowId",
                table: "Seat");

            migrationBuilder.AddColumn<string>(
                name: "Column",
                table: "Seat",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Row",
                table: "Seat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "PlayLength",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(TimeOnly),
                oldType: "time");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seat",
                table: "Seat",
                columns: new[] { "MovieId", "Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Movies_MovieId",
                table: "Seat",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Movies_MovieId",
                table: "Seat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seat",
                table: "Seat");

            migrationBuilder.DropColumn(
                name: "Column",
                table: "Seat");

            migrationBuilder.DropColumn(
                name: "Row",
                table: "Seat");

            migrationBuilder.AddColumn<int>(
                name: "SeatRowId",
                table: "Seat",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<TimeOnly>(
                name: "PlayLength",
                table: "Movies",
                type: "time",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seat",
                table: "Seat",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SeatRow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatRow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeatRow_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seat_SeatRowId",
                table: "Seat",
                column: "SeatRowId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatRow_MovieId",
                table: "SeatRow",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_SeatRow_SeatRowId",
                table: "Seat",
                column: "SeatRowId",
                principalTable: "SeatRow",
                principalColumn: "Id");
        }
    }
}
