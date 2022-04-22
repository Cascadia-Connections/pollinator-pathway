namespace PollinatorPathway.Model
{
    public class UploadedImage
    {
            public int ImageId { get; set; }
            public string imageUrl { get; set; }
            public Boolean IsApprovced { get; set; }
            public UserProfile Profile { get; set; }

    }
}
