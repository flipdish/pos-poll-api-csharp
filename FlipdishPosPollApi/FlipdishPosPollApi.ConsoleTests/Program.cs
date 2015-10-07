using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipdishPosPollApi.ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            string apiKey = "test-key";
            int physicalRestaurantId = 19;
            var flipdishPollApiClient = new FlipdishPollApiClient();

            Console.WriteLine("Let's test out the API");
            Console.WriteLine("PhysicalRestaurantId: {0}. ApiKey: {1}", physicalRestaurantId, apiKey);

            Console.WriteLine("First let's call RequestNewOrder. Hit {enter} to make the request.");
            Console.ReadLine();


            FlipdishOrder flipdishOrder = flipdishPollApiClient.RequestNewOrder(physicalRestaurantId, apiKey);

            if (flipdishOrder == null)
            {
                Console.WriteLine("No order found.");
            }
            else
            {
                Console.WriteLine("Found {0} order with ID {1} for {2} {3}.", flipdishOrder.DeliveryType, flipdishOrder.OrderId, flipdishOrder.TotalAmount, flipdishOrder.Currency);

                Console.WriteLine("Press [enter] to call GetOrder for order {0}", flipdishOrder.OrderId); 
                Console.ReadLine();
                flipdishOrder = flipdishPollApiClient.GetOrder(physicalRestaurantId, apiKey, flipdishOrder.OrderId);

                Console.WriteLine("Got {0} order with ID {1} for {2} {3}.", flipdishOrder.DeliveryType, flipdishOrder.OrderId, flipdishOrder.TotalAmount, flipdishOrder.Currency);

            }


            Console.WriteLine();
            Console.WriteLine("Press {enter} to exit");
            Console.ReadLine();

        }
    }
}
