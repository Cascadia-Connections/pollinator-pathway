namespace PollinatorPathway.Model
{
    public class UploadedImage
    {
        public long Id { get; set; }
        public Boolean IsApproved { get; set; }
        public byte[] File { get; set; }
        public string Name { get; set; }

        public UserProfile Uploader { get; set; }


    }
}
