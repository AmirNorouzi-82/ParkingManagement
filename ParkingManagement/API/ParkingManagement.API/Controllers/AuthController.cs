using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ParkingManagement.API.Models;
using ParkingManagement.Infrastructure.ParkingManagement.Persistance.Contexts;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ParkingManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ParkingDbContext _db;
        private readonly IConfiguration _config;

        public AuthController(ParkingDbContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthRequest request)
        {
            if (request is null)
                return BadRequest(new { message = "Request body is required." });

            request.Username = (request.Username ?? "").Trim();
            request.Password = (request.Password ?? "").Trim();

            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
                return BadRequest(new { message = "Username and Password are required." });

            try
            {
                var admin = await _db.Admins.FirstOrDefaultAsync(a => a.Username == request.Username);

                if (admin is null)
                {
                    Log.Warning("Login failed: user not found. username={Username}", request.Username);
                    return Unauthorized(new { message = "Invalid username or password." });
                }

                if ((admin.PasswordHash ?? "").Trim() != request.Password)
                {
                    Log.Warning("Login failed: wrong password. username={Username}", request.Username);
                    return Unauthorized(new { message = "Invalid username or password." });
                }

                var jwtKey = _config["Jwt:Key"];
                var issuer = _config["Jwt:Issuer"];
                var audience = _config["Jwt:Audience"];

                if (string.IsNullOrWhiteSpace(jwtKey) || string.IsNullOrWhiteSpace(issuer) || string.IsNullOrWhiteSpace(audience))
                {
                    Log.Error("JWT settings missing. Jwt:Key/Issuer/Audience");
                    return StatusCode(500, new { message = "JWT settings are missing in appsettings.json (Jwt:Key/Issuer/Audience)" });
                }

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, admin.Id.ToString()),
                    new Claim(ClaimTypes.Name, admin.Username ?? "admin"),
                    new Claim(ClaimTypes.Role, "Admin"),
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var expires = DateTime.UtcNow.AddHours(4);

                var token = new JwtSecurityToken(
                    issuer: issuer,
                    audience: audience,
                    claims: claims,
                    expires: expires,
                    signingCredentials: creds
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                Log.Information("Login success. username={Username} adminId={AdminId}", admin.Username, admin.Id);

                return Ok(new AuthResponse
                {
                    Token = tokenString,
                    Expiration = expires,
                    Admin = new
                    {
                        admin.Id,
                        admin.Username,
                        admin.Email,
                        admin.FullName
                    }
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Login failed due to server/database error. username={Username}", request.Username);

                return StatusCode(500, new
                {
                    message = "Login failed due to server/database error.",
                    detail = ex.Message
                });
            }
        }
    }
}
