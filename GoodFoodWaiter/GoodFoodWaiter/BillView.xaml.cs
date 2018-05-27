using GoodFoodWaiter.Droid.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoodFoodWaiter
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BillView : ContentView
    {
        private Xamarin.Forms.ListView dishListView;
        private Label subTotalLabel;
        private Label totalLabel;
        public static ObservableCollection<OrderItem> orderList { get; set; }
        public BillView()
        {
            InitializeComponent();
            orderList = new ObservableCollection<OrderItem>();

            var scrollView = new ScrollView();
            Content = scrollView;
            var stackLayout = new StackLayout();
            stackLayout.Children.Add(new Label { Text = "Rachunek", HorizontalOptions = LayoutOptions.Center });
            stackLayout.Children.Add(new BoxView { Color = Color.Black, HeightRequest = 2 });

            var orderDataTemplate = new DataTemplate(() =>
            {
                OrderItemView orderItemView = new OrderItemView();
                return new ViewCell { View = orderItemView };
            });

            dishListView = new ListView();
            dishListView.HeightRequest = 10;
            dishListView.ItemTemplate = orderDataTemplate;
            dishListView.ItemTemplate.SetBinding(TextCell.TextProperty, "dishName");

            dishListView.ItemTapped += OnTap;
            dishListView.ItemSelected += OnSelect;

            stackLayout.Children.Add(dishListView);
            dishListView.ItemsSource = orderList;
            stackLayout.Children.Add(new BoxView { Color = Color.Black, HeightRequest = 2 });

            var grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = 25 });
            grid.RowDefinitions.Add(new RowDefinition { Height = 25 });
            grid.RowDefinitions.Add(new RowDefinition { Height = 2 });
            grid.RowDefinitions.Add(new RowDefinition { Height = 25 });

            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = 100 });
            grid.ColumnDefinitions.Add(new ColumnDefinition { });

            var placeOrderButton = new Button();
            placeOrderButton.Text = "Wyślij";
            placeOrderButton.VerticalOptions = LayoutOptions.Fill;
            grid.Children.Add(placeOrderButton, 0, 0);
            Grid.SetRowSpan(placeOrderButton, 4);

            subTotalLabel = new Label();
            subTotalLabel.Text = "Cena: 0zł";
            grid.Children.Add(subTotalLabel, 1, 0);

            grid.Children.Add(new BoxView { Color = Color.Black, HeightRequest = 2 }, 1, 2);

            var discountLabel = new Label();
            discountLabel.Text = "Zniżka: 5%";
            grid.Children.Add(discountLabel, 1, 1);

            totalLabel = new Label();
            totalLabel.Text = "Razem: 0zł";
            grid.Children.Add(totalLabel, 1, 3);

            stackLayout.Children.Add(grid);
            scrollView.Content = stackLayout;
        }

        public void addOrderItem(OrderItem orderItem)
        {
            foreach (var order in orderList)
            {
                if (order.dishName.Equals(orderItem.dishName))
                {
                    order.amount++;
                    updatePrices();
                    refreshDishListView();
                    return;
                }
            }

            orderItem.amount = 1;
            orderList.Add(orderItem);
            updatePrices();
            refreshDishListView();
        }

        public void refreshDishListView()
        {
            dishListView.ItemsSource = null;
            dishListView.ItemsSource = orderList;
            dishListView.HeightRequest = orderList.Count() * 45;
        }

        public void updatePrices()
        {
            float sum = 0;
            foreach (var order in orderList)
            {
                order.price = order.amount * order.basePrice;
                sum += order.price;
            }

            subTotalLabel.Text = String.Format("Cena: {0:F2}zł", sum);
            totalLabel.Text = String.Format("Razem: {0:F2}zł", sum * 0.95);
        }

        public void OnTap(object sender, ItemTappedEventArgs e)
        {
            var orderItemView = (OrderItem)e.Item;
            foreach (var orderItem in orderList)
            {
                if(orderItem.dishName.Equals(orderItemView.dishName))
                {
                    if(orderItem.amount > 1)
                    {
                        orderItem.amount--;
                    }
                    else
                    {
                        orderList.Remove(orderItem);
                    }
                    updatePrices();
                    refreshDishListView();
                    break;
                }
            }
        }

        public void OnSelect(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
        }
    }
}