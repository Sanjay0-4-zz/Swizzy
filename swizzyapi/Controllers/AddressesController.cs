using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using swizzyapi.Models;

namespace swizzyapi.Controllers
{
    [EnableCors("Cors")]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly SwizzyContext _context;

        public AddressesController(SwizzyContext context)
        {
            _context = context;
        }

        //// GET: api/Addresses
        //[HttpGet]
        //public IEnumerable<Address> GetAddress()
        //{
        //    return _context.Address;
        //}

        //// GET: api/Addresses/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetAddress([FromRoute] long id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var address = await _context.Address.FindAsync(id);

        //    if (address == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(address);
        //}

        //// PUT: api/Addresses/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAddress([FromRoute] long id, [FromBody] Address address)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != address.id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(address).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AddressExists(id))
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

        [HttpGet]
        public ActionResult<List<Address>> GetAll()
        {
            return _context.Address.ToList();
        }

        //// POST: api/Addresses
        
        [HttpPost]
        public IActionResult Create(Address address)
        {
            _context.Address.Add(address);
            _context.SaveChanges();
            return CreatedAtRoute("GetAddress", new { id = address.id }, address);
        }

        //// DELETE: api/Addresses/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteAddress([FromRoute] long id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var address = await _context.Address.FindAsync(id);
        //    if (address == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Address.Remove(address);
        //    await _context.SaveChangesAsync();

        //    return Ok(address);
        //}

        //private bool AddressExists(long id)
        //{
        //    return _context.Address.Any(e => e.id == id);
        //}
    }
}