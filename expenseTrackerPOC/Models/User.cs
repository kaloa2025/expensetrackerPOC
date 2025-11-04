using System.ComponentModel.DataAnnotations;

namespace expenseTrackerPOC.Models
{
    public class User
    {
        public int UserId { get; set; }
        [Required, MaxLength(50)]
        public string Username { get; set; }
        [Required, EmailAddress, MaxLength(100)]
        public string Email { get; set; }
        [Required]
        public string HashPassword { get; set; }

        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    }
}
