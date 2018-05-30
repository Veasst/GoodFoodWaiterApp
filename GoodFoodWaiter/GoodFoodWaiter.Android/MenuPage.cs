using GoodFoodWaiter.Droid.Models;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GoodFoodWaiter.Droid
{
    public class MenuPage : ContentPage
    {
        public static BillView billView;
        public RestService restService;

        public MenuPage(RestService restService)
        {
            this.restService = restService;
            billView = new BillView(restService);
        }

        public async Task GetDishes(StackLayout stackLayout, string dishType)
        {
            var scrollView = new Xamarin.Forms.ScrollView();
            Content = scrollView;
            var menu = await restService.GetMenu(dishType);

            foreach (Dish dish in menu)
            {
                var dishRow = new DishRow(dish.dishId, dish.dishName, dish.price, dish.logoPath);

                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += OnTap;
                dishRow.GestureRecognizers.Add(tapGestureRecognizer);
                stackLayout.Children.Add(dishRow);
                
            }
            stackLayout.Children.Add(billView);

            scrollView.Content = stackLayout;
        }

        private void OnTap(object obj, EventArgs args)
        {
            var dishRow = (DishRow)obj;
            billView.addOrderItem(new OrderItem{ dishId = dishRow.dishId, dishName=dishRow.dishName, price = dishRow.price, basePrice = dishRow.price });
        }
    }
}