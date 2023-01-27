using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

public class Gebruiker //: IdentityUser
{
    [Key]
    public int UserID {get; set;}

    [Required]
    [MaxLength (100)]
    public string Naam {set; get;} = string.Empty;

    [Required]
    public string Email {set; get;} = string.Empty;

    [Required]
    public string Wachtwoord {set; get;} = string.Empty;
    //Password hash? Security? 
    //public byte[] PasswordHash { get; set; }
    //public byte[] SaltHash { get; set; }


    [Required]
    public string Username {set;get;} = string.Empty;
    // public List<Ticket>? tickets {set; get;}
}

public class GebruikerLogin{
    [Required(ErrorMessage = "Username is required")]
    public string? UserName { get; init; }

    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; init; }
}