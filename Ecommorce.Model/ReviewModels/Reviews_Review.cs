using Ecommorce.Model.ProductModels;

namespace Ecommorce.Model.ReviewModels
{
    public class Reviews_Review : Common
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public required string Title { get; set; }
        public required string Comment { get; set; }
        public int Rating { get; set; }
        public required string ReviewerName { get; set; }
        public required string Status { get; set; }
        public int EntityTypeId { get; set; }
        public int EntityId { get; set; }
        public int SourceId { get; set; }
        public required string SourceType { get; set; }
        public bool IsAnonymous { get; set; }
        public required string SupportCount { get; set; }
        public bool IsSystem { get; set; }





    }

}
