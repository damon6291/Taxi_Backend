using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Taxi_Backend.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalizedname = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    concurrencystamp = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aspnetroles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "backgroundhistory",
                columns: table => new
                {
                    backgroundhistoryid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    issuccess = table.Column<bool>(type: "boolean", nullable: false),
                    customerqueuecount = table.Column<int>(type: "integer", nullable: false),
                    driverqueuecount = table.Column<int>(type: "integer", nullable: false),
                    successamount = table.Column<int>(type: "integer", nullable: false),
                    erroramount = table.Column<int>(type: "integer", nullable: false),
                    process = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    error = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    createddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_backgroundhistory", x => x.backgroundhistoryid);
                });

            migrationBuilder.CreateTable(
                name: "company",
                columns: table => new
                {
                    companyid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    address = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    contact = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    phonenumber = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    timezone = table.Column<int>(type: "integer", nullable: false),
                    isarchived = table.Column<bool>(type: "boolean", nullable: false),
                    createddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_company", x => x.companyid);
                });

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    customerid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    phonenumber = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    createddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customer", x => x.customerid);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    roleid = table.Column<long>(type: "bigint", nullable: false),
                    claimtype = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    claimvalue = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aspnetroleclaims", x => x.id);
                    table.ForeignKey(
                        name: "fk_aspnetroleclaims_aspnetroles_roleid",
                        column: x => x.roleid,
                        principalTable: "AspNetRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    companyid = table.Column<long>(type: "bigint", nullable: false),
                    isarchived = table.Column<bool>(type: "boolean", nullable: false),
                    firstname = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    lastname = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    drivernumber = table.Column<int>(type: "integer", nullable: false),
                    lastlogindatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    createduserid = table.Column<long>(type: "bigint", nullable: true),
                    modifieduserid = table.Column<long>(type: "bigint", nullable: true),
                    createddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modifieddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    username = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalizedusername = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalizedemail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    emailconfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    passwordhash = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    securitystamp = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    concurrencystamp = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    phonenumber = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    phonenumberconfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    twofactorenabled = table.Column<bool>(type: "boolean", nullable: false),
                    lockoutend = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    lockoutenabled = table.Column<bool>(type: "boolean", nullable: false),
                    accessfailedcount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aspnetusers", x => x.id);
                    table.ForeignKey(
                        name: "fk_aspnetusers_aspnetusers_createduserid",
                        column: x => x.createduserid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_aspnetusers_aspnetusers_modifieduserid",
                        column: x => x.modifieduserid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_aspnetusers_company_companyid",
                        column: x => x.companyid,
                        principalTable: "company",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<long>(type: "bigint", nullable: false),
                    claimtype = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    claimvalue = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aspnetuserclaims", x => x.id);
                    table.ForeignKey(
                        name: "fk_aspnetuserclaims_aspnetusers_userid",
                        column: x => x.userid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    loginprovider = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    providerkey = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    providerdisplayname = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    userid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aspnetuserlogins", x => new { x.loginprovider, x.providerkey });
                    table.ForeignKey(
                        name: "fk_aspnetuserlogins_aspnetusers_userid",
                        column: x => x.userid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    userid = table.Column<long>(type: "bigint", nullable: false),
                    roleid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aspnetuserroles", x => new { x.userid, x.roleid });
                    table.ForeignKey(
                        name: "fk_aspnetuserroles_aspnetroles_roleid",
                        column: x => x.roleid,
                        principalTable: "AspNetRoles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_aspnetuserroles_aspnetusers_userid",
                        column: x => x.userid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    userid = table.Column<long>(type: "bigint", nullable: false),
                    loginprovider = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    value = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_aspnetusertokens", x => new { x.userid, x.loginprovider, x.name });
                    table.ForeignKey(
                        name: "fk_aspnetusertokens_aspnetusers_userid",
                        column: x => x.userid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "taxi",
                columns: table => new
                {
                    taxiid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    driverid = table.Column<long>(type: "bigint", nullable: false),
                    color = table.Column<int>(type: "integer", nullable: false),
                    make = table.Column<int>(type: "integer", nullable: false),
                    model = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    licenseplate = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    size = table.Column<int>(type: "integer", nullable: false),
                    createddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_taxi", x => x.taxiid);
                    table.ForeignKey(
                        name: "fk_taxi_users_driverid",
                        column: x => x.driverid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trip",
                columns: table => new
                {
                    tripid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    customerid = table.Column<long>(type: "bigint", nullable: false),
                    companyid = table.Column<long>(type: "bigint", nullable: false),
                    driverid = table.Column<long>(type: "bigint", nullable: true),
                    tripstatus = table.Column<int>(type: "integer", nullable: false),
                    calledtaxisize = table.Column<int>(type: "integer", nullable: false),
                    pickupaddress = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    droppoffaddress = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    mileage = table.Column<decimal>(type: "numeric", nullable: false),
                    alcoholphonenumber = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    alcoholtripid = table.Column<long>(type: "bigint", nullable: true),
                    notes = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    createddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    completedtime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trip", x => x.tripid);
                    table.ForeignKey(
                        name: "fk_trip_company_companyid",
                        column: x => x.companyid,
                        principalTable: "company",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_trip_customer_customerid",
                        column: x => x.customerid,
                        principalTable: "customer",
                        principalColumn: "customerid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_trip_users_driverid",
                        column: x => x.driverid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "customerqueue",
                columns: table => new
                {
                    customerqueueid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    customerid = table.Column<long>(type: "bigint", nullable: false),
                    tripid = table.Column<long>(type: "bigint", nullable: false),
                    companyid = table.Column<long>(type: "bigint", nullable: false),
                    queuestatus = table.Column<int>(type: "integer", nullable: false),
                    createddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_customerqueue", x => x.customerqueueid);
                    table.ForeignKey(
                        name: "fk_customerqueue_company_companyid",
                        column: x => x.companyid,
                        principalTable: "company",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_customerqueue_customer_customerid",
                        column: x => x.customerid,
                        principalTable: "customer",
                        principalColumn: "customerid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_customerqueue_trip_tripid",
                        column: x => x.tripid,
                        principalTable: "trip",
                        principalColumn: "tripid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "driverqueue",
                columns: table => new
                {
                    driverqueueid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    driverid = table.Column<long>(type: "bigint", nullable: false),
                    companyid = table.Column<long>(type: "bigint", nullable: false),
                    tripid = table.Column<long>(type: "bigint", nullable: true),
                    customerqueueid = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    queuestatus = table.Column<int>(type: "integer", nullable: false),
                    declinedcount = table.Column<int>(type: "integer", nullable: true),
                    longitude = table.Column<double>(type: "numeric(9,6)", nullable: false),
                    latitude = table.Column<double>(type: "numeric(8,6)", nullable: false),
                    declinedtime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    createddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_driverqueue", x => x.driverqueueid);
                    table.ForeignKey(
                        name: "fk_driverqueue_company_companyid",
                        column: x => x.companyid,
                        principalTable: "company",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_driverqueue_trip_tripid",
                        column: x => x.tripid,
                        principalTable: "trip",
                        principalColumn: "tripid");
                    table.ForeignKey(
                        name: "fk_driverqueue_users_driverid",
                        column: x => x.driverid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "id", "concurrencystamp", "name", "normalizedname" },
                values: new object[,]
                {
                    { 1L, null, "DRIVER", null },
                    { 2L, null, "CUSTOMER", null },
                    { 3L, null, "COMPANY", null },
                    { 4L, null, "DISPATCHER", null }
                });

            migrationBuilder.CreateIndex(
                name: "ix_aspnetroleclaims_roleid",
                table: "AspNetRoleClaims",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "normalizedname",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_aspnetuserclaims_userid",
                table: "AspNetUserClaims",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "ix_aspnetuserlogins_userid",
                table: "AspNetUserLogins",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "ix_aspnetuserroles_roleid",
                table: "AspNetUserRoles",
                column: "roleid");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "normalizedemail");

            migrationBuilder.CreateIndex(
                name: "ix_aspnetusers_companyid",
                table: "AspNetUsers",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "ix_aspnetusers_createduserid",
                table: "AspNetUsers",
                column: "createduserid");

            migrationBuilder.CreateIndex(
                name: "ix_aspnetusers_modifieduserid",
                table: "AspNetUsers",
                column: "modifieduserid");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "normalizedusername",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_customer_phonenumber",
                table: "customer",
                column: "phonenumber",
                unique: true,
                filter: "PhoneNumber is not null");

            migrationBuilder.CreateIndex(
                name: "ix_customerqueue_companyid",
                table: "customerqueue",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "ix_customerqueue_createddatetime",
                table: "customerqueue",
                column: "createddatetime",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "ix_customerqueue_customerid",
                table: "customerqueue",
                column: "customerid",
                unique: true,
                filter: "CustomerId is not null");

            migrationBuilder.CreateIndex(
                name: "ix_customerqueue_queuestatus",
                table: "customerqueue",
                column: "queuestatus");

            migrationBuilder.CreateIndex(
                name: "ix_customerqueue_tripid",
                table: "customerqueue",
                column: "tripid");

            migrationBuilder.CreateIndex(
                name: "ix_driverqueue_companyid",
                table: "driverqueue",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "ix_driverqueue_createddatetime",
                table: "driverqueue",
                column: "createddatetime",
                descending: new bool[0]);

            migrationBuilder.CreateIndex(
                name: "ix_driverqueue_driverid",
                table: "driverqueue",
                column: "driverid",
                unique: true,
                filter: "DriverId is not null");

            migrationBuilder.CreateIndex(
                name: "ix_driverqueue_queuestatus",
                table: "driverqueue",
                column: "queuestatus");

            migrationBuilder.CreateIndex(
                name: "ix_driverqueue_tripid",
                table: "driverqueue",
                column: "tripid");

            migrationBuilder.CreateIndex(
                name: "ix_taxi_driverid",
                table: "taxi",
                column: "driverid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_taxi_size",
                table: "taxi",
                column: "size");

            migrationBuilder.CreateIndex(
                name: "ix_trip_companyid",
                table: "trip",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "ix_trip_completedtime",
                table: "trip",
                column: "completedtime");

            migrationBuilder.CreateIndex(
                name: "ix_trip_customerid",
                table: "trip",
                column: "customerid");

            migrationBuilder.CreateIndex(
                name: "ix_trip_driverid",
                table: "trip",
                column: "driverid");

            migrationBuilder.CreateIndex(
                name: "ix_trip_tripstatus",
                table: "trip",
                column: "tripstatus");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "backgroundhistory");

            migrationBuilder.DropTable(
                name: "customerqueue");

            migrationBuilder.DropTable(
                name: "driverqueue");

            migrationBuilder.DropTable(
                name: "taxi");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "trip");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "company");
        }
    }
}
