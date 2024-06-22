using System;
using Microsoft.EntityFrameworkCore.Migrations;

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
                name: "company",
                columns: table => new
                {
                    companyid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
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
                name: "companypermission",
                columns: table => new
                {
                    companypermissionid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    companyid = table.Column<Guid>(type: "uuid", nullable: false),
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
                    companyid = table.Column<Guid>(type: "uuid", nullable: false)
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
                name: "team",
                columns: table => new
                {
                    teamid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    isarchived = table.Column<bool>(type: "boolean", nullable: false),
                    companyid = table.Column<Guid>(type: "uuid", nullable: false)
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
                name: "user",
                columns: table => new
                {
                    userid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    passwordhash = table.Column<byte[]>(type: "bytea", nullable: true),
                    passwordsalt = table.Column<byte[]>(type: "bytea", nullable: true),
                    isarchived = table.Column<bool>(type: "boolean", nullable: false),
                    firstname = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    lastname = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    phone = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    lastlogindatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    createddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modifieddatetime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    modifieduserid = table.Column<Guid>(type: "uuid", nullable: true),
                    companyid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user", x => x.userid);
                    table.ForeignKey(
                        name: "fk_user_company_companyid",
                        column: x => x.companyid,
                        principalTable: "company",
                        principalColumn: "companyid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_user_modifieduserid",
                        column: x => x.modifieduserid,
                        principalTable: "user",
                        principalColumn: "userid");
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
                    teamid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_supplier", x => x.supplierid);
                    table.ForeignKey(
                        name: "fk_supplier_team_teamid",
                        column: x => x.teamid,
                        principalTable: "team",
                        principalColumn: "teamid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teamlocation",
                columns: table => new
                {
                    teamlocationid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    teamid = table.Column<Guid>(type: "uuid", nullable: false),
                    locationid = table.Column<Guid>(type: "uuid", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "notification",
                columns: table => new
                {
                    notificationid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    notificationtype = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    isarchived = table.Column<bool>(type: "boolean", nullable: false),
                    userid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_notification", x => x.notificationid);
                    table.ForeignKey(
                        name: "fk_notification_user_userid",
                        column: x => x.userid,
                        principalTable: "user",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchaserequest",
                columns: table => new
                {
                    purchaserequestid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    userid = table.Column<Guid>(type: "uuid", nullable: false),
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
                        name: "fk_purchaserequest_user_userid",
                        column: x => x.userid,
                        principalTable: "user",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "teamuser",
                columns: table => new
                {
                    teamuserid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    userid = table.Column<Guid>(type: "uuid", nullable: false),
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
                        name: "fk_teamuser_user_userid",
                        column: x => x.userid,
                        principalTable: "user",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userpermission",
                columns: table => new
                {
                    userpermissionid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    userid = table.Column<Guid>(type: "uuid", nullable: false),
                    permissiontype = table.Column<int>(type: "integer", nullable: false),
                    iscrud = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_userpermission", x => x.userpermissionid);
                    table.ForeignKey(
                        name: "fk_userpermission_user_userid",
                        column: x => x.userid,
                        principalTable: "user",
                        principalColumn: "userid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userpreference",
                columns: table => new
                {
                    userpreferenceid = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    userid = table.Column<Guid>(type: "uuid", nullable: false),
                    preferencetype = table.Column<int>(type: "integer", nullable: false),
                    value = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_userpreference", x => x.userpreferenceid);
                    table.ForeignKey(
                        name: "fk_userpreference_user_userid",
                        column: x => x.userid,
                        principalTable: "user",
                        principalColumn: "userid",
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
                    userid = table.Column<Guid>(type: "uuid", nullable: false),
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
                        name: "fk_purchaseorder_user_userid",
                        column: x => x.userid,
                        principalTable: "user",
                        principalColumn: "userid",
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
                    userid = table.Column<Guid>(type: "uuid", nullable: false),
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
                        name: "fk_inventory_user_userid",
                        column: x => x.userid,
                        principalTable: "user",
                        principalColumn: "userid",
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
                name: "ix_supplier_teamid",
                table: "supplier",
                column: "teamid");

            migrationBuilder.CreateIndex(
                name: "ix_team_companyid",
                table: "team",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "ix_teamlocation_locationid",
                table: "teamlocation",
                column: "locationid");

            migrationBuilder.CreateIndex(
                name: "ix_teamlocation_teamid",
                table: "teamlocation",
                column: "teamid");

            migrationBuilder.CreateIndex(
                name: "ix_teamuser_teamid",
                table: "teamuser",
                column: "teamid");

            migrationBuilder.CreateIndex(
                name: "ix_teamuser_userid",
                table: "teamuser",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "ix_user_companyid",
                table: "user",
                column: "companyid");

            migrationBuilder.CreateIndex(
                name: "ix_user_modifieduserid",
                table: "user",
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
                name: "teamlocation");

            migrationBuilder.DropTable(
                name: "teamuser");

            migrationBuilder.DropTable(
                name: "userpermission");

            migrationBuilder.DropTable(
                name: "userpreference");

            migrationBuilder.DropTable(
                name: "rack");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "purchaseorder");

            migrationBuilder.DropTable(
                name: "location");

            migrationBuilder.DropTable(
                name: "supplier");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "team");

            migrationBuilder.DropTable(
                name: "company");
        }
    }
}
