using System.Linq;
using System.Threading.Tasks;
using WebApp.Dto;
using WebApp.Exceptions;
using WebApp.Helpers;

namespace WebApp.Services
{
    public sealed class UserService : IUserService
    {
        public AppDatabaseContext _context;

        public UserService(AppDatabaseContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public IQueryable<User> GetAllUsers()
        {
            return _context.Users.AsQueryable();
        }

        /// <inheritdoc />
        public async Task<User> GetUser(int userId)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == userId);

            if (user is null)
                throw new NotFoundException($"User with Id {userId} does not exist");

            return await Task.FromResult(user);
        }

        /// <inheritdoc />
        public async Task<long> AddUser(NewUser newUser)
        {
            var isEmailInDatabase = _context.Users.FirstOrDefault(u => u.Email == newUser.Email);

            if (isEmailInDatabase is not null)
                throw new BadRequestException($"Email {newUser.Email} already exists in database");

            var user = new User(newUser.Email, newUser.FirstName, newUser.LastName,
                newUser.PasswordPlainText);

            _context.Add(user);

            await _context.SaveChangesAsync();

            return await Task.FromResult(user.UserId);
        }

        /// <inheritdoc />
        public async Task DeleteUser(int userId)
        {
            var user = await GetUser(userId);

            if (user is null) throw new NotFoundException($"User with Id {userId} does not exist");
            _context.Remove(user);

            await _context.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task<User> UpdateUser(int userId, NewUser newUser)
        {
            var user = await GetUser(userId);

            if (user is null)
                throw new NotFoundException($"User with Id {userId} does not exist");

            _context.Users.First(u => u.UserId == userId).Email = newUser.Email;
            _context.Users.First(u => u.UserId == userId).FirstName = newUser.FirstName;
            _context.Users.First(u => u.UserId == userId).LastName = newUser.LastName;
            _context.Users.First(u => u.UserId == userId).PasswordHash =
                Hashing.GetSha512Hash(_context.Users.First(u => u.UserId == userId).Salt + newUser.PasswordPlainText);

            await _context.SaveChangesAsync();

            return await Task.FromResult(user);
        }
    }
}