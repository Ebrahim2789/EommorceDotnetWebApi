using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Ecommorce.Model.ProductModels
{
    public class Order_OrderItem : Common
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductName { get; set; }
        public string ProductMediaUrl { get; set; }
        public int Quantity { get; set; }
        public int ShippedQuantity { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal ItemAmount { get; set; }
        public decimal ItemWeight { get; set; }
        public string Note { get; set; }
        public string CreatedById { get; set; }
        public string UpdatedById { get; set; }




    }

}
