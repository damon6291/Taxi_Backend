using System.ComponentModel.DataAnnotations;

namespace WMS_backend.Models.Enums
{
    public enum EnumPermissionType
    {
        //Dashboard = 1,
        Order = 4,
        Inbound = 13,
        Putaway = 20,
        Quality = 30,
        Outbound = 40,
        Picking = 50,
        Packing = 60,
        Shipping = 70,
        Product = 80,
        Stock = 90,
        Location = 95,
        PurchaseOrder = 100,
        PurchaseRequest = 110,
        Supplier = 120,
        ReportOrder = 130,
        ReportPurchaseOrder = 140,
        ReportInventory = 150,
        //UserPreference = 160,
        ManageCompany = 170,
        ManageTeam = 180,



    }
}
