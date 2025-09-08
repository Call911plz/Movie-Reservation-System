using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMovieSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<float>(type: "real", nullable: false),
                    PlayLength = table.Column<TimeOnly>(type: "time", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnnouncmentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShowTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    ReservedUserId = table.Column<int>(type: "int", nullable: true),
                    SeatRowId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seat_SeatRow_SeatRowId",
                        column: x => x.SeatRowId,
                        principalTable: "SeatRow",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Seat_Users_ReservedUserId",
                        column: x => x.ReservedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seat_ReservedUserId",
                table: "Seat",
                column: "ReservedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_SeatRowId",
                table: "Seat",
                column: "SeatRowId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatRow_MovieId",
                table: "SeatRow",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.DropTable(
                name: "SeatRow");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
