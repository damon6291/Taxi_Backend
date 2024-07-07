using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS_backend.Migrations
{
    /// <inheritdoc />
    public partial class tote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_supplier_team_teamid",
                table: "supplier");

            migrationBuilder.DropTable(
                name: "teamlocation");

            migrationBuilder.RenameColumn(
                name: "teamid",
                table: "supplier",
                newName: "companyid");

            migrationBuilder.RenameIndex(
                name: "ix_supplier_teamid",
                table: "supplier",
                newName: "ix_supplier_companyid");

            migrationBuilder.CreateTable(
                name: "tote",
                columns: table => new
                {
                    toteid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    countmax = table.Column<int>(type: "integer", nullable: false),
                    isarchived = table.Column<bool>(type: "boolean", nullable: false),
                    loactionid = table.Column<Guid>(type: "uuid", nullable: false),
                    locationid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tote", x => x.toteid);
                    table.ForeignKey(
                        name: "fk_tote_location_locationid",
                        column: x => x.locationid,
                        principalTable: "location",
                        principalColumn: "locationid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_tote_locationid",
                table: "tote",
                column: "locationid");

            migrationBuilder.AddForeignKey(
                name: "fk_supplier_company_companyid",
                table: "supplier",
                column: "companyid",
                principalTable: "company",
                principalColumn: "companyid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_supplier_company_companyid",
                table: "supplier");

            migrationBuilder.DropTable(
                name: "tote");

            migrationBuilder.RenameColumn(
                name: "companyid",
                table: "supplier",
                newName: "teamid");

            migrationBuilder.RenameIndex(
                name: "ix_supplier_companyid",
                table: "supplier",
                newName: "ix_supplier_teamid");

            migrationBuilder.CreateTable(
                name: "teamlocation",
                columns: table => new
                {
                    teamlocationid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    locationid = table.Column<Guid>(type: "uuid", nullable: false),
                    teamid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_teamlocation", x => x.teamlocationid);
                    table.ForeignKey(
                        name: "fk_teamlocation_location_locationid",
                        column: x => x.locationid,
                        principalTable: "location",
                        principalColumn: "locationid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_teamlocation_team_teamid",
                        column: x => x.teamid,
                        principalTable: "team",
                        principalColumn: "teamid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_teamlocation_locationid",
                table: "teamlocation",
                column: "locationid");

            migrationBuilder.CreateIndex(
                name: "ix_teamlocation_teamid",
                table: "teamlocation",
                column: "teamid");

            migrationBuilder.AddForeignKey(
                name: "fk_supplier_team_teamid",
                table: "supplier",
                column: "teamid",
                principalTable: "team",
                principalColumn: "teamid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
