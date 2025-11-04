namespace expenseTrackerPOC.Models
{
    public class CategoryIcon
    {
        public int IconId { get; set; }
        public string IconImageUrl { get; set; }

        public ICollection<Category> Categories { get; set; } = new List<Category>();

    }
}
