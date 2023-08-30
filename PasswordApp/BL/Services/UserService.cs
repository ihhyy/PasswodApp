using BL.Interfaces;
using BL.Models;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BL.Services
{
    public class UserService : IUserMethods
    {
        private readonly IUserRepository userRepository;
        private readonly IConfiguration configuration;

        public UserService(IUserRepository _userRepository, IConfiguration _configuration)
        {
            userRepository = _userRepository;
            configuration = _configuration;
        }

        public User RegisterUser(UserLogin request)
        {
            User user = new();
            CreatePasswodHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.UserName = request.UserName;
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            userRepository.SetUserAsync(user);

            return user;
        }

        public async Task<string> LoginUserAsync(UserLogin request)
        {
            User user = await userRepository.GetUserByNameAsync(request.UserName);

            if (user == null)
            {
                throw new Exception("user not found");
            }
            
            if(!VerifyPasswodHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                throw new Exception("wrong password");
            }

            return CreateToken(user);
        }

        private string CreateToken(User user)
        {
            string? audience = configuration["Jwt:Audience"];
            string? key = configuration["Jwt:Key"];
            string? issuer = configuration["Jwt:Issuer"];

            SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(key));
            SigningCredentials credentials = new(securityKey, SecurityAlgorithms.HmacSha256);

            Claim[] claims = new[]
            {
               new Claim(ClaimTypes.Name, user.UserName)
            };

            var token = new JwtSecurityToken(issuer,
                audience,
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private void CreatePasswodHash(string password, out byte[] passwordHash, out byte[] passwodSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwodSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswodHash(string password, byte[] passwordHash, byte[] passwodSalt)
        {
            using (var hmac = new HMACSHA512(passwodSalt))
            {
                var computeCash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computeCash.SequenceEqual(passwordHash);
            }
        }
    }
}
