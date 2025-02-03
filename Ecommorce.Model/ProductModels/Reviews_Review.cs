namespace Ecommorce.Model.ProductModels
{
    public class Reviews_Review
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public string ReviewerName { get; set; }
        public string Status { get; set; }
        public int EntityTypeId { get; set; }
        public int EntityId { get; set; }
        public int SourceId { get; set; }
        public string SourceType { get; set; }
        public bool IsAnonymous { get; set; }
        public string SupportCount { get; set; }
        public bool IsSystem { get; set; }





    }

}
