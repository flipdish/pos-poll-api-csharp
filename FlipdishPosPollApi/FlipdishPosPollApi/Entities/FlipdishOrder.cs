using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlipdishPosPollApi.Entities;

namespace FlipdishPosPollApi
{
    public class FlipdishOrder
    {
        public int OrderId { get; set; }
        public int VirtualRestaurantId { get; set; }
        public int? PhysicalRestaurantId { get; set; }
        public DeliveryType DeliveryType { get; set; }
        public string RestaurantName { get; set; }
        public decimal TipAmount { get; set; }
        public decimal DeliveryAmount { get; set; }
        public decimal FoodAmount { get; set; }
        public decimal TotalAmount { get; set; } // TotalCustomerAmount
        public DateTime? TsEditTipEndTimeUtc { get; set; }
        public DateTime TsUpdate { get; set; }

        public int? UserRating { get; set; }


        public string PaymentAccountDescription { get; set; } // Visa **** 2371. or Apple Pay. or Cash
        public List<PreviousOrderItemDm> PreviousOrderItemVms { get; set; }

        public bool IsHiddenFromRecentOrdersList { get; set; }

        public Currency Currency { get; set; }

        public DateTime? TsOrderPlaced { get; set; }

        public string DeliveryLocationAddressString { get; set; }// eg. 20 Waterloo Road

        public int? DeliveryLocationId { get; set; }
        public string DeliveryInstructions { get; set; }
        public CoordinatesDm Coordinates { get; set; }

        #region RestaurantOrders

        public decimal TotalRestaurantAmount { get; set; }

        public PaymentAccountType PaymentAccountType { get; set; }

        public OrderState OrderState { get; set; }

        public string CustomerName { get; set; }

        public string CustomerPhoneNumberLocalFormatString { get; set; }

        public string CustomerPhoneNumberInternationalFormatString { get; set; }

        public int? AmendmentForOrderId { get; set; }

        public bool HasAmendmentOrder { get; set; }
        #endregion
    }
}
