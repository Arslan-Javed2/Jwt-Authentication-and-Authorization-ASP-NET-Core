using LoginAPI.Data;
using LoginAPI.Models;
using LoginAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LoginAPI.Repositories.Implementations
{
    public class UserAPIRepository : IUserAPI
    {
        private readonly MyDBContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserAPIRepository(MyDBContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> GetName()
        {
            string userName = null;
            if (_httpContextAccessor != null)
            {
                userName=_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            }
            return userName;
        }
        public async Task<string> CreateUser(Users users)
        {
            await _context.Users.AddAsync(users);
            await _context.SaveChangesAsync();
            return "User Added Successfully!";
        }

        public async Task<List<Users>> GetUsersData()
        {
            var dataOfUsers = await _context.Users.ToListAsync();
            return dataOfUsers;
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<Users> GetUsersDataById(int id)
        {
            var dataById=await _context.Users.FindAsync(id);
            return dataById;
        }

        public async Task<string> GetUsersDataByUserNameAndPassword(string userName, string password)
        {
            string token = null;
            var userData = await _context.Users.Where(u=>u.UserName==userName && u.Password==password).FirstOrDefaultAsync();
            if(userData is not null)
            {
                token = GenerateToken(userData);
            }
            return token;
        }

        private string? GenerateToken(Users userData)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,userData.UserName),
                new Claim(ClaimTypes.Role,"Admin"),
                new Claim(ClaimTypes.Role,"Ali")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("GHJJvhgghBVHGJH67867*^&8678t767VHHJVJHvkhjh"));

            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256Signature);

            var token = new JwtSecurityToken
                (
                    claims:claims,
                    expires:DateTime.Now.AddMinutes(2),
                    signingCredentials:creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;

        }
    }
}
