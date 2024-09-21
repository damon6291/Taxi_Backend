using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WMS_backend.Migrations
{
    /// <inheritdoc />
    public partial class intial : Migration
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
                    isarchived = table.Column<bool>(type: "boolean", nullable: false),
                    createddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_company", x => x.companyid);
                });

            migrationBuilder.CreateTable(
                name: "courier",
                columns: table => new
                {
                    courierid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_courier", x => x.courierid);
                });

            migrationBuilder.CreateTable(
                name: "permissiontype",
                columns: table => new
                {
                    permissiontypeid = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_permissiontype", x => x.permissiontypeid);
                });

            migrationBuilder.CreateTable(
                name: "platform",
                columns: table => new
                {
                    platformid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_platform", x => x.platformid);
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
                    isarchived = table.Column<bool>(type: "boolean", nullable: false),
                    firstname = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    lastname = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    lastlogindatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    companyid = table.Column<long>(type: "bigint", nullable: true),
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
                        principalColumn: "companyid");
                });

            migrationBuilder.CreateTable(
                name: "companypermission",
                columns: table => new
                {
                    companypermissionid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    companyid = table.Column<long>(type: "bigint", nullable: false),
                    permissiontype = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_companypermission", x => x.companypermissionid);
                    table.ForeignKey(
                        name: "fk_companypermission_company_companyid",
                        column: x => x.companyid,
                        principalTable: "company",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shippingoption",
                columns: table => new
                {
                    shippingoptionid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    courierid = table.Column<long>(type: "bigint", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_shippingoption", x => x.shippingoptionid);
                    table.ForeignKey(
                        name: "fk_shippingoption_courier_courierid",
                        column: x => x.courierid,
                        principalTable: "courier",
                        principalColumn: "courierid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "platformcourier",
                columns: table => new
                {
                    platformcourierid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    platformid = table.Column<long>(type: "bigint", nullable: false),
                    courierid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_platformcourier", x => x.platformcourierid);
                    table.ForeignKey(
                        name: "fk_platformcourier_courier_courierid",
                        column: x => x.courierid,
                        principalTable: "courier",
                        principalColumn: "courierid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_platformcourier_platform_platformid",
                        column: x => x.platformid,
                        principalTable: "platform",
                        principalColumn: "platformid",
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
                name: "client",
                columns: table => new
                {
                    clientid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    address1 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    address2 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    city = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    state = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    zip = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    note = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    companyid = table.Column<long>(type: "bigint", nullable: false),
                    createduserid = table.Column<long>(type: "bigint", nullable: true),
                    modifieduserid = table.Column<long>(type: "bigint", nullable: true),
                    createddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updateddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_client", x => x.clientid);
                    table.ForeignKey(
                        name: "fk_client_company_companyid",
                        column: x => x.companyid,
                        principalTable: "company",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_client_users_createduserid",
                        column: x => x.createduserid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_client_users_modifieduserid",
                        column: x => x.modifieduserid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "companycourier",
                columns: table => new
                {
                    companycourierid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    companyid = table.Column<long>(type: "bigint", nullable: false),
                    key = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    createduserid = table.Column<long>(type: "bigint", nullable: true),
                    modifieduserid = table.Column<long>(type: "bigint", nullable: true),
                    createddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updateddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_companycourier", x => x.companycourierid);
                    table.ForeignKey(
                        name: "fk_companycourier_company_companyid",
                        column: x => x.companyid,
                        principalTable: "company",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_companycourier_users_createduserid",
                        column: x => x.createduserid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_companycourier_users_modifieduserid",
                        column: x => x.modifieduserid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "companyplatform",
                columns: table => new
                {
                    companyplatformid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    companyid = table.Column<long>(type: "bigint", nullable: false),
                    key = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    createduserid = table.Column<long>(type: "bigint", nullable: true),
                    modifieduserid = table.Column<long>(type: "bigint", nullable: true),
                    createddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updateddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_companyplatform", x => x.companyplatformid);
                    table.ForeignKey(
                        name: "fk_companyplatform_company_companyid",
                        column: x => x.companyid,
                        principalTable: "company",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_companyplatform_users_createduserid",
                        column: x => x.createduserid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_companyplatform_users_modifieduserid",
                        column: x => x.modifieduserid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "location",
                columns: table => new
                {
                    locationid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    address = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    phonenumber = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    locationtype = table.Column<int>(type: "integer", nullable: false),
                    isarchived = table.Column<bool>(type: "boolean", nullable: false),
                    companyid = table.Column<long>(type: "bigint", nullable: false),
                    createduserid = table.Column<long>(type: "bigint", nullable: true),
                    modifieduserid = table.Column<long>(type: "bigint", nullable: true),
                    createddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updateddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_location", x => x.locationid);
                    table.ForeignKey(
                        name: "fk_location_company_companyid",
                        column: x => x.companyid,
                        principalTable: "company",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_location_users_createduserid",
                        column: x => x.createduserid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_location_users_modifieduserid",
                        column: x => x.modifieduserid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "notification",
                columns: table => new
                {
                    notificationid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    notificationtype = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    isarchived = table.Column<bool>(type: "boolean", nullable: false),
                    createddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    userid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_notification", x => x.notificationid);
                    table.ForeignKey(
                        name: "fk_notification_users_userid",
                        column: x => x.userid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchaserequest",
                columns: table => new
                {
                    purchaserequestid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    messagetoteam = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    isarchived = table.Column<bool>(type: "boolean", nullable: false),
                    staus = table.Column<int>(type: "integer", nullable: false),
                    messagefromteam = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    companyid = table.Column<long>(type: "bigint", nullable: false),
                    createduserid = table.Column<long>(type: "bigint", nullable: true),
                    modifieduserid = table.Column<long>(type: "bigint", nullable: true),
                    createddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updateddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchaserequest", x => x.purchaserequestid);
                    table.ForeignKey(
                        name: "fk_purchaserequest_company_companyid",
                        column: x => x.companyid,
                        principalTable: "company",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaserequest_users_createduserid",
                        column: x => x.createduserid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_purchaserequest_users_modifieduserid",
                        column: x => x.modifieduserid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "supplier",
                columns: table => new
                {
                    supplierid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    address = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    contact = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    phonenumber = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    isarchived = table.Column<bool>(type: "boolean", nullable: false),
                    companyid = table.Column<long>(type: "bigint", nullable: false),
                    createduserid = table.Column<long>(type: "bigint", nullable: true),
                    modifieduserid = table.Column<long>(type: "bigint", nullable: true),
                    createddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updateddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_supplier", x => x.supplierid);
                    table.ForeignKey(
                        name: "fk_supplier_company_companyid",
                        column: x => x.companyid,
                        principalTable: "company",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_supplier_users_createduserid",
                        column: x => x.createduserid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_supplier_users_modifieduserid",
                        column: x => x.modifieduserid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "userpermission",
                columns: table => new
                {
                    userpermissionid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<long>(type: "bigint", nullable: false),
                    permissiontype = table.Column<int>(type: "integer", nullable: false),
                    iscrud = table.Column<bool>(type: "boolean", nullable: false),
                    createduserid = table.Column<long>(type: "bigint", nullable: true),
                    modifieduserid = table.Column<long>(type: "bigint", nullable: true),
                    createddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updateddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_userpermission", x => x.userpermissionid);
                    table.ForeignKey(
                        name: "fk_userpermission_users_createduserid",
                        column: x => x.createduserid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_userpermission_users_modifieduserid",
                        column: x => x.modifieduserid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_userpermission_users_userid",
                        column: x => x.userid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userpreference",
                columns: table => new
                {
                    userpreferenceid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<long>(type: "bigint", nullable: false),
                    preferencetype = table.Column<int>(type: "integer", nullable: false),
                    value = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_userpreference", x => x.userpreferenceid);
                    table.ForeignKey(
                        name: "fk_userpreference_users_userid",
                        column: x => x.userid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    orderid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    companyid = table.Column<long>(type: "bigint", nullable: false),
                    platformid = table.Column<long>(type: "bigint", nullable: true),
                    courierid = table.Column<long>(type: "bigint", nullable: true),
                    shippingoptionid = table.Column<long>(type: "bigint", nullable: true),
                    clientid = table.Column<long>(type: "bigint", nullable: true),
                    orderstatus = table.Column<int>(type: "integer", nullable: false),
                    ordernumber = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    expecteddate = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    note = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    trackingnumber = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    createduserid = table.Column<long>(type: "bigint", nullable: true),
                    modifieduserid = table.Column<long>(type: "bigint", nullable: true),
                    createddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updateddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order", x => x.orderid);
                    table.ForeignKey(
                        name: "fk_order_client_clientid",
                        column: x => x.clientid,
                        principalTable: "client",
                        principalColumn: "clientid");
                    table.ForeignKey(
                        name: "fk_order_company_companyid",
                        column: x => x.companyid,
                        principalTable: "company",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_order_courier_courierid",
                        column: x => x.courierid,
                        principalTable: "courier",
                        principalColumn: "courierid");
                    table.ForeignKey(
                        name: "fk_order_platform_platformid",
                        column: x => x.platformid,
                        principalTable: "platform",
                        principalColumn: "platformid");
                    table.ForeignKey(
                        name: "fk_order_shippingoption_shippingoptionid",
                        column: x => x.shippingoptionid,
                        principalTable: "shippingoption",
                        principalColumn: "shippingoptionid");
                    table.ForeignKey(
                        name: "fk_order_users_createduserid",
                        column: x => x.createduserid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_order_users_modifieduserid",
                        column: x => x.modifieduserid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "rack",
                columns: table => new
                {
                    rackid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    xslotmax = table.Column<int>(type: "integer", nullable: false),
                    yslotmax = table.Column<int>(type: "integer", nullable: false),
                    isarchived = table.Column<bool>(type: "boolean", nullable: false),
                    locationid = table.Column<long>(type: "bigint", nullable: false),
                    createduserid = table.Column<long>(type: "bigint", nullable: true),
                    modifieduserid = table.Column<long>(type: "bigint", nullable: true),
                    createddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updateddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_rack", x => x.rackid);
                    table.ForeignKey(
                        name: "fk_rack_location_locationid",
                        column: x => x.locationid,
                        principalTable: "location",
                        principalColumn: "locationid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_rack_users_createduserid",
                        column: x => x.createduserid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_rack_users_modifieduserid",
                        column: x => x.modifieduserid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "tote",
                columns: table => new
                {
                    toteid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    countmax = table.Column<int>(type: "integer", nullable: false),
                    isarchived = table.Column<bool>(type: "boolean", nullable: false),
                    locationid = table.Column<long>(type: "bigint", nullable: false),
                    createduserid = table.Column<long>(type: "bigint", nullable: true),
                    modifieduserid = table.Column<long>(type: "bigint", nullable: true),
                    createddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updateddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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
                    table.ForeignKey(
                        name: "fk_tote_users_createduserid",
                        column: x => x.createduserid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_tote_users_modifieduserid",
                        column: x => x.modifieduserid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    productid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    isarchived = table.Column<bool>(type: "boolean", nullable: false),
                    supplierid = table.Column<long>(type: "bigint", nullable: true),
                    companyid = table.Column<long>(type: "bigint", nullable: false),
                    createduserid = table.Column<long>(type: "bigint", nullable: true),
                    modifieduserid = table.Column<long>(type: "bigint", nullable: true),
                    createddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updateddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product", x => x.productid);
                    table.ForeignKey(
                        name: "fk_product_company_companyid",
                        column: x => x.companyid,
                        principalTable: "company",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_product_supplier_supplierid",
                        column: x => x.supplierid,
                        principalTable: "supplier",
                        principalColumn: "supplierid");
                    table.ForeignKey(
                        name: "fk_product_users_createduserid",
                        column: x => x.createduserid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_product_users_modifieduserid",
                        column: x => x.modifieduserid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "purchaseorder",
                columns: table => new
                {
                    purchaseorderid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    purchaseordernumber = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    postatus = table.Column<int>(type: "integer", nullable: false),
                    locationid = table.Column<long>(type: "bigint", nullable: false),
                    supplierid = table.Column<long>(type: "bigint", nullable: false),
                    expecteddate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    shippingcarrier = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    trackingnumber = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    note = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    unitorders = table.Column<int>(type: "integer", nullable: false),
                    subtotal = table.Column<float>(type: "real", nullable: false),
                    tax = table.Column<float>(type: "real", nullable: false),
                    shipping = table.Column<float>(type: "real", nullable: false),
                    total = table.Column<float>(type: "real", nullable: false),
                    isarchived = table.Column<bool>(type: "boolean", nullable: false),
                    companyid = table.Column<long>(type: "bigint", nullable: false),
                    createduserid = table.Column<long>(type: "bigint", nullable: true),
                    modifieduserid = table.Column<long>(type: "bigint", nullable: true),
                    createddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updateddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchaseorder", x => x.purchaseorderid);
                    table.ForeignKey(
                        name: "fk_purchaseorder_company_companyid",
                        column: x => x.companyid,
                        principalTable: "company",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseorder_location_locationid",
                        column: x => x.locationid,
                        principalTable: "location",
                        principalColumn: "locationid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseorder_supplier_supplierid",
                        column: x => x.supplierid,
                        principalTable: "supplier",
                        principalColumn: "supplierid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseorder_users_createduserid",
                        column: x => x.createduserid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_purchaseorder_users_modifieduserid",
                        column: x => x.modifieduserid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "orderhistory",
                columns: table => new
                {
                    orderhistoryid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    orderid = table.Column<Guid>(type: "uuid", nullable: false),
                    userid = table.Column<long>(type: "bigint", nullable: false),
                    message = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orderhistory", x => x.orderhistoryid);
                    table.ForeignKey(
                        name: "fk_orderhistory_order_orderid",
                        column: x => x.orderid,
                        principalTable: "order",
                        principalColumn: "orderid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_orderhistory_users_userid",
                        column: x => x.userid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "producthistory",
                columns: table => new
                {
                    producthistoryid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    userid = table.Column<long>(type: "bigint", nullable: false),
                    message = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    createddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    productid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_producthistory", x => x.producthistoryid);
                    table.ForeignKey(
                        name: "fk_producthistory_product_productid",
                        column: x => x.productid,
                        principalTable: "product",
                        principalColumn: "productid");
                    table.ForeignKey(
                        name: "fk_producthistory_users_userid",
                        column: x => x.userid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productvariant",
                columns: table => new
                {
                    productvariantid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    sku = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    barcode = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    barcode1 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    barcode2 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    barcode3 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    width = table.Column<double>(type: "double precision", nullable: true),
                    length = table.Column<double>(type: "double precision", nullable: true),
                    height = table.Column<double>(type: "double precision", nullable: true),
                    weight = table.Column<double>(type: "double precision", nullable: true),
                    purchaseprice = table.Column<float>(type: "real", nullable: true),
                    retailprice = table.Column<float>(type: "real", nullable: true),
                    taxrate = table.Column<float>(type: "real", nullable: true),
                    isarchived = table.Column<bool>(type: "boolean", nullable: false),
                    productid = table.Column<Guid>(type: "uuid", nullable: false),
                    createduserid = table.Column<long>(type: "bigint", nullable: true),
                    modifieduserid = table.Column<long>(type: "bigint", nullable: true),
                    createddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updateddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_productvariant", x => x.productvariantid);
                    table.ForeignKey(
                        name: "fk_productvariant_product_productid",
                        column: x => x.productid,
                        principalTable: "product",
                        principalColumn: "productid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productvariant_users_createduserid",
                        column: x => x.createduserid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_productvariant_users_modifieduserid",
                        column: x => x.modifieduserid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "purchaseorderhistory",
                columns: table => new
                {
                    purchaseorderhistoryid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    userid = table.Column<long>(type: "bigint", nullable: false),
                    message = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    createddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    purchaseorderid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchaseorderhistory", x => x.purchaseorderhistoryid);
                    table.ForeignKey(
                        name: "fk_purchaseorderhistory_purchaseorder_purchaseorderid",
                        column: x => x.purchaseorderid,
                        principalTable: "purchaseorder",
                        principalColumn: "purchaseorderid");
                    table.ForeignKey(
                        name: "fk_purchaseorderhistory_users_userid",
                        column: x => x.userid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inventory",
                columns: table => new
                {
                    inventoryid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    productvariantid = table.Column<Guid>(type: "uuid", nullable: false),
                    rackid = table.Column<Guid>(type: "uuid", nullable: false),
                    xslot = table.Column<int>(type: "integer", nullable: false),
                    yslot = table.Column<int>(type: "integer", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    lotnumber = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    expirationdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    companyid = table.Column<long>(type: "bigint", nullable: false),
                    createduserid = table.Column<long>(type: "bigint", nullable: true),
                    modifieduserid = table.Column<long>(type: "bigint", nullable: true),
                    createddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updateddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_inventory", x => x.inventoryid);
                    table.ForeignKey(
                        name: "fk_inventory_company_companyid",
                        column: x => x.companyid,
                        principalTable: "company",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_inventory_productvariant_productvariantid",
                        column: x => x.productvariantid,
                        principalTable: "productvariant",
                        principalColumn: "productvariantid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_inventory_rack_rackid",
                        column: x => x.rackid,
                        principalTable: "rack",
                        principalColumn: "rackid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_inventory_users_createduserid",
                        column: x => x.createduserid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_inventory_users_modifieduserid",
                        column: x => x.modifieduserid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "orderitem",
                columns: table => new
                {
                    orderitemid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    orderid = table.Column<Guid>(type: "uuid", nullable: false),
                    productvariantid = table.Column<Guid>(type: "uuid", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false),
                    amountperitem = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orderitem", x => x.orderitemid);
                    table.ForeignKey(
                        name: "fk_orderitem_order_orderid",
                        column: x => x.orderid,
                        principalTable: "order",
                        principalColumn: "orderid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_orderitem_productvariant_productvariantid",
                        column: x => x.productvariantid,
                        principalTable: "productvariant",
                        principalColumn: "productvariantid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productbundle",
                columns: table => new
                {
                    productbundleid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    productvariantid = table.Column<Guid>(type: "uuid", nullable: false),
                    createduserid = table.Column<long>(type: "bigint", nullable: true),
                    modifieduserid = table.Column<long>(type: "bigint", nullable: true),
                    createddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updateddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_productbundle", x => x.productbundleid);
                    table.ForeignKey(
                        name: "fk_productbundle_productvariant_productvariantid",
                        column: x => x.productvariantid,
                        principalTable: "productvariant",
                        principalColumn: "productvariantid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productbundle_users_createduserid",
                        column: x => x.createduserid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_productbundle_users_modifieduserid",
                        column: x => x.modifieduserid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "purchaseorderitem",
                columns: table => new
                {
                    purchaseorderitemid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    productvariantid = table.Column<Guid>(type: "uuid", nullable: false),
                    purchaseorderid = table.Column<Guid>(type: "uuid", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchaseorderitem", x => x.purchaseorderitemid);
                    table.ForeignKey(
                        name: "fk_purchaseorderitem_productvariant_productvariantid",
                        column: x => x.productvariantid,
                        principalTable: "productvariant",
                        principalColumn: "productvariantid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseorderitem_purchaseorder_purchaseorderid",
                        column: x => x.purchaseorderid,
                        principalTable: "purchaseorder",
                        principalColumn: "purchaseorderid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "company",
                columns: new[] { "companyid", "address", "contact", "createddatetime", "email", "isarchived", "name", "phonenumber" },
                values: new object[,]
                {
                    { 100L, null, null, new DateTime(2024, 9, 20, 12, 33, 50, 608, DateTimeKind.Utc).AddTicks(6520), null, false, "Jedediah Mills", null },
                    { 101L, null, null, new DateTime(2024, 9, 20, 20, 11, 6, 837, DateTimeKind.Utc).AddTicks(8419), null, false, "Trenton Wilkinson", null }
                });

            migrationBuilder.InsertData(
                table: "courier",
                columns: new[] { "courierid", "name" },
                values: new object[,]
                {
                    { 100L, "Amazon" },
                    { 101L, "USPS" }
                });

            migrationBuilder.InsertData(
                table: "permissiontype",
                columns: new[] { "permissiontypeid", "name" },
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
                    { 95, "Location" },
                    { 100, "PurchaseOrder" },
                    { 110, "PurchaseRequest" },
                    { 120, "Supplier" },
                    { 130, "ReportOrder" },
                    { 140, "ReportPurchaseOrder" },
                    { 150, "ReportInventory" },
                    { 170, "ManageCompany" },
                    { 180, "ManageTeam" }
                });

            migrationBuilder.InsertData(
                table: "platform",
                columns: new[] { "platformid", "name" },
                values: new object[,]
                {
                    { 100L, "Amazon" },
                    { 101L, "Ebay" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "id", "accessfailedcount", "companyid", "concurrencystamp", "createddatetime", "createduserid", "email", "emailconfirmed", "firstname", "isarchived", "lastlogindatetime", "lastname", "lockoutenabled", "lockoutend", "modifieddatetime", "modifieduserid", "normalizedemail", "normalizedusername", "passwordhash", "phonenumber", "phonenumberconfirmed", "securitystamp", "twofactorenabled", "username" },
                values: new object[,]
                {
                    { 100L, 0, 101L, "50f5a329-4aab-4f64-9095-067856db3f85", new DateTime(2024, 9, 20, 10, 27, 27, 734, DateTimeKind.Utc).AddTicks(249), null, "Madeline88@yahoo.com", false, "Nash", true, null, "Rath", false, null, new DateTime(2024, 9, 20, 22, 42, 18, 910, DateTimeKind.Utc).AddTicks(6317), null, "MADELINE88@YAHOO.COM", "MADELINE88@YAHOO.COM", "AQAAAAIAAYagAAAAEJCx0o43IjUq0DFnyjUNecUU9c/Iluz+U8QWtmqk3fT7PpJXB0sfDD+fBomd62Bohw==", null, false, "E7EYWZPTSKQWK5AVQYJDWIUBFAUHH4PI", false, "Madeline88@yahoo.com" },
                    { 101L, 0, 101L, "71f78036-c4fe-4937-820e-aca5e20dce27", new DateTime(2024, 9, 20, 21, 4, 23, 636, DateTimeKind.Utc).AddTicks(2684), null, "Bethel.Roberts6@hotmail.com", false, "Murray", false, null, "Hudson", false, null, new DateTime(2024, 9, 20, 8, 54, 14, 838, DateTimeKind.Utc).AddTicks(1844), null, "BETHEL.ROBERTS6@HOTMAIL.COM", "BETHEL.ROBERTS6@HOTMAIL.COM", "AQAAAAIAAYagAAAAEJCx0o43IjUq0DFnyjUNecUU9c/Iluz+U8QWtmqk3fT7PpJXB0sfDD+fBomd62Bohw==", null, false, "E7EYWZPTSKQWK5AVQYJDWIUBFAUHH4PI", false, "Bethel.Roberts6@hotmail.com" },
                    { 102L, 0, 101L, "ccae47a7-2502-4c10-88de-de776dabbcda", new DateTime(2024, 9, 20, 11, 4, 58, 497, DateTimeKind.Utc).AddTicks(9250), null, "Trever95@hotmail.com", false, "Violette", false, null, "Ondricka", false, null, new DateTime(2024, 9, 20, 17, 42, 15, 343, DateTimeKind.Utc).AddTicks(8205), null, "TREVER95@HOTMAIL.COM", "TREVER95@HOTMAIL.COM", "AQAAAAIAAYagAAAAEJCx0o43IjUq0DFnyjUNecUU9c/Iluz+U8QWtmqk3fT7PpJXB0sfDD+fBomd62Bohw==", null, false, "E7EYWZPTSKQWK5AVQYJDWIUBFAUHH4PI", false, "Trever95@hotmail.com" },
                    { 103L, 0, 100L, "6e8913ec-4c47-4ad6-8556-e17e5e9174b9", new DateTime(2024, 9, 20, 18, 41, 57, 114, DateTimeKind.Utc).AddTicks(2618), null, "Vicky7@yahoo.com", false, "Charlotte", true, null, "Bergstrom", false, null, new DateTime(2024, 9, 21, 2, 9, 35, 716, DateTimeKind.Utc).AddTicks(877), null, "VICKY7@YAHOO.COM", "VICKY7@YAHOO.COM", "AQAAAAIAAYagAAAAEJCx0o43IjUq0DFnyjUNecUU9c/Iluz+U8QWtmqk3fT7PpJXB0sfDD+fBomd62Bohw==", null, false, "E7EYWZPTSKQWK5AVQYJDWIUBFAUHH4PI", false, "Vicky7@yahoo.com" },
                    { 104L, 0, 101L, "d75ab569-c5d0-44a1-9ee4-0ce2262bccc5", new DateTime(2024, 9, 20, 14, 36, 23, 20, DateTimeKind.Utc).AddTicks(6158), null, "Mckenna25@gmail.com", false, "Kaela", false, null, "Treutel", false, null, new DateTime(2024, 9, 20, 11, 29, 20, 981, DateTimeKind.Utc).AddTicks(9022), null, "MCKENNA25@GMAIL.COM", "MCKENNA25@GMAIL.COM", "AQAAAAIAAYagAAAAEJCx0o43IjUq0DFnyjUNecUU9c/Iluz+U8QWtmqk3fT7PpJXB0sfDD+fBomd62Bohw==", null, false, "E7EYWZPTSKQWK5AVQYJDWIUBFAUHH4PI", false, "Mckenna25@gmail.com" },
                    { 105L, 0, 100L, "18760e2a-b18d-4a08-bb02-5bf45e7002e6", new DateTime(2024, 9, 20, 19, 52, 18, 164, DateTimeKind.Utc).AddTicks(9294), null, "Wilma_Feeney75@hotmail.com", false, "Nico", true, null, "Lowe", false, null, new DateTime(2024, 9, 21, 0, 44, 58, 57, DateTimeKind.Utc).AddTicks(3404), null, "WILMA_FEENEY75@HOTMAIL.COM", "WILMA_FEENEY75@HOTMAIL.COM", "AQAAAAIAAYagAAAAEJCx0o43IjUq0DFnyjUNecUU9c/Iluz+U8QWtmqk3fT7PpJXB0sfDD+fBomd62Bohw==", null, false, "E7EYWZPTSKQWK5AVQYJDWIUBFAUHH4PI", false, "Wilma_Feeney75@hotmail.com" },
                    { 106L, 0, 101L, "39d8bf77-0391-4ab5-88a4-b414dfd7e55f", new DateTime(2024, 9, 20, 14, 24, 27, 762, DateTimeKind.Utc).AddTicks(8693), null, "Quinten_Goyette21@gmail.com", false, "Coty", false, null, "Jast", false, null, new DateTime(2024, 9, 20, 12, 4, 26, 603, DateTimeKind.Utc).AddTicks(8474), null, "QUINTEN_GOYETTE21@GMAIL.COM", "QUINTEN_GOYETTE21@GMAIL.COM", "AQAAAAIAAYagAAAAEJCx0o43IjUq0DFnyjUNecUU9c/Iluz+U8QWtmqk3fT7PpJXB0sfDD+fBomd62Bohw==", null, false, "E7EYWZPTSKQWK5AVQYJDWIUBFAUHH4PI", false, "Quinten_Goyette21@gmail.com" },
                    { 107L, 0, 101L, "e8917dd0-d609-4d22-b386-3bf8bb58ec40", new DateTime(2024, 9, 20, 21, 15, 59, 365, DateTimeKind.Utc).AddTicks(7123), null, "Robb.Roberts79@gmail.com", false, "Sarina", false, null, "Fay", false, null, new DateTime(2024, 9, 20, 11, 34, 4, 391, DateTimeKind.Utc).AddTicks(53), null, "ROBB.ROBERTS79@GMAIL.COM", "ROBB.ROBERTS79@GMAIL.COM", "AQAAAAIAAYagAAAAEJCx0o43IjUq0DFnyjUNecUU9c/Iluz+U8QWtmqk3fT7PpJXB0sfDD+fBomd62Bohw==", null, false, "E7EYWZPTSKQWK5AVQYJDWIUBFAUHH4PI", false, "Robb.Roberts79@gmail.com" },
                    { 108L, 0, 100L, "9ebe50e9-3928-4cb2-a0e7-b3e97aeea469", new DateTime(2024, 9, 21, 2, 45, 7, 123, DateTimeKind.Utc).AddTicks(7117), null, "Brice62@hotmail.com", false, "Josephine", true, null, "Pagac", false, null, new DateTime(2024, 9, 20, 3, 55, 56, 470, DateTimeKind.Utc).AddTicks(8927), null, "BRICE62@HOTMAIL.COM", "BRICE62@HOTMAIL.COM", "AQAAAAIAAYagAAAAEJCx0o43IjUq0DFnyjUNecUU9c/Iluz+U8QWtmqk3fT7PpJXB0sfDD+fBomd62Bohw==", null, false, "E7EYWZPTSKQWK5AVQYJDWIUBFAUHH4PI", false, "Brice62@hotmail.com" },
                    { 109L, 0, 100L, "af3b6b35-a958-49f2-9ca8-44e2e0c14ea3", new DateTime(2024, 9, 20, 19, 7, 36, 841, DateTimeKind.Utc).AddTicks(5758), null, "Wellington33@yahoo.com", false, "Jamarcus", true, null, "Cartwright", false, null, new DateTime(2024, 9, 20, 19, 28, 0, 994, DateTimeKind.Utc).AddTicks(7839), null, "WELLINGTON33@YAHOO.COM", "WELLINGTON33@YAHOO.COM", "AQAAAAIAAYagAAAAEJCx0o43IjUq0DFnyjUNecUU9c/Iluz+U8QWtmqk3fT7PpJXB0sfDD+fBomd62Bohw==", null, false, "E7EYWZPTSKQWK5AVQYJDWIUBFAUHH4PI", false, "Wellington33@yahoo.com" }
                });

            migrationBuilder.InsertData(
                table: "client",
                columns: new[] { "clientid", "address1", "address2", "city", "companyid", "createddatetime", "createduserid", "modifieduserid", "name", "note", "state", "updateddatetime", "zip" },
                values: new object[,]
                {
                    { 100L, null, null, null, 100L, new DateTime(2024, 9, 21, 3, 44, 6, 188, DateTimeKind.Utc).AddTicks(7946), null, null, "Maximus Schaefer", "copy Corner Licensed Wooden Pants payment withdrawal Russian Ruble Kentucky framework Optimization bypassing", "Wisconsin", new DateTime(2024, 9, 21, 3, 44, 6, 188, DateTimeKind.Utc).AddTicks(7947), null },
                    { 101L, null, "Suite 877", null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 188, DateTimeKind.Utc).AddTicks(8903), null, null, "Ricky Witting", null, "Arizona", new DateTime(2024, 9, 21, 3, 44, 6, 188, DateTimeKind.Utc).AddTicks(8904), null },
                    { 102L, null, null, null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 188, DateTimeKind.Utc).AddTicks(9185), null, null, "Cleora Prosacco", null, "Ohio", new DateTime(2024, 9, 21, 3, 44, 6, 188, DateTimeKind.Utc).AddTicks(9186), "70602-1333" },
                    { 103L, null, "Apt. 249", "Dareberg", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 188, DateTimeKind.Utc).AddTicks(9366), null, null, "Dennis Upton", "port withdrawal Awesome Rubber Bike architectures Stravenue Graphic Interface Dynamic Centers B2B implement", null, new DateTime(2024, 9, 21, 3, 44, 6, 188, DateTimeKind.Utc).AddTicks(9366), null },
                    { 104L, "024 Will Port", "Apt. 256", null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 188, DateTimeKind.Utc).AddTicks(9536), null, null, "Janelle Anderson", "Point array gold Rubber calculating Underpass New Jersey programming Riel ADP", "Maryland", new DateTime(2024, 9, 21, 3, 44, 6, 188, DateTimeKind.Utc).AddTicks(9537), null },
                    { 105L, "6428 Sonny Trafficway", null, "South Deonbury", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 188, DateTimeKind.Utc).AddTicks(9686), null, null, "Hermann Crona", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 188, DateTimeKind.Utc).AddTicks(9687), "72236" },
                    { 106L, "7553 Murphy Greens", null, null, 100L, new DateTime(2024, 9, 21, 3, 44, 6, 188, DateTimeKind.Utc).AddTicks(9888), null, null, "Odell Wisoky", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 188, DateTimeKind.Utc).AddTicks(9888), null },
                    { 107L, null, null, "Waltonborough", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(37), null, null, "Lera Heaney", "Generic matrices Wooden cross-platform Quetzal connect Canadian Dollar Customizable Practical Fresh Chips Brunei Darussalam", null, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(38), null },
                    { 108L, null, "Suite 427", null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(182), null, null, "Clarabelle Yundt", "IB infrastructures Sleek Soft Pants Supervisor workforce paradigms indexing Electronics & Outdoors Equatorial Guinea dynamic", "New York", new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(183), "19929" },
                    { 109L, null, "Apt. 282", "Lake Eldonfurt", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(373), null, null, "Velda Bernhard", "microchip Savings Account Falls Credit Card Account architect system Security Re-engineered fuchsia GB", "Colorado", new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(373), "30045-5011" },
                    { 110L, null, "Suite 009", null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(544), null, null, "Jalen Kuhic", null, "Arkansas", new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(545), null },
                    { 111L, "71448 Rodriguez Harbors", "Suite 454", "North Florencioburgh", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(723), null, null, "Ludie Beier", "SQL empower TCP Fantastic Dam Bedfordshire Rhode Island Refined Brand bluetooth", null, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(723), "17819-5117" },
                    { 112L, "8640 Bechtelar Mountain", null, null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(872), null, null, "Camille Bartoletti", null, "Alaska", new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(873), null },
                    { 113L, "2019 Thea Garden", null, null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(1055), null, null, "Yvonne Kihn", "Chief Steel target Facilitator out-of-the-box program violet Sports, Beauty & Sports Practical mint green", "Iowa", new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(1055), "54557" },
                    { 114L, "2409 Myrtice Ridges", null, null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(1211), null, null, "Marques Zboncak", "Panama fuchsia Toys Riel Tasty Steel Cheese drive Shoes, Shoes & Health Wooden Tasty USB", null, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(1212), "69772-7712" },
                    { 115L, null, null, "West Tristianville", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(1363), null, null, "Elbert Gulgowski", "infrastructures virtual models Dale generate moratorium port reboot Extended Malta", "Oklahoma", new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(1363), null },
                    { 116L, "941 Mills Bridge", null, null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(1533), null, null, "Juvenal Frami", "matrices Well Georgia hacking back-end Metal Health, Toys & Jewelery Tasty Stravenue withdrawal", "Georgia", new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(1534), null },
                    { 117L, null, "Suite 316", null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(1674), null, null, "Rosie Donnelly", "Clothing & Industrial neural cross-platform Indian Rupee feed neural strategize Investment Account Small Concrete Chair Texas", "Colorado", new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(1674), null },
                    { 118L, "470 Maximus Manors", "Apt. 388", null, 100L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(1823), null, null, "Damien Senger", "COM Response Books maroon Fantastic Granite Ball orange Sleek Concrete Salad Valley invoice Toys, Jewelery & Computers", "Tennessee", new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(1824), null },
                    { 119L, "48625 Dominique Tunnel", null, null, 100L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(1987), null, null, "Oscar Conn", "array Gorgeous Concrete Shirt ivory Gorgeous Steel Shirt eco-centric enterprise payment lime Avon users", null, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(1987), null },
                    { 120L, null, null, null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(2160), null, null, "Rodolfo Ratke", null, "Florida", new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(2160), "03177" },
                    { 121L, null, null, "MacGyverborough", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(2292), null, null, "Iliana Turcotte", "connecting protocol Rial Omani invoice transmitting bypass Avon Forward e-enable yellow", "Alabama", new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(2293), "95302" },
                    { 122L, "11569 Sanford Rue", "Apt. 540", "Lake Antoinetteport", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(2429), null, null, "Ismael Hudson", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(2430), null },
                    { 123L, null, null, "West Jaclynchester", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(2571), null, null, "Keely Mitchell", null, "Colorado", new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(2571), null },
                    { 124L, null, null, null, 100L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(2719), null, null, "Ryder Rice", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(2719), "04408" },
                    { 125L, "4066 Shaylee Street", null, null, 100L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(2859), null, null, "Frank Walsh", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(2859), null },
                    { 126L, "31179 Mills Roads", null, "North Todland", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(3016), null, null, "Antone Spinka", null, "New Jersey", new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(3016), "93987-5140" },
                    { 127L, "1904 Daisha Roads", "Apt. 062", "Lake Alyciafurt", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(3179), null, null, "Leonard Jakubowski", "Borders Gorgeous Concrete Chair Yemeni Rial Credit Card Account firewall Devolved connect Texas Customizable Oregon", "Louisiana", new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(3179), "93340-7989" },
                    { 128L, null, null, null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(3323), null, null, "Gavin Tremblay", "unleash copying PCI CFP Franc Director silver Rustic Steel Chair Granite channels Sleek", null, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(3323), "65115" },
                    { 129L, "31663 Jakob Dam", null, "Sauerberg", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(3464), null, null, "Andrew Wisoky", "Senior demand-driven Customer Texas Cocos (Keeling) Islands transmitting Minnesota Burundi Franc Plastic next-generation", "California", new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(3464), "63673" },
                    { 130L, "056 Wyman Lodge", "Suite 726", "Fritschmouth", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(3590), null, null, "Abdiel Ortiz", null, "Iowa", new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(3590), null },
                    { 131L, "035 Lambert Highway", null, null, 100L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(3745), null, null, "Prudence Barton", "Mount Technician Wyoming deposit paradigms Borders Wisconsin AI leverage front-end", null, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(3745), null },
                    { 132L, "447 Kirlin Villages", "Suite 662", null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(3897), null, null, "Priscilla Strosin", "bandwidth SCSI composite lavender Rapid invoice e-business Soft Ecuador Cambridgeshire", null, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(3898), "28064-8734" },
                    { 133L, null, "Apt. 917", "Hayleestad", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(4046), null, null, "Jazmin Flatley", "Generic withdrawal Spur Interactions Handcrafted Steel Towels concept Strategist connect Idaho Assimilated", "South Dakota", new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(4046), "45857-3585" },
                    { 134L, "771 Cecelia Locks", null, "Alanisfort", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(4190), null, null, "Vern Gleason", "neural-net Refined Concrete Hat teal methodical SSL secondary Incredible Cotton Salad Avon Loop firewall", "Rhode Island", new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(4191), null },
                    { 135L, "44477 Lockman Inlet", "Suite 195", null, 100L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(4360), null, null, "Alvina Zieme", "Arkansas Sri Lanka Rupee black Small Plastic Salad cross-platform Mauritius Rupee driver Codes specifically reserved for testing purposes Uruguay transmitting", "North Carolina", new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(4360), "81988" },
                    { 136L, null, "Suite 139", "Port Nina", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(4515), null, null, "Verlie Thiel", "SDD Brazilian Real Malagasy Ariary extensible black Operations ivory Incredible Wooden Salad utilize COM", "Maine", new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(4516), null },
                    { 137L, null, "Suite 547", "Freidabury", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(4655), null, null, "Amy Franecki", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(4656), null },
                    { 138L, "405 Don Islands", null, "Mabellemouth", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(4818), null, null, "Willard Steuber", null, "North Dakota", new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(4819), null },
                    { 139L, "2500 Gina Centers", null, "Bartbury", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(4999), null, null, "Germaine Reichert", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(4999), "88197" },
                    { 140L, null, "Apt. 163", "Turnerborough", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(5156), null, null, "Ottis Botsford", "revolutionize fresh-thinking solid state system Avon paradigms Virtual synthesize Forint Practical Steel Table", "Idaho", new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(5156), "75734-3945" },
                    { 141L, null, null, "New Elton", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(5297), null, null, "Theodora Prosacco", "Awesome invoice Indian Rupee Awesome Rubber Mouse Communications Frozen Ethiopia Home Loan Account Home & Tools Mall", "Utah", new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(5298), null },
                    { 142L, "030 Lueilwitz River", null, "Bradlyport", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(5459), null, null, "Aron Will", null, "Oregon", new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(5459), "80329-2691" },
                    { 143L, null, null, "North Briana", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(5626), null, null, "Laron Stark", "Internal Jewelery & Sports Ergonomic Unbranded Plastic Table Robust Implementation maximized payment Burkina Faso next-generation", null, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(5626), null },
                    { 144L, null, null, null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(5771), null, null, "Jo Tremblay", "Bedfordshire Garden silver emulation Open-source Bahraini Dinar CSS Product Incredible Cotton Bacon indigo", null, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(5771), "74386" },
                    { 145L, null, "Apt. 010", "North Kelsiburgh", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(5928), null, null, "Elinor Kiehn", "Gorgeous Home, Electronics & Movies Kuwait hacking flexibility Colorado Home copy Facilitator Savings Account", null, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(5929), null },
                    { 146L, null, "Suite 882", null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(6101), null, null, "Destinee Bernhard", null, "Louisiana", new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(6101), "92032" },
                    { 147L, null, "Suite 872", null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(6254), null, null, "Andy Gutmann", null, "Colorado", new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(6254), null },
                    { 148L, "47399 Viviane Falls", "Apt. 488", "West Estafurt", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(6399), null, null, "Hoyt Haag", null, "Texas", new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(6400), null },
                    { 149L, "632 Kathryn Ridges", null, null, 100L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(6557), null, null, "Flavio Gerhold", null, "Louisiana", new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(6557), null },
                    { 150L, null, "Apt. 645", "Darrenburgh", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(6777), null, null, "Sunny Satterfield", null, "Alaska", new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(6777), "31159" },
                    { 151L, null, null, null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(6924), null, null, "Jennyfer Murazik", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(6925), null },
                    { 152L, null, "Suite 844", null, 100L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(7068), null, null, "Clovis Strosin", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(7068), "79514" },
                    { 153L, "93775 Violette Ways", "Apt. 357", null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(7274), null, null, "Roberto Pfeffer", null, "Nevada", new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(7274), "43873-9032" },
                    { 154L, "358 Rau Field", null, null, 100L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(7442), null, null, "Leda Champlin", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(7443), "42651" },
                    { 155L, null, null, null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(7603), null, null, "Kenneth Greenholt", "Rustic Mill Indiana Metal distributed hack Beauty, Jewelery & Outdoors Refined Soft Tuna Fantastic Plastic Table Roads", null, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(7603), "83074-2249" },
                    { 156L, null, "Suite 861", "New Emilioberg", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(7744), null, null, "Verner Schmitt", "Florida Markets redundant Boliviano boliviano payment Small Soft Fish e-business real-time lime methodical", null, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(7744), "29720" },
                    { 157L, "58251 Jacobs Burgs", null, "Elviebury", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(7908), null, null, "Lucas McKenzie", "orchid Lock next generation Florida Florida Centralized parse Buckinghamshire Rustic Concrete Hat mission-critical", null, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(7908), "36903-7948" },
                    { 158L, null, null, "Kianaburgh", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(8052), null, null, "Duncan Ryan", "synergies driver Sleek Metal Chair invoice Minnesota Steel 24/365 Incredible Frozen Shoes Bedfordshire 24/7", "Delaware", new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(8052), null },
                    { 159L, null, null, "North Cesarhaven", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(8196), null, null, "Tevin Abernathy", "withdrawal Concrete Prairie Movies, Shoes & Sports Norway driver Credit Card Account empowering Rapid Avon", "Montana", new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(8196), null },
                    { 160L, null, "Apt. 149", "New Chloe", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(8343), null, null, "Antwon Greenholt", "maroon disintermediate Berkshire white Rwanda Consultant South Carolina Wooden challenge ADP", null, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(8344), "86534" },
                    { 161L, null, null, "Lockmanburgh", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(8498), null, null, "Maurice Kutch", "syndicate Technician Peru SSL Checking Account Parkway Glen Mews Baby Plastic", null, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(8498), null },
                    { 162L, null, null, null, 100L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(8629), null, null, "Lizeth Hermiston", "Handcrafted invoice compelling Rufiyaa Intelligent Cotton Mouse Soft JSON Mali port unleash", null, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(8629), null },
                    { 163L, null, "Suite 860", null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(8769), null, null, "Verla Oberbrunner", "rich utilisation Argentine Peso application Walk Gorgeous Granite Chicken interface invoice payment Marketing", "Michigan", new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(8769), "65200" },
                    { 164L, "286 Torphy Ville", null, "East Doloresside", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(8903), null, null, "Pedro Collins", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(8903), null },
                    { 165L, null, "Apt. 314", "North Bridgetport", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(9098), null, null, "Vinnie Lowe", "California Buckinghamshire Via Electronics Engineer Sleek Gorgeous Cotton Cheese Gorgeous Cotton Chips Rustic Rubber Bacon Intelligent Concrete Pants", "Florida", new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(9098), null },
                    { 166L, null, "Suite 006", null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(9267), null, null, "Delta Huel", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(9268), "89478-7649" },
                    { 167L, "396 Oma Rapid", null, null, 100L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(9427), null, null, "Johanna Williamson", null, "Arkansas", new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(9427), null },
                    { 168L, "106 Waelchi Point", null, "South Saige", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(9566), null, null, "Yessenia Krajcik", null, "Illinois", new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(9566), "60681-8011" },
                    { 169L, null, "Apt. 836", null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(9723), null, null, "Trystan Kuphal", "Avon Frozen bluetooth empower Corners Vermont West Virginia Baby monitor encoding", null, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(9724), null },
                    { 170L, "958 Lucius Throughway", null, null, 100L, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(9843), null, null, "Ethan Cummings", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 189, DateTimeKind.Utc).AddTicks(9844), "91463" },
                    { 171L, null, "Apt. 498", "East Genetown", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(20), null, null, "Oleta Strosin", null, "Alaska", new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(20), null },
                    { 172L, null, "Suite 403", "North Loniechester", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(177), null, null, "Lavern Dach", "initiatives green Personal Loan Account Virtual Plastic Implementation Assistant Personal Loan Account payment Canada", "Tennessee", new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(178), "86391-1514" },
                    { 173L, null, "Suite 525", "O'Keefemouth", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(310), null, null, "Danial Hickle", "United Kingdom digital redundant synergy back-end Afghani context-sensitive technologies Regional dynamic", null, new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(310), null },
                    { 174L, null, "Apt. 754", "Leannonton", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(442), null, null, "Kaylah Mante", null, "Mississippi", new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(442), null },
                    { 175L, "306 Frederik Spurs", null, "Murrayton", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(791), null, null, "Lisa Schneider", null, "South Carolina", new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(791), null },
                    { 176L, null, "Suite 620", null, 100L, new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(948), null, null, "Bernita Altenwerth", "architect primary Unbranded Cotton Salad Executive Fresh Home Loan Account Canyon Ethiopia connect TCP", "Tennessee", new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(948), "96844-4928" },
                    { 177L, null, "Apt. 257", null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(1114), null, null, "Marie Gutmann", null, "Washington", new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(1115), "30496-4303" },
                    { 178L, null, "Apt. 124", "Watsonton", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(1283), null, null, "Eric Strosin", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(1284), null },
                    { 179L, null, "Apt. 608", null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(1475), null, null, "Wilma O'Reilly", "Horizontal lavender monitor Generic Fresh Pants connecting Rustic Fresh Mouse Dalasi backing up empowering Dynamic", "New York", new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(1475), null },
                    { 180L, "0376 Little Extensions", null, "West Vaughnhaven", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(1634), null, null, "Lucile Kohler", null, "Virginia", new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(1634), null },
                    { 181L, "520 Calista Estate", null, "Doyleville", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(1789), null, null, "Lauretta Champlin", "Shore Investment Account recontextualize transition JBOD silver Total Michigan solutions Granite", "Arkansas", new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(1790), "11277" },
                    { 182L, "8034 Rogahn Greens", null, "East Katarina", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(1918), null, null, "Destini Mraz", "deposit Open-source Avon Unbranded Generic Cape Forward Buckinghamshire Gorgeous Saint Pierre and Miquelon", null, new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(1918), "98877" },
                    { 183L, null, null, "Iketon", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(2069), null, null, "Emelia Labadie", "bus transmitter hack Books & Clothing Strategist back-end turquoise online Savings Account Cambridgeshire", "South Carolina", new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(2070), null },
                    { 184L, "40194 Gaston Islands", null, "Caseyfort", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(2223), null, null, "Kip Bogisich", null, "Arkansas", new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(2223), null },
                    { 185L, null, null, "North Maeganhaven", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(2365), null, null, "Cassandra Roob", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(2366), "67000-2784" },
                    { 186L, "4243 Nicolas Trace", "Apt. 644", "New Nettieshire", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(2550), null, null, "Abdullah Bayer", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(2550), null },
                    { 187L, "723 Zemlak Creek", "Apt. 091", null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(2721), null, null, "Quinten McGlynn", null, "Florida", new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(2721), null },
                    { 188L, "0068 Flatley Crescent", null, "New Jocelynton", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(2871), null, null, "Sarah Bauch", null, "Mississippi", new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(2871), null },
                    { 189L, null, null, "North Leannafort", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(3045), null, null, "Franz West", null, "Georgia", new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(3046), null },
                    { 190L, "426 Caroline Common", "Apt. 399", "Zoieton", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(3224), null, null, "Camila Osinski", "Samoa Avon Cyprus Buckinghamshire feed Open-architected Re-engineered Bedfordshire Assurance emulation", null, new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(3225), null },
                    { 191L, null, "Suite 921", null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(3366), null, null, "Pink Hoeger", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(3366), "15259-1850" },
                    { 192L, "508 Pagac River", "Suite 147", "Gulgowskiside", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(3499), null, null, "Reuben Mann", null, "Nebraska", new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(3500), "00170" },
                    { 193L, null, null, "New Wilmaton", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(3631), null, null, "Chandler Christiansen", "Internal payment navigating Tasty Steel Towels Interactions International ADP process improvement transitional programming", null, new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(3631), null },
                    { 194L, null, "Apt. 899", null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(3777), null, null, "Mckenna Breitenberg", "Industrial calculating Adaptive Borders Incredible Granite Shirt Dynamic Intelligent Frozen Ball Response deposit Automotive & Industrial", "Idaho", new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(3777), "98913" },
                    { 195L, null, "Suite 535", "McCulloughshire", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(3937), null, null, "Kian McClure", "Configurable Program Buckinghamshire niches Handcrafted Rubber Chair connecting Movies Ohio Rustic Metal Table Personal Loan Account", null, new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(3937), "23192" },
                    { 196L, "581 Abbigail Highway", null, null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(4080), null, null, "Luis Rempel", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(4081), "26215" },
                    { 197L, null, null, "East Aiden", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(4235), null, null, "Billy Daniel", "Money Market Account generate Technician European Unit of Account 17(E.U.A.-17) indigo Small Concrete Chair drive markets ivory fuchsia", "Nevada", new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(4236), "03800" },
                    { 198L, "91888 Jeramy Via", null, "East Rebecamouth", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(4416), null, null, "Alejandrin O'Conner", "models Berkshire moderator synthesize GB copying salmon sky blue grow Ville", "Maine", new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(4416), "97827" },
                    { 199L, null, null, null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(4561), null, null, "Retta Schumm", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 190, DateTimeKind.Utc).AddTicks(4562), null }
                });

            migrationBuilder.InsertData(
                table: "companypermission",
                columns: new[] { "companypermissionid", "companyid", "permissiontype" },
                values: new object[,]
                {
                    { 100L, 100L, 4 },
                    { 101L, 100L, 13 },
                    { 102L, 100L, 20 },
                    { 103L, 100L, 30 },
                    { 104L, 100L, 40 },
                    { 105L, 100L, 50 },
                    { 106L, 100L, 60 },
                    { 107L, 100L, 70 },
                    { 108L, 100L, 80 },
                    { 109L, 100L, 90 },
                    { 110L, 100L, 95 },
                    { 111L, 100L, 100 },
                    { 112L, 100L, 110 },
                    { 113L, 100L, 120 },
                    { 114L, 100L, 130 },
                    { 115L, 100L, 140 },
                    { 116L, 100L, 150 },
                    { 117L, 100L, 170 },
                    { 118L, 100L, 180 },
                    { 119L, 101L, 4 },
                    { 120L, 101L, 13 },
                    { 121L, 101L, 20 },
                    { 122L, 101L, 30 },
                    { 123L, 101L, 40 },
                    { 124L, 101L, 50 },
                    { 125L, 101L, 60 },
                    { 126L, 101L, 70 },
                    { 127L, 101L, 80 },
                    { 128L, 101L, 90 },
                    { 129L, 101L, 95 },
                    { 130L, 101L, 100 },
                    { 131L, 101L, 110 },
                    { 132L, 101L, 120 },
                    { 133L, 101L, 130 },
                    { 134L, 101L, 140 },
                    { 135L, 101L, 150 },
                    { 136L, 101L, 170 },
                    { 137L, 101L, 180 }
                });

            migrationBuilder.InsertData(
                table: "location",
                columns: new[] { "locationid", "address", "companyid", "createddatetime", "createduserid", "isarchived", "locationtype", "modifieduserid", "name", "phonenumber", "updateddatetime" },
                values: new object[,]
                {
                    { 100L, "7439 Kemmer Flats, Boganborough, Botswana", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 196, DateTimeKind.Utc).AddTicks(9045), null, true, 2, null, "Computers & Games", null, new DateTime(2024, 9, 21, 3, 44, 6, 196, DateTimeKind.Utc).AddTicks(9046) },
                    { 101L, "880 Feil Cliff, East Zion, Papua New Guinea", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(3233), null, true, 2, null, "Toys, Sports & Clothing", "1-511-865-3776 x9397", new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(3233) },
                    { 102L, "098 Nasir Centers, South Makennaland, Guinea-Bissau", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(4196), null, true, 1, null, "Kids", null, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(4196) },
                    { 103L, null, 100L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(4386), null, false, 2, null, "Movies & Games", null, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(4387) },
                    { 104L, "180 Lela Square, New Lavinia, Puerto Rico", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(4545), null, false, 2, null, "Clothing & Music", null, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(4546) },
                    { 105L, null, 100L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(4666), null, false, 1, null, "Kids", "(269) 598-7907 x029", new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(4666) },
                    { 106L, null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(4831), null, false, 2, null, "Garden & Games", "(856) 351-5559", new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(4831) },
                    { 107L, "293 Woodrow Corners, Port Salmatown, Belize", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(4947), null, false, 1, null, "Grocery", "1-668-380-6715", new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(4947) },
                    { 108L, "101 Armando Ridges, Donatoberg, Marshall Islands", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(5049), null, true, 1, null, "Tools", "(687) 536-0023", new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(5049) },
                    { 109L, null, 100L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(5152), null, true, 1, null, "Books", null, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(5152) },
                    { 110L, "27338 Dickens Pine, South Reginald, New Caledonia", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(5259), null, true, 1, null, "Automotive & Kids", "1-238-364-9415 x851", new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(5259) },
                    { 111L, "041 Presley Plain, Port Eulaliafort, Liberia", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(5374), null, true, 1, null, "Kids & Beauty", null, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(5375) },
                    { 112L, null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(5482), null, true, 1, null, "Automotive, Computers & Books", null, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(5482) },
                    { 113L, "868 Virgie Drive, South Kip, Namibia", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(5632), null, true, 1, null, "Shoes, Movies & Industrial", "(499) 367-3699 x43718", new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(5633) },
                    { 114L, null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(5745), null, false, 2, null, "Music", null, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(5746) },
                    { 115L, "671 Kian Ports, Harveyberg, Ghana", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(5844), null, false, 2, null, "Beauty & Electronics", null, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(5844) },
                    { 116L, "51633 Marcella Pines, East Sigmund, Austria", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(5946), null, true, 2, null, "Shoes", null, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(5946) },
                    { 117L, "867 Will Forks, Boehmborough, Seychelles", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(6050), null, true, 1, null, "Industrial", null, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(6050) },
                    { 118L, "89716 Wilkinson Centers, Lake Evangeline, Taiwan", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(6155), null, true, 1, null, "Games", "(708) 254-4873", new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(6156) },
                    { 119L, null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(6254), null, true, 2, null, "Toys, Tools & Baby", "431-546-5682 x60531", new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(6254) },
                    { 120L, "629 Stark Circles, Lake Judyton, Liberia", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(6380), null, false, 1, null, "Music, Movies & Shoes", null, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(6381) },
                    { 121L, null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(6511), null, false, 1, null, "Books & Clothing", "1-744-266-3903", new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(6512) },
                    { 122L, null, 100L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(6608), null, false, 1, null, "Health & Toys", "204-692-9833 x3666", new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(6608) },
                    { 123L, "4423 Josefina View, Littleburgh, Russian Federation", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(6716), null, true, 1, null, "Clothing", null, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(6717) },
                    { 124L, "6458 MacGyver Trail, Port Thoratown, Christmas Island", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(6819), null, false, 1, null, "Automotive & Kids", "(707) 997-0839", new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(6819) },
                    { 125L, null, 100L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(6924), null, false, 2, null, "Music, Shoes & Books", null, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(6924) },
                    { 126L, "550 Santino Cliff, North Brielle, Poland", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(7027), null, false, 1, null, "Shoes, Home & Jewelery", null, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(7027) },
                    { 127L, "423 Geoffrey Way, East Ashlymouth, Spain", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(7140), null, false, 2, null, "Computers", null, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(7141) },
                    { 128L, null, 100L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(7265), null, true, 2, null, "Music, Music & Computers", "202-749-1486 x93496", new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(7265) },
                    { 129L, null, 100L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(7364), null, false, 2, null, "Sports, Home & Garden", null, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(7364) },
                    { 130L, "385 Tromp Burg, Kohlerchester, Panama", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(7471), null, true, 2, null, "Clothing & Computers", null, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(7472) },
                    { 131L, "38138 Gayle Lodge, South Deanna, Denmark", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(7584), null, true, 2, null, "Games & Health", null, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(7585) },
                    { 132L, "7152 Sydni Keys, Newtonville, American Samoa", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(7685), null, true, 2, null, "Outdoors", "(571) 444-2390 x592", new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(7685) },
                    { 133L, null, 100L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(7780), null, false, 2, null, "Books & Games", null, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(7780) },
                    { 134L, "73391 Cassin Isle, Port Merltown, Japan", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(7908), null, false, 2, null, "Industrial & Computers", null, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(7908) },
                    { 135L, null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(8025), null, true, 1, null, "Music, Games & Garden", null, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(8026) },
                    { 136L, null, 100L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(8140), null, false, 2, null, "Sports, Beauty & Grocery", null, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(8140) },
                    { 137L, null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(8243), null, true, 2, null, "Garden & Automotive", "715.807.7515", new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(8243) },
                    { 138L, null, 100L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(8346), null, true, 2, null, "Jewelery, Toys & Computers", "1-795-647-8186 x8761", new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(8346) },
                    { 139L, "036 Damaris Centers, West Coraliefort, British Indian Ocean Territory (Chagos Archipelago)", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(8449), null, false, 1, null, "Garden, Home & Toys", null, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(8450) },
                    { 140L, "1278 Josefina Village, Gleasonmouth, Luxembourg", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(8594), null, true, 2, null, "Books", "(268) 209-9664 x16078", new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(8595) },
                    { 141L, null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(8694), null, true, 2, null, "Grocery", "200-275-0852", new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(8694) },
                    { 142L, "98499 Lemke Ridge, Oscarview, Norway", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(8800), null, true, 1, null, "Games & Garden", null, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(8800) },
                    { 143L, "64005 Kira Spurs, East Jayne, United States of America", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(8912), null, true, 2, null, "Music, Games & Health", null, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(8913) },
                    { 144L, null, 100L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(9022), null, false, 1, null, "Games, Kids & Automotive", "1-304-474-7245", new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(9022) },
                    { 145L, null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(9135), null, false, 2, null, "Jewelery & Clothing", "629-297-6840 x47057", new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(9135) },
                    { 146L, null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(9241), null, true, 2, null, "Electronics & Garden", "(263) 297-2212 x9324", new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(9241) },
                    { 147L, "9664 Marianne Crescent, Lake Anderson, Hong Kong", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(9380), null, true, 1, null, "Clothing", null, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(9381) },
                    { 148L, null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(9480), null, true, 1, null, "Clothing & Outdoors", null, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(9480) },
                    { 149L, "3738 Marquardt Expressway, Port Ivory, Romania", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(9591), null, true, 1, null, "Games & Electronics", null, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(9592) },
                    { 150L, "8002 Hane Point, Kiraport, Libyan Arab Jamahiriya", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(9705), null, false, 2, null, "Kids", null, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(9705) },
                    { 151L, "66958 Deckow Roads, East Andresshire, Bangladesh", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(9798), null, false, 1, null, "Computers, Tools & Computers", null, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(9798) },
                    { 152L, "20747 Meghan Turnpike, Anjalichester, Finland", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(9911), null, false, 1, null, "Electronics & Home", "(797) 966-3091 x24753", new DateTime(2024, 9, 21, 3, 44, 6, 197, DateTimeKind.Utc).AddTicks(9911) },
                    { 153L, null, 100L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(32), null, false, 2, null, "Beauty, Baby & Jewelery", "(693) 677-0608 x409", new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(33) },
                    { 154L, "98319 Koss Fords, West Ottilie, Burkina Faso", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(153), null, false, 1, null, "Electronics", "319.809.8836", new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(154) },
                    { 155L, null, 100L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(249), null, true, 1, null, "Books, Electronics & Garden", null, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(249) },
                    { 156L, "11180 Boehm Rue, Lake Angelicaburgh, Palau", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(358), null, true, 1, null, "Garden & Tools", "(497) 691-4182", new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(358) },
                    { 157L, null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(468), null, false, 2, null, "Books", "1-610-236-2029 x996", new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(469) },
                    { 158L, null, 100L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(568), null, false, 2, null, "Baby, Electronics & Sports", "(488) 783-0495", new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(568) },
                    { 159L, "356 Winston Glen, Jackelinefurt, Peru", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(692), null, false, 1, null, "Jewelery", null, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(692) },
                    { 160L, null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(811), null, true, 2, null, "Automotive", "(589) 964-1719 x8759", new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(812) },
                    { 161L, null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(904), null, true, 2, null, "Clothing & Home", null, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(904) },
                    { 162L, null, 100L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(1005), null, true, 1, null, "Tools, Clothing & Automotive", null, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(1005) },
                    { 163L, null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(1120), null, true, 2, null, "Jewelery, Automotive & Toys", null, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(1120) },
                    { 164L, "213 Morissette Common, Lake Sophie, Kazakhstan", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(1235), null, false, 1, null, "Sports & Toys", null, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(1236) },
                    { 165L, "73667 Moore Inlet, Champlinside, Turkmenistan", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(1337), null, true, 2, null, "Outdoors, Music & Garden", null, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(1338) },
                    { 166L, null, 100L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(1469), null, true, 2, null, "Books, Computers & Tools", null, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(1469) },
                    { 167L, null, 100L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(1571), null, false, 2, null, "Beauty, Games & Outdoors", null, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(1572) },
                    { 168L, null, 100L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(1656), null, true, 2, null, "Games", "410-251-2994", new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(1656) },
                    { 169L, "7132 Daugherty Branch, South Angus, Bahrain", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(1847), null, false, 1, null, "Kids & Games", null, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(1847) },
                    { 170L, null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(1963), null, true, 2, null, "Sports, Movies & Beauty", "709-464-4571", new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(1963) },
                    { 171L, "3233 Dickens Burgs, South Rosaleeport, Guernsey", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(2067), null, true, 2, null, "Computers", "306.378.4067", new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(2068) },
                    { 172L, null, 100L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(2172), null, false, 1, null, "Books, Sports & Clothing", "568.374.4116", new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(2173) },
                    { 173L, "0622 Precious Skyway, Joanieton, Cocos (Keeling) Islands", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(2312), null, true, 2, null, "Automotive", null, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(2313) },
                    { 174L, "64545 Lacey Groves, Port Halieshire, French Guiana", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(2408), null, false, 1, null, "Toys, Jewelery & Grocery", "1-793-623-2563 x568", new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(2408) },
                    { 175L, null, 100L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(2512), null, false, 2, null, "Kids & Clothing", "858-210-7398", new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(2512) },
                    { 176L, null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(2621), null, true, 1, null, "Beauty, Clothing & Sports", null, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(2621) },
                    { 177L, "91984 Brekke Parkway, Marjorymouth, Kyrgyz Republic", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(2743), null, false, 2, null, "Baby & Shoes", "1-393-667-7942", new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(2743) },
                    { 178L, null, 100L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(2850), null, true, 1, null, "Clothing, Beauty & Computers", null, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(2850) },
                    { 179L, null, 100L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(2958), null, true, 2, null, "Automotive & Games", null, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(2959) },
                    { 180L, "399 Bauch Islands, East Twila, Eritrea", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(3087), null, true, 2, null, "Outdoors & Home", null, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(3087) },
                    { 181L, "05771 Nora Unions, Hegmanntown, Syrian Arab Republic", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(4317), null, false, 2, null, "Kids & Games", null, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(4318) },
                    { 182L, null, 100L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(4530), null, true, 1, null, "Movies, Grocery & Garden", null, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(4530) },
                    { 183L, "16575 Frami Plaza, Steuberfort, Ethiopia", 101L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(4684), null, false, 2, null, "Industrial & Automotive", null, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(4684) },
                    { 184L, null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(4821), null, false, 2, null, "Games, Books & Electronics", "1-702-394-3074 x776", new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(4821) },
                    { 185L, "568 Ferry Station, Effertzchester, Dominica", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(4947), null, false, 2, null, "Sports & Kids", "284.525.8712 x03409", new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(4947) },
                    { 186L, "415 Esmeralda Stravenue, Julianneville, Niger", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(5066), null, false, 2, null, "Movies & Books", null, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(5066) },
                    { 187L, "997 Patrick Well, South Leonardo, Kyrgyz Republic", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(5225), null, true, 2, null, "Automotive & Sports", null, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(5226) },
                    { 188L, null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(5334), null, false, 2, null, "Kids", "1-823-732-3467 x05543", new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(5334) },
                    { 189L, "698 Kayla Crescent, Jennieberg, Malaysia", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(5715), null, false, 2, null, "Shoes & Clothing", "1-784-874-1912 x11737", new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(5715) },
                    { 190L, "57053 Blick Shore, Port Isabelberg, Taiwan", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(5871), null, false, 2, null, "Sports", null, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(5871) },
                    { 191L, null, 100L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(5998), null, true, 2, null, "Tools & Movies", "(408) 460-4430 x89547", new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(5998) },
                    { 192L, null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(6126), null, true, 2, null, "Home, Health & Books", "1-790-272-1994 x813", new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(6126) },
                    { 193L, "22522 Leonora Way, West Citlallimouth, French Guiana", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(6263), null, false, 1, null, "Home, Garden & Grocery", "755-715-3790", new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(6263) },
                    { 194L, "79936 Marina Loop, New Ninaville, Angola", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(6403), null, false, 2, null, "Music", null, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(6403) },
                    { 195L, "61436 Von Skyway, Schimmelshire, British Indian Ocean Territory (Chagos Archipelago)", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(6560), null, false, 2, null, "Toys", null, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(6560) },
                    { 196L, "90182 Collins Spring, West Shanel, Antarctica (the territory South of 60 deg S)", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(6665), null, false, 1, null, "Tools & Home", null, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(6665) },
                    { 197L, "75675 Durgan Landing, North Zita, Cameroon", 100L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(6788), null, false, 2, null, "Beauty, Shoes & Garden", "657-394-1695 x60335", new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(6789) },
                    { 198L, null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(6918), null, true, 1, null, "Movies & Clothing", "532.991.5330", new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(6918) },
                    { 199L, null, 101L, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(7062), null, false, 1, null, "Shoes", null, new DateTime(2024, 9, 21, 3, 44, 6, 198, DateTimeKind.Utc).AddTicks(7062) }
                });

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "productid", "companyid", "createddatetime", "createduserid", "description", "isarchived", "modifieduserid", "name", "supplierid", "updateddatetime" },
                values: new object[,]
                {
                    { new Guid("0088f9b5-8d00-329f-0ffb-dcb1f0521836"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(6164), null, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", false, null, "Unbranded Frozen Keyboard", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(6165) },
                    { new Guid("06e63b8c-da85-d5ae-6f59-868bac0ed939"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4481), null, null, true, null, "Handmade Wooden Tuna", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4482) },
                    { new Guid("0c280c52-d3b3-14a4-4445-0743e6bd6bad"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5353), null, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", false, null, "Handcrafted Steel Sausages", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5353) },
                    { new Guid("10a20f76-91d6-677c-07ee-68ff91e550a8"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5715), null, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", false, null, "Ergonomic Fresh Chair", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5716) },
                    { new Guid("1c59edc4-cfc2-6afd-03af-fc90c84142d6"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5476), null, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", true, null, "Refined Metal Chips", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5476) },
                    { new Guid("25631cdd-d2fb-3fb0-0426-227a89759f14"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(6120), null, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", false, null, "Handmade Cotton Towels", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(6120) },
                    { new Guid("36d50a52-29c3-9a3f-716c-f9e617313c18"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5803), null, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", false, null, "Sleek Metal Soap", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5803) },
                    { new Guid("3b72bc0b-b71e-d78c-aba8-8434e7a84032"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4426), null, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", true, null, "Fantastic Soft Shirt", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4427) },
                    { new Guid("3f1bc061-c4e3-08db-8df9-b4f23a722270"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5445), null, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", false, null, "Tasty Frozen Chips", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5445) },
                    { new Guid("415ce7b1-6dfc-335a-f56e-8c0c3df7f6f7"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5307), null, null, true, null, "Licensed Wooden Pizza", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5307) },
                    { new Guid("464e8df9-4bc5-34f1-637f-8d261d4013a6"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5975), null, null, false, null, "Ergonomic Soft Shirt", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5976) },
                    { new Guid("47ac6a72-f771-2cdf-3f22-ddc5f7361084"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4587), null, null, false, null, "Handmade Fresh Sausages", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4587) },
                    { new Guid("4c4ac2d0-6231-1adf-d77d-f1973bad1b3d"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5574), null, null, false, null, "Unbranded Concrete Table", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5575) },
                    { new Guid("53268d03-8513-d5f8-d47b-afe4398f3612"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5842), null, null, true, null, "Generic Metal Salad", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5843) },
                    { new Guid("55359340-5867-a3d3-0af4-6165fe9df831"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5053), null, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", false, null, "Incredible Plastic Chair", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5053) },
                    { new Guid("56bb4b5a-3797-5621-7b87-ca8423f1930f"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5490), null, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", false, null, "Tasty Steel Sausages", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5490) },
                    { new Guid("5e5a79a6-5d5b-14ad-bed5-21214263193b"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5731), null, null, false, null, "Tasty Plastic Chair", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5731) },
                    { new Guid("63082b39-7e5e-9f05-1a0e-b6aae0a659b9"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4571), null, "The Football Is Good For Training And Recreational Purposes", false, null, "Unbranded Wooden Shoes", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4571) },
                    { new Guid("653dd38d-d89c-5cf6-6cf3-55ee2623679a"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4280), null, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", false, null, "Tasty Plastic Pants", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4281) },
                    { new Guid("69970e40-b67f-b97d-0775-b4c7805aaf62"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4921), null, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", true, null, "Small Concrete Chair", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4921) },
                    { new Guid("6fdda05d-cb66-3d67-33f3-b0980375b744"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4977), null, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", false, null, "Generic Soft Computer", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4977) },
                    { new Guid("778660c0-4365-e8fe-2c90-c5e241030d9b"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4402), null, null, true, null, "Licensed Concrete Chicken", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4402) },
                    { new Guid("77be7c73-be33-6d2f-f56d-c1a8297aacc6"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4903), null, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", false, null, "Intelligent Steel Towels", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4904) },
                    { new Guid("8116f650-b121-7f5a-6d20-3c185005c1e1"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5384), null, null, true, null, "Incredible Cotton Chicken", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5384) },
                    { new Guid("823444f1-24bf-ef69-3041-1b4674ce7d96"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5904), null, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", true, null, "Ergonomic Cotton Bacon", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5904) },
                    { new Guid("8913461a-677a-a518-8de2-bcf24d05f61e"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5322), null, null, false, null, "Fantastic Soft Ball", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5322) },
                    { new Guid("9248519f-5ea8-24f5-929b-f1bbf2c3520d"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5889), null, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", false, null, "Awesome Cotton Cheese", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5889) },
                    { new Guid("95b11b65-4dde-b62c-2fb9-3d14ffc1411b"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(6106), null, "Boston's most advanced compression wear technology increases muscle oxygenation, stabilizes active muscles", true, null, "Awesome Concrete Shirt", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(6106) },
                    { new Guid("9e866982-ddaf-c778-9360-8ebf229081c2"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5223), null, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", true, null, "Handmade Granite Computer", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5224) },
                    { new Guid("a4f8634b-c174-3b87-8a9a-468e41aa911f"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5276), null, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", true, null, "Fantastic Rubber Shoes", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5276) },
                    { new Guid("a9f31e8f-b3e7-7f8e-a142-20ff29b52eb0"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4818), null, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", true, null, "Generic Steel Computer", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4818) },
                    { new Guid("aba244f4-1a51-fc6a-6926-ef714384407d"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(6179), null, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", false, null, "Rustic Rubber Sausages", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(6179) },
                    { new Guid("b07224e6-6de1-078e-77db-8cb78a526581"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5874), null, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", false, null, "Generic Fresh Soap", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5874) },
                    { new Guid("b1da89d7-4cb2-f646-d3a5-c28a78260c59"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5558), null, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", false, null, "Ergonomic Concrete Bacon", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5558) },
                    { new Guid("b38145a9-41bf-a8d8-610a-690623410c6f"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4715), null, null, true, null, "Small Wooden Sausages", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4715) },
                    { new Guid("b5cd263b-d611-4b13-b83b-847113df84fe"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4765), null, null, true, null, "Intelligent Frozen Fish", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4765) },
                    { new Guid("b970dfc8-734a-f701-d40b-49fd87bde072"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(6194), null, null, true, null, "Unbranded Granite Shirt", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(6194) },
                    { new Guid("bed55f35-76d0-3d0e-93e2-2747aa7b0674"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5339), null, "The Football Is Good For Training And Recreational Purposes", false, null, "Fantastic Metal Bike", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5339) },
                    { new Guid("c48c9793-833f-8426-c47d-69e531df0f82"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5368), null, null, false, null, "Rustic Steel Sausages", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5368) },
                    { new Guid("c6ce3b76-1246-5a86-5600-690a2e51c7cf"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5759), null, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", true, null, "Tasty Rubber Keyboard", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5760) },
                    { new Guid("cc2d75b7-e516-86cb-0262-87954e295a53"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4524), null, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", false, null, "Sleek Frozen Cheese", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4524) },
                    { new Guid("d57526e4-1bc4-fa1d-3281-6b6bbf0cda6c"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5655), null, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", false, null, "Gorgeous Metal Chicken", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5655) },
                    { new Guid("dc9f5d08-82c5-d454-3a82-b71fa1d187f5"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4835), null, null, true, null, "Gorgeous Metal Fish", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4836) },
                    { new Guid("defefb95-283b-5d7f-bb78-7c2fe699c46a"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(6329), null, null, false, null, "Unbranded Metal Table", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(6329) },
                    { new Guid("e6a3f35b-0d6c-ad52-fa2f-172109ac90ba"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5745), null, null, true, null, "Sleek Plastic Gloves", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5745) },
                    { new Guid("e73d84af-3b2d-c96a-3ac8-684c8708d73d"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(6347), null, null, false, null, "Fantastic Rubber Soap", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(6347) },
                    { new Guid("eca49e87-c298-2ad4-d72f-38356213b9d2"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4661), null, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", false, null, "Generic Rubber Shoes", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4662) },
                    { new Guid("eedcb6da-fa1d-4f88-ad31-d7c11fd72735"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5195), null, null, false, null, "Handcrafted Plastic Cheese", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5195) },
                    { new Guid("f1901298-0eb6-64f9-5886-1ec21048e162"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5066), null, null, true, null, "Tasty Concrete Gloves", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5067) },
                    { new Guid("f92a45cb-f494-f2c7-c94c-9d089374b925"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(6009), null, null, false, null, "Licensed Steel Sausages", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(6009) },
                    { new Guid("fd7b3406-a393-8f4e-0263-7980231e9f06"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5292), null, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", true, null, "Sleek Granite Towels", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5292) },
                    { new Guid("ffc1acd4-31e8-f885-8e6e-92ed752471ec"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4887), null, null, false, null, "Practical Granite Shirt", null, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4887) }
                });

            migrationBuilder.InsertData(
                table: "supplier",
                columns: new[] { "supplierid", "address", "companyid", "contact", "createddatetime", "createduserid", "email", "isarchived", "modifieduserid", "name", "phonenumber", "updateddatetime" },
                values: new object[,]
                {
                    { 100L, null, 100L, null, new DateTime(2024, 9, 21, 3, 44, 6, 191, DateTimeKind.Utc).AddTicks(7844), null, null, true, null, "Garden & Movies", "540.382.3353 x41121", new DateTime(2024, 9, 21, 3, 44, 6, 191, DateTimeKind.Utc).AddTicks(7845) },
                    { 101L, null, 101L, "Eunice Rippin", new DateTime(2024, 9, 21, 3, 44, 6, 191, DateTimeKind.Utc).AddTicks(9837), null, null, false, null, "Tools", "956.809.2645", new DateTime(2024, 9, 21, 3, 44, 6, 191, DateTimeKind.Utc).AddTicks(9838) },
                    { 102L, null, 100L, null, new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(198), null, "Darrel78@yahoo.com", false, null, "Games", "1-841-600-4120 x23052", new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(198) },
                    { 103L, "775 Alfonso Run, Rockyville, Congo", 100L, null, new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(428), null, "Dixie99@gmail.com", false, null, "Books & Industrial", null, new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(428) },
                    { 104L, null, 100L, "Vito Kuhlman", new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(818), null, null, true, null, "Clothing", null, new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(819) },
                    { 105L, "551 Zboncak Circle, Kiraton, Ghana", 100L, null, new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(1342), null, null, true, null, "Books", "(746) 878-5738", new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(1342) },
                    { 106L, "92971 Renner Valleys, West Lew, Grenada", 101L, "Giovani Aufderhar", new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(1643), null, "Maximilian.Hoppe43@yahoo.com", true, null, "Clothing & Outdoors", null, new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(1643) },
                    { 107L, null, 100L, "Katarina Howell", new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(1861), null, "Willis_Schoen24@yahoo.com", false, null, "Health & Grocery", null, new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(1862) },
                    { 108L, "69028 Hillard Viaduct, West Elfrieda, Suriname", 100L, "Carlie Kuhic", new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(2036), null, null, false, null, "Outdoors, Beauty & Clothing", null, new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(2037) },
                    { 109L, "6802 Sunny Shoal, Uniquemouth, Martinique", 101L, null, new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(2235), null, "Elbert53@gmail.com", false, null, "Music & Garden", "885.585.6719 x636", new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(2235) },
                    { 110L, "73886 Richmond Mountain, Jerrellfort, Nigeria", 101L, "Cordia Witting", new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(2410), null, null, false, null, "Beauty & Health", null, new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(2411) },
                    { 111L, "7271 Ratke Road, New Eduardo, Turkey", 101L, null, new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(2570), null, null, true, null, "Kids", "281-675-5809 x7043", new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(2570) },
                    { 112L, "6428 Jacobson Islands, Ornmouth, Myanmar", 100L, "Wendy Crona", new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(2757), null, "Cathy.Daugherty@gmail.com", true, null, "Games", "1-400-935-0162 x6198", new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(2757) },
                    { 113L, null, 100L, null, new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(2900), null, "Hoyt1@hotmail.com", true, null, "Toys, Beauty & Music", null, new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(2900) },
                    { 114L, "11287 Caleigh Junction, Port Dianaville, Paraguay", 101L, null, new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(3064), null, "Marty69@hotmail.com", true, null, "Garden, Beauty & Automotive", "820.230.0322 x145", new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(3064) },
                    { 115L, null, 100L, null, new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(3232), null, null, false, null, "Music & Electronics", null, new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(3232) },
                    { 116L, null, 100L, "Antoinette Gleason", new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(3384), null, "Celine.Wisoky69@gmail.com", false, null, "Health & Toys", null, new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(3384) },
                    { 117L, null, 100L, "Prince Cormier", new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(3536), null, null, true, null, "Garden & Jewelery", "1-762-348-2188 x2471", new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(3536) },
                    { 118L, null, 100L, null, new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(3751), null, "Richard69@yahoo.com", false, null, "Outdoors", null, new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(3751) },
                    { 119L, "8132 Rozella Trail, Catherineburgh, Botswana", 100L, null, new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(3889), null, null, false, null, "Electronics", "(752) 270-7576 x115", new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(3889) },
                    { 120L, null, 100L, null, new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(4023), null, null, true, null, "Clothing, Clothing & Electronics", "1-316-283-5855 x487", new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(4024) },
                    { 121L, null, 101L, null, new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(4182), null, null, false, null, "Games & Industrial", null, new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(4182) },
                    { 122L, null, 100L, null, new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(4329), null, null, true, null, "Outdoors & Shoes", "591-773-6969 x0011", new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(4329) },
                    { 123L, "22289 Hegmann Corners, Jairostad, Cameroon", 101L, "Rusty Heaney", new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(4476), null, "Alba35@gmail.com", false, null, "Music, Baby & Garden", "370.298.0842", new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(4476) },
                    { 124L, null, 101L, null, new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(4663), null, "Janick64@hotmail.com", true, null, "Outdoors, Outdoors & Outdoors", "817.953.5720", new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(4664) },
                    { 125L, null, 100L, "Ted West", new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(4809), null, "Linwood_Price@yahoo.com", true, null, "Shoes & Electronics", "729-229-0211", new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(4809) },
                    { 126L, null, 100L, "Iva Dickens", new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(4950), null, null, true, null, "Garden & Clothing", "1-445-288-2328 x59627", new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(4951) },
                    { 127L, null, 101L, null, new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(5117), null, null, false, null, "Electronics, Tools & Tools", "(621) 306-6274 x66488", new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(5117) },
                    { 128L, null, 101L, "Ludie Olson", new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(5281), null, null, false, null, "Movies", null, new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(5281) },
                    { 129L, "780 Osinski Lock, Koepptown, Jamaica", 100L, "Loraine Rodriguez", new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(5478), null, null, true, null, "Books, Health & Outdoors", "(886) 702-1990 x778", new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(5478) },
                    { 130L, "00036 Thaddeus Island, South Jevon, Syrian Arab Republic", 100L, null, new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(5644), null, "Earl_Von63@gmail.com", true, null, "Tools, Games & Toys", null, new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(5644) },
                    { 131L, null, 101L, "Danial Jacobson", new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(5804), null, null, false, null, "Sports, Beauty & Clothing", null, new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(5804) },
                    { 132L, "98207 Turcotte Unions, Mannhaven, Liechtenstein", 100L, null, new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(5980), null, "Frances_McKenzie@gmail.com", false, null, "Electronics & Baby", "1-541-386-9744 x52079", new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(5981) },
                    { 133L, null, 101L, "Fanny Schamberger", new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(6118), null, "Laney.McCullough90@hotmail.com", false, null, "Home & Outdoors", "(796) 858-6326 x325", new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(6119) },
                    { 134L, "06160 Koch Lakes, South Dandre, Cape Verde", 101L, null, new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(6272), null, null, false, null, "Home & Music", null, new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(6272) },
                    { 135L, null, 101L, "Maximilian Bashirian", new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(6445), null, "Kristoffer_Macejkovic61@yahoo.com", true, null, "Garden", "870.824.2908", new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(6445) },
                    { 136L, "91373 Kozey Via, Eleanorashire, Jamaica", 101L, null, new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(6590), null, "Norval80@gmail.com", true, null, "Beauty", null, new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(6590) },
                    { 137L, "7030 Cassandre Alley, West Jairo, Guyana", 101L, null, new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(6729), null, null, false, null, "Music, Grocery & Movies", null, new DateTime(2024, 9, 21, 3, 44, 6, 192, DateTimeKind.Utc).AddTicks(6729) },
                    { 138L, null, 101L, null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(2744), null, null, true, null, "Jewelery", "(773) 201-1204", new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(2745) },
                    { 139L, "176 Corbin Viaduct, New Jada, Norway", 101L, "Talia Spinka", new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(3279), null, "Hilario_Bradtke21@gmail.com", true, null, "Automotive, Beauty & Health", null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(3279) },
                    { 140L, null, 100L, null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(3569), null, "Amara.Bogan66@yahoo.com", false, null, "Garden, Outdoors & Clothing", null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(3570) },
                    { 141L, null, 101L, "Raphael Pfannerstill", new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(3773), null, "Kory32@yahoo.com", false, null, "Baby, Automotive & Automotive", "369.224.2244 x3036", new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(3773) },
                    { 142L, "0049 Zemlak Islands, Port Dewayne, Swaziland", 101L, "Felicita Wisoky", new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(3987), null, null, true, null, "Beauty", null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(3988) },
                    { 143L, null, 100L, "Bonita Nolan", new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(4182), null, "Vergie_Runte@hotmail.com", false, null, "Games & Kids", null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(4182) },
                    { 144L, null, 101L, "Kari Hammes", new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(4400), null, null, false, null, "Outdoors & Computers", null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(4401) },
                    { 145L, "61034 Padberg Cape, North Jarrethaven, Cayman Islands", 100L, "Dion McGlynn", new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(4844), null, "Jordan76@yahoo.com", true, null, "Kids & Grocery", "951.887.8321", new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(4845) },
                    { 146L, "28395 Franz Plain, South Yolandafurt, Maldives", 101L, "Fannie Schuster", new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(5033), null, null, false, null, "Automotive, Outdoors & Beauty", "356.945.3921 x8402", new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(5033) },
                    { 147L, "11374 Brendon Curve, Port Anita, Somalia", 101L, "August Sporer", new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(5219), null, "Arnold.Wolf86@hotmail.com", true, null, "Computers, Health & Home", null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(5220) },
                    { 148L, "24963 Montana River, Arielleland, Mayotte", 101L, null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(5402), null, null, false, null, "Grocery", null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(5402) },
                    { 149L, null, 101L, "Reba Hahn", new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(5676), null, "Rahul_Stroman@gmail.com", false, null, "Books", null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(5677) },
                    { 150L, null, 100L, null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(5940), null, null, true, null, "Movies", "1-716-378-5970 x81551", new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(5940) },
                    { 151L, null, 101L, null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(6112), null, "Winnifred69@hotmail.com", true, null, "Computers & Clothing", "480-769-6585", new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(6113) },
                    { 152L, null, 101L, "Porter Hane", new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(6311), null, "Keith_Lakin@hotmail.com", false, null, "Health & Shoes", null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(6312) },
                    { 153L, "4173 Mose Hills, Frederickport, Ethiopia", 101L, null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(6504), null, null, true, null, "Home", null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(6505) },
                    { 154L, "26965 Meda Loop, Abagailview, Saint Pierre and Miquelon", 101L, "Sibyl Klocko", new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(6656), null, null, false, null, "Electronics & Outdoors", "(230) 656-7391", new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(6656) },
                    { 155L, null, 100L, "Nolan Walker", new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(6879), null, "Adonis58@gmail.com", true, null, "Sports, Toys & Clothing", null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(6879) },
                    { 156L, "80706 Swaniawski Squares, North Magnushaven, Argentina", 100L, "Billie Corwin", new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(7063), null, "Erna.Fritsch@yahoo.com", false, null, "Computers & Grocery", null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(7063) },
                    { 157L, "3570 Tromp Rapid, Schulistberg, Cote d'Ivoire", 100L, "Gus Leannon", new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(7249), null, null, true, null, "Music & Home", null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(7250) },
                    { 158L, "56089 Breitenberg Camp, East Krystina, Central African Republic", 101L, null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(7395), null, null, true, null, "Garden, Kids & Home", null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(7395) },
                    { 159L, "4097 Winston Loop, Bartellfort, Senegal", 100L, null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(7557), null, null, false, null, "Clothing, Shoes & Tools", null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(7558) },
                    { 160L, null, 101L, "Camryn Rolfson", new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(7710), null, "Marion.Schneider@yahoo.com", true, null, "Games, Home & Home", null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(7710) },
                    { 161L, "532 Pfeffer Island, Mikaylamouth, Philippines", 100L, "Caleigh Tromp", new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(7891), null, null, true, null, "Shoes & Beauty", null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(7891) },
                    { 162L, null, 100L, null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(8041), null, "Felipa23@yahoo.com", true, null, "Books & Beauty", null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(8041) },
                    { 163L, null, 101L, null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(8195), null, null, false, null, "Books & Garden", null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(8195) },
                    { 164L, "2221 Prohaska Ridge, West Gilberto, American Samoa", 100L, null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(8380), null, "Virgil.Sauer44@gmail.com", false, null, "Grocery, Home & Toys", null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(8380) },
                    { 165L, null, 101L, "Solon Emmerich", new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(8545), null, null, true, null, "Grocery", null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(8545) },
                    { 166L, "732 Yvonne Lake, Lake Donatoborough, New Zealand", 101L, "Tiana Lind", new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(8720), null, "Christine.Breitenberg88@gmail.com", true, null, "Books, Jewelery & Beauty", "776-617-8501 x5613", new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(8720) },
                    { 167L, null, 100L, null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(8899), null, "Porter_Brakus78@yahoo.com", true, null, "Kids", "(694) 655-8887 x8115", new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(8899) },
                    { 168L, null, 100L, null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(9047), null, "Clarissa_Heidenreich@gmail.com", false, null, "Garden & Tools", "220-793-7818 x659", new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(9048) },
                    { 169L, null, 100L, null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(9220), null, null, false, null, "Movies", "409.944.8640", new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(9221) },
                    { 170L, null, 101L, null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(9422), null, "Ralph60@gmail.com", true, null, "Toys", null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(9422) },
                    { 171L, "5402 Hardy Circles, West Alexaneview, Macao", 100L, null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(9562), null, "Omari.Hintz@yahoo.com", false, null, "Beauty", "548.830.1619 x7618", new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(9562) },
                    { 172L, null, 101L, null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(9754), null, null, false, null, "Garden, Sports & Industrial", null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(9754) },
                    { 173L, "59593 Pollich Well, Feeneyhaven, Pakistan", 100L, null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(9927), null, null, true, null, "Grocery, Outdoors & Home", null, new DateTime(2024, 9, 21, 3, 44, 6, 193, DateTimeKind.Utc).AddTicks(9928) },
                    { 174L, "254 Easton Bypass, Shainaton, Bangladesh", 100L, "Margret Hoeger", new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(69), null, "Alayna.Larkin4@yahoo.com", true, null, "Sports & Health", null, new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(70) },
                    { 175L, null, 100L, "Nicholas O'Reilly", new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(244), null, null, true, null, "Electronics", null, new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(244) },
                    { 176L, "63873 Carmel Haven, Orlomouth, Italy", 101L, "Cameron Welch", new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(398), null, null, false, null, "Toys, Health & Baby", "1-470-538-1760 x610", new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(398) },
                    { 177L, null, 101L, "Bulah Stehr", new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(560), null, "Samara25@yahoo.com", true, null, "Home & Automotive", null, new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(561) },
                    { 178L, "1816 Elda Street, Lake Vince, Denmark", 101L, null, new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(742), null, null, true, null, "Grocery, Computers & Automotive", "768-644-9747", new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(742) },
                    { 179L, "46787 Corbin Valley, Reichertburgh, Burundi", 101L, null, new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(912), null, null, false, null, "Home, Outdoors & Computers", null, new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(912) },
                    { 180L, "5762 Kunde Throughway, North Amyaland, Equatorial Guinea", 101L, "Ellie Lubowitz", new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(1068), null, "Newton_Hoeger38@yahoo.com", false, null, "Books, Movies & Games", null, new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(1068) },
                    { 181L, "592 Pagac Inlet, Abelborough, Qatar", 101L, "Arlo Weissnat", new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(1266), null, "Donavon_Champlin16@yahoo.com", true, null, "Home", null, new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(1266) },
                    { 182L, null, 101L, null, new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(1416), null, null, true, null, "Grocery", null, new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(1416) },
                    { 183L, null, 101L, "Brandon Skiles", new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(1566), null, null, false, null, "Automotive & Computers", null, new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(1566) },
                    { 184L, "12826 Cremin Passage, Douglasberg, Greece", 101L, null, new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(1732), null, "Kendall.Roob@hotmail.com", true, null, "Home, Outdoors & Music", null, new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(1732) },
                    { 185L, null, 100L, null, new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(1891), null, null, true, null, "Music", "(374) 347-8844 x7272", new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(1892) },
                    { 186L, "018 Vladimir Islands, Georgefurt, Chile", 101L, "Justus Gutmann", new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(2031), null, "Robb47@gmail.com", true, null, "Music, Books & Automotive", null, new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(2031) },
                    { 187L, "2379 Makenna Knolls, East Robbfurt, Yemen", 100L, null, new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(2202), null, null, true, null, "Health, Garden & Music", null, new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(2202) },
                    { 188L, null, 100L, null, new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(2354), null, null, false, null, "Sports & Baby", null, new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(2354) },
                    { 189L, null, 100L, null, new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(8075), null, "Adam99@yahoo.com", false, null, "Industrial, Beauty & Baby", "651.633.3815 x7608", new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(8076) },
                    { 190L, null, 101L, null, new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(8717), null, null, false, null, "Industrial & Shoes", "(640) 992-4630 x91116", new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(8717) },
                    { 191L, "448 Cathrine Views, D'Amoreshire, Tonga", 101L, null, new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(8937), null, "Louvenia_Lindgren24@gmail.com", false, null, "Outdoors, Toys & Tools", "1-930-421-6417 x40530", new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(8937) },
                    { 192L, "60752 Chesley Walk, Lake Mariam, Nauru", 101L, null, new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(9201), null, null, false, null, "Outdoors", "582-893-6307 x66212", new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(9202) },
                    { 193L, null, 101L, "Tyshawn Zulauf", new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(9401), null, "Augustus70@hotmail.com", true, null, "Baby & Outdoors", null, new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(9402) },
                    { 194L, "5668 Botsford Brook, Elwynbury, French Southern Territories", 100L, null, new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(9576), null, "Dangelo52@yahoo.com", true, null, "Clothing", null, new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(9576) },
                    { 195L, "59978 Paolo Fort, North Fernestad, Grenada", 101L, "Newton Mante", new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(9768), null, null, true, null, "Shoes & Automotive", null, new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(9768) },
                    { 196L, "06853 Luettgen Estate, Terryhaven, France", 100L, "Irma Windler", new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(9950), null, null, false, null, "Music", "760-711-1228 x615", new DateTime(2024, 9, 21, 3, 44, 6, 194, DateTimeKind.Utc).AddTicks(9950) },
                    { 197L, null, 100L, "Gabriella Beatty", new DateTime(2024, 9, 21, 3, 44, 6, 195, DateTimeKind.Utc).AddTicks(108), null, "Deontae.Hartmann69@hotmail.com", false, null, "Automotive & Kids", "911.916.4819", new DateTime(2024, 9, 21, 3, 44, 6, 195, DateTimeKind.Utc).AddTicks(109) },
                    { 198L, null, 100L, "Federico Gulgowski", new DateTime(2024, 9, 21, 3, 44, 6, 195, DateTimeKind.Utc).AddTicks(511), null, null, true, null, "Baby & Tools", "(936) 220-1966 x623", new DateTime(2024, 9, 21, 3, 44, 6, 195, DateTimeKind.Utc).AddTicks(513) },
                    { 199L, null, 101L, null, new DateTime(2024, 9, 21, 3, 44, 6, 195, DateTimeKind.Utc).AddTicks(1104), null, null, true, null, "Jewelery", null, new DateTime(2024, 9, 21, 3, 44, 6, 195, DateTimeKind.Utc).AddTicks(1105) }
                });

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "productid", "companyid", "createddatetime", "createduserid", "description", "isarchived", "modifieduserid", "name", "supplierid", "updateddatetime" },
                values: new object[,]
                {
                    { new Guid("04b90168-323c-baca-f337-527c31e1039c"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(6040), null, null, true, null, "Handcrafted Rubber Towels", 198L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(6040) },
                    { new Guid("09507115-1175-2425-692f-bd9b9eb755e0"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4697), null, null, true, null, "Fantastic Concrete Gloves", 136L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4698) },
                    { new Guid("1a14120b-e568-5fba-0e83-30b0bf29f0a4"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4368), null, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", false, null, "Incredible Concrete Shirt", 125L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4368) },
                    { new Guid("23b45705-1d18-3ae3-b8ec-135857a817d6"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4605), null, null, false, null, "Handmade Frozen Bike", 169L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4605) },
                    { new Guid("2839f2e8-1a35-f860-86b6-19c1a1d27788"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5919), null, null, false, null, "Fantastic Granite Soap", 157L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5919) },
                    { new Guid("2d0dd14a-51cb-c9f8-a85f-076014ff01e1"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(6287), null, null, true, null, "Licensed Wooden Towels", 169L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(6288) },
                    { new Guid("2dc86bbc-af1d-e015-596e-97268a1f435e"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5209), null, null, true, null, "Sleek Cotton Sausages", 102L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5209) },
                    { new Guid("306b3cb9-ec5d-fea6-fcf7-e291db2911cf"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5149), null, "The Football Is Good For Training And Recreational Purposes", true, null, "Tasty Steel Chair", 177L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5150) },
                    { new Guid("32db338c-8773-4c58-6d4f-b41193e8d10d"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(6272), null, null, false, null, "Gorgeous Plastic Bacon", 128L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(6273) },
                    { new Guid("404ac733-b74b-3fde-b462-0c01c351b89a"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5460), null, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", false, null, "Rustic Soft Chair", 150L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5460) },
                    { new Guid("44ec8c13-b9cd-70ba-5260-51a38ad67a96"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5787), null, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", false, null, "Fantastic Concrete Shoes", 134L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5787) },
                    { new Guid("4b40f938-1581-a32e-a5c0-9c18465de601"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5858), null, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", false, null, "Gorgeous Rubber Chicken", 156L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5858) },
                    { new Guid("5678d654-4e49-7902-3c3d-e751477748a8"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5180), null, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", false, null, "Small Metal Bike", 124L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5181) },
                    { new Guid("5ac17955-22ae-3b7d-3954-a3096d334f67"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5008), null, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", true, null, "Small Steel Keyboard", 133L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5008) },
                    { new Guid("5fb73477-b1c7-65f7-af3a-35c199cdbe86"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5038), null, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", true, null, "Refined Concrete Soap", 120L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5038) },
                    { new Guid("63f0befa-3aeb-463c-7289-3af9421eb2ee"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(6257), null, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", false, null, "Incredible Steel Gloves", 181L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(6258) },
                    { new Guid("691eb2d6-314c-53c3-3aab-b72e34dd96cf"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5698), null, null, false, null, "Small Plastic Pizza", 185L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5698) },
                    { new Guid("6c357dbb-56f6-bcf7-5ccb-cba371a9ede4"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4732), null, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", true, null, "Handmade Granite Shirt", 123L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4732) },
                    { new Guid("6d0bccb9-5439-b035-cfe2-8afba9a143e2"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5590), null, "The Football Is Good For Training And Recreational Purposes", true, null, "Handcrafted Metal Towels", 182L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5591) },
                    { new Guid("748d4380-0e91-9d9c-2e78-95d4ac9d28bb"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5606), null, null, true, null, "Generic Soft Chips", 123L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5606) },
                    { new Guid("7b9a9dca-645d-654a-4300-bd684865463d"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(6315), null, "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart", true, null, "Licensed Granite Mouse", 114L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(6315) },
                    { new Guid("809094ca-1942-62ca-f728-b54a1ea2febc"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(6301), null, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", true, null, "Licensed Steel Towels", 169L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(6301) },
                    { new Guid("8197f14e-f5ce-88b2-4d80-4746e0a7f2b5"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(6056), null, "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016", false, null, "Awesome Soft Bike", 106L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(6056) },
                    { new Guid("86195222-ff46-1d33-bd92-7ca6d125cdd6"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4502), null, null, true, null, "Rustic Concrete Bacon", 140L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4503) },
                    { new Guid("88672cbf-752f-a74e-d6ce-4543b254e568"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5133), null, null, false, null, "Gorgeous Plastic Towels", 196L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5134) },
                    { new Guid("889eb714-3e8c-1e2c-54ed-40323924419f"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(6070), null, "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit", true, null, "Incredible Wooden Soap", 197L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(6070) },
                    { new Guid("8c380469-da20-2c57-b71d-959d5622a9ca"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4680), null, "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J", false, null, "Unbranded Rubber Fish", 126L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4681) },
                    { new Guid("8d4ac50d-6d42-2869-62dd-4cb30cbf2a7f"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4865), null, "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive", true, null, "Incredible Wooden Bike", 184L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4866) },
                    { new Guid("8f91b4b2-96ed-bb76-508c-a442768d3c12"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(6396), null, null, false, null, "Licensed Frozen Towels", 115L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(6396) },
                    { new Guid("917b20df-5c5c-9cb6-9bb9-11a73c3dd3ed"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5620), null, null, false, null, "Rustic Rubber Mouse", 193L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5621) },
                    { new Guid("a1e9ae79-c5ef-fa67-ee4c-152571308b3f"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5990), null, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", false, null, "Small Cotton Sausages", 131L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5990) },
                    { new Guid("a2bbed74-956b-5e1d-64a9-2987ea0dff99"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5023), null, "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals", false, null, "Rustic Concrete Hat", 112L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5023) },
                    { new Guid("a5202e07-085c-5ace-958e-890551a7adb1"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4543), null, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", true, null, "Unbranded Frozen Hat", 177L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4544) },
                    { new Guid("a7b25e73-ccc4-031c-357c-75ded4000e97"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5429), null, null, true, null, "Fantastic Cotton Mouse", 133L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5430) },
                    { new Guid("a885d2bb-477d-dfcc-c704-c4a33b6bb471"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4748), null, null, true, null, "Handmade Concrete Pizza", 161L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4749) },
                    { new Guid("aa7c3ba5-126c-e2a4-37ef-8d1003a2cc0e"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5415), null, "The Football Is Good For Training And Recreational Purposes", true, null, "Sleek Plastic Chair", 136L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5416) },
                    { new Guid("ac4db52d-1c01-cf30-2e01-30c89033e78d"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(6135), null, null, false, null, "Ergonomic Plastic Cheese", 121L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(6135) },
                    { new Guid("b7550520-ae85-7639-2075-38e37678e19e"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5164), null, null, true, null, "Incredible Cotton Bike", 103L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5164) },
                    { new Guid("c14aa15d-48e8-e500-e424-7f3d015a584e"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(6024), null, "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design", true, null, "Incredible Concrete Mouse", 144L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(6025) },
                    { new Guid("c8a136e8-577b-0237-67df-56efa3dbbfcb"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4850), null, "The slim & simple Maple Gaming Keyboard from Dev Byte comes with a sleek body and 7- Color RGB LED Back-lighting for smart functionality", false, null, "Awesome Rubber Salad", 104L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4851) },
                    { new Guid("cc83e122-0410-25ed-c5c8-9ba9f9556e08"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(558), null, null, false, null, "Refined Steel Bacon", 126L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(562) },
                    { new Guid("d05e2711-a3ff-4548-bb22-169f4aa0a94c"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4992), null, null, false, null, "Handmade Plastic Tuna", 107L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4992) },
                    { new Guid("d0e3c0e5-8580-5cd2-fff6-d283e6b41d91"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5773), null, null, false, null, "Small Frozen Chair", 120L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5773) },
                    { new Guid("d7aee5e8-33a4-4341-bb6b-9f2b082704f9"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4643), null, "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support", false, null, "Refined Steel Sausages", 183L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(4643) },
                    { new Guid("db3a8db6-a245-b773-f5d7-312fc7fb26ba"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5934), null, null, true, null, "Refined Plastic Soap", 138L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5935) },
                    { new Guid("dd4af1db-de8f-0aa4-a1b2-ed200bd11bdf"), 100L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5636), null, "The Football Is Good For Training And Recreational Purposes", true, null, "Small Wooden Table", 128L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5637) },
                    { new Guid("de7f3f06-e8db-44f9-84ce-1d62920309f2"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(6150), null, null, false, null, "Fantastic Fresh Bike", 182L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(6150) },
                    { new Guid("de9674f2-7a55-ec71-5f67-8442136b78da"), 101L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5505), null, "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients", false, null, "Unbranded Steel Bike", 178L, new DateTime(2024, 9, 21, 3, 44, 6, 201, DateTimeKind.Utc).AddTicks(5505) }
                });

            migrationBuilder.InsertData(
                table: "productvariant",
                columns: new[] { "productvariantid", "barcode", "barcode1", "barcode2", "barcode3", "createddatetime", "createduserid", "height", "isarchived", "length", "modifieduserid", "productid", "purchaseprice", "retailprice", "sku", "taxrate", "updateddatetime", "weight", "width" },
                values: new object[,]
                {
                    { new Guid("007b7d79-155b-b5d3-296c-06e2dc97c97b"), "revolutionize", null, null, "Sleek", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(9838), null, null, true, null, null, new Guid("69970e40-b67f-b97d-0775-b4c7805aaf62"), 0.38509735f, 0.37259743f, "Officer", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(9839), 0.76997778041752885, null },
                    { new Guid("052ecf28-c157-3ff1-761e-5fdf256a5439"), "e-tailers", null, "supply-chains", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2566), null, 0.58388532678777605, false, null, null, new Guid("bed55f35-76d0-3d0e-93e2-2747aa7b0674"), 0.66423565f, null, "Baht", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2566), 0.78279995349366216, 0.79720870116595588 },
                    { new Guid("0c51a401-7beb-95bd-73fd-070c01a63150"), "Dynamic", null, null, null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(3907), null, 0.84690716669285071, true, 0.034323489309439195, null, new Guid("c6ce3b76-1246-5a86-5600-690a2e51c7cf"), 0.7643918f, null, "Florida", null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(3907), null, 0.25667607516826879 },
                    { new Guid("0e380ff1-1f4e-a83f-1d5e-37908127fe46"), "Soft", "deposit", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2174), null, 0.12740986194806633, false, 0.3011340491013294, null, new Guid("0088f9b5-8d00-329f-0ffb-dcb1f0521836"), null, 0.6461134f, "solid state", 0.05039687f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2174), 0.52116882545927945, null },
                    { new Guid("10f0ac13-3411-a949-0a1a-6d959cfb2e67"), "Intelligent Fresh Towels", null, "Tennessee", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3361), null, null, true, 0.79654010003271514, null, new Guid("63082b39-7e5e-9f05-1a0e-b6aae0a659b9"), null, 0.99151075f, "payment", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3362), 0.59650139026180904, 0.73531103494358763 },
                    { new Guid("123ec987-eff9-361b-f6b6-1da883f98568"), "optical", "Avon", "Borders", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(7691), null, 0.85332839510092906, true, null, null, new Guid("47ac6a72-f771-2cdf-3f22-ddc5f7361084"), null, 0.8534915f, "Handmade", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(7692), null, null },
                    { new Guid("12e34d1c-649a-1265-f0a6-9382bb273d43"), "Iowa", "Fresh", null, "copying", new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6573), null, 0.49319955263901483, false, 0.52944283212043475, null, new Guid("10a20f76-91d6-677c-07ee-68ff91e550a8"), 0.602984f, null, "Tactics", null, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6573), 0.94361282882448883, 0.57043089092263533 },
                    { new Guid("131ad091-d9c3-f212-0ba8-5949bb871ab0"), "Alabama", "Markets", "Internal", null, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6068), null, 0.36224335588619272, true, null, null, new Guid("5e5a79a6-5d5b-14ad-bed5-21214263193b"), 0.05242452f, 0.17162955f, "Handcrafted Metal Bike", null, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6068), null, null },
                    { new Guid("1ad6d281-34bd-7c3b-d85e-cba60a8b2c79"), "AI", "maroon", "Ergonomic Metal Ball", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(6940), null, 0.9295051009065961, false, null, null, new Guid("9248519f-5ea8-24f5-929b-f1bbf2c3520d"), null, 0.88247937f, "TCP", 0.09247395f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(6941), null, 0.89337583440047497 },
                    { new Guid("1ec8dcda-84b0-9a02-d775-e7aaf7eab97c"), "Factors", null, "Toys & Sports", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(713), null, null, true, null, null, new Guid("f1901298-0eb6-64f9-5886-1ec21048e162"), null, null, "RAM", 0.07488202f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(714), null, 0.81725482121913451 },
                    { new Guid("1f904565-ee92-a64e-cb36-a3857e3feada"), "Delaware", "Swedish Krona", "invoice", "Licensed Frozen Bacon", new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6487), null, 0.18693968569251693, true, 0.79886052189341772, null, new Guid("95b11b65-4dde-b62c-2fb9-3d14ffc1411b"), null, 0.28721365f, "empower", null, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6487), null, null },
                    { new Guid("215215a2-0802-b2d6-bdfe-97313047c246"), "clicks-and-mortar", "Track", "International", null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(3941), null, 0.40522739170362587, true, 0.77865754197289117, null, new Guid("b07224e6-6de1-078e-77db-8cb78a526581"), null, 0.4484731f, "calculating", 0.05053378f, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(3941), null, null },
                    { new Guid("216141e2-4e6c-df72-7135-b109185d3d18"), "user-centric", null, null, null, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(9326), null, null, true, 0.60754018817448063, null, new Guid("b07224e6-6de1-078e-77db-8cb78a526581"), null, 0.84674776f, "Netherlands Antillian Guilder", 0.05335504f, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(9327), null, 0.19399138735327467 },
                    { new Guid("24c49940-d61a-108c-8888-ac7da53bfcab"), "Research", "Movies & Electronics", null, "Sleek Soft Sausages", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3785), null, null, false, null, null, new Guid("ffc1acd4-31e8-f885-8e6e-92ed752471ec"), null, null, "Director", 0.04561619f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3785), null, null },
                    { new Guid("263d5f62-4d72-c952-afb2-9bde2757b28c"), "United Kingdom", "Profit-focused", null, "Borders", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(7221), null, 0.3793543220401529, false, 0.14053278935166671, null, new Guid("25631cdd-d2fb-3fb0-0426-227a89759f14"), null, 0.5658644f, "Slovakia (Slovak Republic)", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(7222), null, 0.46096142728857764 },
                    { new Guid("26ed07c6-eb28-da1d-d7ae-f6aabf93315f"), "Light", null, "Outdoors", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3995), null, 0.58126963329560577, true, null, null, new Guid("9248519f-5ea8-24f5-929b-f1bbf2c3520d"), null, 0.49975818f, "Refined", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3996), 0.45557776766623265, null },
                    { new Guid("2c592cc0-8c0c-f2f6-3a77-b3813f375bcf"), "Future", null, null, null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2764), null, null, true, null, null, new Guid("fd7b3406-a393-8f4e-0263-7980231e9f06"), null, null, "deploy", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2764), 0.85392937942125335, 0.62427755707142762 },
                    { new Guid("2dabd4ed-8015-27cb-fb03-9ce436900f60"), "deposit", "connect", "hybrid", "back-end", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3935), null, 0.74186943133448691, false, null, null, new Guid("f1901298-0eb6-64f9-5886-1ec21048e162"), 0.9816165f, 0.7109188f, "matrix", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3936), 0.25836123119032067, null },
                    { new Guid("3119ef96-75e3-4a95-bbb6-f1156258fed4"), "payment", "Metal", "eco-centric", "Moldova", new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(1719), null, 0.18192738349639223, false, null, null, new Guid("464e8df9-4bc5-34f1-637f-8d261d4013a6"), 0.49052197f, null, "Jewelery & Health", 0.08444259f, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(1719), 0.60863075387134713, null },
                    { new Guid("323ff609-f33e-0ae7-7760-ddc51f698a42"), "tangible", null, null, "Belize Dollar", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2603), null, null, true, 0.96798596529661951, null, new Guid("c48c9793-833f-8426-c47d-69e531df0f82"), null, 0.7100836f, "Direct", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2603), 0.30695618889618487, 0.044508316109193639 },
                    { new Guid("36b5ce01-d0ee-42ea-928d-9a19135921c4"), "turquoise", null, "indexing", "Assistant", new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6449), null, 0.47922918222808708, true, 0.70318881548158307, null, new Guid("778660c0-4365-e8fe-2c90-c5e241030d9b"), 0.5117925f, 0.2842959f, "Pennsylvania", 0.023854628f, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6449), 0.2499539108248213, null },
                    { new Guid("39f7c055-aaac-2bb3-2ff2-385ef84d8499"), "synthesize", "Grocery", null, "Markets", new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6533), null, 0.30136898686241775, true, 0.48633097414222126, null, new Guid("d57526e4-1bc4-fa1d-3281-6b6bbf0cda6c"), null, null, "Forward", 0.03843593f, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6533), 0.48082006977909247, null },
                    { new Guid("3b431e0e-67fe-5a50-0071-a61721e4289f"), "Frozen", null, null, "Mill", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(8831), null, 0.8407937147844553, false, null, null, new Guid("cc2d75b7-e516-86cb-0262-87954e295a53"), 0.07078261f, null, "Multi-lateral", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(8832), null, null },
                    { new Guid("3d7ae817-8434-df2f-a69f-2b3efa6ce0c0"), "Lead", "bypassing", null, "cutting-edge", new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(1838), null, null, false, 0.24083240760529059, null, new Guid("69970e40-b67f-b97d-0775-b4c7805aaf62"), null, null, "input", 0.0019171532f, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(1838), 0.039236216824146089, null },
                    { new Guid("3e6bbd2d-5300-18e8-57cf-6942457a4dc7"), "turquoise", null, null, "Internal", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(492), null, null, true, 0.29087657355278573, null, new Guid("69970e40-b67f-b97d-0775-b4c7805aaf62"), null, 0.88061714f, "calculating", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(492), null, null },
                    { new Guid("3f73de0e-8772-1e33-bdfe-3a28a8e6271b"), "Intelligent", "Analyst", "card", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(394), null, null, true, null, null, new Guid("55359340-5867-a3d3-0af4-6165fe9df831"), null, 0.6627674f, "hacking", 0.002325075f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(394), null, null },
                    { new Guid("4194ca01-16d7-d84e-b1aa-0874ecab8ad6"), "matrices", "SAS", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2324), null, 0.58949091871711001, true, null, null, new Guid("36d50a52-29c3-9a3f-716c-f9e617313c18"), 0.1814942f, 0.12245311f, "Sleek Metal Table", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2324), null, 0.45138415016764039 },
                    { new Guid("44f405b1-0017-451c-5efa-e7f7e3917bec"), "online", null, "Principal", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(6152), null, 0.53567765491813313, false, 0.35553990134761665, null, new Guid("36d50a52-29c3-9a3f-716c-f9e617313c18"), null, null, "New Hampshire", 0.055353615f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(6153), null, null },
                    { new Guid("451a1999-fb87-1199-1f64-4f30e455aa8b"), "withdrawal", "Rue", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(4062), null, 0.64041394677032437, false, 0.071428354397149924, null, new Guid("415ce7b1-6dfc-335a-f56e-8c0c3df7f6f7"), null, 0.33410132f, "Rubber", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(4062), 0.057962739867140886, null },
                    { new Guid("46f899b7-75da-4ccb-8d04-98412e2ebd7c"), "cross-platform", null, null, "Gorgeous", new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(1404), null, null, true, null, null, new Guid("f1901298-0eb6-64f9-5886-1ec21048e162"), 0.62721825f, null, "Mountain", null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(1405), 0.81778956056469565, 0.32620144417798214 },
                    { new Guid("472d24c4-044e-6095-3371-8a64c5f9afc2"), "back up", null, "compressing", "Rustic", new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6960), null, 0.65011883929843028, true, 0.25516166968977155, null, new Guid("b07224e6-6de1-078e-77db-8cb78a526581"), null, 0.79334134f, "Avon", null, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6960), 0.97342920115842912, null },
                    { new Guid("4731cc80-1803-2d0d-86e6-a6c2d132bedf"), "Brand", null, "communities", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(1586), null, null, false, null, null, new Guid("b970dfc8-734a-f701-d40b-49fd87bde072"), null, null, "mesh", 0.079070866f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(1588), 0.4247124206389824, null },
                    { new Guid("47e63e10-16ae-a3ad-33ea-f99d5fd3275b"), "Land", "real-time", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3434), null, 0.86092729860028594, false, 0.52084502974564439, null, new Guid("dc9f5d08-82c5-d454-3a82-b71fa1d187f5"), null, null, "cross-platform", 0.03203656f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3434), 0.46700025697564718, null },
                    { new Guid("481965db-7275-1382-4ba7-83f489e58ec4"), "Liberian Dollar", null, "Kip", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(4225), null, 0.42697439083222971, true, 0.58408467917893303, null, new Guid("36d50a52-29c3-9a3f-716c-f9e617313c18"), 0.16476466f, 0.06552304f, "paradigm", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(4225), null, 0.8907883539287319 },
                    { new Guid("48c5c343-909d-c1fa-cb3c-34ab12750086"), "protocol", "feed", "Home Loan Account", "Anguilla", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(5980), null, 0.3491404020921981, false, null, null, new Guid("0c280c52-d3b3-14a4-4445-0743e6bd6bad"), null, 0.99230653f, "Auto Loan Account", 0.08411152f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(5980), null, 0.34959112775958662 },
                    { new Guid("4a4634c3-a78d-f81f-3b26-1294331881ed"), "paradigm", null, "Self-enabling", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(1274), null, null, false, 0.14981915296512616, null, new Guid("a9f31e8f-b3e7-7f8e-a142-20ff29b52eb0"), 0.24429698f, null, "Light", 0.09818877f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(1274), null, 0.2395949509179196 },
                    { new Guid("4dc2821a-f131-63fd-0684-40f16dc8efed"), "Aruba", "Tasty Granite Salad", null, "Florida", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(7580), null, null, true, 0.35912900574464768, null, new Guid("ffc1acd4-31e8-f885-8e6e-92ed752471ec"), 0.09870768f, 0.74921894f, "Junction", 0.014961058f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(7581), 0.88945731049843935, null },
                    { new Guid("4e49a7d8-b876-a526-c457-79de7d99af45"), "service-desk", null, "Generic Soft Pants", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3496), null, null, true, 0.5840403403081188, null, new Guid("6fdda05d-cb66-3d67-33f3-b0980375b744"), null, 0.40871453f, "Practical", 0.04452536f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3496), 0.23065968986165694, 0.2052647323372144 },
                    { new Guid("53146eb1-aa0f-dae8-0ff5-e337bdc02c9d"), "Saint Vincent and the Grenadines", null, null, null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(1939), null, null, true, null, null, new Guid("eca49e87-c298-2ad4-d72f-38356213b9d2"), null, null, "aggregate", 0.073983304f, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(1939), 0.66020835408019296, 0.96421372423144691 },
                    { new Guid("5459148c-064b-dd8d-a3cf-39777f820240"), "Steel", "PCI", "Rustic Rubber Chips", "Plastic", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3665), null, null, false, 0.57741334595597038, null, new Guid("dc9f5d08-82c5-d454-3a82-b71fa1d187f5"), null, 0.59877115f, "Mountain", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3665), 0.10539986430918792, null },
                    { new Guid("59ec70cf-6711-f3a5-3484-e14f7995cedc"), "Music", null, "Generic", "Developer", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3634), null, 0.42849071530089283, true, null, null, new Guid("3f1bc061-c4e3-08db-8df9-b4f23a722270"), null, 0.17311072f, "Steel", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3635), 0.66711389118205466, 0.18418566285827462 },
                    { new Guid("6912bd64-8e0c-606d-7cc1-f10ea7f8c973"), "sticky", "Fantastic Granite Chicken", "Estates", "Inlet", new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(2944), null, null, true, 0.82482622415983409, null, new Guid("e73d84af-3b2d-c96a-3ac8-684c8708d73d"), 0.28187156f, null, "Accountability", 0.040177964f, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(2945), 0.11740895831836805, null },
                    { new Guid("6bd5a3f1-669e-1b26-c562-738372a4c565"), "District", null, null, null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2218), null, null, false, 0.29080278672780974, null, new Guid("77be7c73-be33-6d2f-f56d-c1a8297aacc6"), 0.19078538f, null, "Canyon", 0.010183649f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2219), 0.21441351120100055, null },
                    { new Guid("6cf22e9f-ee50-0a50-2012-294a2446e90e"), "solutions", null, null, "multi-byte", new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(3839), null, null, true, 0.025628032174719512, null, new Guid("63082b39-7e5e-9f05-1a0e-b6aae0a659b9"), 0.47821984f, 0.041339777f, "quantifying", null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(3839), null, 0.50919418619442458 },
                    { new Guid("6ff72b95-d063-7278-9d0a-7fc186032211"), "sky blue", "communities", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(1348), null, null, false, 0.49590676300968356, null, new Guid("56bb4b5a-3797-5621-7b87-ca8423f1930f"), 0.036142208f, null, "Steel", null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(1348), null, null },
                    { new Guid("710476ec-02d7-62e9-8f47-cd10b085866f"), "indexing", null, null, "Granite", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(930), null, null, false, 0.57967428983173996, null, new Guid("9248519f-5ea8-24f5-929b-f1bbf2c3520d"), 0.16307665f, 0.0647977f, "needs-based", 0.05769548f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(930), null, null },
                    { new Guid("71b22d35-4ae6-4c3f-2ece-d750b747023b"), "models", null, null, "synergies", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2800), null, null, true, null, null, new Guid("aba244f4-1a51-fc6a-6926-ef714384407d"), 0.59291095f, 0.15727952f, "Ameliorated", 0.06616952f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2801), null, null },
                    { new Guid("733f496e-08d2-6711-a732-c749c2ccc9a0"), "back up", null, null, "Lake", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(446), null, null, false, null, null, new Guid("6fdda05d-cb66-3d67-33f3-b0980375b744"), null, 0.25781435f, "Cross-platform", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(447), 0.4927614584997117, null },
                    { new Guid("73417c8a-0596-1cfd-c243-3f0f17dc574a"), "visualize", null, null, null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(306), null, 0.87817558780227578, true, 0.45605916318300144, null, new Guid("10a20f76-91d6-677c-07ee-68ff91e550a8"), 0.44564572f, null, "Buckinghamshire", 0.048609596f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(306), 0.16872281868416947, 0.0033803670682852937 },
                    { new Guid("7975526e-bd17-e2e6-7908-980d4e28c006"), "Handcrafted Steel Gloves", "Streets", "Home & Tools", "global", new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6256), null, null, false, 0.5800343191158186, null, new Guid("95b11b65-4dde-b62c-2fb9-3d14ffc1411b"), 0.97941506f, 0.3617855f, "functionalities", null, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6257), null, null },
                    { new Guid("79977149-987f-2aff-067b-86d83a4c31f2"), "Concrete", null, null, "Auto Loan Account", new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(3490), null, null, true, 0.86414574173472158, null, new Guid("0088f9b5-8d00-329f-0ffb-dcb1f0521836"), null, 0.7914169f, "Streamlined", 0.05820383f, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(3499), 0.40008344007659863, 0.85700747503759689 },
                    { new Guid("7f68ff12-5e62-3c5a-14c2-dfb2889be6a6"), "Canadian Dollar", "Senior", "RAM", "system", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(1952), null, null, false, 0.36410298355114784, null, new Guid("77be7c73-be33-6d2f-f56d-c1a8297aacc6"), 0.1795215f, 0.73886925f, "Concrete", 0.061268f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(1953), 0.43927396714653538, 0.064156874578519194 },
                    { new Guid("83937b30-1fb9-d085-c1ad-9260374a10e5"), "Croatia", null, null, null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3534), null, 0.48926644003450237, true, null, null, new Guid("8913461a-677a-a518-8de2-bcf24d05f61e"), 0.91975f, null, "mint green", 0.016215058f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3534), 0.3316314939091129, 0.24172993900334924 },
                    { new Guid("89379549-adc2-9868-fce9-ca65012db56e"), "Intranet", "Shoes", null, "Small", new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(2733), null, null, false, null, null, new Guid("3f1bc061-c4e3-08db-8df9-b4f23a722270"), null, 0.11833935f, "Shoal", null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(2734), null, 0.59784730365399608 },
                    { new Guid("8b357998-f854-1987-9783-b75389b8de7d"), "Technician", "Rustic Granite Soap", "Meadows", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(1114), null, null, false, 0.48464855481155616, null, new Guid("77be7c73-be33-6d2f-f56d-c1a8297aacc6"), 0.8684275f, 0.19096145f, "grey", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(1114), null, 0.72534657582889617 },
                    { new Guid("8b9908e5-65c8-e32c-83f8-4050c23d24ad"), "grey", "evolve", "blue", "hack", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3965), null, 0.9159460528362291, false, 0.3150096020265527, null, new Guid("464e8df9-4bc5-34f1-637f-8d261d4013a6"), 0.91089827f, null, "1080p", 0.023053251f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3966), null, null },
                    { new Guid("8bde6a77-be88-4179-912c-b5851667350e"), "Planner", null, "Borders", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2262), null, 0.28346798442465626, true, null, null, new Guid("56bb4b5a-3797-5621-7b87-ca8423f1930f"), null, null, "Handmade Frozen Chips", 0.049467318f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2262), 0.29117879005669561, null },
                    { new Guid("8cecc452-1aef-157d-5652-497f6e6fc23b"), "Incredible Frozen Gloves", null, "Chief", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3398), null, null, true, null, null, new Guid("778660c0-4365-e8fe-2c90-c5e241030d9b"), 0.6080595f, null, "Implementation", 0.044131257f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3398), 0.52781398386127032, null },
                    { new Guid("8dceb6f5-24de-9af3-0a01-d491174852b6"), "AGP", "Manager", "Inverse", "SQL", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2949), null, null, false, 0.15102169949143274, null, new Guid("8913461a-677a-a518-8de2-bcf24d05f61e"), null, null, "Auto Loan Account", 0.068522654f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2949), 0.81438548668026245, 0.79878558814469058 },
                    { new Guid("8f024ab7-2a51-61bc-7464-672f31b13c61"), "Auto Loan Account", "Persevering", "Cayman Islands Dollar", null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(2081), null, 0.94268926416648979, false, null, null, new Guid("a9f31e8f-b3e7-7f8e-a142-20ff29b52eb0"), null, 0.52000695f, "Berkshire", 0.08008165f, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(2081), 0.12356841057705154, 0.3235548545250459 },
                    { new Guid("911a5924-e46d-9ad7-572c-ae90d2e6bac5"), "Soft", null, null, "firewall", new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(1295), null, null, true, 0.51307850308393987, null, new Guid("36d50a52-29c3-9a3f-716c-f9e617313c18"), 0.47084773f, 0.86988235f, "red", null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(1295), 0.27938288137287964, null },
                    { new Guid("92916ccd-349e-d6fa-89fa-a2d41643c00c"), "Handmade Plastic Ball", null, null, "Iowa", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3891), null, 0.6043008848113478, true, 0.69944757209133712, null, new Guid("b1da89d7-4cb2-f646-d3a5-c28a78260c59"), 0.2612752f, 0.7480947f, "cross-platform", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3891), null, null },
                    { new Guid("930e2945-f90c-6206-188b-ee1fdf708aaa"), "Fantastic Metal Fish", null, null, null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(9915), null, null, true, 0.35505330066897595, null, new Guid("47ac6a72-f771-2cdf-3f22-ddc5f7361084"), null, 0.21776335f, "invoice", 0.06621528f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(9916), 0.88642054278702498, null },
                    { new Guid("949b3449-662b-4c92-dbaf-b5b781bde4c3"), "partnerships", null, null, null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(439), null, null, false, null, null, new Guid("9248519f-5ea8-24f5-929b-f1bbf2c3520d"), null, null, "Minnesota", 0.03529987f, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(439), null, 0.7362046240531861 },
                    { new Guid("980e06a3-1b75-2bf5-e220-140bfa227834"), "USB", null, "networks", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(5878), null, null, true, 0.7154698342622583, null, new Guid("cc2d75b7-e516-86cb-0262-87954e295a53"), 0.3213606f, null, "calculating", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(5878), null, 0.075289238279354409 },
                    { new Guid("9847852a-2012-745a-381c-ad2c78258238"), "XML", null, "Generic", "bypass", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(98), null, 0.16918180844242769, true, null, null, new Guid("cc2d75b7-e516-86cb-0262-87954e295a53"), null, null, "Ergonomic Frozen Tuna", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(98), 0.20994736263991676, null },
                    { new Guid("99a80d9b-18b6-58b7-d85b-6f65c7ab2cb6"), "Springs", "Mauritius", null, "Knolls", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(1004), null, null, true, null, null, new Guid("e73d84af-3b2d-c96a-3ac8-684c8708d73d"), null, null, "Practical Rubber Chair", 0.04231773f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(1004), null, 0.95212190083792525 },
                    { new Guid("99e2ce9b-430f-70ad-82c4-a9f11dcd9e21"), "connecting", "JSON", "Bhutanese Ngultrum", "tertiary", new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(8746), null, 0.22860951872012089, true, null, null, new Guid("b970dfc8-734a-f701-d40b-49fd87bde072"), 0.8626503f, null, "complexity", null, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(8749), null, null },
                    { new Guid("9e40fa95-81a8-c801-f98e-262044d73365"), "Cambridgeshire", null, null, "withdrawal", new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6860), null, 0.32853902845109767, false, null, null, new Guid("56bb4b5a-3797-5621-7b87-ca8423f1930f"), null, null, "Rubber", 0.032407064f, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6861), 0.62269785982682269, 0.04736083701595703 },
                    { new Guid("9e7bdefa-ebdf-b8e9-e7f7-c483030aa7db"), "Island", "Metal", "fresh-thinking", "Home", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3008), null, null, true, 0.72336417842813028, null, new Guid("f92a45cb-f494-f2c7-c94c-9d089374b925"), null, 0.69447416f, "Fantastic Soft Salad", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3008), null, 0.14971245925394466 },
                    { new Guid("9e837a31-104b-41b7-e4b9-45e9bf17153f"), "Intelligent Granite Cheese", "Indian Rupee", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2841), null, 0.11325689410476801, true, null, null, new Guid("9248519f-5ea8-24f5-929b-f1bbf2c3520d"), 0.79739374f, null, "Locks", 0.060160078f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2841), null, 0.32328241799179575 },
                    { new Guid("a1e4c689-ace0-b246-340b-1627abb378f9"), "multi-byte", "payment", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(606), null, 0.22514719386824741, false, 0.95757110647744081, null, new Guid("63082b39-7e5e-9f05-1a0e-b6aae0a659b9"), null, null, "invoice", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(607), 0.36306645225876311, 0.93169324050270641 },
                    { new Guid("a7d3be75-c069-0e15-5c15-16f029c83c0e"), "lavender", null, null, "Djibouti Franc", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3830), null, 0.99821290420285091, false, 0.19132554540006702, null, new Guid("4c4ac2d0-6231-1adf-d77d-f1973bad1b3d"), null, 0.6278916f, "Spring", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3830), null, null },
                    { new Guid("aa1a9efe-c037-0c2d-f48b-123e2c007f9d"), "project", "withdrawal", "Money Market Account", "parse", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3467), null, null, true, 0.93376454661309927, null, new Guid("778660c0-4365-e8fe-2c90-c5e241030d9b"), null, 0.56646633f, "Auto Loan Account", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3468), null, 0.41438209284766675 },
                    { new Guid("ab688498-0101-2993-cda9-1130008916ee"), "invoice", null, "CSS", "Ville", new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6990), null, 0.097801091660652817, false, 0.07514739505720669, null, new Guid("06e63b8c-da85-d5ae-6f59-868bac0ed939"), 0.7045494f, null, "Vista", 0.054352716f, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6990), null, 0.22274613809899713 },
                    { new Guid("ac006ac2-a5fb-8b39-b977-ba19a75fd637"), "JBOD", null, "impactful", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(4596), null, 0.88511584973200963, false, null, null, new Guid("dc9f5d08-82c5-d454-3a82-b71fa1d187f5"), 0.35819831f, 0.05397926f, "Ergonomic Wooden Salad", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(4597), 0.38563942601235557, null },
                    { new Guid("ae23f6af-2540-8df0-85f1-e11ad5bc3b1a"), "Soft", "matrix", "Circle", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(812), null, null, false, null, null, new Guid("778660c0-4365-e8fe-2c90-c5e241030d9b"), 0.54709435f, null, "Refined Cotton Cheese", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(813), 0.028085404088760448, null },
                    { new Guid("ae3bec1d-eef8-f842-ff5a-64c0371b9eb6"), "Generic Plastic Pants", "bypassing", "Georgia", "Graphical User Interface", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(4151), null, null, true, null, null, new Guid("aba244f4-1a51-fc6a-6926-ef714384407d"), 0.3158354f, 0.46138397f, "bypass", 0.078238845f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(4151), 0.68777469763894317, null },
                    { new Guid("b580b3dc-7503-26cc-a772-aeeb22e23e55"), "Home, Computers & Computers", "Cambridgeshire", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(8292), null, 0.6022440710115452, false, null, null, new Guid("36d50a52-29c3-9a3f-716c-f9e617313c18"), null, null, "Intelligent Metal Computer", 0.028462041f, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(8294), null, 0.68046325756258486 },
                    { new Guid("b60199ba-146e-7e27-4202-3a4ba1ff26e9"), "Unbranded Cotton Shirt", null, "Sleek Concrete Keyboard", "Phased", new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(9100), null, null, false, null, null, new Guid("e6a3f35b-0d6c-ad52-fa2f-172109ac90ba"), 0.91364586f, null, "Checking Account", 0.08360296f, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(9100), 0.74330721830171864, 0.50371532351882908 },
                    { new Guid("b891fc74-1306-fb65-efd7-a2db3af5cab3"), "Ergonomic Soft Computer", null, "Internal", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(210), null, null, false, null, null, new Guid("eca49e87-c298-2ad4-d72f-38356213b9d2"), null, null, "matrix", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(211), null, 0.94411657887702649 },
                    { new Guid("b92d7bb3-e262-fbd0-a34a-a0279e5ce154"), "relationships", "Tasty Frozen Sausages", "Applications", "Stream", new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(40), null, null, false, 0.32329989938219073, null, new Guid("b07224e6-6de1-078e-77db-8cb78a526581"), 0.6526446f, 0.32427198f, "XSS", 0.09758925f, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(40), 0.85146666124997039, null },
                    { new Guid("b9dd3fa7-84f6-5381-6bc9-89af6b8beffa"), "Coordinator", null, "holistic", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2369), null, 0.11902047699271723, false, 0.59804875850586625, null, new Guid("3f1bc061-c4e3-08db-8df9-b4f23a722270"), null, null, "Consultant", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2369), null, 0.35570374846258374 },
                    { new Guid("bcd4051d-b928-6ed0-053f-68bab6bd8735"), "Uruguay", null, "array", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(8473), null, 0.6687614748574614, false, 0.8382390988237407, null, new Guid("10a20f76-91d6-677c-07ee-68ff91e550a8"), null, null, "Pre-emptive", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(8474), 0.46460822805045554, null },
                    { new Guid("bde495e6-282b-008d-dc79-23e377313287"), "compressing", null, null, "Assimilated", new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(1146), null, 0.84992713939860798, false, null, null, new Guid("6fdda05d-cb66-3d67-33f3-b0980375b744"), 0.13164435f, null, "Granite", 0.083069675f, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(1147), null, null },
                    { new Guid("c05ec297-e430-49dd-9026-bf00b04aec49"), "orchid", null, null, "Wooden", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(1154), null, 0.17549361715814732, true, 0.46740717835137957, null, new Guid("ffc1acd4-31e8-f885-8e6e-92ed752471ec"), 0.82414895f, 0.43495777f, "Villages", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(1155), 0.52103982564110296, null },
                    { new Guid("c268d352-d05a-2f50-1973-67b78fc49c77"), "deposit", "Cambridgeshire", "Consultant", "virtual", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2734), null, null, false, null, null, new Guid("a9f31e8f-b3e7-7f8e-a142-20ff29b52eb0"), null, null, "Borders", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2734), null, 0.49214748129814279 },
                    { new Guid("c2f86465-6cb6-a637-c80b-f25f54f908a8"), "pixel", null, null, "Missouri", new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(1982), null, null, true, 0.85315383824201019, null, new Guid("b38145a9-41bf-a8d8-610a-690623410c6f"), null, null, "Massachusetts", null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(1982), 0.64700752247451221, null },
                    { new Guid("c39a94a9-7e81-3c50-a6af-095ad2c40ac3"), "invoice", "Dominican Peso", "Soft", "transmitter", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(1186), null, null, false, null, null, new Guid("3f1bc061-c4e3-08db-8df9-b4f23a722270"), null, 0.49441066f, "Gorgeous Metal Chair", 0.072846375f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(1186), 0.79837542204110667, 0.34374105434107644 },
                    { new Guid("c3b89973-0cc3-f3e8-3459-645472ea7404"), "bypassing", null, null, null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(526), null, null, false, null, null, new Guid("415ce7b1-6dfc-335a-f56e-8c0c3df7f6f7"), null, 0.24046536f, "Ecuador", 0.021411914f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(527), null, null },
                    { new Guid("c47e2cad-1be9-1624-fad7-4ee0cac2a75b"), "SQL", "Mississippi", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6349), null, null, true, 0.85880551666897043, null, new Guid("464e8df9-4bc5-34f1-637f-8d261d4013a6"), 0.8953465f, null, "orchid", null, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6349), 0.14759440959784872, 0.85104775235571328 },
                    { new Guid("cf9eaedd-9423-44f1-c48e-2163ee42a5a7"), "systems", null, "next generation", "programming", new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(1447), null, 0.76844592847323323, false, null, null, new Guid("47ac6a72-f771-2cdf-3f22-ddc5f7361084"), 0.050029315f, null, "Borders", 0.009368191f, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(1447), 0.89150697313784943, 0.077249640634865335 },
                    { new Guid("d0cc802b-ea40-4ec7-df80-38c6edc44b3c"), "Gourde", "Junctions", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(4096), null, null, true, 0.97855737664669629, null, new Guid("f92a45cb-f494-f2c7-c94c-9d089374b925"), 0.25144467f, null, "deploy", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(4096), 0.030452016755217692, null },
                    { new Guid("db516a74-791f-f86e-0c3c-d67a924f1179"), "Plastic", "copying", null, "Extended", new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(1679), null, 0.54974088796868026, false, 0.18030741493231961, null, new Guid("9e866982-ddaf-c778-9360-8ebf229081c2"), 0.81077254f, 0.33787224f, "Coordinator", null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(1680), null, 0.043821224497547946 },
                    { new Guid("dc693297-c5a6-6419-5d33-be79812e7fcf"), "Pataca", null, null, "backing up", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(4192), null, null, true, null, null, new Guid("415ce7b1-6dfc-335a-f56e-8c0c3df7f6f7"), 0.037272263f, 0.63910884f, "Mews", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(4193), null, null },
                    { new Guid("dd62c8bc-a860-03c9-1813-cee7c39e664c"), "Belgium", "Credit Card Account", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(9243), null, null, true, 0.64913980693050655, null, new Guid("b1da89d7-4cb2-f646-d3a5-c28a78260c59"), 0.89728355f, 0.71632123f, "multimedia", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(9243), 0.46976409920945955, null },
                    { new Guid("de798fc0-4ce6-ed23-77eb-49d07fb46279"), "Books, Sports & Games", "Gorgeous", "Incredible Steel Pants", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3736), null, 0.30257740118660842, false, 0.76336055005125725, null, new Guid("9248519f-5ea8-24f5-929b-f1bbf2c3520d"), 0.114115f, 0.05241467f, "Louisiana", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3737), null, 0.83481652468201539 },
                    { new Guid("df2e232f-78b9-40fa-2d29-94c85516420e"), "hack", "Metal", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(1562), null, 0.43123260207065967, true, 0.60763008827698883, null, new Guid("e73d84af-3b2d-c96a-3ac8-684c8708d73d"), 0.021164961f, 0.974523f, "Money Market Account", 0.08162314f, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(1562), null, 0.68549193287524024 },
                    { new Guid("df781296-8d33-3711-2be8-2600c9118f40"), "Hills", "explicit", "wireless", "feed", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(6065), null, null, false, 0.82956564139088873, null, new Guid("77be7c73-be33-6d2f-f56d-c1a8297aacc6"), null, null, "Intelligent", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(6065), 0.2427521926549972, 0.34775653451111005 },
                    { new Guid("e39305b3-3418-17dd-bb53-e8bc5c239df2"), "Rustic Soft Car", null, null, null, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6677), null, null, true, null, null, new Guid("8116f650-b121-7f5a-6d20-3c185005c1e1"), 0.77234125f, 0.24783644f, "reintermediate", null, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6677), null, null },
                    { new Guid("e3c87d82-e918-0204-7888-39d798788041"), "withdrawal", "Handmade Rubber Fish", "connect", "redundant", new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(8950), null, null, false, 0.77805513971394635, null, new Guid("ffc1acd4-31e8-f885-8e6e-92ed752471ec"), null, null, "firewall", null, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(8950), null, 0.50084566581102352 },
                    { new Guid("e7561554-e0c8-c881-d7f3-11b33bf3111e"), "Wall", null, null, "transmit", new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(179), null, 0.21413045433076586, false, 0.98267506760669643, null, new Guid("1c59edc4-cfc2-6afd-03af-fc90c84142d6"), null, null, "Credit Card Account", 0.0516033f, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(180), null, null },
                    { new Guid("e942556a-2afd-0f68-b54a-c84d023071e4"), "Balboa", null, "Indiana", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3160), null, 0.98545748460360683, false, 0.66667481216912849, null, new Guid("dc9f5d08-82c5-d454-3a82-b71fa1d187f5"), 0.20659226f, null, "parsing", 0.015578556f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3161), null, null },
                    { new Guid("ea35b956-cb30-5eab-7c9f-a7f250911ad7"), "Cliffs", null, "Senior", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3328), null, null, false, 0.37360165052749295, null, new Guid("47ac6a72-f771-2cdf-3f22-ddc5f7361084"), 0.86708885f, null, "SDR", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3328), 0.26515514089965969, 0.032750810046098575 },
                    { new Guid("eaac149c-f5f7-e401-2675-85b2de9d1060"), "Berkshire", null, "deposit", "IB", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(780), null, 0.21520950049870158, true, null, null, new Guid("b970dfc8-734a-f701-d40b-49fd87bde072"), 0.17180917f, 0.708011f, "Inverse", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(780), 0.65336428473394559, null },
                    { new Guid("ecac1580-2c6c-da4a-1276-ce052dfcdcea"), "virtual", "Tennessee", "withdrawal", null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(2178), null, 0.5873946824983669, false, null, null, new Guid("464e8df9-4bc5-34f1-637f-8d261d4013a6"), 0.13446513f, null, "South Dakota", null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(2179), 0.32299416480725357, null },
                    { new Guid("f02b25ef-d1b3-03b3-b19e-a1e69c654d30"), "bifurcated", "deposit", "Cambridgeshire", null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(2447), null, 0.19601630847715601, false, 0.65937806650035924, null, new Guid("63082b39-7e5e-9f05-1a0e-b6aae0a659b9"), null, null, "yellow", null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(2448), null, null },
                    { new Guid("f040876b-2d4f-fdee-b98a-f85ac36654fb"), "Prairie", null, null, "sky blue", new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(9568), null, null, false, 0.83916923722213566, null, new Guid("d57526e4-1bc4-fa1d-3281-6b6bbf0cda6c"), null, 0.16219097f, "Beauty & Automotive", null, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(9569), null, null },
                    { new Guid("f41921cd-eb55-1610-e1a1-3ded074ab077"), "Handcrafted", null, null, null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(675), null, null, false, null, null, new Guid("c6ce3b76-1246-5a86-5600-690a2e51c7cf"), 0.82213396f, null, "payment", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(675), 0.22307399111943041, null },
                    { new Guid("f683369c-f784-e027-006b-4e2613596521"), "Fantastic Soft Bike", null, null, "Credit Card Account", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(4261), null, 0.70285568838140722, false, null, null, new Guid("fd7b3406-a393-8f4e-0263-7980231e9f06"), 0.54477555f, null, "web services", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(4261), 0.15689953517024383, 0.74931107962006283 },
                    { new Guid("f880f7b4-58c7-2ca3-ea10-287db692563e"), "Liaison", null, null, "bypass", new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(5904), null, null, true, 0.30356071856970002, null, new Guid("653dd38d-d89c-5cf6-6cf3-55ee2623679a"), null, null, "Checking Account", null, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(5904), null, 0.43836402540950292 },
                    { new Guid("fe8e00a0-d576-71d0-0533-6aab8c0e9a23"), "Harbor", null, "Lodge", null, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(9997), null, null, true, null, null, new Guid("56bb4b5a-3797-5621-7b87-ca8423f1930f"), null, 0.49701288f, "out-of-the-box", 0.06061178f, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(9998), 0.64437150240148022, null },
                    { new Guid("fe9d86e7-f28a-d772-6b19-dcbd0858b80e"), "Tactics", null, "Practical", "Graphical User Interface", new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(398), null, 0.473904296045147, false, 0.63781776681440783, null, new Guid("f92a45cb-f494-f2c7-c94c-9d089374b925"), null, 0.6760626f, "Metal", 0.058300864f, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(398), 0.69478419548588999, null },
                    { new Guid("ff0b7e23-bfea-f7a7-30bf-d19858f05b76"), "Developer", null, null, "Applications", new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(2316), null, null, true, 0.32147101979771209, null, new Guid("9e866982-ddaf-c778-9360-8ebf229081c2"), null, 0.9486996f, "Rest", 0.061131738f, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(2316), 0.17837297179660433, null }
                });

            migrationBuilder.InsertData(
                table: "userpermission",
                columns: new[] { "userpermissionid", "createddatetime", "createduserid", "iscrud", "modifieduserid", "permissiontype", "updateddatetime", "userid" },
                values: new object[,]
                {
                    { 100L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4718), null, true, null, 4, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4719), 100L },
                    { 101L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4725), null, true, null, 13, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4725), 100L },
                    { 102L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4726), null, true, null, 20, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4726), 100L },
                    { 103L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4727), null, true, null, 30, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4727), 100L },
                    { 104L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4728), null, true, null, 40, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4729), 100L },
                    { 105L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4730), null, true, null, 50, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4730), 100L },
                    { 106L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4731), null, true, null, 60, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4731), 100L },
                    { 107L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4732), null, true, null, 70, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4732), 100L },
                    { 108L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4733), null, true, null, 80, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4733), 100L },
                    { 109L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4734), null, true, null, 90, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4735), 100L },
                    { 110L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4735), null, true, null, 95, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4735), 100L },
                    { 111L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4736), null, true, null, 100, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4736), 100L },
                    { 112L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4737), null, true, null, 110, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4737), 100L },
                    { 113L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4738), null, true, null, 120, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4738), 100L },
                    { 114L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4738), null, true, null, 130, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4739), 100L },
                    { 115L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4739), null, true, null, 140, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4739), 100L },
                    { 116L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4740), null, true, null, 150, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4740), 100L },
                    { 117L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4742), null, true, null, 170, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4742), 100L },
                    { 118L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4742), null, true, null, 180, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4743), 100L },
                    { 119L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4745), null, true, null, 4, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4746), 101L },
                    { 120L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4791), null, true, null, 13, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4791), 101L },
                    { 121L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4793), null, true, null, 20, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4793), 101L },
                    { 122L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4794), null, true, null, 30, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4794), 101L },
                    { 123L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4795), null, true, null, 40, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4795), 101L },
                    { 124L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4795), null, true, null, 50, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4796), 101L },
                    { 125L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4796), null, true, null, 60, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4797), 101L },
                    { 126L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4797), null, true, null, 70, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4798), 101L },
                    { 127L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4798), null, true, null, 80, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4798), 101L },
                    { 128L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4799), null, true, null, 90, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4799), 101L },
                    { 129L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4800), null, true, null, 95, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4800), 101L },
                    { 130L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4801), null, true, null, 100, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4801), 101L },
                    { 131L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4801), null, true, null, 110, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4802), 101L },
                    { 132L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4802), null, true, null, 120, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4802), 101L },
                    { 133L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4804), null, true, null, 130, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4804), 101L },
                    { 134L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4805), null, true, null, 140, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4805), 101L },
                    { 135L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4805), null, true, null, 150, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4806), 101L },
                    { 136L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4806), null, true, null, 170, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4806), 101L },
                    { 137L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4807), null, true, null, 180, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4807), 101L },
                    { 138L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4809), null, true, null, 4, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4809), 102L },
                    { 139L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4811), null, true, null, 13, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4811), 102L },
                    { 140L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4811), null, true, null, 20, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4812), 102L },
                    { 141L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4812), null, true, null, 30, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4813), 102L },
                    { 142L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4813), null, true, null, 40, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4813), 102L },
                    { 143L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4814), null, true, null, 50, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4814), 102L },
                    { 144L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4815), null, true, null, 60, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4815), 102L },
                    { 145L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4815), null, true, null, 70, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4816), 102L },
                    { 146L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4816), null, true, null, 80, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4816), 102L },
                    { 147L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4817), null, true, null, 90, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4817), 102L },
                    { 148L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4818), null, true, null, 95, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4818), 102L },
                    { 149L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4818), null, true, null, 100, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4819), 102L },
                    { 150L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4819), null, true, null, 110, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4819), 102L },
                    { 151L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4820), null, true, null, 120, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4820), 102L },
                    { 152L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4821), null, true, null, 130, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4821), 102L },
                    { 153L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4821), null, true, null, 140, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4822), 102L },
                    { 154L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4822), null, true, null, 150, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4822), 102L },
                    { 155L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4823), null, true, null, 170, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4823), 102L },
                    { 156L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4824), null, true, null, 180, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4824), 102L },
                    { 157L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4826), null, true, null, 4, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4826), 103L },
                    { 158L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4827), null, true, null, 13, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4827), 103L },
                    { 159L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4828), null, true, null, 20, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4828), 103L },
                    { 160L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4829), null, true, null, 30, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4829), 103L },
                    { 161L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4829), null, true, null, 40, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4830), 103L },
                    { 162L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4830), null, true, null, 50, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4830), 103L },
                    { 163L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4831), null, true, null, 60, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4831), 103L },
                    { 164L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4832), null, true, null, 70, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4832), 103L },
                    { 165L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4833), null, true, null, 80, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4833), 103L },
                    { 166L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4834), null, true, null, 90, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4834), 103L },
                    { 167L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4856), null, true, null, 95, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4856), 103L },
                    { 168L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4857), null, true, null, 100, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4857), 103L },
                    { 169L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4858), null, true, null, 110, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4858), 103L },
                    { 170L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4859), null, true, null, 120, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4859), 103L },
                    { 171L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4860), null, true, null, 130, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4860), 103L },
                    { 172L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4860), null, true, null, 140, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4861), 103L },
                    { 173L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4861), null, true, null, 150, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4862), 103L },
                    { 174L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4862), null, true, null, 170, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4862), 103L },
                    { 175L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4863), null, true, null, 180, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4863), 103L },
                    { 176L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4865), null, true, null, 4, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4865), 104L },
                    { 177L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4867), null, true, null, 13, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4867), 104L },
                    { 178L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4867), null, true, null, 20, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4868), 104L },
                    { 179L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4868), null, true, null, 30, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4868), 104L },
                    { 180L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4869), null, true, null, 40, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4869), 104L },
                    { 181L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4870), null, true, null, 50, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4870), 104L },
                    { 182L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4871), null, true, null, 60, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4871), 104L },
                    { 183L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4871), null, true, null, 70, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4872), 104L },
                    { 184L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4872), null, true, null, 80, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4872), 104L },
                    { 185L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4873), null, true, null, 90, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4873), 104L },
                    { 186L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4874), null, true, null, 95, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4874), 104L },
                    { 187L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4874), null, true, null, 100, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4875), 104L },
                    { 188L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4875), null, true, null, 110, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4875), 104L },
                    { 189L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4876), null, true, null, 120, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4876), 104L },
                    { 190L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4877), null, true, null, 130, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4877), 104L },
                    { 191L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4878), null, true, null, 140, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4878), 104L },
                    { 192L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4878), null, true, null, 150, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4879), 104L },
                    { 193L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4879), null, true, null, 170, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4879), 104L },
                    { 194L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4880), null, true, null, 180, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4880), 104L },
                    { 195L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4882), null, true, null, 4, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4882), 105L },
                    { 196L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4884), null, true, null, 13, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4884), 105L },
                    { 197L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4885), null, true, null, 20, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4885), 105L },
                    { 198L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4885), null, true, null, 30, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4886), 105L },
                    { 199L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4886), null, true, null, 40, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4886), 105L },
                    { 200L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4887), null, true, null, 50, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4887), 105L },
                    { 201L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4888), null, true, null, 60, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4888), 105L },
                    { 202L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4888), null, true, null, 70, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4889), 105L },
                    { 203L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4889), null, true, null, 80, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4889), 105L },
                    { 204L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4890), null, true, null, 90, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4890), 105L },
                    { 205L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4891), null, true, null, 95, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4891), 105L },
                    { 206L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4892), null, true, null, 100, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4892), 105L },
                    { 207L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4892), null, true, null, 110, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4893), 105L },
                    { 208L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4893), null, true, null, 120, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4893), 105L },
                    { 209L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4894), null, true, null, 130, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4894), 105L },
                    { 210L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4895), null, true, null, 140, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4895), 105L },
                    { 211L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4895), null, true, null, 150, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4896), 105L },
                    { 212L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4896), null, true, null, 170, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4896), 105L },
                    { 213L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4897), null, true, null, 180, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4897), 105L },
                    { 214L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4899), null, true, null, 4, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4899), 106L },
                    { 215L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4900), null, true, null, 13, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4900), 106L },
                    { 216L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4901), null, true, null, 20, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4901), 106L },
                    { 217L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4902), null, true, null, 30, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4902), 106L },
                    { 218L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4903), null, true, null, 40, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4903), 106L },
                    { 219L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4903), null, true, null, 50, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4904), 106L },
                    { 220L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4904), null, true, null, 60, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4904), 106L },
                    { 221L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4905), null, true, null, 70, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4905), 106L },
                    { 222L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4906), null, true, null, 80, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4906), 106L },
                    { 223L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4907), null, true, null, 90, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4907), 106L },
                    { 224L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4928), null, true, null, 95, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4928), 106L },
                    { 225L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4929), null, true, null, 100, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4929), 106L },
                    { 226L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4930), null, true, null, 110, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4930), 106L },
                    { 227L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4930), null, true, null, 120, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4931), 106L },
                    { 228L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4931), null, true, null, 130, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4932), 106L },
                    { 229L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4933), null, true, null, 140, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4933), 106L },
                    { 230L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4934), null, true, null, 150, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4934), 106L },
                    { 231L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4935), null, true, null, 170, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4935), 106L },
                    { 232L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4935), null, true, null, 180, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4936), 106L },
                    { 233L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4937), null, true, null, 4, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4937), 107L },
                    { 234L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4941), null, true, null, 13, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4941), 107L },
                    { 235L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4942), null, true, null, 20, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4942), 107L },
                    { 236L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4942), null, true, null, 30, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4943), 107L },
                    { 237L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4943), null, true, null, 40, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4943), 107L },
                    { 238L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4944), null, true, null, 50, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4944), 107L },
                    { 239L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4945), null, true, null, 60, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4945), 107L },
                    { 240L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4945), null, true, null, 70, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4946), 107L },
                    { 241L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4946), null, true, null, 80, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4946), 107L },
                    { 242L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4947), null, true, null, 90, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4947), 107L },
                    { 243L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4948), null, true, null, 95, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4948), 107L },
                    { 244L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4949), null, true, null, 100, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4949), 107L },
                    { 245L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4949), null, true, null, 110, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4950), 107L },
                    { 246L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4950), null, true, null, 120, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4950), 107L },
                    { 247L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4951), null, true, null, 130, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4951), 107L },
                    { 248L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4952), null, true, null, 140, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4952), 107L },
                    { 249L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4953), null, true, null, 150, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4953), 107L },
                    { 250L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4953), null, true, null, 170, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4954), 107L },
                    { 251L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4954), null, true, null, 180, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4954), 107L },
                    { 252L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4956), null, true, null, 4, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4956), 108L },
                    { 253L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4961), null, true, null, 13, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4961), 108L },
                    { 254L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4962), null, true, null, 20, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4962), 108L },
                    { 255L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4962), null, true, null, 30, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4963), 108L },
                    { 256L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4963), null, true, null, 40, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4964), 108L },
                    { 257L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4964), null, true, null, 50, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4965), 108L },
                    { 258L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4965), null, true, null, 60, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4965), 108L },
                    { 259L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4966), null, true, null, 70, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4966), 108L },
                    { 260L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4967), null, true, null, 80, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4967), 108L },
                    { 261L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4967), null, true, null, 90, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4968), 108L },
                    { 262L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4968), null, true, null, 95, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4968), 108L },
                    { 263L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4969), null, true, null, 100, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4969), 108L },
                    { 264L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4970), null, true, null, 110, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4970), 108L },
                    { 265L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4970), null, true, null, 120, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4971), 108L },
                    { 266L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4971), null, true, null, 130, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4971), 108L },
                    { 267L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4984), null, true, null, 140, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4985), 108L },
                    { 268L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4986), null, true, null, 150, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4986), 108L },
                    { 269L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4987), null, true, null, 170, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4987), 108L },
                    { 270L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4988), null, true, null, 180, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4988), 108L },
                    { 271L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4990), null, true, null, 4, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4990), 109L },
                    { 272L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4991), null, true, null, 13, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4991), 109L },
                    { 273L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4992), null, true, null, 20, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4992), 109L },
                    { 274L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4993), null, true, null, 30, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4993), 109L },
                    { 275L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4994), null, true, null, 40, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4994), 109L },
                    { 276L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4995), null, true, null, 50, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4995), 109L },
                    { 277L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4995), null, true, null, 60, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4996), 109L },
                    { 278L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4996), null, true, null, 70, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4996), 109L },
                    { 279L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4997), null, true, null, 80, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4997), 109L },
                    { 280L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4998), null, true, null, 90, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4998), 109L },
                    { 281L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4998), null, true, null, 95, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4999), 109L },
                    { 282L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4999), null, true, null, 100, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4999), 109L },
                    { 283L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(5000), null, true, null, 110, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(5000), 109L },
                    { 284L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(5001), null, true, null, 120, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(5001), 109L },
                    { 285L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(5002), null, true, null, 130, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(5002), 109L },
                    { 286L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(5002), null, true, null, 140, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(5003), 109L },
                    { 287L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(5003), null, true, null, 150, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(5003), 109L },
                    { 288L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(5004), null, true, null, 170, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(5004), 109L },
                    { 289L, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(5005), null, true, null, 180, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(5005), 109L }
                });

            migrationBuilder.InsertData(
                table: "productvariant",
                columns: new[] { "productvariantid", "barcode", "barcode1", "barcode2", "barcode3", "createddatetime", "createduserid", "height", "isarchived", "length", "modifieduserid", "productid", "purchaseprice", "retailprice", "sku", "taxrate", "updateddatetime", "weight", "width" },
                values: new object[,]
                {
                    { new Guid("014a3b7f-37a4-8dde-cc27-3d3a4444102d"), "teal", "parse", "leading edge", "Senior", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2919), null, null, true, null, null, new Guid("2839f2e8-1a35-f860-86b6-19c1a1d27788"), null, null, "1080p", 0.013547465f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2920), null, 0.76740487700673043 },
                    { new Guid("09b582c8-5e14-dcb7-2023-43648cd330c3"), "Checking Account", null, "Liberian Dollar", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3703), null, null, false, 0.7993590341877933, null, new Guid("5fb73477-b1c7-65f7-af3a-35c199cdbe86"), 0.009284317f, 0.5481873f, "azure", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3704), 0.25898728997399439, 0.48979115602084955 },
                    { new Guid("0a926617-2264-22f2-faef-376525a70259"), "Assistant", null, "Garden", "French Polynesia", new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6718), null, 0.46647041498984693, true, 0.10596302249746538, null, new Guid("04b90168-323c-baca-f337-527c31e1039c"), 0.4273202f, null, "Antigua and Barbuda", null, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6718), 0.061381635284694674, 0.13459026586943784 },
                    { new Guid("11f1a82f-96d2-300d-e22b-ec8b62608a25"), "payment", "backing up", null, "Senior", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(9146), null, 0.11887067049689157, false, null, null, new Guid("63f0befa-3aeb-463c-7289-3af9421eb2ee"), 0.3532946f, null, "Qatar", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(9146), 0.56638971928804638, 0.67488902186736888 },
                    { new Guid("11fa7e6d-d119-35a3-8e08-c728351bf703"), "Steel", null, null, null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(3031), null, null, true, null, null, new Guid("de9674f2-7a55-ec71-5f67-8442136b78da"), 0.53028524f, 0.458178f, "driver", 0.036842372f, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(3032), null, 0.7818392309275638 },
                    { new Guid("1997c9c8-8bb1-1af6-1f8d-0d33dc975163"), "back-end", "infomediaries", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(7485), null, null, true, null, null, new Guid("a885d2bb-477d-dfcc-c704-c4a33b6bb471"), 0.47030655f, null, "driver", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(7486), null, 0.0097994827711020988 },
                    { new Guid("1cfc2eb2-a7b7-2725-3a1a-838e6c82b3c9"), "experiences", "Buckinghamshire", null, "Factors", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3237), null, 0.37171166826584917, false, 0.21072344491757614, null, new Guid("dd4af1db-de8f-0aa4-a1b2-ed200bd11bdf"), 0.92620367f, null, "multi-state", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3238), null, null },
                    { new Guid("1ee21374-3716-e3ea-779f-6358fa47d180"), "PCI", null, "copying", "SQL", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(641), null, 1.8657650807247335E-05, true, null, null, new Guid("c8a136e8-577b-0237-67df-56efa3dbbfcb"), null, 0.5553924f, "Engineer", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(641), 0.39551303135022198, null },
                    { new Guid("25ec4ec1-7ad9-dd81-d916-655a2bcaa2d5"), "Virtual", "Down-sized", null, "context-sensitive", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(8087), null, 0.044669060523001972, false, 0.73950058069988178, null, new Guid("c14aa15d-48e8-e500-e424-7f3d015a584e"), 0.5839989f, 0.20604077f, "open system", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(8087), 0.83250388960936283, 0.63388753711892643 },
                    { new Guid("29962d74-19ba-8257-bbef-5865e18c7440"), "New York", null, "Small", null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(3872), null, null, false, null, null, new Guid("8d4ac50d-6d42-2869-62dd-4cb30cbf2a7f"), 0.8522619f, null, "secondary", null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(3873), null, null },
                    { new Guid("2d27c4de-a9be-72d5-880d-2ecb4ae9657a"), "Investor", "core", null, "cohesive", new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4), null, null, true, null, null, new Guid("7b9a9dca-645d-654a-4300-bd684865463d"), null, 0.34527978f, "primary", 0.050104763f, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4), 0.11462597507733198, null },
                    { new Guid("2e319603-1a1b-37c6-dadb-695677b2629a"), "Tanzanian Shilling", null, null, "index", new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(3085), null, 0.00087734079029287248, false, 0.49773790710500343, null, new Guid("809094ca-1942-62ca-f728-b54a1ea2febc"), null, null, "Handcrafted Cotton Shoes", null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(3086), 0.48389446385386142, 0.86734598403207308 },
                    { new Guid("2e874b10-e6cb-4065-8a74-863d4e0dbb40"), "service-desk", null, null, "Tasty Wooden Sausages", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(9488), null, 0.30817278814882637, false, 0.15256623604920053, null, new Guid("c8a136e8-577b-0237-67df-56efa3dbbfcb"), null, 0.12710494f, "Trail", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(9488), null, null },
                    { new Guid("31c77da3-5b49-c8aa-528f-7d48eb751ce3"), "Tools & Electronics", "pixel", "system", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(5262), null, null, false, null, null, new Guid("6d0bccb9-5439-b035-cfe2-8afba9a143e2"), 0.29728857f, 0.898516f, "override", 0.07673655f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(5269), 0.99497880367328362, null },
                    { new Guid("34b5b6c2-b64c-0d84-3236-85d488f92741"), "compressing", null, "vortals", null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4052), null, null, false, 0.1622580597932721, null, new Guid("8c380469-da20-2c57-b71d-959d5622a9ca"), null, 0.7910807f, "Delaware", null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4052), 0.84448512496635553, 0.95907763110430799 },
                    { new Guid("3508a86e-06bc-1032-7aad-1e4b6cb53fb1"), "parsing", "ROI", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(1782), null, null, false, null, null, new Guid("db3a8db6-a245-b773-f5d7-312fc7fb26ba"), null, 0.1597183f, "Games", null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(1783), 0.46615821936454543, 0.27638914123009384 },
                    { new Guid("37ba42b5-a93a-1700-1264-6feb8630b1ad"), "Malaysia", null, null, "granular", new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(2012), null, 0.86359652963634415, false, null, null, new Guid("a1e9ae79-c5ef-fa67-ee4c-152571308b3f"), null, null, "Incredible", 0.094901234f, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(2012), null, 0.87630926998160275 },
                    { new Guid("39ad0d4f-1160-f7a6-59e6-b1f1ccc31818"), "hard drive", "Brook", "Configurable", "Division", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2031), null, 0.63375769771344848, false, null, null, new Guid("aa7c3ba5-126c-e2a4-37ef-8d1003a2cc0e"), null, null, "Strategist", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2032), 0.064117936447317683, null },
                    { new Guid("3a926c3f-4d28-00e8-92f1-eed1e7ee02bb"), "reboot", null, null, null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2690), null, null, true, 0.97387541317095772, null, new Guid("2d0dd14a-51cb-c9f8-a85f-076014ff01e1"), null, null, "Saudi Riyal", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2691), 0.18037515514547711, null },
                    { new Guid("3cfa9f54-6ed8-6bd3-9954-e64c21f7e84c"), "dot-com", "SQL", null, "best-of-breed", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2887), null, 0.99695247039056967, false, null, null, new Guid("5fb73477-b1c7-65f7-af3a-35c199cdbe86"), 0.20352437f, 0.7024504f, "Unbranded", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2888), 0.75500836211955569, null },
                    { new Guid("3d0f0fb8-dd4e-410f-d100-f205c60bad23"), "Liaison", null, "Berkshire", "Cotton", new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(1905), null, null, true, 0.053085654067381124, null, new Guid("306b3cb9-ec5d-fea6-fcf7-e291db2911cf"), null, null, "Assurance", null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(1905), null, 0.72271923661358617 },
                    { new Guid("44a9afd9-cd41-0286-45b9-54737598b70a"), "Bridge", "Credit Card Account", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(3675), null, null, false, null, null, new Guid("809094ca-1942-62ca-f728-b54a1ea2febc"), 0.91640466f, null, "turquoise", 0.091702856f, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(3675), 0.76459043089514156, 0.78185702337969887 },
                    { new Guid("4585e7cb-4e7f-d6f6-84d6-ebd7faf8265d"), "Solutions", "invoice", "Checking Account", "Senior", new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(7023), null, 0.8222299757517082, true, null, null, new Guid("404ac733-b74b-3fde-b462-0c01c351b89a"), 0.37612382f, 0.010608641f, "Reverse-engineered", 0.026072279f, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(7023), 0.71510552787925374, 0.83020041502555852 },
                    { new Guid("473b5293-38a7-9856-b790-e243759025f2"), "withdrawal", null, null, null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(893), null, null, true, null, null, new Guid("2839f2e8-1a35-f860-86b6-19c1a1d27788"), 0.55294734f, 0.23356098f, "Branch", 0.013554017f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(893), 0.04731301034209924, null },
                    { new Guid("49e3b242-d8cf-8c09-c71e-338e44debb81"), "leverage", null, null, null, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6925), null, null, true, 0.78530095181674742, null, new Guid("d0e3c0e5-8580-5cd2-fff6-d283e6b41d91"), 0.6622502f, null, "feed", null, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6926), null, 0.63229017827300826 },
                    { new Guid("4a6f0d83-048c-0bf2-070c-64b0a9372dce"), "synthesize", "transmit", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(1236), null, null, false, 0.71247961032785456, null, new Guid("5fb73477-b1c7-65f7-af3a-35c199cdbe86"), null, null, "Valleys", 0.01033353f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(1237), null, 0.31950711147836741 },
                    { new Guid("4ff922d5-27bf-2e7d-4c43-58567da41101"), "artificial intelligence", "Principal", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6645), null, 0.41501014326466718, false, 0.41059576040627238, null, new Guid("c14aa15d-48e8-e500-e424-7f3d015a584e"), null, 0.77748865f, "New Hampshire", 0.08929571f, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6645), 0.3822849483146728, null },
                    { new Guid("50512acf-ff99-d60c-3a4b-3d80797dba54"), "Integration", "bi-directional", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(2272), null, 0.068868098812582018, true, null, null, new Guid("2d0dd14a-51cb-c9f8-a85f-076014ff01e1"), null, 0.9789238f, "North Korean Won", 0.039935544f, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(2272), null, 0.10801657480561015 },
                    { new Guid("5109ddee-1aec-ad07-17ed-9f2e35d76739"), "teal", null, "Director", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(6823), null, 0.18849397692293579, true, null, null, new Guid("a7b25e73-ccc4-031c-357c-75ded4000e97"), 0.010850302f, 0.7736563f, "mission-critical", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(6825), null, 0.21203409750574925 },
                    { new Guid("5c64f572-a44f-0f02-82f5-e2a45f44755d"), "Investor", "Haven", null, "policy", new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6386), null, null, true, null, null, new Guid("8197f14e-f5ce-88b2-4d80-4746e0a7f2b5"), 0.42195344f, null, "incubate", 0.05718063f, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6386), 0.21129566394318625, 0.098499135625781095 },
                    { new Guid("5d01a66e-1163-4c95-e290-271655fdbcd5"), "withdrawal", "Computers & Grocery", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(7884), null, null, false, null, null, new Guid("5fb73477-b1c7-65f7-af3a-35c199cdbe86"), null, null, "Mountain", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(7884), null, null },
                    { new Guid("5eab708d-974b-0671-4492-3da477d0aa58"), "eyeballs", "Tunisia", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6145), null, null, false, null, null, new Guid("2839f2e8-1a35-f860-86b6-19c1a1d27788"), 0.9356859f, null, "Generic", null, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6145), 0.18550741262059073, null },
                    { new Guid("61bf3c2c-0c99-165f-340a-8266aa70c289"), "Buckinghamshire", null, "markets", "Idaho", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2077), null, null, false, 0.74690545850754975, null, new Guid("889eb714-3e8c-1e2c-54ed-40323924419f"), 0.772648f, null, "Unbranded Frozen Chicken", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2078), null, null },
                    { new Guid("6708c5c3-e5b8-7abb-cea4-dd04e31d0dac"), "Personal Loan Account", "Small Plastic Chips", "programming", "Fresh", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(1074), null, null, false, null, null, new Guid("88672cbf-752f-a74e-d6ce-4543b254e568"), null, null, "Handcrafted Concrete Chips", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(1074), 0.50617390848052402, null },
                    { new Guid("700cb00f-2712-118d-ed96-90978b808015"), "archive", null, "multi-byte", "paradigms", new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(3459), null, 0.76907074207862403, true, null, null, new Guid("6d0bccb9-5439-b035-cfe2-8afba9a143e2"), 0.92132086f, null, "e-tailers", 0.06304538f, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(3460), null, 0.36963068478257893 },
                    { new Guid("70e36954-9a8b-45fd-8e6e-baef79f7af07"), "sexy", "indexing", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(9756), null, null, false, null, null, new Guid("a5202e07-085c-5ace-958e-890551a7adb1"), 0.63296133f, 0.31507972f, "Netherlands", 0.06801763f, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(9756), null, 0.81404722706137567 },
                    { new Guid("72432f74-b1d8-5549-d144-6f56c1548e4a"), "channels", null, "transmitter", "aggregate", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(4692), null, null, false, 0.13924448990227864, null, new Guid("691eb2d6-314c-53c3-3aab-b72e34dd96cf"), null, null, "Producer", 0.016417872f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(4693), null, 0.66763251864706752 },
                    { new Guid("749977f1-2552-c146-a8b9-ebb45e06f1ec"), "Human", "Orchestrator", "Lakes", "hack", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(4031), null, null, true, 0.82157254071048114, null, new Guid("b7550520-ae85-7639-2075-38e37678e19e"), 0.7768616f, null, "navigating", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(4031), null, 0.50030620931661973 },
                    { new Guid("802c4e29-64f8-e7be-91f1-c91bd4eee443"), "Profound", null, null, "sticky", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2413), null, null, true, 0.76183095935817391, null, new Guid("88672cbf-752f-a74e-d6ce-4543b254e568"), null, null, "Steel", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2414), 0.90843228106779617, 0.66624544359103099 },
                    { new Guid("8043f10b-5b07-4a6c-4754-69841be3ebae"), "Executive", null, "Chief", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2138), null, 0.58120674620438684, false, 0.59832232287075482, null, new Guid("db3a8db6-a245-b773-f5d7-312fc7fb26ba"), null, null, "bus", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2139), null, 0.35201585914567851 },
                    { new Guid("80c3a158-8872-fbd2-8037-169529e371a7"), "District", "Fantastic Wooden Salad", "synergies", "Balanced", new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(285), null, 0.15791733244337017, true, null, null, new Guid("2d0dd14a-51cb-c9f8-a85f-076014ff01e1"), null, 0.2072244f, "Tasty Frozen Tuna", null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(286), 0.46960389915369632, 0.30031396043501513 },
                    { new Guid("82c1933e-80bb-b35b-989a-df1ba6be112e"), "communities", null, null, "deposit", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3196), null, 0.18004230790773515, false, 0.33167926470361614, null, new Guid("dd4af1db-de8f-0aa4-a1b2-ed200bd11bdf"), 0.548601f, null, "bus", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3196), 0.514078859013542, 0.081648117900662176 },
                    { new Guid("87661acf-43cf-bee5-937a-18d483042326"), "encompassing", null, "Nigeria", "Rest", new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(1603), null, null, true, 0.84636559935583067, null, new Guid("a5202e07-085c-5ace-958e-890551a7adb1"), null, 0.08486675f, "Wooden", 0.03526826f, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(1603), 0.41699701334209971, null },
                    { new Guid("88483b9c-b461-2cce-61f0-cdc543f18936"), "transmitting", "Down-sized", "revolutionize", "Tasty Rubber Ball", new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(3549), null, 0.88261982979374931, false, 0.95936297018051286, null, new Guid("cc83e122-0410-25ed-c5c8-9ba9f9556e08"), 0.96033967f, null, "Fresh", 0.08056952f, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(3549), 0.041276260764001059, null },
                    { new Guid("8b6c863e-fe88-0858-807f-33eb583aa2ad"), "connecting", null, null, null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2457), null, 0.38687955326721052, false, 0.58393070175495498, null, new Guid("86195222-ff46-1d33-bd92-7ca6d125cdd6"), 0.1255316f, 0.478664f, "fault-tolerant", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2458), 0.66874975975078987, null },
                    { new Guid("8d1fe23a-bc44-27ca-6a17-f8bcbbaab781"), "wireless", "Station", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3126), null, null, true, null, null, new Guid("c14aa15d-48e8-e500-e424-7f3d015a584e"), null, 0.024635866f, "Orchestrator", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3127), null, 0.94108323284475282 },
                    { new Guid("922d313b-b612-a3ba-bf52-6eeba38107d0"), "Movies & Garden", "rich", null, "synthesize", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(964), null, 0.064959122829585852, true, 0.21126253773051432, null, new Guid("691eb2d6-314c-53c3-3aab-b72e34dd96cf"), 0.0074548046f, 0.61610585f, "Corporate", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(964), 0.98200754867028794, null },
                    { new Guid("92948356-c1de-39aa-a681-7f0088c9f331"), "array", "Washington", "copy", "Berkshire", new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(2351), null, 0.68064818190440912, false, 0.23594694362764571, null, new Guid("6d0bccb9-5439-b035-cfe2-8afba9a143e2"), null, 0.30587482f, "COM", null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(2351), null, null },
                    { new Guid("92e412eb-3e87-97a0-d50c-dc99c77f47d0"), "indexing", "Fresh", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(2240), null, 0.97690483460990007, false, 0.20774125503736607, null, new Guid("4b40f938-1581-a32e-a5c0-9c18465de601"), null, null, "Unbranded Rubber Mouse", 0.017251756f, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(2241), 0.84202476024721973, null },
                    { new Guid("94f8373f-f589-6d7f-dba4-1096d92150a3"), "XML", null, "Right-sized", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(9963), null, null, true, null, null, new Guid("a1e9ae79-c5ef-fa67-ee4c-152571308b3f"), null, null, "matrix", 0.07837587f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(9964), null, 0.87302867503512127 },
                    { new Guid("9e5f2b39-8c69-5626-9607-b570e6c1d82c"), "Checking Account", "Refined", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(5767), null, 0.8471974110450583, false, 0.39311196114547176, null, new Guid("de9674f2-7a55-ec71-5f67-8442136b78da"), 0.21228148f, 0.03690901f, "Strategist", 0.043476004f, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(5768), null, 0.34737367106013639 },
                    { new Guid("a145ceeb-7230-65be-2d5d-37e9fec724da"), "Automotive & Home", null, "XSS", null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(3721), null, 0.31578292432976091, false, 0.7825676569633967, null, new Guid("d05e2711-a3ff-4548-bb22-169f4aa0a94c"), null, 0.16118f, "New Mexico", 0.052925617f, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(3722), 0.56106002748061901, null },
                    { new Guid("a43c098b-5e61-7297-b81d-438afe1fa741"), "Assurance", null, null, "Solutions", new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(488), null, 0.82278735461774621, false, null, null, new Guid("917b20df-5c5c-9cb6-9bb9-11a73c3dd3ed"), 0.91197056f, 0.71426004f, "backing up", 0.079594314f, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(489), 0.90835827351936993, null },
                    { new Guid("a4db8a95-96ba-ac42-f313-7c5570f7df83"), "Technician", null, null, "platforms", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(7999), null, 0.22417853643380969, true, 0.5624420980747985, null, new Guid("88672cbf-752f-a74e-d6ce-4543b254e568"), 0.09308405f, null, "leading-edge", 0.09496015f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(7999), null, null },
                    { new Guid("a921c3b2-ca18-03dc-3f62-b3159e7d31bc"), "syndicate", "neutral", null, "Mews", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(566), null, 0.094302273864998606, false, null, null, new Guid("a885d2bb-477d-dfcc-c704-c4a33b6bb471"), null, null, "Handmade Granite Towels", 0.034328274f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(566), null, null },
                    { new Guid("a9ac46b3-c98a-0e31-16a8-a1502dd429a5"), "black", "human-resource", "bandwidth", "Paradigm", new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(3977), null, null, true, null, null, new Guid("6c357dbb-56f6-bcf7-5ccb-cba371a9ede4"), null, null, "haptic", null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(3977), null, 0.49470943794339406 },
                    { new Guid("aa709680-53e7-5ac2-6ce6-416c845cbd75"), "primary", "directional", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6788), null, null, false, null, null, new Guid("c8a136e8-577b-0237-67df-56efa3dbbfcb"), 0.040292643f, null, "programming", 0.06910888f, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6788), 0.22150500035914825, 0.74868001637453219 },
                    { new Guid("aaec3771-b2ad-a65f-8fda-46a7a0b9933a"), "Switzerland", "Investment Account", null, "Lead", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(9353), null, 0.68868470130892689, false, null, null, new Guid("748d4380-0e91-9d9c-2e78-95d4ac9d28bb"), 0.87781817f, 0.35417923f, "Shoes & Books", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(9354), 0.73202959715017568, 0.22301109424932444 },
                    { new Guid("aef94853-9b75-503b-3a90-6b85e81e3456"), "Berkshire", "neural", "hacking", null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(1873), null, 0.81324387333041237, false, null, null, new Guid("88672cbf-752f-a74e-d6ce-4543b254e568"), 0.73416257f, 0.5030575f, "SQL", 0.013365535f, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(1873), 0.68862017602129844, 0.929121428601966 },
                    { new Guid("b24507f5-35d4-be12-cf3b-cf7c6d9af95a"), "SMTP", null, "Facilitator", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(852), null, null, false, null, null, new Guid("d05e2711-a3ff-4548-bb22-169f4aa0a94c"), null, 0.96905625f, "Fantastic Granite Ball", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(852), 0.99211809690674679, 0.31883787145784026 },
                    { new Guid("b2bfb039-f920-c2a5-73f5-e7dacbfc284b"), "cyan", null, "Quality", "Illinois", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3049), null, null, true, 0.089540316764982558, null, new Guid("d0e3c0e5-8580-5cd2-fff6-d283e6b41d91"), 0.0040012337f, 0.5163157f, "Berkshire", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3049), null, 0.4205886975026637 },
                    { new Guid("b55147f9-689f-1f08-bcde-ac858001f7fb"), "green", null, "regional", "auxiliary", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(4657), null, null, true, 0.18295314916547067, null, new Guid("7b9a9dca-645d-654a-4300-bd684865463d"), null, null, "Savings Account", 0.0961621f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(4657), null, null },
                    { new Guid("bd3a574e-d97a-d741-61b8-0d3a8eaa26e1"), "deposit", null, null, null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(2131), null, null, false, 0.029849746744078465, null, new Guid("917b20df-5c5c-9cb6-9bb9-11a73c3dd3ed"), null, null, "Rustic Rubber Chips", 0.09185344f, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(2131), null, null },
                    { new Guid("c0669383-0ba3-2adf-f92f-93fee3b13aa2"), "Fresh", "invoice", null, "Buckinghamshire", new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(9235), null, null, false, 0.45160755442995931, null, new Guid("a7b25e73-ccc4-031c-357c-75ded4000e97"), 0.6313671f, null, "Personal Loan Account", 0.023619546f, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(9235), 0.051681930223331757, null },
                    { new Guid("c13d5b93-08c7-a352-ee4f-114a698e35a5"), "optimal", "user-centric", null, "grow", new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6607), null, 0.85209119452726623, true, 0.73297143621974226, null, new Guid("32db338c-8773-4c58-6d4f-b41193e8d10d"), 0.5459336f, 0.09055306f, "streamline", null, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6607), 0.9488794849947465, null },
                    { new Guid("c1eea81a-6bb7-b79a-35e3-e3d9eec6ef92"), "Harbors", null, null, "Small Granite Salad", new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6187), null, null, false, 0.026930574805909106, null, new Guid("de7f3f06-e8db-44f9-84ce-1d62920309f2"), null, 0.34447715f, "black", null, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6187), null, 0.70034504714437995 },
                    { new Guid("c5ee5b58-0933-b6f7-7fdb-ceac7f164a53"), "Minnesota", null, "Product", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3590), null, null, true, 0.15385847825271007, null, new Guid("6d0bccb9-5439-b035-cfe2-8afba9a143e2"), null, null, "overriding", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3590), 0.75334250310125872, 0.34879254379719149 },
                    { new Guid("d22c2bdd-415d-9d4a-e175-07469731f4fe"), "sensor", "program", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3272), null, null, true, 0.7239582821372702, null, new Guid("dd4af1db-de8f-0aa4-a1b2-ed200bd11bdf"), 0.7954853f, null, "embrace", 0.008742437f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3273), 0.3868988777449815, null },
                    { new Guid("d391b310-af6b-a823-40d5-8dfd0255a288"), "sticky", "Accounts", null, "even-keeled", new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6892), null, null, false, 0.66736245232977087, null, new Guid("db3a8db6-a245-b773-f5d7-312fc7fb26ba"), 0.4691677f, 0.0075491443f, "Markets", 0.041865826f, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6893), null, 0.81019146591899516 },
                    { new Guid("d8b3a24b-976a-867e-ef52-9df018b0aadd"), "neural", null, "Outdoors & Beauty", null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(3799), null, null, false, null, null, new Guid("23b45705-1d18-3ae3-b8ec-135857a817d6"), null, 0.5839274f, "extend", 0.027351128f, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(3799), null, 0.21402598648053872 },
                    { new Guid("dc0658e9-191f-6d25-acd1-4749107003b2"), "Parkways", "Handmade", null, "Assurance", new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4118), null, null, false, 0.99991400912400052, null, new Guid("5ac17955-22ae-3b7d-3954-a3096d334f67"), 0.7999671f, 0.1258428f, "AI", 0.030074848f, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4118), null, null },
                    { new Guid("dc385660-0b88-05c3-644e-78f9da01e8ed"), "Accounts", "purple", "Open-source", null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(3507), null, 0.21141843181635181, false, 0.41737442110542877, null, new Guid("d05e2711-a3ff-4548-bb22-169f4aa0a94c"), null, null, "Avenue", 0.02432123f, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(3507), 0.89630971285342687, null },
                    { new Guid("e7b06da8-76cd-1a20-8acc-a9abf91e0247"), "Fantastic Soft Salad", "moderator", null, "GB", new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(1519), null, 0.41217287788734441, false, 0.15627172456880645, null, new Guid("5fb73477-b1c7-65f7-af3a-35c199cdbe86"), null, null, "neural-net", null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(1519), 0.81156511223482208, 0.91112290830869358 },
                    { new Guid("eb1d2ebe-6771-624e-8e91-fac3799d5eb6"), "Frozen", null, "rich", null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4084), null, null, true, null, null, new Guid("4b40f938-1581-a32e-a5c0-9c18465de601"), null, 0.16863547f, "override", 0.068753384f, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(4084), null, null },
                    { new Guid("ebaf8c61-ad04-4918-5d28-bcf10d3982ae"), "system-worthy", "Prairie", "Kids & Games", "matrix", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2498), null, null, true, null, null, new Guid("1a14120b-e568-5fba-0e83-30b0bf29f0a4"), 0.40839836f, 0.9469648f, "customer loyalty", 0.00042078207f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(2498), 0.83068608158765644, null },
                    { new Guid("ec690af8-8c10-b539-d705-ad830e4db969"), "Missouri", "Rustic", "indexing", "Vista", new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(2210), null, 0.86133399971822933, false, null, null, new Guid("691eb2d6-314c-53c3-3aab-b72e34dd96cf"), 0.21005455f, null, "red", null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(2210), null, 0.082318278999216052 },
                    { new Guid("edd7ea30-67c0-3cc4-364e-6083da127133"), "Strategist", "withdrawal", "drive", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(5768), null, 0.14616066177662493, false, 0.82839858104865927, null, new Guid("4b40f938-1581-a32e-a5c0-9c18465de601"), null, 0.9549465f, "one-to-one", 0.0843728f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(5770), null, 0.52911124635912066 },
                    { new Guid("f1db1fba-177b-638e-c8fd-0da8cb3163b3"), "application", "matrix", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(2050), null, 0.029867736636599404, false, null, null, new Guid("8d4ac50d-6d42-2869-62dd-4cb30cbf2a7f"), null, 0.93204963f, "Borders", 0.07598693f, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(2051), 0.72050517691322846, null },
                    { new Guid("f404757d-3725-b76d-d18c-e9a4faa884e4"), "solution-oriented", "e-business", "Credit Card Account", "Buckinghamshire", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3088), null, 0.2694801559063979, true, 0.33658437958759457, null, new Guid("d7aee5e8-33a4-4341-bb6b-9f2b082704f9"), 0.95472527f, 0.18236631f, "calculate", 0.0786979f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(3088), 0.084904092869211037, null },
                    { new Guid("f68355fd-6df7-29bd-605d-320b3c9ca622"), "Garden", "tan", "Village", null, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6001), null, 0.48991040815129427, false, null, null, new Guid("a885d2bb-477d-dfcc-c704-c4a33b6bb471"), 0.65996826f, 0.30638018f, "Borders", 0.012293015f, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6001), 0.61296149511493814, 0.80127031765937351 },
                    { new Guid("f75b3b0d-5b6d-2c3d-5b92-4d0841ec7afe"), "Dynamic", null, "Generic", null, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6828), null, null, true, null, null, new Guid("db3a8db6-a245-b773-f5d7-312fc7fb26ba"), 0.8696756f, null, "Eritrea", null, new DateTime(2024, 9, 21, 3, 44, 6, 204, DateTimeKind.Utc).AddTicks(6828), 0.27546825319317553, 0.58284018634950752 },
                    { new Guid("f78c59e6-494b-c805-c711-4a0681009db9"), "synergy", "Producer", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(1640), null, null, true, null, null, new Guid("5678d654-4e49-7902-3c3d-e751477748a8"), 0.351066f, 0.06819195f, "Minnesota", 0.026847761f, new DateTime(2024, 9, 21, 3, 44, 6, 206, DateTimeKind.Utc).AddTicks(1640), null, 0.7991328541185394 },
                    { new Guid("f895f304-6174-e670-0a8c-784583b1ad35"), "Extensions", "solutions", null, null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(6237), null, null, true, 0.21374615664302657, null, new Guid("691eb2d6-314c-53c3-3aab-b72e34dd96cf"), null, null, "Engineer", 0.088105574f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(6238), 0.63200553489476696, null },
                    { new Guid("fa618566-2596-2412-395c-aa201c5a95c3"), "Row", null, null, null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(262), null, null, false, 0.57252133384930037, null, new Guid("a7b25e73-ccc4-031c-357c-75ded4000e97"), 0.6411824f, 0.8656147f, "experiences", 0.073623374f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(262), null, 0.057598015320300129 },
                    { new Guid("fdb672fd-d4af-7d87-2144-d0ff3965cfe9"), "Kenyan Shilling", null, null, "Parks", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(9022), null, 0.38338077738107218, true, 0.79692178489497012, null, new Guid("889eb714-3e8c-1e2c-54ed-40323924419f"), null, null, "Steel", null, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(9023), 0.27739981202287589, null },
                    { new Guid("ff19fe0d-26c1-ef83-7d4c-f4192bd513e8"), "empower", null, "Industrial, Sports & Home", "CSS", new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(7774), null, 0.98724912758322858, false, null, null, new Guid("ac4db52d-1c01-cf30-2e01-30c89033e78d"), null, null, "olive", 0.017863065f, new DateTime(2024, 9, 21, 3, 44, 6, 205, DateTimeKind.Utc).AddTicks(7775), null, null }
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
                name: "ix_client_companyid",
                table: "client",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "ix_client_createduserid",
                table: "client",
                column: "createduserid");

            migrationBuilder.CreateIndex(
                name: "ix_client_modifieduserid",
                table: "client",
                column: "modifieduserid");

            migrationBuilder.CreateIndex(
                name: "ix_companycourier_companyid",
                table: "companycourier",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "ix_companycourier_createduserid",
                table: "companycourier",
                column: "createduserid");

            migrationBuilder.CreateIndex(
                name: "ix_companycourier_modifieduserid",
                table: "companycourier",
                column: "modifieduserid");

            migrationBuilder.CreateIndex(
                name: "ix_companypermission_companyid",
                table: "companypermission",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "ix_companyplatform_companyid",
                table: "companyplatform",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "ix_companyplatform_createduserid",
                table: "companyplatform",
                column: "createduserid");

            migrationBuilder.CreateIndex(
                name: "ix_companyplatform_modifieduserid",
                table: "companyplatform",
                column: "modifieduserid");

            migrationBuilder.CreateIndex(
                name: "ix_inventory_companyid",
                table: "inventory",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "ix_inventory_createduserid",
                table: "inventory",
                column: "createduserid");

            migrationBuilder.CreateIndex(
                name: "ix_inventory_modifieduserid",
                table: "inventory",
                column: "modifieduserid");

            migrationBuilder.CreateIndex(
                name: "ix_inventory_productvariantid",
                table: "inventory",
                column: "productvariantid");

            migrationBuilder.CreateIndex(
                name: "ix_inventory_rackid",
                table: "inventory",
                column: "rackid");

            migrationBuilder.CreateIndex(
                name: "ix_location_companyid",
                table: "location",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "ix_location_createduserid",
                table: "location",
                column: "createduserid");

            migrationBuilder.CreateIndex(
                name: "ix_location_modifieduserid",
                table: "location",
                column: "modifieduserid");

            migrationBuilder.CreateIndex(
                name: "ix_notification_userid",
                table: "notification",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "ix_order_clientid",
                table: "order",
                column: "clientid");

            migrationBuilder.CreateIndex(
                name: "ix_order_companyid",
                table: "order",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "ix_order_courierid",
                table: "order",
                column: "courierid");

            migrationBuilder.CreateIndex(
                name: "ix_order_createduserid",
                table: "order",
                column: "createduserid");

            migrationBuilder.CreateIndex(
                name: "ix_order_modifieduserid",
                table: "order",
                column: "modifieduserid");

            migrationBuilder.CreateIndex(
                name: "ix_order_platformid",
                table: "order",
                column: "platformid");

            migrationBuilder.CreateIndex(
                name: "ix_order_shippingoptionid",
                table: "order",
                column: "shippingoptionid");

            migrationBuilder.CreateIndex(
                name: "ix_orderhistory_orderid",
                table: "orderhistory",
                column: "orderid");

            migrationBuilder.CreateIndex(
                name: "ix_orderhistory_userid",
                table: "orderhistory",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "ix_orderitem_orderid",
                table: "orderitem",
                column: "orderid");

            migrationBuilder.CreateIndex(
                name: "ix_orderitem_productvariantid",
                table: "orderitem",
                column: "productvariantid");

            migrationBuilder.CreateIndex(
                name: "ix_platformcourier_courierid",
                table: "platformcourier",
                column: "courierid");

            migrationBuilder.CreateIndex(
                name: "ix_platformcourier_platformid",
                table: "platformcourier",
                column: "platformid");

            migrationBuilder.CreateIndex(
                name: "ix_product_companyid",
                table: "product",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "ix_product_createduserid",
                table: "product",
                column: "createduserid");

            migrationBuilder.CreateIndex(
                name: "ix_product_modifieduserid",
                table: "product",
                column: "modifieduserid");

            migrationBuilder.CreateIndex(
                name: "ix_product_supplierid",
                table: "product",
                column: "supplierid");

            migrationBuilder.CreateIndex(
                name: "ix_productbundle_createduserid",
                table: "productbundle",
                column: "createduserid");

            migrationBuilder.CreateIndex(
                name: "ix_productbundle_modifieduserid",
                table: "productbundle",
                column: "modifieduserid");

            migrationBuilder.CreateIndex(
                name: "ix_productbundle_productvariantid",
                table: "productbundle",
                column: "productvariantid");

            migrationBuilder.CreateIndex(
                name: "ix_producthistory_productid",
                table: "producthistory",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_producthistory_userid",
                table: "producthistory",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "ix_productvariant_createduserid",
                table: "productvariant",
                column: "createduserid");

            migrationBuilder.CreateIndex(
                name: "ix_productvariant_modifieduserid",
                table: "productvariant",
                column: "modifieduserid");

            migrationBuilder.CreateIndex(
                name: "ix_productvariant_productid",
                table: "productvariant",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorder_companyid",
                table: "purchaseorder",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorder_createduserid",
                table: "purchaseorder",
                column: "createduserid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorder_locationid",
                table: "purchaseorder",
                column: "locationid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorder_modifieduserid",
                table: "purchaseorder",
                column: "modifieduserid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorder_supplierid",
                table: "purchaseorder",
                column: "supplierid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorderhistory_purchaseorderid",
                table: "purchaseorderhistory",
                column: "purchaseorderid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorderhistory_userid",
                table: "purchaseorderhistory",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorderitem_productvariantid",
                table: "purchaseorderitem",
                column: "productvariantid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorderitem_purchaseorderid",
                table: "purchaseorderitem",
                column: "purchaseorderid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaserequest_companyid",
                table: "purchaserequest",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaserequest_createduserid",
                table: "purchaserequest",
                column: "createduserid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaserequest_modifieduserid",
                table: "purchaserequest",
                column: "modifieduserid");

            migrationBuilder.CreateIndex(
                name: "ix_rack_createduserid",
                table: "rack",
                column: "createduserid");

            migrationBuilder.CreateIndex(
                name: "ix_rack_locationid",
                table: "rack",
                column: "locationid");

            migrationBuilder.CreateIndex(
                name: "ix_rack_modifieduserid",
                table: "rack",
                column: "modifieduserid");

            migrationBuilder.CreateIndex(
                name: "ix_shippingoption_courierid",
                table: "shippingoption",
                column: "courierid");

            migrationBuilder.CreateIndex(
                name: "ix_supplier_companyid",
                table: "supplier",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "ix_supplier_createduserid",
                table: "supplier",
                column: "createduserid");

            migrationBuilder.CreateIndex(
                name: "ix_supplier_modifieduserid",
                table: "supplier",
                column: "modifieduserid");

            migrationBuilder.CreateIndex(
                name: "ix_tote_createduserid",
                table: "tote",
                column: "createduserid");

            migrationBuilder.CreateIndex(
                name: "ix_tote_locationid",
                table: "tote",
                column: "locationid");

            migrationBuilder.CreateIndex(
                name: "ix_tote_modifieduserid",
                table: "tote",
                column: "modifieduserid");

            migrationBuilder.CreateIndex(
                name: "ix_userpermission_createduserid",
                table: "userpermission",
                column: "createduserid");

            migrationBuilder.CreateIndex(
                name: "ix_userpermission_modifieduserid",
                table: "userpermission",
                column: "modifieduserid");

            migrationBuilder.CreateIndex(
                name: "ix_userpermission_userid",
                table: "userpermission",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "ix_userpreference_userid",
                table: "userpreference",
                column: "userid");
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
                name: "companycourier");

            migrationBuilder.DropTable(
                name: "companypermission");

            migrationBuilder.DropTable(
                name: "companyplatform");

            migrationBuilder.DropTable(
                name: "inventory");

            migrationBuilder.DropTable(
                name: "notification");

            migrationBuilder.DropTable(
                name: "orderhistory");

            migrationBuilder.DropTable(
                name: "orderitem");

            migrationBuilder.DropTable(
                name: "permissiontype");

            migrationBuilder.DropTable(
                name: "platformcourier");

            migrationBuilder.DropTable(
                name: "productbundle");

            migrationBuilder.DropTable(
                name: "producthistory");

            migrationBuilder.DropTable(
                name: "purchaseorderhistory");

            migrationBuilder.DropTable(
                name: "purchaseorderitem");

            migrationBuilder.DropTable(
                name: "purchaserequest");

            migrationBuilder.DropTable(
                name: "tote");

            migrationBuilder.DropTable(
                name: "userpermission");

            migrationBuilder.DropTable(
                name: "userpreference");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "rack");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "productvariant");

            migrationBuilder.DropTable(
                name: "purchaseorder");

            migrationBuilder.DropTable(
                name: "client");

            migrationBuilder.DropTable(
                name: "platform");

            migrationBuilder.DropTable(
                name: "shippingoption");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "location");

            migrationBuilder.DropTable(
                name: "courier");

            migrationBuilder.DropTable(
                name: "supplier");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "company");
        }
    }
}
