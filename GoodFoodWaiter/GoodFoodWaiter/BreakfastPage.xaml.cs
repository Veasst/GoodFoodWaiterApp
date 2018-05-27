using Android.Widget;
using GoodFoodWaiter.Droid;
using GoodFoodWaiter.Droid.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoodFoodWaiter
{
	
	public partial class BreakfastPage : MenuPage
    {
        private StackLayout stackLayout;
		public BreakfastPage(RestService restService) : base(restService)
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

            this.Appearing += OnAppear;

            await GetDishes(stackLayout, "Śniadanie");
        }

        public void OnAppear(object sender, EventArgs e)
        {
            stackLayout.Children.Add(MenuPage.billView);
            Toast.MakeText(Android.App.Application.Context, "TEST2", ToastLength.Short).Show();
        }
	}
}