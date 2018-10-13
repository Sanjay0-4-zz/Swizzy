using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwizzyApi.Models;
using swizzyapi.Models;
using Microsoft.AspNetCore.Cors;

namespace swizzyapi.Controllers
{
    [EnableCors("Cors")]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly SwizzyContext _context;

        public RestaurantsController(SwizzyContext context)
        {
            _context = context;
        }

       //GET: api/Restaurants
       [HttpGet]
        public ActionResult<List<Restaurant>> GetAll()
        {
            return _context.Restaurant.ToList();
        }

        // GET: api/Restaurants/5
        [HttpGet("{id}")]
        public ActionResult<Restaurant> GetById(int id)
        {           
            var restaurant = _context.Restaurant.Find(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return restaurant;
        }

        // PUT: api/Restaurants/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutRestaurant([FromRoute] int id, [FromBody] Restaurant restaurant)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != restaurant.RestaurantId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(restaurant).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!RestaurantExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Restaurants
        [HttpPost]
        public IActionResult Create(Restaurant restaurant)
        {
            _context.Restaurant.Add(restaurant);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = restaurant.RestaurantId }, restaurant);
        }

        //// DELETE: api/Restaurants/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteRestaurant([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var restaurant = await _context.Restaurant.FindAsync(id);
        //    if (restaurant == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Restaurant.Remove(restaurant);
        //    await _context.SaveChangesAsync();

        //    return Ok(restaurant);
        //}

        //private bool RestaurantExists(int id)
        //{
        //    return _context.Restaurant.Any(e => e.RestaurantId == id);
        //}
    }
}