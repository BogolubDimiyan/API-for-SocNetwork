namespace SocNet1.Contracts
{
    public class GetPostsResponse
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string content { get; set; } = null!;
        public string image_url { get; set; } = null!;
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }

    }
}