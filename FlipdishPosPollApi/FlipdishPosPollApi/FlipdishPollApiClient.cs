using System;
using FlipdishPosPollApi.Entities;
using Newtonsoft.Json;

namespace FlipdishPosPollApi
{
    public class FlipdishPollApiClient
    {
        private static string ProductionApiEndpoint = "https://flipdish.ie/pollapi";
        private static readonly string TestApiEndpoint = "https://flipdishstaging.azurewebsites.net/pollapi";
        private static string LocalApiEndpoint = "http://localhost/pollapi";

        private static readonly string ApiEndpoint = TestApiEndpoint;

        public FlipdishOrder RequestNewOrder(int physicalRestaurantId, string key)
        {
            var url = string.Format("{0}/RequestNewOrder?physicalRestaurantId={1}&apiKey={2}", ApiEndpoint,
                physicalRestaurantId, key);

            Console.WriteLine("Making HTTP Request: {0}", url);
            var apiResult = HttpHelper.HttpPostApiResult(url, string.Empty);

            if (apiResult.Success)
            {
                var flipdishOrder = JsonConvert.DeserializeObject<FlipdishOrder>(apiResult.Data.ToString());
                return flipdishOrder;
            }

            return null;
        }

        public FlipdishOrder GetOrder(int physicalRestaurantId, string key, int orderId)
        {
            var url = string.Format("{0}/GetOrder?physicalRestaurantId={1}&apiKey={2}&orderId={3}", ApiEndpoint,
                physicalRestaurantId, key, orderId);

            Console.WriteLine("Making HTTP Request: {0}", url);

            var apiResult = HttpHelper.HttpPostApiResult(url, string.Empty);

            if (apiResult.Success)
            {
                var flipdishOrder = JsonConvert.DeserializeObject<FlipdishOrder>(apiResult.Data.ToString());
                return flipdishOrder;
            }

            return null;
        }

        public ApiResult AcceptOrder(int physicalRestaurantId, string key, int orderId)
        {
            var url = string.Format("{0}/AcceptOrder?physicalRestaurantId={1}&apiKey={2}&orderId={3}", ApiEndpoint,
                physicalRestaurantId, key, orderId);

            Console.WriteLine("Making HTTP Request: {0}", url);

            var apiResult = HttpHelper.HttpPostApiResult(url, string.Empty);

            return apiResult;
        }

        public ApiResult RejectOrder(int physicalRestaurantId, string key, int orderId)
        {
            var url = string.Format("{0}/RejectOrder?physicalRestaurantId={1}&apiKey={2}&orderId={3}", ApiEndpoint,
                physicalRestaurantId, key, orderId);

            Console.WriteLine("Making HTTP Request: {0}", url);

            var apiResult = HttpHelper.HttpPostApiResult(url, string.Empty);
            return apiResult;
        }
    }
}