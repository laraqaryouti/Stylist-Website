using System.ComponentModel.DataAnnotations;
namespace FinalProject.Models
{
    public class Consultation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z][a-z]*$", ErrorMessage = "First name should start with an uppercase letter and it should be at least one character")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z][a-z]*$", ErrorMessage = "Last name should start with an uppercase letter and it should be at least one character")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        [StringLength(250, MinimumLength = 0, ErrorMessage = "Max Length is 250")]
        [Required]
        public string ReasonForConsultation { get; set; }
        [Required]
        public string ConsultationType { get; set; }
        [Required]
        public string PackageType { get; set; }
        [Required]
        public string ContactMethod { get; set; }
        public DateTime AvailabilityDate { get; set; }
        [Required]
        public string Style { get; set; }
        [StringLength(500, MinimumLength = 0, ErrorMessage = "Max Length is 500")]
        public string Message { get; set; }
    }
    public class StylistAccount
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z][a-z]*$", ErrorMessage = "First name should start with an uppercase letter and it should be at least one character")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z][a-z]*$", ErrorMessage = "Last name should start with an uppercase letter and it should be at least one character")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"[A-Za-z]{1,}[0-9]{0,}", ErrorMessage = "Username should have at least one character followed by zero or more digits")]
        public string Username { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"[A-Za-z0-9@#$%]{10,}", ErrorMessage = "Password must at least have 10 characters")]
        public string Password { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        public string Gender { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public float YearsOfExperience { get; set; }
        [Required]
        public string LicenseNumber { get; set; }
        [Required]
        [Range(0.0, 1000.0)]
        public float PricesCharged { get; set; }
        [Required]
        public string AreasOfExpertise { get; set; }
        [Required]
        [StringLength(250, MinimumLength = 0, ErrorMessage = "Max Length is 250")]
        public string Address { get; set; }

    }
    public class UserAccount
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z][a-z]*$", ErrorMessage = "First name should start with an uppercase letter and it should be at least one character")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z][a-z]*$", ErrorMessage = "Last name should start with an uppercase letter and it should be at least one character")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"[A-Za-z]{1,}[0-9]{0,}", ErrorMessage = "Username should have at least one character followed by zero or more digits")]
        public string Username { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"[A-Za-z0-9@#$%]{10,}", ErrorMessage = "Password must at least have 10 characters")]
        public string Password { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        public string Gender { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public float Budget { get; set; }
        public string ClothingSize { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 0, ErrorMessage = "Max Length is 250")]
        public string Address { get; set; }
    }
}
