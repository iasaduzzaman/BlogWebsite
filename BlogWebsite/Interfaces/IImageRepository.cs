namespace BlogWebsite.Interfaces
{
    public interface IImageRepository
    {
        Task<string> UploadAsync(IFormFile file);
    }
}
