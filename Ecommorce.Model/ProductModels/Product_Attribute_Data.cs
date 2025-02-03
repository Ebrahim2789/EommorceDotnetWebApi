namespace Ecommorce.Model.ProductModels
{
    public class Product_Attribute_Data
    {
        public int Id { get; set; }
        public int AttributeId { get; set; }
        public int ProductId { get; set; }
        public string Value { get; set; }
        public bool IsDisplay { get; set; }


    }

}
