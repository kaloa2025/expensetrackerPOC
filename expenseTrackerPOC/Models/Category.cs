using System.ComponentModel.DataAnnotations;

namespace expenseTrackerPOC.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required, MaxLength(50)]
        public string CategoryName { get; set; }

        public int IconId { get; set; }


        public CategoryIcon Icon { get; set; }
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    }
}

