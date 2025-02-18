namespace Ecommorce.Model.ReviewModels
{
    public class Reviews_Reply
    {
        public int Id { get; set; }
        public int ParentId { get; set; }

        //1: customer(default value)
        //2: merchant
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public required string Comment { get; set; }
        public required string ReplierName { get; set; }
        public int ToUserId { get; set; }
        public required string ToUserName { get; set; }
        public required string Status { get; set; }
        public bool IsAnonymous { get; set; }
        public required string SupportCount { get; set; }

    }

}
