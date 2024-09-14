using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WMS_backend.Migrations
{
    /// <inheritdoc />
    public partial class sampledata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "company",
                columns: new[] { "companyid", "address", "contact", "createddatetime", "email", "isarchived", "name", "phone" },
                values: new object[,]
                {
                    { new Guid("2f08a644-f120-b99d-7a50-0e8ef1e502a2"), null, null, new DateTime(2024, 9, 13, 15, 26, 36, 863, DateTimeKind.Utc).AddTicks(4407), null, false, "Lonny Swift", null },
                    { new Guid("58d6ac23-b9ba-53a2-4892-7f8b5d6e9896"), null, null, new DateTime(2024, 9, 14, 5, 4, 4, 357, DateTimeKind.Utc).AddTicks(7693), null, false, "Reymundo Mayer", null },
                    { new Guid("9825481b-9e16-8ef4-195c-2f1d50869c89"), null, null, new DateTime(2024, 9, 14, 0, 55, 32, 144, DateTimeKind.Utc).AddTicks(1341), null, false, "Yasmin Graham", null },
                    { new Guid("f26fcf2f-e7ed-59fb-861b-85c1f532c2c7"), null, null, new DateTime(2024, 9, 13, 16, 44, 56, 643, DateTimeKind.Utc).AddTicks(3448), null, false, "Lillian Hodkiewicz", null },
                    { new Guid("ff1d66b5-0328-033a-8da6-5bcc805718c8"), null, null, new DateTime(2024, 9, 13, 15, 12, 55, 424, DateTimeKind.Utc).AddTicks(1681), null, false, "Lila Ullrich", null }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "userid", "companyid", "createddatetime", "email", "firstname", "isarchived", "lastlogindatetime", "lastname", "modifieddatetime", "modifieduserid", "passwordhash", "passwordsalt", "phone" },
                values: new object[,]
                {
                    { new Guid("012db46d-3354-269c-3b8c-e92685c53a21"), new Guid("9825481b-9e16-8ef4-195c-2f1d50869c89"), new DateTime(2024, 9, 13, 12, 30, 30, 820, DateTimeKind.Utc).AddTicks(1165), "Brittany_Reichert@gmail.com", "Eldon", false, null, "Sauer", new DateTime(2024, 9, 13, 14, 4, 38, 339, DateTimeKind.Utc).AddTicks(3964), null, null, null, null },
                    { new Guid("037d1980-5276-deb4-5352-9ca0c48e80a5"), new Guid("2f08a644-f120-b99d-7a50-0e8ef1e502a2"), new DateTime(2024, 9, 13, 20, 2, 20, 536, DateTimeKind.Utc).AddTicks(5579), "Claire_Purdy91@yahoo.com", "Fredrick", false, null, "Hudson", new DateTime(2024, 9, 13, 14, 45, 28, 991, DateTimeKind.Utc).AddTicks(2280), null, null, null, null },
                    { new Guid("0482f077-777f-8062-1cf7-b94f6a5199f2"), new Guid("ff1d66b5-0328-033a-8da6-5bcc805718c8"), new DateTime(2024, 9, 13, 17, 26, 9, 231, DateTimeKind.Utc).AddTicks(4105), "Parker_Murray@yahoo.com", "Junior", false, null, "Kunze", new DateTime(2024, 9, 14, 3, 3, 45, 506, DateTimeKind.Utc).AddTicks(8169), null, null, null, null },
                    { new Guid("07347aa6-8b58-1302-7b91-21a4139ee1d3"), new Guid("f26fcf2f-e7ed-59fb-861b-85c1f532c2c7"), new DateTime(2024, 9, 13, 12, 12, 35, 881, DateTimeKind.Utc).AddTicks(4107), "Bernie18@yahoo.com", "Lafayette", false, null, "Wehner", new DateTime(2024, 9, 14, 3, 35, 52, 522, DateTimeKind.Utc).AddTicks(9058), null, null, null, null },
                    { new Guid("07761ee1-3937-ee82-bee7-5b44a7d90360"), new Guid("2f08a644-f120-b99d-7a50-0e8ef1e502a2"), new DateTime(2024, 9, 13, 12, 6, 34, 732, DateTimeKind.Utc).AddTicks(2446), "Shaylee36@hotmail.com", "Nakia", false, null, "Hauck", new DateTime(2024, 9, 13, 10, 32, 12, 838, DateTimeKind.Utc).AddTicks(8730), null, null, null, null },
                    { new Guid("07b7e844-eb28-9476-8ad4-c426e03e7fcc"), new Guid("9825481b-9e16-8ef4-195c-2f1d50869c89"), new DateTime(2024, 9, 14, 0, 52, 36, 531, DateTimeKind.Utc).AddTicks(4392), "Kaley_Bradtke@gmail.com", "Celestine", false, null, "Feest", new DateTime(2024, 9, 13, 20, 14, 9, 397, DateTimeKind.Utc).AddTicks(5500), null, null, null, null },
                    { new Guid("080ca897-9d74-b37c-c7f0-d3af0f420dee"), new Guid("f26fcf2f-e7ed-59fb-861b-85c1f532c2c7"), new DateTime(2024, 9, 13, 7, 43, 9, 307, DateTimeKind.Utc).AddTicks(6859), "Jayde57@hotmail.com", "Elyse", false, null, "Ryan", new DateTime(2024, 9, 13, 22, 54, 52, 591, DateTimeKind.Utc).AddTicks(8068), null, null, null, null },
                    { new Guid("0da17a93-1d9a-a1ef-7c7d-2ea2209c44f1"), new Guid("58d6ac23-b9ba-53a2-4892-7f8b5d6e9896"), new DateTime(2024, 9, 14, 2, 40, 37, 678, DateTimeKind.Utc).AddTicks(8238), "Madie.Purdy12@gmail.com", "Alejandra", false, null, "Stokes", new DateTime(2024, 9, 13, 10, 15, 14, 894, DateTimeKind.Utc).AddTicks(703), null, null, null, null },
                    { new Guid("11331ab0-a5d7-4292-f5f8-020681c6d0b5"), new Guid("58d6ac23-b9ba-53a2-4892-7f8b5d6e9896"), new DateTime(2024, 9, 13, 15, 41, 55, 743, DateTimeKind.Utc).AddTicks(4268), "Ari.Waters@yahoo.com", "Evie", false, null, "Hansen", new DateTime(2024, 9, 13, 12, 50, 32, 467, DateTimeKind.Utc).AddTicks(2741), null, null, null, null },
                    { new Guid("1278a5b0-30c8-0273-e244-6de2410965ba"), new Guid("9825481b-9e16-8ef4-195c-2f1d50869c89"), new DateTime(2024, 9, 13, 15, 38, 42, 831, DateTimeKind.Utc).AddTicks(5227), "Weston81@yahoo.com", "Winnifred", false, null, "Feest", new DateTime(2024, 9, 14, 3, 25, 53, 361, DateTimeKind.Utc).AddTicks(5663), null, null, null, null },
                    { new Guid("13f94d5a-1e4b-3e0c-7265-3a7f2bc6fefd"), new Guid("2f08a644-f120-b99d-7a50-0e8ef1e502a2"), new DateTime(2024, 9, 14, 3, 43, 10, 211, DateTimeKind.Utc).AddTicks(444), "Ashly_Kuhic@gmail.com", "Ken", false, null, "Kihn", new DateTime(2024, 9, 13, 16, 47, 32, 859, DateTimeKind.Utc).AddTicks(5178), null, null, null, null },
                    { new Guid("13fd8ae1-5402-2068-5575-abc85a235730"), new Guid("9825481b-9e16-8ef4-195c-2f1d50869c89"), new DateTime(2024, 9, 13, 19, 38, 17, 617, DateTimeKind.Utc).AddTicks(4512), "Ezequiel.Crooks72@yahoo.com", "Abe", false, null, "Jast", new DateTime(2024, 9, 14, 0, 35, 4, 832, DateTimeKind.Utc).AddTicks(775), null, null, null, null },
                    { new Guid("1564ffb6-46bc-ed01-8487-4ae09c96349d"), new Guid("f26fcf2f-e7ed-59fb-861b-85c1f532c2c7"), new DateTime(2024, 9, 14, 2, 24, 53, 378, DateTimeKind.Utc).AddTicks(5020), "Jena_Fadel@gmail.com", "Melvin", false, null, "Keebler", new DateTime(2024, 9, 14, 4, 15, 57, 207, DateTimeKind.Utc).AddTicks(9811), null, null, null, null },
                    { new Guid("16844e84-e1e1-b7ad-ac95-82416556abe9"), new Guid("ff1d66b5-0328-033a-8da6-5bcc805718c8"), new DateTime(2024, 9, 13, 21, 37, 7, 92, DateTimeKind.Utc).AddTicks(6542), "Jamar98@gmail.com", "Jeramie", false, null, "Block", new DateTime(2024, 9, 14, 0, 54, 58, 60, DateTimeKind.Utc).AddTicks(7798), null, null, null, null },
                    { new Guid("1780f77c-8481-56db-0100-02794662a901"), new Guid("2f08a644-f120-b99d-7a50-0e8ef1e502a2"), new DateTime(2024, 9, 13, 16, 40, 48, 803, DateTimeKind.Utc).AddTicks(6819), "Petra_Lowe@gmail.com", "Britney", false, null, "Pouros", new DateTime(2024, 9, 13, 12, 20, 13, 209, DateTimeKind.Utc).AddTicks(3039), null, null, null, null },
                    { new Guid("1b8edb47-7688-8c4f-158d-d74ae139c0dd"), new Guid("2f08a644-f120-b99d-7a50-0e8ef1e502a2"), new DateTime(2024, 9, 13, 20, 29, 0, 44, DateTimeKind.Utc).AddTicks(8240), "Lola63@hotmail.com", "Justen", false, null, "Bernier", new DateTime(2024, 9, 13, 11, 57, 49, 143, DateTimeKind.Utc).AddTicks(2969), null, null, null, null },
                    { new Guid("20bd01d7-7b88-b338-781e-bda77c301ebc"), new Guid("2f08a644-f120-b99d-7a50-0e8ef1e502a2"), new DateTime(2024, 9, 13, 18, 54, 12, 914, DateTimeKind.Utc).AddTicks(1309), "Lee.Lemke80@hotmail.com", "Kylie", false, null, "Collier", new DateTime(2024, 9, 13, 8, 45, 35, 291, DateTimeKind.Utc).AddTicks(7491), null, null, null, null },
                    { new Guid("2bc3a1f9-d45b-5813-3e50-c06b9368ccab"), new Guid("9825481b-9e16-8ef4-195c-2f1d50869c89"), new DateTime(2024, 9, 13, 17, 41, 43, 644, DateTimeKind.Utc).AddTicks(8882), "Christy_Mohr3@yahoo.com", "Nella", false, null, "Mitchell", new DateTime(2024, 9, 14, 5, 16, 43, 796, DateTimeKind.Utc).AddTicks(728), null, null, null, null },
                    { new Guid("3120ccde-ff01-445d-acda-5cb7a37e7b40"), new Guid("ff1d66b5-0328-033a-8da6-5bcc805718c8"), new DateTime(2024, 9, 14, 3, 21, 19, 163, DateTimeKind.Utc).AddTicks(6217), "Robert89@hotmail.com", "Kane", false, null, "Koelpin", new DateTime(2024, 9, 13, 18, 39, 38, 709, DateTimeKind.Utc).AddTicks(817), null, null, null, null },
                    { new Guid("319bfa5d-5b0d-613b-55a1-4c9a4536df33"), new Guid("58d6ac23-b9ba-53a2-4892-7f8b5d6e9896"), new DateTime(2024, 9, 14, 3, 20, 7, 367, DateTimeKind.Utc).AddTicks(918), "Ardella83@gmail.com", "Winfield", false, null, "Ledner", new DateTime(2024, 9, 13, 18, 13, 27, 933, DateTimeKind.Utc).AddTicks(735), null, null, null, null },
                    { new Guid("32415cfe-f994-a20e-2b34-4789f8bad15e"), new Guid("58d6ac23-b9ba-53a2-4892-7f8b5d6e9896"), new DateTime(2024, 9, 13, 7, 12, 21, 861, DateTimeKind.Utc).AddTicks(6439), "Deion60@hotmail.com", "Adam", false, null, "Gerlach", new DateTime(2024, 9, 13, 12, 39, 2, 783, DateTimeKind.Utc).AddTicks(8222), null, null, null, null },
                    { new Guid("32d12f50-26cd-f7d9-d97e-25fe393cac35"), new Guid("58d6ac23-b9ba-53a2-4892-7f8b5d6e9896"), new DateTime(2024, 9, 14, 0, 2, 53, 81, DateTimeKind.Utc).AddTicks(6809), "Ludie57@hotmail.com", "Justine", false, null, "Lowe", new DateTime(2024, 9, 14, 3, 22, 36, 52, DateTimeKind.Utc).AddTicks(9408), null, null, null, null },
                    { new Guid("38b0bbcb-d9dc-4d5c-51bd-c197738a69a9"), new Guid("9825481b-9e16-8ef4-195c-2f1d50869c89"), new DateTime(2024, 9, 13, 12, 28, 16, 805, DateTimeKind.Utc).AddTicks(6574), "Lillie_Auer40@gmail.com", "Daniella", false, null, "Donnelly", new DateTime(2024, 9, 13, 23, 37, 23, 296, DateTimeKind.Utc).AddTicks(5900), null, null, null, null },
                    { new Guid("3c1f054f-b57e-9e75-f5c0-ab1d7959ba62"), new Guid("ff1d66b5-0328-033a-8da6-5bcc805718c8"), new DateTime(2024, 9, 13, 17, 58, 19, 807, DateTimeKind.Utc).AddTicks(6600), "Eddie.Jones@yahoo.com", "Eleanore", false, null, "Kertzmann", new DateTime(2024, 9, 14, 0, 45, 23, 628, DateTimeKind.Utc).AddTicks(6054), null, null, null, null },
                    { new Guid("3ddf74e3-ebc3-ce83-0009-6729fdf38d02"), new Guid("2f08a644-f120-b99d-7a50-0e8ef1e502a2"), new DateTime(2024, 9, 13, 20, 37, 31, 641, DateTimeKind.Utc).AddTicks(684), "Griffin20@yahoo.com", "Nyasia", false, null, "Leffler", new DateTime(2024, 9, 13, 5, 57, 23, 967, DateTimeKind.Utc).AddTicks(8699), null, null, null, null },
                    { new Guid("3ec5d0c6-7568-bfe6-5a63-1f054d897975"), new Guid("f26fcf2f-e7ed-59fb-861b-85c1f532c2c7"), new DateTime(2024, 9, 14, 3, 48, 56, 43, DateTimeKind.Utc).AddTicks(423), "General13@gmail.com", "Vladimir", false, null, "Satterfield", new DateTime(2024, 9, 13, 23, 29, 25, 887, DateTimeKind.Utc).AddTicks(2955), null, null, null, null },
                    { new Guid("51e55d72-d7e5-1959-65a2-887ca85eec01"), new Guid("ff1d66b5-0328-033a-8da6-5bcc805718c8"), new DateTime(2024, 9, 13, 16, 33, 46, 842, DateTimeKind.Utc).AddTicks(844), "Eli20@gmail.com", "Fay", false, null, "Cummings", new DateTime(2024, 9, 13, 6, 0, 58, 874, DateTimeKind.Utc).AddTicks(2796), null, null, null, null },
                    { new Guid("5270c29c-e156-9e33-bf2c-045161160ec4"), new Guid("f26fcf2f-e7ed-59fb-861b-85c1f532c2c7"), new DateTime(2024, 9, 13, 17, 56, 53, 901, DateTimeKind.Utc).AddTicks(8924), "Stanford.Fay76@gmail.com", "Nicklaus", false, null, "Streich", new DateTime(2024, 9, 13, 14, 28, 2, 43, DateTimeKind.Utc).AddTicks(2861), null, null, null, null },
                    { new Guid("5364d89a-d9a6-ef7e-3206-83b4233bb84a"), new Guid("2f08a644-f120-b99d-7a50-0e8ef1e502a2"), new DateTime(2024, 9, 13, 15, 31, 41, 96, DateTimeKind.Utc).AddTicks(7459), "Clint.Schulist@hotmail.com", "Mariana", false, null, "Maggio", new DateTime(2024, 9, 13, 9, 57, 31, 648, DateTimeKind.Utc).AddTicks(5358), null, null, null, null },
                    { new Guid("5671febb-ec84-5754-f64e-38c576e36b78"), new Guid("f26fcf2f-e7ed-59fb-861b-85c1f532c2c7"), new DateTime(2024, 9, 14, 5, 36, 4, 937, DateTimeKind.Utc).AddTicks(9128), "Ezra76@yahoo.com", "Brad", false, null, "Greenholt", new DateTime(2024, 9, 13, 11, 33, 20, 953, DateTimeKind.Utc).AddTicks(1758), null, null, null, null },
                    { new Guid("57061e34-d303-589d-6b5d-c573742d3af5"), new Guid("2f08a644-f120-b99d-7a50-0e8ef1e502a2"), new DateTime(2024, 9, 13, 7, 26, 1, 762, DateTimeKind.Utc).AddTicks(6921), "Eliza76@gmail.com", "Genoveva", false, null, "Mante", new DateTime(2024, 9, 13, 22, 40, 12, 740, DateTimeKind.Utc).AddTicks(8019), null, null, null, null },
                    { new Guid("58e59519-0689-90ef-57b6-94028932d41d"), new Guid("58d6ac23-b9ba-53a2-4892-7f8b5d6e9896"), new DateTime(2024, 9, 14, 1, 21, 44, 890, DateTimeKind.Utc).AddTicks(9034), "Dorothy.Kshlerin48@yahoo.com", "Jalen", false, null, "Marks", new DateTime(2024, 9, 13, 14, 10, 22, 504, DateTimeKind.Utc).AddTicks(3093), null, null, null, null },
                    { new Guid("59e55857-4a5b-0f58-1f04-0b1b5c6bbd54"), new Guid("9825481b-9e16-8ef4-195c-2f1d50869c89"), new DateTime(2024, 9, 13, 18, 45, 18, 430, DateTimeKind.Utc).AddTicks(5641), "Beau30@hotmail.com", "Cierra", false, null, "Schamberger", new DateTime(2024, 9, 13, 11, 45, 13, 585, DateTimeKind.Utc).AddTicks(7322), null, null, null, null },
                    { new Guid("5c8f62ff-7839-1415-331f-d48e5568987d"), new Guid("9825481b-9e16-8ef4-195c-2f1d50869c89"), new DateTime(2024, 9, 13, 16, 44, 0, 0, DateTimeKind.Utc).AddTicks(9481), "Jennie27@hotmail.com", "Tyreek", false, null, "Zemlak", new DateTime(2024, 9, 14, 0, 21, 56, 922, DateTimeKind.Utc).AddTicks(9367), null, null, null, null },
                    { new Guid("5da0066e-cae9-0ce4-09bb-0fea58db92b9"), new Guid("ff1d66b5-0328-033a-8da6-5bcc805718c8"), new DateTime(2024, 9, 13, 11, 34, 31, 696, DateTimeKind.Utc).AddTicks(9539), "Mikayla.Hayes@yahoo.com", "Raven", false, null, "Casper", new DateTime(2024, 9, 13, 16, 33, 57, 819, DateTimeKind.Utc).AddTicks(4692), null, null, null, null },
                    { new Guid("5f142dbb-6432-d9da-1880-daa8dad1f477"), new Guid("2f08a644-f120-b99d-7a50-0e8ef1e502a2"), new DateTime(2024, 9, 14, 3, 32, 29, 286, DateTimeKind.Utc).AddTicks(161), "Davonte.Gusikowski@yahoo.com", "Deshaun", false, null, "Hammes", new DateTime(2024, 9, 13, 15, 24, 46, 252, DateTimeKind.Utc).AddTicks(3781), null, null, null, null },
                    { new Guid("6436429c-c69b-1467-ace5-fa0b211325fa"), new Guid("9825481b-9e16-8ef4-195c-2f1d50869c89"), new DateTime(2024, 9, 13, 9, 46, 45, 384, DateTimeKind.Utc).AddTicks(1496), "Orlando.Kuphal30@hotmail.com", "Euna", false, null, "Bode", new DateTime(2024, 9, 14, 5, 22, 2, 135, DateTimeKind.Utc).AddTicks(3111), null, null, null, null },
                    { new Guid("654ce664-930a-4a1b-c5e1-e1bdf140924b"), new Guid("ff1d66b5-0328-033a-8da6-5bcc805718c8"), new DateTime(2024, 9, 14, 1, 13, 24, 872, DateTimeKind.Utc).AddTicks(5467), "Vance.Dach@gmail.com", "Haskell", false, null, "Towne", new DateTime(2024, 9, 13, 19, 7, 1, 677, DateTimeKind.Utc).AddTicks(9948), null, null, null, null },
                    { new Guid("6c5952c1-cdf3-09da-629c-d8e138f91974"), new Guid("9825481b-9e16-8ef4-195c-2f1d50869c89"), new DateTime(2024, 9, 13, 11, 40, 19, 123, DateTimeKind.Utc).AddTicks(4762), "Zita66@gmail.com", "Ciara", false, null, "O'Connell", new DateTime(2024, 9, 14, 1, 2, 44, 422, DateTimeKind.Utc).AddTicks(827), null, null, null, null },
                    { new Guid("6e495146-d8f9-fb30-a9f0-a694c1e67ff3"), new Guid("9825481b-9e16-8ef4-195c-2f1d50869c89"), new DateTime(2024, 9, 13, 18, 15, 30, 534, DateTimeKind.Utc).AddTicks(1521), "Evelyn50@gmail.com", "Bailee", false, null, "Connelly", new DateTime(2024, 9, 13, 7, 42, 50, 212, DateTimeKind.Utc).AddTicks(914), null, null, null, null },
                    { new Guid("7373943f-d5a3-f454-a6e4-c99a018fa460"), new Guid("2f08a644-f120-b99d-7a50-0e8ef1e502a2"), new DateTime(2024, 9, 13, 10, 50, 20, 562, DateTimeKind.Utc).AddTicks(1737), "Weston.Funk@hotmail.com", "Fae", false, null, "Kreiger", new DateTime(2024, 9, 13, 12, 47, 58, 782, DateTimeKind.Utc).AddTicks(7143), null, null, null, null },
                    { new Guid("76341cc7-1295-62d5-2011-cda34ec81226"), new Guid("ff1d66b5-0328-033a-8da6-5bcc805718c8"), new DateTime(2024, 9, 13, 6, 26, 33, 281, DateTimeKind.Utc).AddTicks(8642), "Leilani4@hotmail.com", "Dennis", false, null, "Buckridge", new DateTime(2024, 9, 13, 15, 31, 3, 469, DateTimeKind.Utc).AddTicks(1891), null, null, null, null },
                    { new Guid("7a126f0a-3b91-2b0f-200a-219c39b24364"), new Guid("f26fcf2f-e7ed-59fb-861b-85c1f532c2c7"), new DateTime(2024, 9, 13, 11, 30, 32, 159, DateTimeKind.Utc).AddTicks(7752), "Darien.Farrell94@hotmail.com", "Reilly", false, null, "Lueilwitz", new DateTime(2024, 9, 13, 20, 44, 41, 784, DateTimeKind.Utc).AddTicks(8749), null, null, null, null },
                    { new Guid("7d39fed6-b6a0-09f9-4f6b-50208a548c97"), new Guid("2f08a644-f120-b99d-7a50-0e8ef1e502a2"), new DateTime(2024, 9, 13, 21, 30, 33, 969, DateTimeKind.Utc).AddTicks(1447), "Jensen.Sauer@hotmail.com", "Kurtis", false, null, "Wolff", new DateTime(2024, 9, 13, 6, 16, 26, 255, DateTimeKind.Utc).AddTicks(5119), null, null, null, null },
                    { new Guid("80c1a3e2-4d9e-8020-4b62-838eaab981d0"), new Guid("2f08a644-f120-b99d-7a50-0e8ef1e502a2"), new DateTime(2024, 9, 13, 19, 24, 12, 770, DateTimeKind.Utc).AddTicks(2492), "Leone27@gmail.com", "Layne", false, null, "Schulist", new DateTime(2024, 9, 13, 19, 29, 45, 964, DateTimeKind.Utc).AddTicks(6604), null, null, null, null },
                    { new Guid("82e6681d-58e8-9d41-6323-f7e14931fafd"), new Guid("9825481b-9e16-8ef4-195c-2f1d50869c89"), new DateTime(2024, 9, 14, 1, 49, 48, 169, DateTimeKind.Utc).AddTicks(2854), "Orion3@gmail.com", "Dayana", false, null, "O'Reilly", new DateTime(2024, 9, 13, 12, 44, 36, 469, DateTimeKind.Utc).AddTicks(1371), null, null, null, null },
                    { new Guid("830d6557-acbb-f90a-64e2-767d50115ead"), new Guid("f26fcf2f-e7ed-59fb-861b-85c1f532c2c7"), new DateTime(2024, 9, 13, 22, 21, 14, 592, DateTimeKind.Utc).AddTicks(7012), "Esperanza.Hudson@yahoo.com", "Rodrick", false, null, "Lakin", new DateTime(2024, 9, 13, 11, 32, 22, 326, DateTimeKind.Utc).AddTicks(5657), null, null, null, null },
                    { new Guid("8b674291-2e0b-cdb5-7f29-e9cd26fd390c"), new Guid("ff1d66b5-0328-033a-8da6-5bcc805718c8"), new DateTime(2024, 9, 13, 7, 37, 34, 573, DateTimeKind.Utc).AddTicks(1801), "Reagan.White@yahoo.com", "Casper", false, null, "Collins", new DateTime(2024, 9, 13, 22, 17, 38, 849, DateTimeKind.Utc).AddTicks(7369), null, null, null, null },
                    { new Guid("8f58390d-af59-899d-7c85-64bf8b43a257"), new Guid("58d6ac23-b9ba-53a2-4892-7f8b5d6e9896"), new DateTime(2024, 9, 14, 3, 32, 50, 766, DateTimeKind.Utc).AddTicks(1306), "Gerson_Murazik48@yahoo.com", "Della", false, null, "Huel", new DateTime(2024, 9, 13, 8, 8, 42, 378, DateTimeKind.Utc).AddTicks(3131), null, null, null, null },
                    { new Guid("9062b0c4-a4f3-db32-5544-fd1dd91e41b5"), new Guid("2f08a644-f120-b99d-7a50-0e8ef1e502a2"), new DateTime(2024, 9, 14, 1, 31, 43, 209, DateTimeKind.Utc).AddTicks(7162), "Tyson_Gaylord@hotmail.com", "Kelsie", false, null, "Boyle", new DateTime(2024, 9, 14, 5, 26, 44, 187, DateTimeKind.Utc).AddTicks(8755), null, null, null, null },
                    { new Guid("9203a05b-0c31-c15b-d4f8-ff23db6b6413"), new Guid("58d6ac23-b9ba-53a2-4892-7f8b5d6e9896"), new DateTime(2024, 9, 13, 23, 25, 49, 818, DateTimeKind.Utc).AddTicks(802), "Skyla.Howe32@hotmail.com", "Kailey", false, null, "Ryan", new DateTime(2024, 9, 13, 6, 17, 35, 881, DateTimeKind.Utc).AddTicks(7113), null, null, null, null },
                    { new Guid("956f19b6-8269-f8e6-d9e3-b9e365f469ea"), new Guid("f26fcf2f-e7ed-59fb-861b-85c1f532c2c7"), new DateTime(2024, 9, 13, 9, 44, 43, 306, DateTimeKind.Utc).AddTicks(2234), "Layla57@gmail.com", "Ryan", false, null, "Walsh", new DateTime(2024, 9, 14, 4, 50, 36, 896, DateTimeKind.Utc).AddTicks(7605), null, null, null, null },
                    { new Guid("969d2106-2141-9cdd-7c17-2213b2c3ada1"), new Guid("f26fcf2f-e7ed-59fb-861b-85c1f532c2c7"), new DateTime(2024, 9, 13, 17, 1, 22, 401, DateTimeKind.Utc).AddTicks(2214), "Paula75@hotmail.com", "Janet", false, null, "Nitzsche", new DateTime(2024, 9, 13, 13, 25, 6, 191, DateTimeKind.Utc).AddTicks(2533), null, null, null, null },
                    { new Guid("96d2a4fa-8290-fa6e-a39e-8bf61f1f8444"), new Guid("f26fcf2f-e7ed-59fb-861b-85c1f532c2c7"), new DateTime(2024, 9, 13, 21, 27, 33, 786, DateTimeKind.Utc).AddTicks(8783), "Ike.Ruecker@gmail.com", "Hester", false, null, "Graham", new DateTime(2024, 9, 14, 0, 8, 27, 868, DateTimeKind.Utc).AddTicks(2143), null, null, null, null },
                    { new Guid("99197927-90d0-fa48-ea3d-ecd06e1b66b2"), new Guid("f26fcf2f-e7ed-59fb-861b-85c1f532c2c7"), new DateTime(2024, 9, 14, 3, 34, 0, 900, DateTimeKind.Utc).AddTicks(5738), "Sigrid_Zemlak6@yahoo.com", "Shany", false, null, "Klocko", new DateTime(2024, 9, 13, 18, 59, 53, 115, DateTimeKind.Utc).AddTicks(9586), null, null, null, null },
                    { new Guid("9ab89b64-f689-a551-d128-7134aba94795"), new Guid("2f08a644-f120-b99d-7a50-0e8ef1e502a2"), new DateTime(2024, 9, 14, 1, 33, 18, 752, DateTimeKind.Utc).AddTicks(439), "Vince_Spinka8@yahoo.com", "Wava", false, null, "Johns", new DateTime(2024, 9, 13, 10, 36, 43, 569, DateTimeKind.Utc).AddTicks(5363), null, null, null, null },
                    { new Guid("9be31292-ede4-ef30-271b-c616878e89c8"), new Guid("9825481b-9e16-8ef4-195c-2f1d50869c89"), new DateTime(2024, 9, 13, 16, 58, 2, 803, DateTimeKind.Utc).AddTicks(2534), "Kavon.Moen@yahoo.com", "Trinity", false, null, "Bartell", new DateTime(2024, 9, 13, 18, 41, 23, 658, DateTimeKind.Utc).AddTicks(9811), null, null, null, null },
                    { new Guid("9cd2df81-92e8-5b6b-16c4-4acc945ece4f"), new Guid("f26fcf2f-e7ed-59fb-861b-85c1f532c2c7"), new DateTime(2024, 9, 13, 13, 55, 27, 484, DateTimeKind.Utc).AddTicks(6657), "Anika_McClure83@gmail.com", "Ava", false, null, "Sanford", new DateTime(2024, 9, 13, 23, 56, 54, 196, DateTimeKind.Utc).AddTicks(6513), null, null, null, null },
                    { new Guid("9d4ea7f4-4228-75ee-0299-2e2043661557"), new Guid("9825481b-9e16-8ef4-195c-2f1d50869c89"), new DateTime(2024, 9, 13, 13, 21, 21, 554, DateTimeKind.Utc).AddTicks(7088), "Rocky.Ryan@yahoo.com", "Ezra", false, null, "King", new DateTime(2024, 9, 13, 8, 24, 33, 460, DateTimeKind.Utc).AddTicks(5867), null, null, null, null },
                    { new Guid("9e947675-e5ce-3db2-bd0a-ae1e2ba2e1eb"), new Guid("ff1d66b5-0328-033a-8da6-5bcc805718c8"), new DateTime(2024, 9, 14, 0, 54, 5, 885, DateTimeKind.Utc).AddTicks(255), "Oral7@hotmail.com", "Nakia", false, null, "Graham", new DateTime(2024, 9, 13, 16, 31, 21, 974, DateTimeKind.Utc).AddTicks(700), null, null, null, null },
                    { new Guid("9ea31fec-26ec-211f-b066-3f8dc87294c4"), new Guid("2f08a644-f120-b99d-7a50-0e8ef1e502a2"), new DateTime(2024, 9, 13, 23, 6, 53, 502, DateTimeKind.Utc).AddTicks(3711), "Rene.Pagac@yahoo.com", "Rebekah", false, null, "Cartwright", new DateTime(2024, 9, 13, 7, 20, 3, 248, DateTimeKind.Utc).AddTicks(9096), null, null, null, null },
                    { new Guid("9f6da6f4-9e85-ad63-3008-d5fa6ddb3d26"), new Guid("2f08a644-f120-b99d-7a50-0e8ef1e502a2"), new DateTime(2024, 9, 13, 19, 34, 43, 489, DateTimeKind.Utc).AddTicks(5914), "Unique_Kuvalis60@hotmail.com", "Prudence", false, null, "Harber", new DateTime(2024, 9, 13, 10, 9, 19, 445, DateTimeKind.Utc).AddTicks(8207), null, null, null, null },
                    { new Guid("9f91f2ef-5490-c864-1050-3acb7dbf1400"), new Guid("2f08a644-f120-b99d-7a50-0e8ef1e502a2"), new DateTime(2024, 9, 13, 10, 15, 55, 496, DateTimeKind.Utc).AddTicks(91), "Josefina95@yahoo.com", "Naomie", false, null, "Yost", new DateTime(2024, 9, 13, 9, 47, 16, 358, DateTimeKind.Utc).AddTicks(7631), null, null, null, null },
                    { new Guid("a3416341-84bd-7a19-fd64-ac351a02dd7d"), new Guid("ff1d66b5-0328-033a-8da6-5bcc805718c8"), new DateTime(2024, 9, 14, 3, 57, 49, 399, DateTimeKind.Utc).AddTicks(7145), "Erick.Will84@gmail.com", "Madisen", false, null, "Reichel", new DateTime(2024, 9, 13, 16, 57, 46, 143, DateTimeKind.Utc).AddTicks(8567), null, null, null, null },
                    { new Guid("a36266dd-416c-9ecc-4b07-e230b3938a9e"), new Guid("ff1d66b5-0328-033a-8da6-5bcc805718c8"), new DateTime(2024, 9, 13, 18, 40, 2, 742, DateTimeKind.Utc).AddTicks(9674), "Milo.Schamberger90@hotmail.com", "Connie", false, null, "Simonis", new DateTime(2024, 9, 14, 1, 27, 48, 236, DateTimeKind.Utc).AddTicks(6700), null, null, null, null },
                    { new Guid("a5ea611a-5cf4-19b0-3dfa-315609a7f0e6"), new Guid("2f08a644-f120-b99d-7a50-0e8ef1e502a2"), new DateTime(2024, 9, 13, 11, 54, 44, 146, DateTimeKind.Utc).AddTicks(1065), "Colt_Thiel74@gmail.com", "Nora", false, null, "Dietrich", new DateTime(2024, 9, 13, 15, 11, 5, 488, DateTimeKind.Utc).AddTicks(4056), null, null, null, null },
                    { new Guid("a90ade96-c557-4ee2-4778-f3a49d76cd70"), new Guid("58d6ac23-b9ba-53a2-4892-7f8b5d6e9896"), new DateTime(2024, 9, 14, 0, 2, 1, 631, DateTimeKind.Utc).AddTicks(2902), "Danyka_Lehner40@hotmail.com", "Madeline", false, null, "Cremin", new DateTime(2024, 9, 13, 14, 0, 26, 992, DateTimeKind.Utc).AddTicks(901), null, null, null, null },
                    { new Guid("adbd7e2b-09ff-6800-baf9-ba2ea24fd0f2"), new Guid("f26fcf2f-e7ed-59fb-861b-85c1f532c2c7"), new DateTime(2024, 9, 14, 4, 19, 9, 42, DateTimeKind.Utc).AddTicks(6864), "Gardner8@hotmail.com", "Irwin", false, null, "Tromp", new DateTime(2024, 9, 13, 20, 43, 14, 333, DateTimeKind.Utc).AddTicks(3930), null, null, null, null },
                    { new Guid("afd9dca0-ce4f-f49d-a5bf-1b65b20c9fa1"), new Guid("58d6ac23-b9ba-53a2-4892-7f8b5d6e9896"), new DateTime(2024, 9, 13, 9, 5, 54, 803, DateTimeKind.Utc).AddTicks(5128), "Georgette.Herzog@gmail.com", "Sylvia", false, null, "Ratke", new DateTime(2024, 9, 13, 11, 13, 53, 58, DateTimeKind.Utc).AddTicks(272), null, null, null, null },
                    { new Guid("b175c4da-5f7a-0a7e-4244-79c4f3e6b111"), new Guid("2f08a644-f120-b99d-7a50-0e8ef1e502a2"), new DateTime(2024, 9, 14, 0, 44, 19, 738, DateTimeKind.Utc).AddTicks(3982), "Kaden_Klocko45@yahoo.com", "Jeanne", false, null, "Dare", new DateTime(2024, 9, 14, 0, 58, 23, 324, DateTimeKind.Utc).AddTicks(4891), null, null, null, null },
                    { new Guid("b418ac2d-1dc0-dd66-0562-2823c92ce7e2"), new Guid("58d6ac23-b9ba-53a2-4892-7f8b5d6e9896"), new DateTime(2024, 9, 13, 11, 28, 26, 548, DateTimeKind.Utc).AddTicks(8670), "Tania32@hotmail.com", "Chad", false, null, "Nitzsche", new DateTime(2024, 9, 13, 8, 57, 50, 669, DateTimeKind.Utc).AddTicks(1274), null, null, null, null },
                    { new Guid("b65fe502-94ed-645a-be8d-a50a3de95dd7"), new Guid("58d6ac23-b9ba-53a2-4892-7f8b5d6e9896"), new DateTime(2024, 9, 14, 4, 22, 35, 105, DateTimeKind.Utc).AddTicks(8050), "Glennie69@hotmail.com", "Pink", false, null, "Cormier", new DateTime(2024, 9, 13, 21, 53, 46, 930, DateTimeKind.Utc).AddTicks(9397), null, null, null, null },
                    { new Guid("b76f1f9d-4207-3736-6a6a-fb20f1fbb75f"), new Guid("58d6ac23-b9ba-53a2-4892-7f8b5d6e9896"), new DateTime(2024, 9, 13, 12, 10, 29, 290, DateTimeKind.Utc).AddTicks(877), "Elisa_Pfannerstill@gmail.com", "Reymundo", false, null, "Barton", new DateTime(2024, 9, 13, 18, 22, 27, 214, DateTimeKind.Utc).AddTicks(9911), null, null, null, null },
                    { new Guid("b984b58c-1c1a-f959-e11c-e03b2cae39ad"), new Guid("2f08a644-f120-b99d-7a50-0e8ef1e502a2"), new DateTime(2024, 9, 14, 1, 22, 53, 446, DateTimeKind.Utc).AddTicks(2874), "Asia.Bosco79@yahoo.com", "Justice", false, null, "Bergnaum", new DateTime(2024, 9, 14, 5, 30, 51, 86, DateTimeKind.Utc).AddTicks(4988), null, null, null, null },
                    { new Guid("b9a5cb26-a02d-3338-6846-221f74b18ac4"), new Guid("9825481b-9e16-8ef4-195c-2f1d50869c89"), new DateTime(2024, 9, 13, 9, 44, 22, 409, DateTimeKind.Utc).AddTicks(1435), "Vinnie_Ziemann@gmail.com", "Tod", false, null, "Mosciski", new DateTime(2024, 9, 14, 2, 58, 45, 188, DateTimeKind.Utc).AddTicks(8153), null, null, null, null },
                    { new Guid("bca9d7d7-a2c2-fa17-0262-a62f33e73a29"), new Guid("9825481b-9e16-8ef4-195c-2f1d50869c89"), new DateTime(2024, 9, 13, 22, 38, 14, 218, DateTimeKind.Utc).AddTicks(1989), "Shirley.Mraz72@yahoo.com", "Colt", false, null, "Harvey", new DateTime(2024, 9, 13, 19, 35, 38, 208, DateTimeKind.Utc).AddTicks(2980), null, null, null, null },
                    { new Guid("bd383332-7318-99f2-9b47-c258079d4de8"), new Guid("2f08a644-f120-b99d-7a50-0e8ef1e502a2"), new DateTime(2024, 9, 14, 0, 41, 1, 935, DateTimeKind.Utc).AddTicks(144), "Oswaldo.Ernser50@hotmail.com", "Taryn", false, null, "Murray", new DateTime(2024, 9, 13, 15, 26, 53, 819, DateTimeKind.Utc).AddTicks(5431), null, null, null, null },
                    { new Guid("beb75c48-d47c-acfc-687b-49d728a8bacb"), new Guid("ff1d66b5-0328-033a-8da6-5bcc805718c8"), new DateTime(2024, 9, 13, 12, 53, 49, 569, DateTimeKind.Utc).AddTicks(6546), "Kaycee_Sporer27@hotmail.com", "Naomie", false, null, "Bartell", new DateTime(2024, 9, 13, 20, 59, 2, 532, DateTimeKind.Utc).AddTicks(4986), null, null, null, null },
                    { new Guid("cc5defbe-ac2b-c786-ce69-4ba4c73d05da"), new Guid("f26fcf2f-e7ed-59fb-861b-85c1f532c2c7"), new DateTime(2024, 9, 13, 5, 38, 47, 542, DateTimeKind.Utc).AddTicks(47), "Jazmyn.Bartell60@yahoo.com", "Magnus", false, null, "Berge", new DateTime(2024, 9, 13, 7, 45, 30, 445, DateTimeKind.Utc).AddTicks(2481), null, null, null, null },
                    { new Guid("ccb807a0-1c7d-34cf-8570-eb655bbd0092"), new Guid("f26fcf2f-e7ed-59fb-861b-85c1f532c2c7"), new DateTime(2024, 9, 13, 15, 36, 17, 12, DateTimeKind.Utc).AddTicks(9619), "Nettie59@yahoo.com", "Mona", false, null, "Grant", new DateTime(2024, 9, 14, 3, 32, 46, 188, DateTimeKind.Utc).AddTicks(5776), null, null, null, null },
                    { new Guid("cde4450a-b7a3-8ed7-c468-64b8e5ec4eee"), new Guid("58d6ac23-b9ba-53a2-4892-7f8b5d6e9896"), new DateTime(2024, 9, 13, 15, 32, 5, 429, DateTimeKind.Utc).AddTicks(3033), "Stacy85@hotmail.com", "Sheldon", false, null, "Ward", new DateTime(2024, 9, 13, 18, 19, 17, 674, DateTimeKind.Utc).AddTicks(7925), null, null, null, null },
                    { new Guid("cdf23ed4-1ea4-e11a-f989-ab2328e751e6"), new Guid("f26fcf2f-e7ed-59fb-861b-85c1f532c2c7"), new DateTime(2024, 9, 13, 18, 12, 28, 72, DateTimeKind.Utc).AddTicks(2192), "Samir_Lehner7@gmail.com", "Justen", false, null, "Mertz", new DateTime(2024, 9, 13, 17, 33, 48, 244, DateTimeKind.Utc).AddTicks(1656), null, null, null, null },
                    { new Guid("ce0edcea-72f7-4cff-8bc3-fc75caef025e"), new Guid("58d6ac23-b9ba-53a2-4892-7f8b5d6e9896"), new DateTime(2024, 9, 14, 2, 21, 37, 769, DateTimeKind.Utc).AddTicks(9315), "Raymond_Schmitt47@hotmail.com", "Tyrell", false, null, "Miller", new DateTime(2024, 9, 13, 11, 42, 1, 682, DateTimeKind.Utc).AddTicks(9629), null, null, null, null },
                    { new Guid("cfea94ec-c524-bd41-5182-0cc52660e965"), new Guid("f26fcf2f-e7ed-59fb-861b-85c1f532c2c7"), new DateTime(2024, 9, 13, 9, 29, 7, 596, DateTimeKind.Utc).AddTicks(5956), "Steve80@yahoo.com", "Dominic", false, null, "Armstrong", new DateTime(2024, 9, 13, 10, 6, 50, 989, DateTimeKind.Utc).AddTicks(9529), null, null, null, null },
                    { new Guid("d1d521c1-7455-6831-1210-5db4cd5e56b5"), new Guid("9825481b-9e16-8ef4-195c-2f1d50869c89"), new DateTime(2024, 9, 14, 2, 58, 43, 958, DateTimeKind.Utc).AddTicks(3744), "Desiree.Stark91@hotmail.com", "Martin", false, null, "Senger", new DateTime(2024, 9, 13, 19, 4, 36, 71, DateTimeKind.Utc).AddTicks(5055), null, null, null, null },
                    { new Guid("d38c48f7-3c84-81a0-3470-bc9c74ab6212"), new Guid("f26fcf2f-e7ed-59fb-861b-85c1f532c2c7"), new DateTime(2024, 9, 13, 7, 38, 16, 16, DateTimeKind.Utc).AddTicks(9135), "Major.Jenkins@gmail.com", "Toney", false, null, "Towne", new DateTime(2024, 9, 13, 9, 58, 36, 49, DateTimeKind.Utc).AddTicks(9837), null, null, null, null },
                    { new Guid("d58a48fd-932f-70e3-4c3c-09d92a58bd06"), new Guid("58d6ac23-b9ba-53a2-4892-7f8b5d6e9896"), new DateTime(2024, 9, 13, 8, 4, 30, 563, DateTimeKind.Utc).AddTicks(5708), "Mikayla_Jacobson@yahoo.com", "Geovany", false, null, "Schmitt", new DateTime(2024, 9, 13, 7, 2, 25, 768, DateTimeKind.Utc).AddTicks(3232), null, null, null, null },
                    { new Guid("d95a0f97-1a74-c084-1d31-89536bb9406a"), new Guid("ff1d66b5-0328-033a-8da6-5bcc805718c8"), new DateTime(2024, 9, 13, 15, 37, 50, 387, DateTimeKind.Utc).AddTicks(2372), "Toney6@gmail.com", "Nestor", false, null, "Heaney", new DateTime(2024, 9, 13, 14, 18, 0, 45, DateTimeKind.Utc).AddTicks(4050), null, null, null, null },
                    { new Guid("e3b2ef46-b36d-4f2a-0569-dd691af2feff"), new Guid("58d6ac23-b9ba-53a2-4892-7f8b5d6e9896"), new DateTime(2024, 9, 13, 8, 29, 56, 776, DateTimeKind.Utc).AddTicks(7607), "Roy_Terry43@yahoo.com", "Lucienne", false, null, "Gleichner", new DateTime(2024, 9, 13, 9, 49, 5, 664, DateTimeKind.Utc).AddTicks(7096), null, null, null, null },
                    { new Guid("e459f19b-0514-bebb-ac19-c87ee467bf76"), new Guid("2f08a644-f120-b99d-7a50-0e8ef1e502a2"), new DateTime(2024, 9, 13, 7, 10, 1, 342, DateTimeKind.Utc).AddTicks(8286), "Vicenta.Hammes46@hotmail.com", "Cortney", false, null, "Little", new DateTime(2024, 9, 14, 4, 7, 17, 188, DateTimeKind.Utc).AddTicks(2927), null, null, null, null },
                    { new Guid("e53ee8e3-a2ce-3ef3-aba7-d9aaf966ff87"), new Guid("2f08a644-f120-b99d-7a50-0e8ef1e502a2"), new DateTime(2024, 9, 13, 10, 40, 57, 296, DateTimeKind.Utc).AddTicks(1543), "Avery.Smith12@yahoo.com", "Kareem", false, null, "Adams", new DateTime(2024, 9, 14, 0, 19, 44, 474, DateTimeKind.Utc).AddTicks(5291), null, null, null, null },
                    { new Guid("e99a56a5-4fa4-bcb1-055e-a9d4d28555de"), new Guid("2f08a644-f120-b99d-7a50-0e8ef1e502a2"), new DateTime(2024, 9, 14, 1, 40, 31, 98, DateTimeKind.Utc).AddTicks(6207), "Maryse_Muller12@hotmail.com", "Vaughn", false, null, "Lubowitz", new DateTime(2024, 9, 13, 12, 46, 56, 369, DateTimeKind.Utc).AddTicks(235), null, null, null, null },
                    { new Guid("eb9c05e7-18bb-aaa9-8381-f229b4449443"), new Guid("ff1d66b5-0328-033a-8da6-5bcc805718c8"), new DateTime(2024, 9, 13, 21, 57, 17, 529, DateTimeKind.Utc).AddTicks(8336), "Cade35@gmail.com", "Kane", false, null, "Murray", new DateTime(2024, 9, 13, 12, 29, 42, 963, DateTimeKind.Utc).AddTicks(4958), null, null, null, null },
                    { new Guid("ec58ee12-8976-82ee-49cd-200e594b8c06"), new Guid("ff1d66b5-0328-033a-8da6-5bcc805718c8"), new DateTime(2024, 9, 13, 16, 34, 51, 664, DateTimeKind.Utc).AddTicks(982), "Tressa_Cassin88@yahoo.com", "Marcelino", false, null, "Flatley", new DateTime(2024, 9, 13, 9, 14, 10, 637, DateTimeKind.Utc).AddTicks(2763), null, null, null, null },
                    { new Guid("f0fd3a27-0320-2df3-7eba-b96abfe09baa"), new Guid("ff1d66b5-0328-033a-8da6-5bcc805718c8"), new DateTime(2024, 9, 13, 23, 24, 40, 564, DateTimeKind.Utc).AddTicks(8965), "Hans.Witting37@gmail.com", "Meaghan", false, null, "Welch", new DateTime(2024, 9, 13, 8, 1, 39, 797, DateTimeKind.Utc).AddTicks(6682), null, null, null, null },
                    { new Guid("f14ab8de-b4a4-80b8-ddda-a05ce6a99c10"), new Guid("58d6ac23-b9ba-53a2-4892-7f8b5d6e9896"), new DateTime(2024, 9, 13, 21, 47, 26, 245, DateTimeKind.Utc).AddTicks(7234), "Marjory.Sipes61@yahoo.com", "Brennan", false, null, "Upton", new DateTime(2024, 9, 13, 23, 18, 36, 796, DateTimeKind.Utc).AddTicks(9026), null, null, null, null },
                    { new Guid("f2bf73b1-6369-7803-6ee4-08dee6c38de4"), new Guid("58d6ac23-b9ba-53a2-4892-7f8b5d6e9896"), new DateTime(2024, 9, 13, 12, 22, 44, 226, DateTimeKind.Utc).AddTicks(8266), "Creola.Murazik2@hotmail.com", "Henri", false, null, "Christiansen", new DateTime(2024, 9, 14, 5, 16, 13, 38, DateTimeKind.Utc).AddTicks(6867), null, null, null, null },
                    { new Guid("fc51b91f-1dc0-998e-e829-7120967d42ed"), new Guid("f26fcf2f-e7ed-59fb-861b-85c1f532c2c7"), new DateTime(2024, 9, 13, 12, 12, 56, 280, DateTimeKind.Utc).AddTicks(6093), "Rebekah98@yahoo.com", "Enrico", false, null, "Dooley", new DateTime(2024, 9, 13, 21, 11, 49, 126, DateTimeKind.Utc).AddTicks(8147), null, null, null, null },
                    { new Guid("fd4219db-80ec-a6d6-dd3c-afdf78fb1066"), new Guid("ff1d66b5-0328-033a-8da6-5bcc805718c8"), new DateTime(2024, 9, 13, 21, 17, 34, 873, DateTimeKind.Utc).AddTicks(8701), "Alfonzo_Torphy@yahoo.com", "Augustine", false, null, "Stoltenberg", new DateTime(2024, 9, 14, 3, 59, 19, 695, DateTimeKind.Utc).AddTicks(8616), null, null, null, null },
                    { new Guid("fdd92483-16e7-562d-a080-88262a0b5154"), new Guid("ff1d66b5-0328-033a-8da6-5bcc805718c8"), new DateTime(2024, 9, 13, 7, 14, 55, 544, DateTimeKind.Utc).AddTicks(9626), "Hailee.Hilll0@hotmail.com", "Joanne", false, null, "Sanford", new DateTime(2024, 9, 13, 18, 35, 1, 219, DateTimeKind.Utc).AddTicks(4454), null, null, null, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("012db46d-3354-269c-3b8c-e92685c53a21"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("037d1980-5276-deb4-5352-9ca0c48e80a5"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("0482f077-777f-8062-1cf7-b94f6a5199f2"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("07347aa6-8b58-1302-7b91-21a4139ee1d3"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("07761ee1-3937-ee82-bee7-5b44a7d90360"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("07b7e844-eb28-9476-8ad4-c426e03e7fcc"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("080ca897-9d74-b37c-c7f0-d3af0f420dee"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("0da17a93-1d9a-a1ef-7c7d-2ea2209c44f1"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("11331ab0-a5d7-4292-f5f8-020681c6d0b5"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("1278a5b0-30c8-0273-e244-6de2410965ba"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("13f94d5a-1e4b-3e0c-7265-3a7f2bc6fefd"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("13fd8ae1-5402-2068-5575-abc85a235730"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("1564ffb6-46bc-ed01-8487-4ae09c96349d"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("16844e84-e1e1-b7ad-ac95-82416556abe9"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("1780f77c-8481-56db-0100-02794662a901"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("1b8edb47-7688-8c4f-158d-d74ae139c0dd"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("20bd01d7-7b88-b338-781e-bda77c301ebc"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("2bc3a1f9-d45b-5813-3e50-c06b9368ccab"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("3120ccde-ff01-445d-acda-5cb7a37e7b40"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("319bfa5d-5b0d-613b-55a1-4c9a4536df33"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("32415cfe-f994-a20e-2b34-4789f8bad15e"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("32d12f50-26cd-f7d9-d97e-25fe393cac35"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("38b0bbcb-d9dc-4d5c-51bd-c197738a69a9"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("3c1f054f-b57e-9e75-f5c0-ab1d7959ba62"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("3ddf74e3-ebc3-ce83-0009-6729fdf38d02"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("3ec5d0c6-7568-bfe6-5a63-1f054d897975"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("51e55d72-d7e5-1959-65a2-887ca85eec01"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("5270c29c-e156-9e33-bf2c-045161160ec4"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("5364d89a-d9a6-ef7e-3206-83b4233bb84a"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("5671febb-ec84-5754-f64e-38c576e36b78"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("57061e34-d303-589d-6b5d-c573742d3af5"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("58e59519-0689-90ef-57b6-94028932d41d"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("59e55857-4a5b-0f58-1f04-0b1b5c6bbd54"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("5c8f62ff-7839-1415-331f-d48e5568987d"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("5da0066e-cae9-0ce4-09bb-0fea58db92b9"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("5f142dbb-6432-d9da-1880-daa8dad1f477"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("6436429c-c69b-1467-ace5-fa0b211325fa"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("654ce664-930a-4a1b-c5e1-e1bdf140924b"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("6c5952c1-cdf3-09da-629c-d8e138f91974"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("6e495146-d8f9-fb30-a9f0-a694c1e67ff3"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("7373943f-d5a3-f454-a6e4-c99a018fa460"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("76341cc7-1295-62d5-2011-cda34ec81226"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("7a126f0a-3b91-2b0f-200a-219c39b24364"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("7d39fed6-b6a0-09f9-4f6b-50208a548c97"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("80c1a3e2-4d9e-8020-4b62-838eaab981d0"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("82e6681d-58e8-9d41-6323-f7e14931fafd"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("830d6557-acbb-f90a-64e2-767d50115ead"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("8b674291-2e0b-cdb5-7f29-e9cd26fd390c"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("8f58390d-af59-899d-7c85-64bf8b43a257"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("9062b0c4-a4f3-db32-5544-fd1dd91e41b5"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("9203a05b-0c31-c15b-d4f8-ff23db6b6413"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("956f19b6-8269-f8e6-d9e3-b9e365f469ea"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("969d2106-2141-9cdd-7c17-2213b2c3ada1"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("96d2a4fa-8290-fa6e-a39e-8bf61f1f8444"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("99197927-90d0-fa48-ea3d-ecd06e1b66b2"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("9ab89b64-f689-a551-d128-7134aba94795"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("9be31292-ede4-ef30-271b-c616878e89c8"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("9cd2df81-92e8-5b6b-16c4-4acc945ece4f"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("9d4ea7f4-4228-75ee-0299-2e2043661557"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("9e947675-e5ce-3db2-bd0a-ae1e2ba2e1eb"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("9ea31fec-26ec-211f-b066-3f8dc87294c4"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("9f6da6f4-9e85-ad63-3008-d5fa6ddb3d26"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("9f91f2ef-5490-c864-1050-3acb7dbf1400"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("a3416341-84bd-7a19-fd64-ac351a02dd7d"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("a36266dd-416c-9ecc-4b07-e230b3938a9e"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("a5ea611a-5cf4-19b0-3dfa-315609a7f0e6"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("a90ade96-c557-4ee2-4778-f3a49d76cd70"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("adbd7e2b-09ff-6800-baf9-ba2ea24fd0f2"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("afd9dca0-ce4f-f49d-a5bf-1b65b20c9fa1"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("b175c4da-5f7a-0a7e-4244-79c4f3e6b111"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("b418ac2d-1dc0-dd66-0562-2823c92ce7e2"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("b65fe502-94ed-645a-be8d-a50a3de95dd7"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("b76f1f9d-4207-3736-6a6a-fb20f1fbb75f"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("b984b58c-1c1a-f959-e11c-e03b2cae39ad"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("b9a5cb26-a02d-3338-6846-221f74b18ac4"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("bca9d7d7-a2c2-fa17-0262-a62f33e73a29"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("bd383332-7318-99f2-9b47-c258079d4de8"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("beb75c48-d47c-acfc-687b-49d728a8bacb"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("cc5defbe-ac2b-c786-ce69-4ba4c73d05da"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("ccb807a0-1c7d-34cf-8570-eb655bbd0092"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("cde4450a-b7a3-8ed7-c468-64b8e5ec4eee"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("cdf23ed4-1ea4-e11a-f989-ab2328e751e6"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("ce0edcea-72f7-4cff-8bc3-fc75caef025e"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("cfea94ec-c524-bd41-5182-0cc52660e965"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("d1d521c1-7455-6831-1210-5db4cd5e56b5"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("d38c48f7-3c84-81a0-3470-bc9c74ab6212"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("d58a48fd-932f-70e3-4c3c-09d92a58bd06"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("d95a0f97-1a74-c084-1d31-89536bb9406a"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("e3b2ef46-b36d-4f2a-0569-dd691af2feff"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("e459f19b-0514-bebb-ac19-c87ee467bf76"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("e53ee8e3-a2ce-3ef3-aba7-d9aaf966ff87"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("e99a56a5-4fa4-bcb1-055e-a9d4d28555de"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("eb9c05e7-18bb-aaa9-8381-f229b4449443"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("ec58ee12-8976-82ee-49cd-200e594b8c06"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("f0fd3a27-0320-2df3-7eba-b96abfe09baa"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("f14ab8de-b4a4-80b8-ddda-a05ce6a99c10"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("f2bf73b1-6369-7803-6ee4-08dee6c38de4"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("fc51b91f-1dc0-998e-e829-7120967d42ed"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("fd4219db-80ec-a6d6-dd3c-afdf78fb1066"));

            migrationBuilder.DeleteData(
                table: "user",
                keyColumn: "userid",
                keyValue: new Guid("fdd92483-16e7-562d-a080-88262a0b5154"));

            migrationBuilder.DeleteData(
                table: "company",
                keyColumn: "companyid",
                keyValue: new Guid("2f08a644-f120-b99d-7a50-0e8ef1e502a2"));

            migrationBuilder.DeleteData(
                table: "company",
                keyColumn: "companyid",
                keyValue: new Guid("58d6ac23-b9ba-53a2-4892-7f8b5d6e9896"));

            migrationBuilder.DeleteData(
                table: "company",
                keyColumn: "companyid",
                keyValue: new Guid("9825481b-9e16-8ef4-195c-2f1d50869c89"));

            migrationBuilder.DeleteData(
                table: "company",
                keyColumn: "companyid",
                keyValue: new Guid("f26fcf2f-e7ed-59fb-861b-85c1f532c2c7"));

            migrationBuilder.DeleteData(
                table: "company",
                keyColumn: "companyid",
                keyValue: new Guid("ff1d66b5-0328-033a-8da6-5bcc805718c8"));
        }
    }
}
