using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS_backend.Migrations
{
    /// <inheritdoc />
    public partial class permission : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPermission_CompanyPermission_CompanyPermissionId",
                table: "UserPermission");

            migrationBuilder.DropIndex(
                name: "IX_UserPermission_CompanyPermissionId",
                table: "UserPermission");

            migrationBuilder.DropColumn(
                name: "CompanyPermissionId",
                table: "UserPermission");

            migrationBuilder.AddColumn<int>(
                name: "PermissionType",
                table: "UserPermission",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "PermissionType",
                columns: new[] { "PermissionTypeId", "Name" },
                values: new object[] { 200, "Test" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PermissionType",
                keyColumn: "PermissionTypeId",
                keyValue: 200);

            migrationBuilder.DropColumn(
                name: "PermissionType",
                table: "UserPermission");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyPermissionId",
                table: "UserPermission",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_UserPermission_CompanyPermissionId",
                table: "UserPermission",
                column: "CompanyPermissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPermission_CompanyPermission_CompanyPermissionId",
                table: "UserPermission",
                column: "CompanyPermissionId",
                principalTable: "CompanyPermission",
                principalColumn: "CompanyPermissionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
