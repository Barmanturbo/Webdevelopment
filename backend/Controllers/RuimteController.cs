using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[Route("api/[controller]")]

[ApiController]
public class RuimteController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Ruimte>> PostRuimte(Ruimte nieuweRuimte){
        try{
            using (var _context = new DBContext()){
                _context.ruimtes
                    .Add(nieuweRuimte);
                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK);
            }
        }catch(Exception e){
            if(e.Equals(e)){}//doesn't give warning anymroe for not using e
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}