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
                Items = null;
            }


            return Items;
        }
    }
}