namespace SocNet1.Contracts
{
    public class GetMessageResponse
    {
        public int id { get; set; }
        public int sender_id { get; set; }
        public int receiver_id { get; set; }
        public string content { get; set; } = null!;
        public bool read_status { get; set; }
        public DateTime created_at { get; set; }
    }
}