using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipdishPosPollApi.Entities
{
    public class PreviousOrderItemOptionDm
    {
        public int MenuItemOptionId { get; set; }
        public bool IsMasterOptionSetItem { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }        
    }
}
