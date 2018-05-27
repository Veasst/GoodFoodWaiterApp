using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoodFoodWaiter
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderItemView : ContentView
    {
        public int amount { get; set; }
        public string dishName { get; set; }
        public float price { get; set; }

        public OrderItemView()
        {
            var grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = 40 });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = 50 });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = 250 });
            grid.ColumnDefinitions.Add(new ColumnDefinition());

            var amountLabel = new Label();
            var dishNameLabel = new Label();
            var priceLabel = new Label();

            amountLabel.SetBinding(Label.TextProperty, new Binding("amount", stringFormat: "{0}x"));
            dishNameLabel.SetBinding(Label.TextProperty, "dishName");

            priceLabel.SetBinding(Label.TextProperty, new Binding("price", stringFormat: "{0:F2}zł"));

            grid.Children.Add(amountLabel);
            grid.Children.Add(dishNameLabel, 1, 0);
            grid.Children.Add(priceLabel, 2, 0);

            Content = grid;
        }
    }
}