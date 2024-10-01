namespace SocNet1.Contracts
{
    public class GetEventsResponse
    {
        public int id { get; set; }
        public string name { get; set; } = null!;
        public string description { get; set; } = null!;
        public string location { get; set; } = null!;
        public DateTime start_time { get; set; }
        public DateTime end_time { get; set; }
        public int created_by { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}