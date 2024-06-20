using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WMS_backend.Migrations
{
    /// <inheritdoc />
    public partial class permissionType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PermissionType",
                columns: table => new
                {
                    PermissionTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionType", x => x.PermissionTypeId);
                });

            migrationBuilder.InsertData(
                table: "PermissionType",
                columns: new[] { "PermissionTypeId", "Name" },
                values: new object[,]
                {
                    { 4, "Order" },
                    { 13, "Inbound" },
                    { 20, "Putaway" },
                    { 30, "Quality" },
                    { 40, "Outbound" },
                    { 50, "Picking" },
                    { 60, "Packing" },
                    { 70, "Shipping" },
                    { 80, "Product" },
                    { 90, "Stock" },
                    { 100, "PurchaseOrder" },
                    { 110, "PurchaseRequest" },
                    { 120, "Supplier" },
                    { 130, "ReportOrder" },
                    { 140, "ReportPurchaseOrder" },
                    { 150, "ReportInventory" },
                    { 170, "ManageCompany" },
                    { 180, "ManageTeam" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PermissionType");
        }
    }
}
