using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS_backend.Migrations
{
    /// <inheritdoc />
    public partial class usercompanynull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_user_company_companyid",
                table: "user");

            migrationBuilder.AlterColumn<Guid>(
                name: "companyid",
                table: "user",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "fk_user_company_companyid",
                table: "user",
                column: "companyid",
                principalTable: "company",
                principalColumn: "companyid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_user_company_companyid",
                table: "user");

            migrationBuilder.AlterColumn<Guid>(
                name: "companyid",
                table: "user",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_user_company_companyid",
                table: "user",
                column: "companyid",
                principalTable: "company",
                principalColumn: "companyid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
