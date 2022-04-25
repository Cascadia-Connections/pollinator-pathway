using Microsoft.Build.Framework;

namespace PollinatorPathway.Model
{
    public class UploadedImage
    {
        public long Id { get; set; }
        public string ImageUrl { get; set; }
        public Boolean IsApprovced { get; set; }
        public UserProfile Profile { get; set; }

        [Required]
        public IFormFile File { get; set; }
         
    }
}