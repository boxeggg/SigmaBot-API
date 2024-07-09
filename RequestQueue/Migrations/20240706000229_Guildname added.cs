using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SigmaBotAPI.Migrations
{
    /// <inheritdoc />
    public partial class Guildnameadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GuildName",
                table: "StatusEntity",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GuildName",
                table: "StatusEntity");
        }
    }
}
