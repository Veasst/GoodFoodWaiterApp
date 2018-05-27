using GoodFoodWaiter.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GoodFoodWaiter
{
	public partial class MainPage : TabbedPage
	{
        public MainPage()
        {
            InitializeComponent();
        }

		public MainPage(RestService restService)
		{
			InitializeComponent();

            NavigationPage breakFastPage = new NavigationPage(new BreakfastPage(restService));
            breakFastPage.Title = "Śniadanie";
            Children.Add(breakFastPage);

            NavigationPage lunchPage = new NavigationPage(new LunchPage(restService));
            lunchPage.Title = "Obiad";
            Children.Add(lunchPage);

            NavigationPage dinnerPage = new NavigationPage(new DinnerPage(restService));
            dinnerPage.Title = "Kolacja";
            Children.Add(dinnerPage);
        }
	}
}
