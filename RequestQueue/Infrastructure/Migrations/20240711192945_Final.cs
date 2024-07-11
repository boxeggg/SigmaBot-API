using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SigmaBotAPI.Migrations
{
    /// <inheritdoc />
    public partial class Final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StatusEntity",
                columns: table => new
                {
                    GuildId = table.Column<string>(type: "TEXT", nullable: false),
                    GuildName = table.Column<string>(type: "TEXT", nullable: false),
                    LoopMode = table.Column<int>(type: "INTEGER", nullable: false),
                    OnVoiceChannel = table.Column<bool>(type: "INTEGER", nullable: false),
                    Volume = table.Column<double>(type: "REAL", nullable: false),
                    SkipQueued = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusEntity", x => x.GuildId);
                });

            migrationBuilder.CreateTable(
                name: "SongEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    User = table.Column<string>(type: "TEXT", nullable: false),
                    Thumbnail_Url = table.Column<string>(type: "TEXT", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GuildId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SongEntity_StatusEntity_GuildId",
                        column: x => x.GuildId,
                        principalTable: "StatusEntity",
                        principalColumn: "GuildId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SongEntity_GuildId",
                table: "SongEntity",
                column: "GuildId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SongEntity");

            migrationBuilder.DropTable(
                name: "StatusEntity");
        }
    }
}
