namespace Ecommorce.Model.ProductModels
{
    public class Reviews_Reply
    {
        public int Id { get; set; }
        public int ParentId { get; set; }

        //1: customer(default value)
        //2: merchant
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }
        public string ReplierName { get; set; }
        public int ToUserId { get; set; }
        public string ToUserName { get; set; }
        public string Status { get; set; }
        public bool IsAnonymous { get; set; }
        public string SupportCount { get; set; }

    }

}
