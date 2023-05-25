using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HueOnlineTicketFestival.Migrations
{
    /// <inheritdoc />
    public partial class updateImageName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "eventImageName",
                table: "EventPicture",
                type: "varchar(max)",
                unicode: false,
                maxLength: 2147483647,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "eventImageName",
                table: "EventPicture",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false,
                oldMaxLength: 2147483647,
                oldNullable: true);
        }
    }
}
