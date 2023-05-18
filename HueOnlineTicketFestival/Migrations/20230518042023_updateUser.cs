using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HueOnlineTicketFestival.Migrations
{
    /// <inheritdoc />
    public partial class updateUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordResetToken",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ResetTokenExpries",
                table: "User",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VerificationToken",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "VerifyAt",
                table: "User",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordResetToken",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ResetTokenExpries",
                table: "User");

            migrationBuilder.DropColumn(
                name: "VerificationToken",
                table: "User");

            migrationBuilder.DropColumn(
                name: "VerifyAt",
                table: "User");
        }
    }
}
