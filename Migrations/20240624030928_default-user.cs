using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS_backend.Migrations
{
    /// <inheritdoc />
    public partial class defaultuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "userid", "companyid", "createddatetime", "email", "firstname", "isarchived", "lastlogindatetime", "lastname", "modifieddatetime", "modifieduserid", "passwordhash", "passwordsalt", "phone" },
                values: new object[] { new Guid("ca307be4-4455-4141-a0aa-923e8e93080d"), null, new DateTime(2024, 6, 24, 3, 9, 28, 340, DateTimeKind.Utc).AddTicks(4585), "damon6291@gmail.com", "Damon", false, null, "Joung", new DateTime(2024, 6, 24, 3, 9, 28, 340, DateTimeKind.Utc).AddTicks(4587), null, new byte[] { 74, 57, 85, 90, 105, 90, 49, 68, 72, 66, 121, 79, 53, 83, 86, 68, 121, 53, 108, 118, 97, 85, 106, 70, 90, 118, 105, 115, 111, 52, 69, 48, 90, 48, 113, 87, 49, 78, 73, 109, 70, 76, 57, 90, 77, 55, 104, 111, 104, 68, 53, 83, 76, 48, 122, 81, 119, 78, 120, 43, 53, 49, 106, 101, 84, 109, 81, 80, 50, 75, 43, 89, 118, 65, 70, 72, 81, 106, 67, 113, 69, 65, 115, 117, 66, 81, 61, 61 }, new byte[] { 116, 57, 80, 73, 108, 57, 108, 55, 50, 103, 48, 89, 111, 71, 47, 48, 103, 71, 51, 102, 99, 87, 82, 116, 49, 107, 72, 115, 48, 110, 87, 74, 66, 119, 97, 54, 56, 113, 50, 122, 68, 53, 122, 54, 114, 72, 52, 78, 76, 102, 76, 76, 121, 122, 67, 84, 108, 79, 81, 69, 77, 56, 78, 106, 43, 114, 77, 122, 50, 110, 70, 53, 97, 74, 109, 90, 109, 87, 120, 53, 113, 69, 122, 48, 72, 98, 118, 122, 112, 105, 72, 78, 81, 47, 108, 71, 74, 111, 50, 52, 90, 89, 89, 99, 50, 109, 70, 100, 115, 80, 103, 66, 106, 89, 120, 118, 90, 75, 48, 112, 68, 65, 84, 73, 69, 109, 114, 78, 110, 89, 117, 107, 109, 104, 73, 106, 113, 57, 52, 98, 100, 115, 67, 43, 114, 101, 119, 117, 65, 55, 85, 49, 102, 118, 88, 83, 98, 107, 103, 55, 69, 84, 119, 102, 83, 103, 122, 116, 97, 68, 77, 61 }, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("ca307be4-4455-4141-a0aa-923e8e93080d"));
        }
    }
}
