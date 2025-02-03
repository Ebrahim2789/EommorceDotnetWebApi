namespace Ecommorce.Model.ProductModels
{
    public class Reviews_Support
    {
        public int Id { get; set; }

        public string Description { get; set; }
        public int UserId { get; set; }
        public int EntityTypeId { get; set; }

        public int EntityId { get; set; }
        public int ReviewId { get; set; }



    }

}
