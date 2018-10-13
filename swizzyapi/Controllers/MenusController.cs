using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using swizzyapi.Models;
using Microsoft.AspNetCore.Cors;
namespace swizzyapi.Controllers
{
    [EnableCors("Cors")]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class MenusController : ControllerBase
    {
        private readonly SwizzyContext _context;

        public MenusController(SwizzyContext context)
        {
            _context = context;
        }

        // GET: api/Menus
        [HttpGet]
        public ActionResult<List<Menu>> GetAll()
        {
            return _context.Menu.ToList();
        }

        //// GET: api/Menus/5
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetMenu([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var menu = await _context.Menu.FindAsync(id);

        //    if (menu == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(menu);
        //}

        //// PUT: api/Menus/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutMenu([FromRoute] int id, [FromBody] Menu menu)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != menu.MenuId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(menu).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!MenuExists(id))
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

        // POST: api/Menus
        [HttpPost]
        public IActionResult Create(Menu menu)
        {
            _context.Menu.Add(menu);
            _context.SaveChanges();
            return CreatedAtAction("GetMenu", new { id = menu.MenuId }, menu);
        }

        //// DELETE: api/Menus/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteMenu([FromRoute] int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var menu = await _context.Menu.FindAsync(id);
        //    if (menu == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Menu.Remove(menu);
        //    await _context.SaveChangesAsync();

        //    return Ok(menu);
        //}

        //private bool MenuExists(int id)
        //{
        //    return _context.Menu.Any(e => e.MenuId == id);
        //}
    }
}