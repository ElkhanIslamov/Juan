namespace Juan.ViewModels.ProductViewModels
{
    public class ProductCreateViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Rating  { get; set; }
        public string Image { get; set; }
        public int DiscountPercent { get; set; }
        public int CategoryId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
