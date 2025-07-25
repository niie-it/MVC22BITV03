using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangeAccountTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpiryDate",
                table: "Account");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpireDate",
                table: "Account",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpireDate",
                table: "Account");

            migrationBuilder.AddColumn<string>(
                name: "ExpiryDate",
                table: "Account",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
