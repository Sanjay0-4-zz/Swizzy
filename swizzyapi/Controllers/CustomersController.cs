using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using swizzyapi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace swizzyapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly SwizzyContext _context;
        private readonly SwizzyContext _appDbContext;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;

        public CustomersController(SwizzyContext context, UserManager<IdentityUser> userManager, IMapper mapper, SwizzyContext appDbContext)
        {
            _context = context;

            _userManager = userManager;
            _mapper = mapper;
            _appDbContext = appDbContext;

        }

        // GET: api/Customers
        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers;
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer([FromRoute] int id, [FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customer.Id)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Customers
        [HttpPost]
        public async Task<IActionResult> PostCustomer([FromBody] BinderModel customer)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //_context.Customers.Add(customer);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userIdentity = new IdentityUser { UserName = customer.UserName, Email=customer.Email};

            var result = await _userManager.CreateAsync(userIdentity, customer.Password);

                        if (!result.Succeeded) return new BadRequestObjectResult("Not Created");

            Customer cus = new Customer { IdentityId=userIdentity.Id };
            await _appDbContext.Customers.AddAsync(cus );
            await _appDbContext.SaveChangesAsync();

            return new OkObjectResult("Account created");

        }
    
        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return Ok(customer);
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }

    public class BinderModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}