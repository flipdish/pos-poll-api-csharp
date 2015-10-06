using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FlipdishPosPollApi
{
    public class FlipdishPollApiClient
    {
        private static string ApiEndpoint = "https://flipdish.ie/pollapi";
        private static string TestApiEndpoint = "https://flipdishstaging.azurewebsites.net/pollapi";
        private static string LocalApiEndpoint = "http://localhost/pollapi";
        public FlipdishOrder RequestNewOrder(int physicalRestaurantId, string key)
        {
            string url = string.Format("{0}/RequestNewOrder?physicalRestaurantId={1}&apiKey={2}", LocalApiEndpoint, physicalRestaurantId, key);

            Console.WriteLine("Making HTTP Request: {0}", url);

            string resultString = HttpHelper.HttpPost(url, string.Empty);

            var flipdishOrder = JsonConvert.DeserializeObject<FlipdishOrder>(resultString);

            return flipdishOrder;
        }
    }
}
