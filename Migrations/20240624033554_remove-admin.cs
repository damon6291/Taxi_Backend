using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS_backend.Migrations
{
    /// <inheritdoc />
    public partial class removeadmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("4abc63e0-a96c-477b-b938-3b085b8375a0"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "userid", "companyid", "createddatetime", "email", "firstname", "isarchived", "lastlogindatetime", "lastname", "modifieddatetime", "modifieduserid", "passwordhash", "passwordsalt", "phone" },
                values: new object[] { new Guid("4abc63e0-a96c-477b-b938-3b085b8375a0"), null, new DateTime(2024, 6, 24, 3, 25, 26, 819, DateTimeKind.Utc).AddTicks(4294), "damon6291@gmail.com", "Damon", false, null, "Joung", new DateTime(2024, 6, 24, 3, 25, 26, 819, DateTimeKind.Utc).AddTicks(4296), null, new byte[] { 198, 89, 207, 229, 216, 185, 121, 93, 169, 28, 21, 4, 243, 134, 239, 164, 110, 146, 131, 59, 74, 28, 43, 82, 203, 144, 233, 20, 49, 174, 156, 225, 34, 47, 45, 231, 228, 51, 189, 80, 28, 58, 232, 25, 138, 88, 13, 126, 97, 100, 32, 9, 187, 33, 46, 183, 130, 249, 23, 197, 101, 11, 116, 134, 12, 47, 196, 211, 80, 147, 23, 139, 54, 40, 111, 240, 62, 118, 24, 37, 150, 20, 227, 88, 238, 206, 235, 140, 200, 183, 121, 124, 248, 254, 128, 19, 143, 4, 220, 182, 220, 99, 119, 164, 62, 26, 166, 217, 10, 88, 139, 51, 88, 248, 124, 219, 69, 124, 34, 219, 163, 80, 103, 24, 112, 7, 240, 42 }, new byte[] { 137, 218, 54, 88, 206, 72, 233, 15, 183, 140, 231, 99, 129, 20, 100, 239, 205, 170, 250, 8, 104, 17, 50, 78, 246, 238, 205, 145, 123, 48, 255, 249, 233, 122, 102, 92, 238, 49, 96, 179, 147, 190, 8, 240, 180, 65, 6, 72, 90, 18, 43, 249, 180, 158, 171, 52, 66, 250, 111, 11, 186, 192, 227, 170 }, null });
        }
    }
}
