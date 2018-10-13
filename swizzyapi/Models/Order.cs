using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace swizzyapi.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int RestaurantId { get; set; }
        public string Phone { get; set; }
        public int ItemId { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
    }
}
