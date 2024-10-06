namespace Juan.Areas.Admin.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Rating { get; set; }
        public string Image { get; set; }
        public bool IsDeleted { get; set; }
        public int  DiscountPercent { get; set; }
        public DateTime DeletedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
