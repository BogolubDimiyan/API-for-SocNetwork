namespace SocNet1.Contracts
{
    public class GetNotificationsResponse
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string message { get; set; } = null!;
        public string type { get; set; } = null!;
        public bool is_read { get; set; }
        public DateTime created_at { get; set; }
    }
}