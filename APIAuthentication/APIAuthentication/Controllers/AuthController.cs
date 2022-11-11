using APIAuthentication.DTOs.AuthDtos;
using APIAuthentication.Entities.Enums;
using APIAuthentication.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDto registerDto)
        {
            AppUser user = await _userManager.FindByEmailAsync(registerDto.Email);
            if (user is not null) return StatusCode(StatusCodes.Status403Forbidden,new
            {
                Message = "User is already exist"
            });
            //MailAddress mailAddress = new(registerDto.Email);
            AppUser newUser = new()
            {
                Fullname = registerDto.Fullname,
                Email = registerDto.Email,
                UserName = registerDto.Email
            };
            IdentityResult result =  await _userManager.CreateAsync(newUser, registerDto.Password);
            if (!result.Succeeded) return StatusCode(StatusCodes.Status403Forbidden, new
            {
                Message = "Register error",
                result.Errors
            });
            IdentityResult resultAddRole = await _userManager.AddToRoleAsync(newUser,Roles.Member.ToString());
            if (!resultAddRole.Succeeded) return StatusCode(StatusCodes.Status403Forbidden, new
            {
                Message = "Register error",
                resultAddRole.Errors
            });
            return Ok(new
            {
                Message = "Register success"
            });
        }

        [HttpPost("add-role")]
        public async Task<IActionResult> AddRoleAsync()
        {
            foreach (object item in Enum.GetValues(typeof(Roles)))
            {
                if(!await _roleManager.RoleExistsAsync(item.ToString()))
                {
                    await _roleManager.CreateAsync(new AppRole
                    {
                        Name = item.ToString(),
                    });
                }
            }
            return NoContent();
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto login)
        {
            AppUser user = await _userManager.FindByEmailAsync(login.Email);
            if (user is null) return NotFound();
            if (!await _userManager.CheckPasswordAsync(user, login.Password)) return Unauthorized();

            IList<string> roles = await _userManager.GetRolesAsync(user);

            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.NameIdentifier,user.Id),
                new Claim("Fullname",user.Fullname),
            };

            claims.AddRange(roles.Select(r=>new Claim(ClaimTypes.Role,r)));

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["JWT:securityKey"]));

            SigningCredentials signingCredentials = new(securityKey,SecurityAlgorithms.HmacSha256);

            DateTime expries = DateTime.Now.AddMinutes(45);

            JwtSecurityToken securityToken = new(issuer: _configuration["JWT:issuer"], audience: _configuration["JWT:audience"],
                claims: claims,expires: expries,signingCredentials: signingCredentials,notBefore: null);

            string token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return Ok(new
            {
                token,
                Message = "Login success"
            });
        }
    }
}
