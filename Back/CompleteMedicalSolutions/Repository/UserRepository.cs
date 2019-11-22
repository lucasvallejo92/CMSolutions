using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.DTOs;
using Repository.Enums;
using Repository.Interfaces;
using Repository.Models;
using Repository.Utils;

namespace Repository
{
    public class UserRepository : IRepository<UserDTO>, IAuthRepository<UserCredentials>
    {
        private readonly CmsolutionsContext _context;

        public UserRepository(CmsolutionsContext context)
        {
            _context = context;
        }

        public List<UserDTO> GetAllAsync()
        {
            return _context.Users.Select(UserHandler.MapToApp).ToList();
        }
        

        public async Task<UserDTO> GetAsync(int id)
        {
            var user = await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            return UserHandler.MapToApp(user);
        }

        public async Task<bool> AddAsync(UserDTO entity)
        {
            var allreadyExists = await _context.Users.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();

            if (allreadyExists != null)
            {
                return false;
            }

            // _context.Users.Add(_mapper.Map<Users>(entity));
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> UpdateAsync(int id, UserDTO entity)
        {
            var user = await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();

            // user = _mapper.Map(entity, user);

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ResponseType> DeleteAsync(int id)
        {
            var user = await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (user == null)
            {
                return ResponseType.Not_Found;
            }

            _context.Remove(user);
            await _context.SaveChangesAsync();

            return ResponseType.Deleted;
        }
        
        public async Task<ResponseType> AuthorizeAsync(UserCredentials credentials)
        {
            var user = await _context.Users.Where(x => x.Email == credentials.Email && x.Password == credentials.Password).FirstOrDefaultAsync();

            return user == null ? ResponseType.Not_Found : ResponseType.Ok;
        }
        
        
    }
}