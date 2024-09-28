namespace SocNet1.Contracts
{
    public class GetLikesResponse
    {
        public int post_id { get; set; }
        public int user_id { get; set; }
        public DateTime created_at { get; set; }
    }
}
