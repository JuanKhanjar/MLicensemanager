namespace MLicensemanager.BlazorUI.Models
{
    public class ProductFromDbDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Remaining { get; set; }
        public decimal Price { get; set; }
    }
}
