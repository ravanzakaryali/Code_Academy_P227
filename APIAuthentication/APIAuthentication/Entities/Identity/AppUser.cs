using Microsoft.AspNetCore.Identity;

namespace APIAuthentication.Entities.Identity;

public class AppUser : IdentityUser
{
    public string Fullname { get; set; } = null!;
}
