using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlipdishPosPollApi.Entities;
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
            ApiResult apiResult = HttpHelper.HttpPostApiResult(url, string.Empty);
        
            if (apiResult.Success)
            {
                var flipdishOrder = JsonConvert.DeserializeObject<FlipdishOrder>(apiResult.Data.ToString());
                return flipdishOrder;
            }

            return null;
        } 
        
        public FlipdishOrder GetOrder(int physicalRestaurantId, string key, int orderId)
        {
            string url = string.Format("{0}/GetOrder?physicalRestaurantId={1}&apiKey={2}&orderId={3}", LocalApiEndpoint, physicalRestaurantId, key, orderId);

            Console.WriteLine("Making HTTP Request: {0}", url);

            ApiResult apiResult = HttpHelper.HttpPostApiResult(url, string.Empty);

            if (apiResult.Success)
            {
                var flipdishOrder = JsonConvert.DeserializeObject<FlipdishOrder>(apiResult.Data.ToString());
                return flipdishOrder;
            }

            return null;
        }

        public ApiResult AcceptOrder(int physicalRestaurantId, string key, int orderId)
        {
            string url = string.Format("{0}/AcceptOrder?physicalRestaurantId={1}&apiKey={2}&orderId={3}", LocalApiEndpoint, physicalRestaurantId, key, orderId);

            Console.WriteLine("Making HTTP Request: {0}", url);

            ApiResult apiResult = HttpHelper.HttpPostApiResult(url, string.Empty);

            return apiResult;
        }
        public ApiResult RejectOrder(int physicalRestaurantId, string key, int orderId)
        {
            string url = string.Format("{0}/RejectOrder?physicalRestaurantId={1}&apiKey={2}&orderId={3}", LocalApiEndpoint, physicalRestaurantId, key, orderId);

            Console.WriteLine("Making HTTP Request: {0}", url);
            
            ApiResult apiResult = HttpHelper.HttpPostApiResult(url, string.Empty);
            return apiResult;
        }
    }
}
