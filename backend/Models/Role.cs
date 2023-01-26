using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

public class Role : IdentityRole{
    
    [Required]
    public int roleid{get;set;}
}