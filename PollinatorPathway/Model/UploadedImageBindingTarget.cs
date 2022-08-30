namespace PollinatorPathway.Model
{
    public class UploadedImageBindingTarget
    {
        public long Id { get; set; }
        public Boolean IsApproved { get; set; }
        public byte[] File { get; set; }
        public string Name { get; set; }

        public virtual UserProfile Uploader { get; set; }


        public UploadedImage ToUploadedImage() => new UploadedImage()
        {
            IsApproved = this.IsApproved,
            File = this.File,
            Name = this.Name,
            Uploader = this.Uploader,
        };

    }
}
