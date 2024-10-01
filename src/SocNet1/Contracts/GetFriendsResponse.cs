using System.Globalization;

namespace SocNet1.Contracts
{
    public class GetFriendsResponse
    {
        public int id { get; set; }
        public int requester_id { get; set; }
        public int receiver_id { get; set; }
        public string status { get; set; } = null!;
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }

}