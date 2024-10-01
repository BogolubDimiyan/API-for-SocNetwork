namespace SocNet1.Contracts
{
    public class GetUserResponse
    {
        public int user_id { get; set; }
        public string username { get; set; } = null!;
        public string email { get; set; } = null!;
        public string password_hash { get; set; } = null!;
        public string first_name { get; set; } = null!;
        public string last_name { get; set; } = null!;
        public DateTime birthday { get; set; }
        public string gender { get; set; } = null!;
        public string profile_picture { get; set; } = null!;
        public string bio { get; set; } = null!;
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}