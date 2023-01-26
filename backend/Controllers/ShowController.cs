using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShowController : ControllerBase
{
    //public static DBContext _context = new DBContext();

    // GET: api/Show
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Show>>> getShows()
    {
        using (var _context = new DBContext())
        {
            if (_context.shows == null)
            {
                return NotFound();
            }
            return await _context.shows.ToListAsync();
        }
    }

    // GET: api/Show/5
    [HttpGet("usingId{id}")]
    public async Task<ActionResult<Show>> GetShowUsingId(int id)
    {
        using (var _context = new DBContext())
        {
            if (_context.shows == null)
            {
                return NotFound();
            }
            var show = await _context.shows.FindAsync(id);

            if (show == null)
            {
                return NotFound();
            }
            return show;
        }
    }

    // // GET: api/Show/ShowName
    // [HttpGet("{name}")] 
    // public async Task<ActionResult<Show>> GetShowUsingName(String name)
    // {
    //    if (_context.shows == null)
    //    {
    //        return NotFound();
    //    }
    //    var show = await _context.shows.FindAsync(name);
    //    if (show == null)
    //    {
    //        return NotFound();
    //    }
    //    return show;
    // }

    // POST: api/Show
    [HttpPost]
    public async Task<ActionResult<Show>> PostShow(Show show)
    {
        using (var _context = new DBContext())
        {
            if (_context.shows == null)
            {
                return Problem("Entity set 'DBcontext.shows'  is null.");
            }
            _context.shows.Add(show);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShow", new { id = show.Shownr }, show);
        }
    }

    // DELETE: api/Show/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<Show>> DeleteShow(int id)
    {
        using (var _context = new DBContext())
        {
            if (_context.shows == null)
            {
                return Problem("Entity set 'DBcontext.shows'  is null.");
            }
            var show = await _context.shows.FindAsync(id);
            if (show == null)
            {
                return NotFound();
            }
            _context.shows.Remove(show);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}