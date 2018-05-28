using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GoodFoodWaiter.Droid.Models;
using Newtonsoft.Json;

namespace GoodFoodWaiter.Droid
{
    public class RestService
    {
        HttpClient client;
        public List<Dish> Items { get; set; }

        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<List<Dish>> GetMenu(string dishType)
        {
            Items = new List<Dish>();
            var uri = new Uri("http://goodfoodapi.azurewebsites.net/api/menu/bydishtype?localId=1&dishType=" + dishType);
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var settings = new JsonSerializerSettings();
                    settings.MetadataPropertyHandling = MetadataPropertyHandling.Ignore;
                    Items = JsonConvert.DeserializeObject<List<Dish>>(content, settings);
                }
            }
            catch (Exception)
            {
            }


            return Items;
        }

        public async Task<int> SaveOrderAsync(Order order)
        {
            var uri = new Uri("http://goodfoodapi.azurewebsites.net/api/orders");

            var json = JsonConvert.SerializeObject(order);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    return int.Parse(await response.Content.ReadAsStringAsync());
                    //Toast.MakeText(Android.App.Application.Context, "POST SUCCESS", ToastLength.Short).Show();
                }
            }
            catch (Exception) { }
            return -1;
        }

        public async Task<bool> SaveOrderDishesAsync(List<OrderDish> order)
        {
            var uri = new Uri("http://goodfoodapi.azurewebsites.net/api/orders/orderdish");

            var json = JsonConvert.SerializeObject(order);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = null;
                response = await client.PostAsync(uri, content);
                Toast.MakeText(Android.App.Application.Context, await response.Content.ReadAsStringAsync(), ToastLength.Short).Show();

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
            }
            catch (Exception) { }
            return false;
        }
    }
}