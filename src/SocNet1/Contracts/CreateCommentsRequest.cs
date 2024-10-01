namespace SocNet1.Contracts
{
    public class CreateCommentsRequest
    {
        public int post_id { get; set; }
        public int user_id { get; set; }
        public string content { get; set; } = null!;
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}