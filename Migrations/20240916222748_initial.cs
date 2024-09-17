using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WMS_backend.Migrations
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
                name: "company",
                columns: table => new
                {
                    companyid = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    address = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    contact = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    phone = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    isarchived = table.Column<bool>(type: "boolean", nullable: false),
                    createddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_company", x => x.companyid);
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
                    createddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modifieddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modifieduserid = table.Column<long>(type: "bigint", nullable: true),
                    companyid = table.Column<long>(type: "bigint", nullable: true),
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
                    companypermissionid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
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
                name: "location",
                columns: table => new
                {
                    locationid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    address = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    phone = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    locationtype = table.Column<int>(type: "integer", nullable: false),
                    isarchived = table.Column<bool>(type: "boolean", nullable: false),
                    companyid = table.Column<long>(type: "bigint", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "supplier",
                columns: table => new
                {
                    supplierid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    address = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    contact = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    phone = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    isarchived = table.Column<bool>(type: "boolean", nullable: false),
                    companyid = table.Column<long>(type: "bigint", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "team",
                columns: table => new
                {
                    teamid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    isarchived = table.Column<bool>(type: "boolean", nullable: false),
                    companyid = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_team", x => x.teamid);
                    table.ForeignKey(
                        name: "fk_team_company_companyid",
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
                name: "userpermission",
                columns: table => new
                {
                    userpermissionid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    userid = table.Column<long>(type: "bigint", nullable: false),
                    permissiontype = table.Column<int>(type: "integer", nullable: false),
                    iscrud = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_userpermission", x => x.userpermissionid);
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
                    userpreferenceid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
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
                name: "rack",
                columns: table => new
                {
                    rackid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    xslotmax = table.Column<int>(type: "integer", nullable: false),
                    yslotmax = table.Column<int>(type: "integer", nullable: false),
                    isarchived = table.Column<bool>(type: "boolean", nullable: false),
                    loactionid = table.Column<Guid>(type: "uuid", nullable: false),
                    locationid = table.Column<Guid>(type: "uuid", nullable: false)
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
                });

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

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    productid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    sku = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    barcode = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    barcode1 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    barcode2 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    barcode3 = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    width = table.Column<double>(type: "double precision", nullable: true),
                    length = table.Column<double>(type: "double precision", nullable: true),
                    height = table.Column<double>(type: "double precision", nullable: true),
                    weight = table.Column<double>(type: "double precision", nullable: true),
                    purchaseprice = table.Column<float>(type: "real", nullable: false),
                    retailprice = table.Column<float>(type: "real", nullable: false),
                    taxrate = table.Column<float>(type: "real", nullable: false),
                    isarchived = table.Column<bool>(type: "boolean", nullable: false),
                    supplierid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_product", x => x.productid);
                    table.ForeignKey(
                        name: "fk_product_supplier_supplierid",
                        column: x => x.supplierid,
                        principalTable: "supplier",
                        principalColumn: "supplierid");
                });

            migrationBuilder.CreateTable(
                name: "purchaseorder",
                columns: table => new
                {
                    purchaseorderid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    purchaseordernumber = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    postatus = table.Column<int>(type: "integer", nullable: false),
                    locationid = table.Column<Guid>(type: "uuid", nullable: false),
                    supplierid = table.Column<Guid>(type: "uuid", nullable: false),
                    userid = table.Column<long>(type: "bigint", nullable: false),
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
                    createddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modifieddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchaseorder", x => x.purchaseorderid);
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
                        name: "fk_purchaseorder_users_userid",
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
                    userid = table.Column<long>(type: "bigint", nullable: false),
                    teamid = table.Column<Guid>(type: "uuid", nullable: false),
                    messagetoteam = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    isarchived = table.Column<bool>(type: "boolean", nullable: false),
                    staus = table.Column<int>(type: "integer", nullable: false),
                    messagefromteam = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    createddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchaserequest", x => x.purchaserequestid);
                    table.ForeignKey(
                        name: "fk_purchaserequest_team_teamid",
                        column: x => x.teamid,
                        principalTable: "team",
                        principalColumn: "teamid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaserequest_users_userid",
                        column: x => x.userid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teamuser",
                columns: table => new
                {
                    teamuserid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    userid = table.Column<long>(type: "bigint", nullable: false),
                    teamid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_teamuser", x => x.teamuserid);
                    table.ForeignKey(
                        name: "fk_teamuser_team_teamid",
                        column: x => x.teamid,
                        principalTable: "team",
                        principalColumn: "teamid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_teamuser_users_userid",
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
                    productid = table.Column<Guid>(type: "uuid", nullable: false),
                    rackid = table.Column<Guid>(type: "uuid", nullable: false),
                    xslot = table.Column<int>(type: "integer", nullable: false),
                    yslot = table.Column<int>(type: "integer", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    expirationdate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    userid = table.Column<long>(type: "bigint", nullable: false),
                    createddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modifieddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_inventory", x => x.inventoryid);
                    table.ForeignKey(
                        name: "fk_inventory_product_productid",
                        column: x => x.productid,
                        principalTable: "product",
                        principalColumn: "productid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_inventory_rack_rackid",
                        column: x => x.rackid,
                        principalTable: "rack",
                        principalColumn: "rackid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_inventory_users_userid",
                        column: x => x.userid,
                        principalTable: "AspNetUsers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchaseorderitem",
                columns: table => new
                {
                    purchaseorderitemid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    productid = table.Column<Guid>(type: "uuid", nullable: false),
                    purchaseorderid = table.Column<Guid>(type: "uuid", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchaseorderitem", x => x.purchaseorderitemid);
                    table.ForeignKey(
                        name: "fk_purchaseorderitem_product_productid",
                        column: x => x.productid,
                        principalTable: "product",
                        principalColumn: "productid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseorderitem_purchaseorder_purchaseorderid",
                        column: x => x.purchaseorderid,
                        principalTable: "purchaseorder",
                        principalColumn: "purchaseorderid",
                        onDelete: ReferentialAction.Cascade);
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
                name: "ix_aspnetusers_modifieduserid",
                table: "AspNetUsers",
                column: "modifieduserid");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "normalizedusername",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_companypermission_companyid",
                table: "companypermission",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "ix_inventory_productid",
                table: "inventory",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_inventory_rackid",
                table: "inventory",
                column: "rackid");

            migrationBuilder.CreateIndex(
                name: "ix_inventory_userid",
                table: "inventory",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "ix_location_companyid",
                table: "location",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "ix_notification_userid",
                table: "notification",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "ix_product_supplierid",
                table: "product",
                column: "supplierid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorder_locationid",
                table: "purchaseorder",
                column: "locationid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorder_supplierid",
                table: "purchaseorder",
                column: "supplierid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorder_userid",
                table: "purchaseorder",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorderitem_productid",
                table: "purchaseorderitem",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorderitem_purchaseorderid",
                table: "purchaseorderitem",
                column: "purchaseorderid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaserequest_teamid",
                table: "purchaserequest",
                column: "teamid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaserequest_userid",
                table: "purchaserequest",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "ix_rack_locationid",
                table: "rack",
                column: "locationid");

            migrationBuilder.CreateIndex(
                name: "ix_supplier_companyid",
                table: "supplier",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "ix_team_companyid",
                table: "team",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "ix_teamuser_teamid",
                table: "teamuser",
                column: "teamid");

            migrationBuilder.CreateIndex(
                name: "ix_teamuser_userid",
                table: "teamuser",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "ix_tote_locationid",
                table: "tote",
                column: "locationid");

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
                name: "companypermission");

            migrationBuilder.DropTable(
                name: "inventory");

            migrationBuilder.DropTable(
                name: "notification");

            migrationBuilder.DropTable(
                name: "permissiontype");

            migrationBuilder.DropTable(
                name: "purchaseorderitem");

            migrationBuilder.DropTable(
                name: "purchaserequest");

            migrationBuilder.DropTable(
                name: "teamuser");

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
                name: "product");

            migrationBuilder.DropTable(
                name: "purchaseorder");

            migrationBuilder.DropTable(
                name: "team");

            migrationBuilder.DropTable(
                name: "location");

            migrationBuilder.DropTable(
                name: "supplier");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "company");
        }
    }
}
