namespace Blazor.FurnitureStore.Shared
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public int ClientId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal Total
        {
            get
            {
                decimal sum = 0;
                if(Products is not null && Products.Any())
                {
                    sum = Products.Sum(p => (p.Price * p.Quantity));
                }
                return sum;
            }
        }
        public int ProductCategoryId { get; set; }
        public List<Product> Products { get; set; }
    }
}
