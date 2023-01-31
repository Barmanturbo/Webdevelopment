using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[Route("api/[controller]")]

[ApiController]
public class ZaalController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Zaal>> PostZaal(Zaal nieuwezaal){
        try{
            using (var _context = new DBContext()){
                _context.zalen
                    .Add(nieuwezaal);
                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK);
            }
        }catch(Exception e){
            if(e.Equals(e)){}//Doesn't give any warning for not using e
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}