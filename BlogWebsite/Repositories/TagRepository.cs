using BlogWebsite.Data;
using BlogWebsite.Interfaces;
using BlogWebsite.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogWebsite.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly BlogDbContext blogDbcontext;

        public TagRepository(BlogDbContext blogDbcontext)
        {
            this.blogDbcontext = blogDbcontext;
        }
        public async Task<Tag> AddAsync(Tag tag)
        {
            await blogDbcontext.Tags.AddAsync(tag);
            await blogDbcontext.SaveChangesAsync();
            return tag;
        }

        public async Task<Tag?> DeleteAsync(Guid id)
        {
            var existingTag = await blogDbcontext.Tags.FindAsync(id);
            if(existingTag != null)
            {
                blogDbcontext.Tags.Remove(existingTag);
                await blogDbcontext.SaveChangesAsync();
                
                return existingTag;
            }
            return null;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await blogDbcontext.Tags.ToListAsync();
        }

        public Task<Tag?> GetAsync(Guid id)
        {
           return blogDbcontext.Tags.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Tag?> UpdateAsync(Tag tag)
        {
            var existingTag = await blogDbcontext.Tags.FindAsync(tag.Id);
            if (existingTag != null) {
                existingTag.name = tag.name;
                existingTag.DisplayName = tag.DisplayName;

                await blogDbcontext.SaveChangesAsync();
                return existingTag;
            }
            else
            {
                return null;
            }
        }
    }
}
