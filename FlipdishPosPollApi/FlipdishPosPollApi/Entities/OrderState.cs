using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipdishPosPollApi.Entities
{
    public enum OrderState
    {
        AwaitingPayment = 0,
        ReadyToProcess = 1,
        AcceptedByRestaurant = 2,
        Dispatched = 3,
        Delivered = 4,
        Cancelled = 5,
        ManualReview = 6
    }
}
