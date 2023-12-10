using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace zdt_application.Migrations
{
    /// <inheritdoc />
    public partial class userpinnedleague : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PinnedLeagues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeagueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PinnedLeagues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPinnedLeagues",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PinnedLeaguesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPinnedLeagues", x => new { x.UserId, x.PinnedLeaguesId });
                    table.ForeignKey(
                        name: "FK_UserPinnedLeagues_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPinnedLeagues_PinnedLeagues_PinnedLeaguesId",
                        column: x => x.PinnedLeaguesId,
                        principalTable: "PinnedLeagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserPinnedLeagues_PinnedLeaguesId",
                table: "UserPinnedLeagues",
                column: "PinnedLeaguesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPinnedLeagues");

            migrationBuilder.DropTable(
                name: "PinnedLeagues");
        }
    }
}
