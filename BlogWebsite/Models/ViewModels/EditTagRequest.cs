using BlogWebsite.Models.Domain;

namespace BlogWebsite.Models.ViewModels
{
    public class EditTagRequest
    {
        public Guid Id { get; set; }
        public string name { get; set; }
        public string DisplayName { get; set; }
    }
}
