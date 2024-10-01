namespace SocNet1.Contracts
{
    public class GetEventAttendeeResponse
    {
        public int id { get; set; }
        public int event_id { get; set; }
        public int user_id { get; set; }
        public string status { get; set; } = null!;
        public DateTime joined_at { get; set; }
    }
}