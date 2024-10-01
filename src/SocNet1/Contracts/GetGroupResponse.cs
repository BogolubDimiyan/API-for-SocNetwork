namespace SocNet1.Contracts
{
    public class GetGroupResponse
    {
        public int id { get; set; }
        public string name { get; set; } = null!;
        public string description { get; set; } = null!;
        public int created_by { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}