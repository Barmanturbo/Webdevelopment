using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    [Route("api/AccountController/{username}/{pass}")]
    public IEnumerable<Gebruiker> CheckLogin(string username, string pass)
    {
        using (var _context = new DBContext())
        {
            if (_context.gebruikers == null)
            {
                return (IEnumerable<Gebruiker>)NotFound();
            }
            else
            {
                var gebruiker = _context.gebruikers
                    .Where((g) => g.Username == username && g.Wachtwoord == pass)
                    .Select((g) => new {g.Username, g.Wachtwoord, g.rol})
                    .ToList();
                if(gebruiker.Count()==1){
                    return (IEnumerable<Gebruiker>)gebruiker;
                }else {return (IEnumerable<Gebruiker>)NotFound();}
            }
        }
    }
    // private readonly UserManager<IdentityUser> _userManager;
    // private readonly SignInManager<IdentityUser> _signInManager;
    // private readonly RoleManager<IdentityRole> _roleManager;

    // public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager){
    //     _userManager = userManager;
    //     _signInManager = signInManager;
    //     _roleManager = roleManager;
    // }

    // [HttpPost("registreerGebruiker")]
    // public async Task<ActionResult<IEnumerable<Gebruiker>>> RegistreerGebruiker([FromBody] Gebruiker gebruiker){
    //     var resultaat = await _userManager.CreateAsync(gebruiker, gebruiker.Wachtwoord);
    //         resultaat = await _userManager.AddToRoleAsync(gebruiker, "Gebruiker");        
    //     return !resultaat.Succeeded ? new BadRequestObjectResult(resultaat) : StatusCode(201);
    // }

    // [HttpPost("registreerMedewerker")]
    // public async Task<ActionResult<IEnumerable<Gebruiker>>> RegistreerMedewerker([FromBody] Gebruiker gebruiker){
    //     var resultaat = await _userManager.CreateAsync(gebruiker, gebruiker.Wachtwoord);
    //         resultaat = await _userManager.AddToRoleAsync(gebruiker, "Medewerker");
    //     return !resultaat.Succeeded ? new BadRequestObjectResult(resultaat) : StatusCode(201);
    // }

    // [HttpPost("login")]
    // public async Task<IActionResult> Login([FromBody] GebruikerLogin gebruikerLogin){
    //     var _user = await _userManager.FindByNameAsync(gebruikerLogin.UserName);
    //     if (_user != null)
    //         if (await _userManager.CheckPasswordAsync(_user, gebruikerLogin.Password)){
    //             var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("awef98awef978haweof8g7aw789efhh789awef8h9awh89efh89awe98f89uawef9j8aw89hefawef"));
    //             var signingCredentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    //             var claims = new List<Claim> { new Claim(ClaimTypes.Name, _user.UserName) };
    //             var roles = await _userManager.GetRolesAsync(_user);
    //             foreach (var role in roles)
    //                 claims.Add(new Claim(ClaimTypes.Role, role));
    //             var tokenOptions = new JwtSecurityToken(
    //                 issuer: "https://localhost:7014",
    //                 audience: "https://localhost:7014",
    //                 claims: claims,
    //                 expires: DateTime.Now.AddMinutes(10),
    //                 signingCredentials: signingCredentials
    //             );
    //             return Ok(new { Token = new JwtSecurityTokenHandler().WriteToken(tokenOptions) });
    //         }
    //     return Unauthorized();
    // }

    // [HttpGet ("checkloginof{username}&password{password}")]
    // public async Task<IResult> Get(string username, string password){
    //     bool correctelogin = await Loginhandler.checkLogin(username,password);
    //     if (correctelogin)
    //     {
    //         return Results.Ok("success");
    //     }
    //     else
    //     {
    //         return Results.BadRequest();
    //     }
    // }
}