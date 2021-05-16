using AutoMapper;
using FinanceWebApp.Data;
using FinanceWebApp.DTOs;
using FinanceWebApp.Entities;
using FinanceWebApp.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FinanceWebApp.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public AccountController(ITokenService tokenService, IMapper mapper)
        {
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto dto)
        {
            if (await UserExists(dto.Username)) return BadRequest("Username is taken");

            var user = _mapper.Map<User>(dto);
            using var hmac = new HMACSHA512();

            user.Username = dto.Username.ToLower();
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(dto.Password));
            user.PasswordSalt = hmac.Key;

            SqliteDataAccess.SaveUserAsync(user);

            return new UserDto
            {
                Username = user.Username,
                Token = _tokenService.CreateToken(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await SqliteDataAccess.GetUserAsync(loginDto.Username);

            if (user == null) return Unauthorized("Invalid username");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");

            return new UserDto
            {
                Username = user.Username,
                Token = _tokenService.CreateToken(user),
            };
        }

        private async Task<bool> UserExists(string username)
        {
            return await SqliteDataAccess.GetUserAsync(username) != null;
        }
    }
}
