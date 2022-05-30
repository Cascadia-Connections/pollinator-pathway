using System.ComponentModel.DataAnnotations;

namespace PollinatorPathway.ViewModels
{
    public class ProfileViewModel
    {
        public long UserId { get; set; }

        [Required(ErrorMessage = "Please type your first name.")]
        [Display(Name = "* First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please type your last name.")]
        [Display(Name = "* Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "* Email address")]
        [EmailAddress(ErrorMessage = "Missing or Invalid Email Address.")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Please type your email address.")]
        [Display(Name = "* Phone Number")]
        [Phone(ErrorMessage = "Missing or Invalid Phone Number.")]
        public string? Phone { get; set; }
        [Required(ErrorMessage = "Please type your team contact at Pollinator Pathway.")]
        [Display(Name = "* Pollinator Pathway Team Contact")]
        public string? TeamContact { get; set; }
        [Required(ErrorMessage = "Please type your date joined.")]
        [Display(Name = "* Date Joined")]
        public string? DateJoined { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The password must be at least 6 character long, and include letters, numbers, and special characters.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "* Password")]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "* Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string? ConfirmPassword { get; set; }

        [Display(Name = "Organization Name")]
        public string? OrganizationName { get; set; }
        [Display(Name = "Organization Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string? OrganizationEmail { get; set; }
        [Display(Name = "Organization Type")]
        public string? OrganizationType { get; set; }
        [Display(Name = "Website Link")]
        public string? WebsiteLink { get; set; }
        [Display(Name = "Social Media")]
        public string? SocialMedia { get; set; }

        [Required(ErrorMessage = "Please select your preference.")]
        [Display(Name = "* Planting Privacy")]
        public string? IsPrivate { get; set; }
        [Required(ErrorMessage = "Please type your planitng address.")]
        [Display(Name = "* Planting Address")]
        public string? Address { get; set; }
        [Required(ErrorMessage = "Please type your planitng GPS coordinates.")]
        [Display(Name = "* Planting GPS Location")]
        public string? GPS { get; set; }
        [Required(ErrorMessage = "Please type your planitng name.")]
        [Display(Name = "* Planting Name")]
        public string? PlantName { get; set; }
        [Required(ErrorMessage = "Please type your planitng description.")]
        [Display(Name = "* Planting Description")]
        public string? PlantDesc { get; set; }
        [Required (ErrorMessage = "You must upload at least 1 image of the plant.")]
        [Display(Name = "* Image 1")]
        public string? Image1 { get; set; }
        [Display(Name = "Image 2")]
        public string? Image2 { get; set; }
        [Display(Name = "Image 3")]
        public string? Image3 { get; set; }

    }
}
