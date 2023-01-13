using Microsoft.IdentityModel.Tokens;
using DigitalBooksAppln.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;

namespace DigitalBooksAppln.Services
{
    public class UsersService : IUsers
    {
        DigitalBooksContext _db;
        private IConfiguration _config;
        public UsersService(DigitalBooksContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }
        public async Task<LoginModel> LoginAsync(User login, bool IsRegister)
        {
            var loginModel = new LoginModel();
            try
            {
                string token = string.Empty;
                var tokenString = token;
                var user = AuthenticateUser(login, IsRegister);
                if (user != null)
                {
                    tokenString = GenerateToken(user);
                    loginModel = new LoginModel { User = user, token = tokenString };
                    return loginModel;
                }

                return loginModel;
            }
            catch (Exception ex)
            {
                return loginModel;
            }
        }

        private User AuthenticateUser(User login, bool IsRegister)
        {
            if (IsRegister)
            {
                _db.Users.Add(login);
                _db.SaveChanges();
                return login;
            }
            else
            {
                if (_db.Users.Any(x => x.UserName == login.UserName && x.Password == login.Password))
                {
                    return _db.Users.Where(x => x.UserName == login.UserName && x.Password == login.Password).FirstOrDefault();
                }
                else
                {
                    return null;
                }
            }
        }

        private string GenerateToken(User login)
        {
            var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.UniqueName, login.UserName??""),
            new Claim(JwtRegisteredClaimNames.Email, login.EmailId??""),
            new Claim(ClaimTypes.Role,login.UserType??"")
        };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_config["jwt:Issuer"],
                _config["jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<string> RegisterAsync(User login, bool IsRegister)
        {
            try
            {
                string token = string.Empty;
                var tokenString = token;
                var user = AuthenticateUser(login, IsRegister);
                if (user != null)
                {
                    tokenString = GenerateToken(user);
                    return tokenString;
                }

                return tokenString;
            }
            catch (Exception ex)
            {
                return "Something went wrong" + ex;
            }
        }
    }
}
