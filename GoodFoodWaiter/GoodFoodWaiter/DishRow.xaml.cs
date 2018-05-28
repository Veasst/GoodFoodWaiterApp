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
	public partial class DishRow : ContentView
	{
        public int dishId { get; set; }
        public string dishName { get; set; }
        public float price { get; set; }

		public DishRow()
		{
			InitializeComponent();

            var grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = 100 });
            grid.RowDefinitions.Add(new RowDefinition { Height = 100 });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = 150 });
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            grid.Children.Add(new Image { Source = "https://polki.pl/pub/wieszjak/p/_wspolne/pliki_infornext/670000/obiad_2.jpg", Aspect = Aspect.Fill}, 0, 0);
            grid.Children.Add(new Label { Text = "Obiad na śniadanie kek", FontSize = 25, VerticalOptions = LayoutOptions.End, HorizontalOptions = LayoutOptions.Center }, 0, 1);
            grid.Children.Add(new Label { Text = "15zł", FontSize = 20, VerticalOptions = LayoutOptions.Start, HorizontalOptions = LayoutOptions.End}, 1, 1);

            Content = grid;
        }

        public DishRow(int dishId, string name, float price, string logoPath)
        {
            InitializeComponent();

            this.dishId = dishId;
            this.dishName = name;
            this.price = price;

            var grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = 50 });
            grid.RowDefinitions.Add(new RowDefinition { Height = 50 });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = 150 });
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            var image = new Image { Source = logoPath, Aspect = Aspect.AspectFill };
            grid.Children.Add(image, 0, 0);
            Grid.SetRowSpan(image, 2);
            grid.Children.Add(new Label { Text = name, FontSize = 20, VerticalOptions = LayoutOptions.Start, HorizontalOptions = LayoutOptions.Start }, 1, 0);
            grid.Children.Add(new Label { Text = price.ToString("0.00") + "zł", FontSize = 15, VerticalOptions = LayoutOptions.Start, HorizontalOptions = LayoutOptions.End }, 1, 1);

            Content = grid;
        }
	}
}