using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace x4StationPlanner
{
    public class ItemQuantity
    {
        public ItemQuantity(string item, double quantity)
        {
            Item = item;
            Quantity = quantity;
        }
        public string Item { get; set; }
        public double Quantity { get; set; }
    }
}
