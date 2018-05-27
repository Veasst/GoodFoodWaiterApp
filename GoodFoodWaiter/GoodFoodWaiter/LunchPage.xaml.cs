using Android.Widget;
using GoodFoodWaiter.Droid;
using GoodFoodWaiter.Droid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoodFoodWaiter
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LunchPage : MenuPage
	{
        private StackLayout stackLayout;
        public LunchPage(RestService restService) : base(restService)
        {
			InitializeComponent();
            this.restService = restService;
            init();
        }

        public async void init()
        {
            var scrollView = new Xamarin.Forms.ScrollView();
            Content = scrollView;
            stackLayout = new StackLayout();

            await GetDishes(stackLayout, "Obiad");

            this.Appearing += OnAppear;
        }

        public void OnAppear(object sender, EventArgs e)
        {
            stackLayout.Children.Add(MenuPage.billView);
            Toast.MakeText(Android.App.Application.Context, "TEST2", ToastLength.Short).Show();
        }
    }
}