namespace MLicensemanager.BlazorUI.Models
{
    public class CustomerProductDto
    {
        public int GroupId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal SubTotal { get; set; }   
    }
}
