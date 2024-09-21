﻿using System.ComponentModel.DataAnnotations.Schema;

namespace WMS_backend.Models.DBModels
{
    public class PurchaseOrderItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PurchaseOrderItemId { get; set; }
        public Guid ProductVariantId { get; set; }
        public Guid PurchaseOrderId { get; set; }
        public int Quantity { get; set; }
        public virtual ProductVariant ProductVariant { get; set; }
        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }
}
