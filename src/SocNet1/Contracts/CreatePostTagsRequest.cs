namespace SocNet1.Contracts
{
    public class CreatePostTagsRequest
    {
        public int post_id { get; set; }
        public int tag_id { get; set; }
    }
}