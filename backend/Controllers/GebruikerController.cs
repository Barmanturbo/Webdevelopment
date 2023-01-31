using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace backend.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize (Roles = "Admin")]
public class GebruikerController : ControllerBase
{
    //public static DBContext _context = new DBContext();
    private readonly IConfiguration _config;
    public GebruikerController(IConfiguration config)
    {
        _config = config;
    }

    // GET: api/Gebruiker
    [HttpGet, Authorize(Roles = "Admin")]
    public async Task<ActionResult<IEnumerable<Gebruiker>>> getGebruiker()
    {
        using (var _context = new DBContext())
        {
            if (_context.gebruikers == null)
            {
                return NotFound();
            }
            return await _context.gebruikers.ToListAsync();
        } 
    }

    // GET: api/Gebruiker/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Gebruiker>> GetGebruikerUsingId(int id)
    {
        using (var _context = new DBContext())
        {
            if (_context.gebruikers == null)
            {
                return NotFound();
            }
            var gebruiker = await _context.gebruikers.FindAsync(id);

            if (gebruiker == null)
            {
                return NotFound();
            }
            return Ok(gebruiker); 
        }
    }

    // POST: api/Gebruiker
    [HttpPost]
    public async Task<ActionResult<Gebruiker>> PostGebruiker(Gebruiker gebruiker)
    {
        using (var _context = new DBContext())
        {
            if (_context.gebruikers == null)
            {
                return Problem("Entity set 'DBcontext.gebruikers'  is null.");
            }
            _context.gebruikers.Add(gebruiker);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGebruiker", new { id = gebruiker.UserID }, gebruiker);
        }
    }
    // POST: api/Gebruiker/login
    [HttpPost("login")]
    public async Task<ActionResult<string>> PostLoginGebruiker(Gebruiker gebruiker)
    {
        using (var _context = new DBContext())
        {

            if (_context.gebruikers == null /* ||gebruiker.Email == cookieGebruiker.Username*/)
            {
                //return uw bent al ingelogt. 
                return Problem("Entity set 'DBcontext.gebruikers'  is null.");
            }

            Gebruiker getUser = await getGebruikerUsingLogin(gebruiker.Username); 

            if (getUser == null)
            {
                return NotFound();
            }
            if (getUser.Username == gebruiker.Username && getUser.Wachtwoord == gebruiker.Wachtwoord)
            {
                //if (!VerifyPasswordHash(...)){
                //return BadRequest("Wrong password");}
                var token = CreateToken(gebruiker ,"admin"); 
                return Ok(token);
            }
            else
            {
                return NotFound();
                
            }
            
        }
    }    

    //PUT api/Gebruiker/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutGebruiker(int id, Gebruiker gebruiker)
    {
        using (var _context = new DBContext())
        {
            if (_context.gebruikers == null)
            {
                return Problem("Entity set 'DBcontext.gebruikers'  is null.");
            }
            if (id != gebruiker.UserID)
            {
                return BadRequest();
            }
            _context.Entry(gebruiker).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

    private bool GebruikerExists(int id)
    {
        using (var _context = new DBContext())
        {
            return _context.gebruikers.Any(e => e.UserID == id);
        }
    }

    // DELETE: api/Gebruiker/5
    [HttpDelete("{id}"), Authorize(Roles = "admin")] //AllowAnonimous //Authenicate the web token. 
    public async Task<ActionResult<Show>> DeleteGebruiker(int id)
    {
        using (var _context = new DBContext())
        {
            if (_context.gebruikers == null)
            {
                return Problem("Entity set 'DBcontext.gebruikers'  is null.");
            }
            var gebruiker = await _context.gebruikers.FindAsync(id);
            if (gebruiker == null)
            {   
                return NotFound();
            }
            _context.gebruikers.Remove(gebruiker);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

    private string CreateToken(Gebruiker gebruiker, string role)
    {
        List<Claim> claims = new List<Claim>
        { 
            new Claim (ClaimTypes.NameIdentifier, gebruiker.UserID.ToString()),
            new Claim (ClaimTypes.Name, gebruiker.Username),
            new Claim(ClaimTypes.Role, "Admin")
        };
        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddHours(6),
            signingCredentials: cred
            );
        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return jwt;
    }

    private async Task<Gebruiker> getGebruikerUsingLogin(string username)
    {
        using (var _context = new DBContext())
        {
            if (_context.gebruikers == null)
            {
                return null;
            }
            var gebruiker = await _context.gebruikers
                    .Where(user => user.Username == username)
                    .FirstOrDefaultAsync();
            return gebruiker; 
        }
    }
    [HttpGet("autorize"), Authorize]
    public async Task<ActionResult<string?>> GetUsername()
    {   
        var role = User.FindFirstValue(ClaimTypes.Role);
        var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var username = User?.Identity?.Name;
        return Ok(new {username, role, id});
    }


    //private bool VerifyPasswordHash(string loginPassword, Gebruiker gebruiker)
    //{
   //     using (var hash = new HMACSHA512(gebruiker./*passwordHash*/))
   //        {
   //           var computeHash = hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(loginPassword));
   //           return computeHash.SequenceEqual(/*gebruiker.passwordHash*/);


   //        }
   //}

   private void PasswordHash(Gebruiker gebruiker)
    {
            using (var hash = new HMACSHA512())
            {
                //gebruiker.passwordHash = hash.Key;
                //gebruiker.saltHash = hmac.Computehash(.....);
            }
    }

}
