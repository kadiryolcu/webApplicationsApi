using System.ComponentModel.DataAnnotations;

namespace  WebApplication1.Models
{
    public class LeadFormModel
    {
        [Key] // Primary key olarak iþaretlendi
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public string Phone { get; set; }

        [Required]
        public string Goal { get; set; }

        public string Company { get; set; }

        [Required]
        public string Industry { get; set; }

        public string TeamSize { get; set; }

        public string Message { get; set; }

        public string Referral { get; set; }
    }
}
