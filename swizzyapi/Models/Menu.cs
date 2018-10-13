using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace swizzyapi.Models
{
    public class Menu
    {
        public int MenuId { get; set; }
        public int RestaurantId { get; set; }
        public string ItemName { get; set; }
        public double ItemPrice { get; set; }
    }
}
