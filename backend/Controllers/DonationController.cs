using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[Route("api/[controller]")]

[ApiController]
public class DonationController : ControllerBase
{
    // GET: api/<DonationController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] {"Value1","Value2"};
    }

    //Get api//<DonationController>/id
    [HttpGet("donate")]
    public string Get(int id)
    {
        return "Value";
    } 

    //POST api/<DonationController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Post(Gebruiker pG)
    {
        try{
            using (var _context = new DBContext()){
                if (_context.gebruikers == null){
                    return NotFound();
                }
                var gebruikersID = _context.gebruikers
                    .Where(g=>g.Email==pG.Email)
                    .Select(g=>g.UserID)
                    .First();
    //Nu hebben we de UserID van degene die gedoneerd heeft.
    //Update nu user met UserID = gebruikersID zodat TotaleDonatie
    //verhoogd wordt met Hoeveelheid.          
            }
            return StatusCode(StatusCodes.Status200OK);
        }catch(Exception e){
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    //PUT api/<DonationController>/id
    [HttpPut ("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    } 

    //DELETE api/<DonationController>/id
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        
    }
}