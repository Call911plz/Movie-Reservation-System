using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExplicitDeclarationOfRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Movies_MovieId",
                table: "Seat");

            migrationBuilder.DropForeignKey(
                name: "FK_Seat_Users_ReservedUserId",
                table: "Seat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seat",
                table: "Seat");

            migrationBuilder.RenameTable(
                name: "Seat",
                newName: "Seats");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_ReservedUserId",
                table: "Seats",
                newName: "IX_Seats_ReservedUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_MovieId",
                table: "Seats",
                newName: "IX_Seats_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seats",
                table: "Seats",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Movies_MovieId",
                table: "Seats",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Users_ReservedUserId",
                table: "Seats",
                column: "ReservedUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Movies_MovieId",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Users_ReservedUserId",
                table: "Seats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seats",
                table: "Seats");

            migrationBuilder.RenameTable(
                name: "Seats",
                newName: "Seat");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_ReservedUserId",
                table: "Seat",
                newName: "IX_Seat_ReservedUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Seats_MovieId",
                table: "Seat",
                newName: "IX_Seat_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seat",
                table: "Seat",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Movies_MovieId",
                table: "Seat",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_Users_ReservedUserId",
                table: "Seat",
                column: "ReservedUserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
