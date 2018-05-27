using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

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