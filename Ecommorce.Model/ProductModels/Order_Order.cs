namespace Ecommorce.Model.ProductModels
{
    public class Order_Order
    {
        public int Id { get; set; }
        public int OrderNo { get; set; }
        public int CustomerId { get; set; }
        public int MerchantId { get; set; }
        public int ShippingAddressId { get; set; }
        public string OrderStatus { get; set; }
        public string PaymentType { get; set; }
        public string ShippingStatusint { get; set; }
        public string ShippedOn { get; set; }
        public string DeliveredOn { get; set; }
        public string DeliveredEndOn  { get; set; }
        public string RefundStatus { get; set; }
        public string RefundReason { get; set; }
        public string RefundOn { get; set; }
        public string RefundAmount { get; set; }
        public string ShippingMethod { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentFeeAmount { get; set; }
        public string PaymentOn { get; set; }
        public string PaymentEndOn { get; set; }
        public string SubTotal { get; set; }
        public string SubTotalWithDiscount { get; set; }
        public string OrderTotal { get; set; }
        public string DiscountAmount { get; set; }
        public string OrderNote { get; set; }
        public string AdminNote { get; set; }
        public string CancelReason { get; set; }
        public string OnHoldReason { get; set; }
        public string CancelOn { get; set; }
        public string CreatedById { get; set; }
        public string UpdatedById { get; set; }




    }

}
