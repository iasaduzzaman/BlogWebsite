using BlogWebsite.Interfaces;
using BlogWebsite.Models.Domain;
using BlogWebsite.Models.ViewModels;
using BlogWebsite.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogWebsite.Controllers
{
    public class AdminBlogPostController : Controller
    {
        private readonly ITagRepository tagRepository;
        private readonly IBlogPostRepository blogPostRepository;

        public AdminBlogPostController(ITagRepository tagRepository, IBlogPostRepository blogPostRepository)
        {
            this.tagRepository = tagRepository;
            this.blogPostRepository = blogPostRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            // Get tag from Repository
            var tags = await tagRepository.GetAllAsync();
            var model = new AddBlogPostRequest
            {
                Tags = tags.Select(x => new SelectListItem 
                {
                    Text = x.name, 
                    Value = x.Id.ToString() 
                })
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddBlogPostRequest addBlogPostRequest)
        {
            //Map view to domain model
            var blogPost = new BlogPost
            { 
             Heading = addBlogPostRequest.Heading,
             PageTitle = addBlogPostRequest.PageTitle,
             Content = addBlogPostRequest.Content,
             ShortDescription = addBlogPostRequest.ShortDescription,
             FeaturedImageUrl = addBlogPostRequest.FeaturedImageUrl,
             UrlHandle = addBlogPostRequest.UrlHandle,
             PublishedDate = addBlogPostRequest.PublishedDate,
             Author = addBlogPostRequest.Author,
             Visible = addBlogPostRequest.Visible,
            };

            //Map Tags from selected tags
            var selectedTags = new List<Tag>();
            foreach (var selectedTagId in addBlogPostRequest.SelectedTags)
            {
                var selectedTagIdAsGuid = Guid.Parse(selectedTagId);
                var existingTag = await tagRepository.GetAsync(selectedTagIdAsGuid);
                if (existingTag != null)
                {
                    selectedTags.Add(existingTag);
                }
            }
             //Mapping Tags back to Domain Model
             blogPost.Tags = selectedTags;

            await blogPostRepository.AddAsync(blogPost);
            return RedirectToAction("Add");
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            //Call the Repository
            var blogPosts = await blogPostRepository.GetAllAsync();

            return View(blogPosts);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            //Retrieve the result from the repository
            var blogPost = await blogPostRepository.GetAsync(id);
            var tagsDomainModel = await tagRepository.GetAllAsync();

            if(blogPost != null)
            {
                //map the domain model into the view model
                var model = new EditBlogPostRequest
                {
                    Id = blogPost.Id,
                    Heading = blogPost.Heading,
                    PageTitle = blogPost.PageTitle,
                    Content = blogPost.Content,
                    Author = blogPost.Author,
                    FeaturedImageUrl = blogPost.FeaturedImageUrl,
                    UrlHandle = blogPost.UrlHandle,
                    ShortDescription = blogPost.ShortDescription,
                    PublishedDate = blogPost.PublishedDate,
                    Visible = blogPost.Visible,
                    Tags = tagsDomainModel.Select(x => new SelectListItem
                    {
                        Text = x.name,
                        Value = x.Id.ToString()
                    }),
                    SelectedTags = blogPost.Tags.Select(x => x.Id.ToString()).ToArray()
                };
                return View(model);
            }
           
            //pass data to view
            return View(null);
        }
    }
}
