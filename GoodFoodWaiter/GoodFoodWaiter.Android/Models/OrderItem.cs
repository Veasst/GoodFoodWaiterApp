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
    public class OrderItem
    {
        public string dishName { get; set; }
        public float price { get; set; }
        public int amount { get; set; }
        public float basePrice { get; set; }
    }
}