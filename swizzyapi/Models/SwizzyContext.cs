using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SwizzyApi.Models;
namespace swizzyapi.Models
{
    public class SwizzyContext : IdentityDbContext<IdentityUser>
    {
        public SwizzyContext(DbContextOptions<SwizzyContext> options) : base(options) { }

        public DbSet<Address> Address { get; set; }
        public DbSet<Restaurant> Restaurant { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }

}
