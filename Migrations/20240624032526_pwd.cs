using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WMS_backend.Migrations
{
    /// <inheritdoc />
    public partial class pwd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("33d8b6da-b51c-4a9e-b7ca-5a54d48f0f5a"));

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "userid", "companyid", "createddatetime", "email", "firstname", "isarchived", "lastlogindatetime", "lastname", "modifieddatetime", "modifieduserid", "passwordhash", "passwordsalt", "phone" },
                values: new object[] { new Guid("4abc63e0-a96c-477b-b938-3b085b8375a0"), null, new DateTime(2024, 6, 24, 3, 25, 26, 819, DateTimeKind.Utc).AddTicks(4294), "damon6291@gmail.com", "Damon", false, null, "Joung", new DateTime(2024, 6, 24, 3, 25, 26, 819, DateTimeKind.Utc).AddTicks(4296), null, new byte[] { 198, 89, 207, 229, 216, 185, 121, 93, 169, 28, 21, 4, 243, 134, 239, 164, 110, 146, 131, 59, 74, 28, 43, 82, 203, 144, 233, 20, 49, 174, 156, 225, 34, 47, 45, 231, 228, 51, 189, 80, 28, 58, 232, 25, 138, 88, 13, 126, 97, 100, 32, 9, 187, 33, 46, 183, 130, 249, 23, 197, 101, 11, 116, 134, 12, 47, 196, 211, 80, 147, 23, 139, 54, 40, 111, 240, 62, 118, 24, 37, 150, 20, 227, 88, 238, 206, 235, 140, 200, 183, 121, 124, 248, 254, 128, 19, 143, 4, 220, 182, 220, 99, 119, 164, 62, 26, 166, 217, 10, 88, 139, 51, 88, 248, 124, 219, 69, 124, 34, 219, 163, 80, 103, 24, 112, 7, 240, 42 }, new byte[] { 137, 218, 54, 88, 206, 72, 233, 15, 183, 140, 231, 99, 129, 20, 100, 239, 205, 170, 250, 8, 104, 17, 50, 78, 246, 238, 205, 145, 123, 48, 255, 249, 233, 122, 102, 92, 238, 49, 96, 179, 147, 190, 8, 240, 180, 65, 6, 72, 90, 18, 43, 249, 180, 158, 171, 52, 66, 250, 111, 11, 186, 192, 227, 170 }, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("4abc63e0-a96c-477b-b938-3b085b8375a0"));

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "userid", "companyid", "createddatetime", "email", "firstname", "isarchived", "lastlogindatetime", "lastname", "modifieddatetime", "modifieduserid", "passwordhash", "passwordsalt", "phone" },
                values: new object[] { new Guid("33d8b6da-b51c-4a9e-b7ca-5a54d48f0f5a"), null, new DateTime(2024, 6, 24, 3, 22, 30, 613, DateTimeKind.Utc).AddTicks(2497), "damon6291@gmail.com", "Damon", false, null, "Joung", new DateTime(2024, 6, 24, 3, 22, 30, 613, DateTimeKind.Utc).AddTicks(2499), null, new byte[] { 117, 101, 114, 112, 103, 116, 67, 77, 56, 117, 71, 73, 104, 85, 83, 115, 101, 98, 72, 54, 98, 115, 77, 82, 66, 48, 77, 98, 101, 67, 56, 117, 56, 72, 57, 80, 84, 112, 113, 80, 120, 57, 51, 73, 76, 122, 52, 86, 84, 51, 86, 83, 68, 116, 76, 84, 55, 102, 113, 77, 116, 118, 89, 56, 55, 83, 117, 51, 54, 99, 82, 115, 102, 73, 98, 87, 79, 49, 69, 72, 65, 115, 52, 48, 116, 81, 61, 61 }, new byte[] { 82, 117, 97, 102, 86, 122, 67, 99, 106, 101, 82, 43, 101, 112, 121, 68, 86, 90, 76, 103, 43, 81, 84, 48, 56, 80, 43, 117, 109, 84, 100, 68, 108, 83, 108, 81, 75, 87, 80, 75, 88, 66, 86, 43, 78, 75, 84, 68, 111, 51, 98, 79, 109, 77, 88, 49, 53, 79, 88, 43, 56, 70, 111, 104, 43, 83, 88, 116, 77, 69, 97, 115, 79, 67, 71, 106, 110, 70, 66, 101, 116, 97, 114, 109, 84, 111, 79, 71, 87, 113, 120, 114, 67, 51, 111, 102, 89, 106, 76, 75, 79, 104, 54, 112, 72, 104, 67, 102, 116, 102, 119, 111, 43, 65, 84, 82, 114, 97, 49, 107, 43, 69, 121, 47, 103, 82, 99, 78, 98, 53, 89, 106, 86, 102, 97, 79, 74, 56, 111, 87, 80, 54, 100, 109, 117, 50, 49, 101, 50, 80, 114, 55, 68, 102, 78, 112, 56, 110, 49, 87, 66, 110, 84, 81, 84, 114, 109, 52, 48, 65, 48, 61 }, null });
        }
    }
}
