using System.ComponentModel.DataAnnotations;

namespace WMS_backend.Models.Enums
{
    public enum EnumPermissionType
    {
        //[Display(GroupName = "Dashboard", Description = "/dashboard/root", ShortName = "all")]
        //Dashboard = 1,
        [Display(GroupName = "Order", Description = "/dashboard/order/order")]
        Order = 4,
        [Display(GroupName = "Inbound", Description = "/dashboard/inbound/inbound")]
        Inbound = 13,
        [Display(GroupName = "Inbound", Description = "/dashboard/inbound/putaway")]
        Putaway = 20,
        [Display(GroupName = "Inbound", Description = "/dashboard/inbound/quality")]
        Quality = 30,
        [Display(GroupName = "Outbound", Description = "/dashboard/outbound/outbound")]
        Outbound = 40,
        [Display(GroupName = "Outbound", Description = "/dashboard/outbound/picking")]
        Picking = 50,
        [Display(GroupName = "Outbound", Description = "/dashboard/outbound/packing")]
        Packing = 60,
        [Display(GroupName = "Outbound", Description = "/dashboard/outbound/shipping")]
        Shipping = 70,
        [Display(GroupName = "Inventory", Description = "/dashboard/inventory/product")]
        Product = 80,
        [Display(GroupName = "Inventory", Description = "/dashboard/inventory/stock")]
        Stock = 90,
        [Display(GroupName = "Inventory", Description = "/dashboard/inventory/location")]
        Location = 95,
        [Display(GroupName = "Purchasing", Description = "/dashboard/purchasing/purchase-order")]
        PurchaseOrder = 100,
        [Display(GroupName = "Purchasing", Description = "/dashboard/purchasing/purchase-request")]
        PurchaseRequest = 110,
        [Display(GroupName = "Purchasing", Description = "/dashboard/purchasing/supplier")]
        Supplier = 120,
        [Display(GroupName = "Report", Description = "/dashboard/report/order")]
        ReportOrder = 130,
        [Display(GroupName = "Report", Description = "/dashboard/report/purchase-order")]
        ReportPurchaseOrder = 140,
        [Display(GroupName = "Report", Description = "/dashboard/report/inventory")]
        ReportInventory = 150,
        //[Display(GroupName = "Setting", Description = "/dashboard/setting/preference", ShortName = "all")]
        //UserPreference = 160,
        [Display(GroupName = "Setting", Description = "/dashboard/setting/company")]
        ManageCompany = 170,
        [Display(GroupName = "Setting", Description = "/dashboard/setting/team")]
        ManageTeam = 180,



    }
}
