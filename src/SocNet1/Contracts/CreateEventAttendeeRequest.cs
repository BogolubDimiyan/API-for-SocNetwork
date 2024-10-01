namespace SocNet1.Contracts
{
    public class CreateEventAttendeeRequest
    {
        public int event_id { get; set; }
        public int user_id { get; set; }
        public string status { get; set; } = null!;
        public DateTime joined_at { get; set; }
    }
}