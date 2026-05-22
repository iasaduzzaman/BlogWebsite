using BlogWebsite.Models.Domain;

namespace BlogWebsite.Interfaces
{
    public interface IBlogPostLikeRepository
    {
        Task<int> GetTotalLikes(Guid blogPostId);
        Task<BlogPostLike>AddLikeForBlog(BlogPostLike blogPostLike);
    }
}
