using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS_backend.Migrations
{
    /// <inheritdoc />
    public partial class notificationdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "createddatetime",
                table: "notification",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "createddatetime",
                table: "notification");
        }
    }
}
