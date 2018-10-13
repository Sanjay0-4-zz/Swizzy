using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace swizzyapi.Models
{
    public class Customer
    {

        public int Id { get; set; }
        
        
        public string Location { get; set; }
        public string Locale { get; set; }
        public string Gender { get; set; }
        public IdentityUser Identity { get; set; }  // navigation property
        public string IdentityId { get; set; }
    }
}
