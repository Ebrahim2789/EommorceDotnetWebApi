namespace Ecommorce.Model.ProductModels
{
    public class Product_Category : Common
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public string Description { get; set; }
        public int ParentId { get; set; }
        public string Thumbnail { get; set; }
        public string DisplayOrder { get; set; }

        public bool IsPublished { get; set; }





    }

}
