using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipdishPosPollApi.Entities
{
    public class PreviousOrderItemDm
    {
        public int VirtualRestaurantId { get; set; }
        public string MenuSectionName { get; set; }
        public int MenuSectionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int OrderItemId { get; set; }
        public int MenuItemId { get; set; }
        public bool IsAvailable { get; set; }
        public List<PreviousOrderItemOptionDm> PreviousOrderItemOptionVms { get; set; }
    }
}
