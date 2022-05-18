using System.ComponentModel.DataAnnotations;

namespace PollinatorPathway.ViewModels
{
    public class ProfileViewModel
    {
        public long UserId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Email address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string EmailAddress { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        [Phone]
        public string? Phone { get; set; }
        [Required]
        [Display(Name = "Team Contact")]
        public string? TeamContact { get; set; }
        [Required]
        [Display(Name = "Date Joined")]
        public string? DateJoined { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The password must be at least 6 character lons, and include letters numbers, and special characters.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }

        [Display(Name = "Organization Name")]
        public string? OrganizationName { get; set; }
        [Display(Name = "Organization Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? OrganizationEmail { get; set; }
        [Display(Name = "Organization Type")]
        public string? OrganizationType { get; set; }
        [Display(Name = "Website Link")]
        public string? WebsiteLink { get; set; }
        [Display(Name = "Social Media")]
        public string? SocialMedia { get; set; }

        [Required]
        [Display(Name = "Plant Address")]
        public string? Address { get; set; }
        [Required]
        [Display(Name = "Plant GPS Location")]
        public string? GPS { get; set; }
        [Required]
        [Display(Name = "Plant Name")]
        public string? PlantName { get; set; }
        [Required]
        [Display(Name = "Plant Description")]
        public string? PlantDesc { get; set; }
        [Required (ErrorMessage = "You must upload at least 1 image of the plant.")]
        [Display(Name = "Image 1")]
        public string? Image1 { get; set; }
        [Display(Name = "Image 2")]
        public string? Image2 { get; set; }
        [Display(Name = "Image 3")]
        public string? Image3 { get; set; }

    }
}
