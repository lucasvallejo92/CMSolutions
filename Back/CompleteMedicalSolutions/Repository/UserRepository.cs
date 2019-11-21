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

namespace Repository
{
    public class UserRepository : IRepository<UserDTO>, IAuthRepository<UserCredentials>
    {
        private readonly CmsolutionsContext _context;

        public UserRepository(CmsolutionsContext context)
        {
            _context = context;
        }

        //public async Task<IEnumerable<UserDTO>> GetAllAsync()
        //{
        //    var users = await _context.Users.ToListAsync();
        //    return new IEnumerable<UserDTO>(users);
        //}

        public async Task<UserDTO> GetAsync(int id)
        {
            var user = await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            return ParseUser(user);
        }

        private UserDTO ParseUser(User user)
        {
            if (user == null)
            {
                return null;
            }
            var usr = new UserDTO();
            usr.Id = user.Id;
            usr.Email = user.Email;
            usr.Type = user.Type;
            usr.UpdatedAt = user.UpdatedAt;
            usr.Status = user.Status;

            return usr;
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