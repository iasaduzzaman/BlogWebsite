namespace BlogWebsite.Models.Domain
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string name { get; set; }
        public string DisplayName { get; set; }
        public ICollection<BlogPost> BlogPosts { get; set; }
    }
}
