using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DemoProject.Models
{
  
    public class CandidateDto
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = null!;

        [Phone]
        [StringLength(15)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = null!;

        [StringLength(20)]
        public string PreferredCallTime { get; set; } = null!;
        [StringLength(200)]
        public string? LinkedInProfileUrl { get; set; }
        [StringLength(200)]
        public string? GitHubProfileUrl { get; set; }

        [Required]
        [StringLength(500)]
        public string FreeTextComment { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string? UdatedBy { get; set; }
    }
}
