namespace PollinatorPathway.Model
{
    public class UserProfile
    {
        internal string File;
        internal DateTime UpdatedAt;

        public long Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
        public string? Phone { get; set; }
        public string? TeamContact { get; set; }
        public string? DateJoined { get; set; }
        public string? Password { get; set; }

        public string? OrganizationName { get; set; }
        public string? OrganizationEmail { get; set; }
        public string? OrganizationType { get; set; }
        public string? WebsiteLink { get; set; }
        public string? SocialMedia { get; set; }

        public string? IsPrivate { get; set; }
        public string? Address { get; set; }
        public string? GPS { get; set; }
        public string? PlantName { get; set; }
        public string? PlantDesc { get; set; }
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; } // List of Uploaded Images, virtual keyword, 
    }
}
