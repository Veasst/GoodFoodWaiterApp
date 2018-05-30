using GoodFoodWaiter.Droid;
using System;
using Xamarin.Forms;

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
        }
	}
}