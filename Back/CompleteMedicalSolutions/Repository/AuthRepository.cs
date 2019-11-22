using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.DTOs;
using Repository.Models;
using Repository.Utils;

namespace Repository
{
    public class AuthRepository
    {
        private readonly CmsolutionsContext _context;

        public AuthRepository(CmsolutionsContext context)
        {
            _context = context;
        }
        
        public async Task<UserDTO> LogIn(UserCredentials credentials)
        {
            var user = await _context.Users.Where(x => x.Email == credentials.Email && x.Password == credentials.Password).FirstOrDefaultAsync();

            return user == null ? null : UserHandler.MapToApp(user);
        }
    }
}