using System.ComponentModel.DataAnnotations.Schema;

namespace WMS_backend.Models.DBModels
{
    public class ProductBundle : Crudable
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ProductBundleId { get; set; }
        public Guid ProductVariantId { get; set; }
        public virtual ProductVariant ProductVariant { get; set; }
    }
}
