/*using Microsoft.EntityFrameworkCore;
using MyApp.Service;
using MyApp.Model;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Service
{
    public class UserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserAsync(string username, string passwordHash)
        {
            return await _context.Users
                                 .Where(u => u.Username == username && u.PasswordHash == passwordHash)
                                 .FirstOrDefaultAsync();
        }

        public async Task<User> AddUserAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
*/