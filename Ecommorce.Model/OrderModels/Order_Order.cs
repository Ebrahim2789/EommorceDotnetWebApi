using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Ecommorce.Model.ProductModels;

namespace Ecommorce.Model.OrderModels
{
    public class Order : Common
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int OrderNo { get; set; }
        public int CustomerId { get; set; }
        public int MerchantId { get; set; }
        public int ShippingAddressId { get; set; }
        public int OrderStatus { get; set; }
        public required string PaymentType { get; set; }
        public int ShippingStatusint { get; set; }
        public DateTime ShippedOn { get; set; }
        public DateTime DeliveredOn { get; set; }
        public DateTime DeliveredEndOn { get; set; }
        public int RefundStatus { get; set; }
        public required string RefundReason { get; set; }
        public DateTime RefundOn { get; set; }
        public decimal RefundAmount { get; set; }
        public required string ShippingMethod { get; set; }
        public required string PaymentMethod { get; set; }
        public decimal PaymentFeeAmount { get; set; }

        public DateTime PaymentOn { get; set; }
        public DateTime PaymentEndOn { get; set; }
        public decimal SubTotal { get; set; }
        public decimal SubTotalWithDiscount { get; set; }
        public decimal OrderTotal { get; set; }
        public decimal DiscountAmount { get; set; }
        public required string OrderNote { get; set; }
        public required string AdminNote { get; set; }
        public required string CancelReason { get; set; }
        public required string OnHoldReason { get; set; }
        public DateTime CancelOn { get; set; }
        public int CreatedById { get; set; }
        public int UpdatedById { get; set; }

        public virtual required ICollection<OrderItem> OrderItems { get; set; }



    }

}
