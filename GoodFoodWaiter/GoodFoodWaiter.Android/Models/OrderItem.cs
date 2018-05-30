namespace GoodFoodWaiter.Droid.Models
{
    public class OrderItem
    {
        public int dishId { get; set; }
        public string dishName { get; set; }
        public float price { get; set; }
        public int amount { get; set; }
        public float basePrice { get; set; }
    }
}