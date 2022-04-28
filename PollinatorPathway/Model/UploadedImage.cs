using Microsoft.Build.Framework;

namespace PollinatorPathway.Model
{
    public class UploadedImage
    {
        public long Id { get; set; }
        public IFormFile File { get; set; }
        public string Name { get; set; }
         
    }
}