using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HueOnlineTicketFestival.Migrations
{
    /// <inheritdoc />
    public partial class updateNewsContent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "newsContent",
                table: "News",
                newName: "NewsContent");

            migrationBuilder.AlterColumn<string>(
                name: "NewsContent",
                table: "News",
                type: "nvarchar(max)",
                maxLength: 2147483647,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NewsContent",
                table: "News",
                newName: "newsContent");

            migrationBuilder.AlterColumn<string>(
                name: "newsContent",
                table: "News",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldMaxLength: 2147483647,
                oldNullable: true);
        }
    }
}
