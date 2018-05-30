namespace GoodFoodWaiter.Droid.Models
{
    public class Dish
    {
        public int dishId { get; set; }
        public string dishName { get; set; }
        public string dishType { get; set; }
        public float price { get; set; }
        public string description { get; set; }
        public string ingredients { get; set; }
        public string logoPath { get; set; }
    }
}