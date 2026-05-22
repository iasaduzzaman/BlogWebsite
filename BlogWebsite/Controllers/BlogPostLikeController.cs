using BlogWebsite.Interfaces;
using BlogWebsite.Models.Domain;
using BlogWebsite.Models.ViewModels;
using BlogWebsite.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostLikeController : ControllerBase
    {
        private readonly IBlogPostLikeRepository blogPostLikeRepository;

        public BlogPostLikeController(IBlogPostLikeRepository blogPostLikeRepository)
        {
            this.blogPostLikeRepository = blogPostLikeRepository;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddLike([FromBody] AddLikeRequest addLikeRequest)
        {
            var model = new BlogPostLike
            {
                BlogPostId = addLikeRequest.BlogPostId,
                UserId = addLikeRequest.UserId
            };
            await blogPostLikeRepository.AddLikeForBlog(model);
            return Ok();
        }
    }
}
