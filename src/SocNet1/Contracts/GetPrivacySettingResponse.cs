namespace SocNet1.Contracts
{
    public class GetPrivacySettingResponse
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public string profile_visible { get; set; } = null!;
        public string post_vidible { get; set; } = null!;
        public string friend_request { get; set; } = null!;
        public DateTime updatetd_at { get; set; }
    }
}