

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
        public string? Password { get; set; }
    }
}
