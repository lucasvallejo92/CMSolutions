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
    public class UserRepository : IRepository<UserDTO>, IAuthRepository<UserDTO>
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
            var allreadyExists = await _context.Users.Where(x => x.Email == entity.Email).FirstOrDefaultAsync();

            if (allreadyExists != null)
            {
                return false;
            }

            _context.Users.Add(UserHandler.MapToDb(entity));
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> UpdateAsync(int id, UserDTO entity)
        {
            try
            {
                var user = await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();

                var valid = entity.Email == user.Email || await ValidateEmail(entity.Email);
                if (!valid)
                {
                    return false;
                }
                
                user = UserHandler.UpdateToDb(user, entity);
                
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        private async Task<bool> ValidateEmail(string email)
        {
            if (email == null)
            {
                return true;
            }
            var user = await _context.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
            return user == null;
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
        
        public async Task<UserDTO> AuthorizeAsync(UserCredentials credentials)
        {
            var user = await _context.Users.Where(x => x.Email == credentials.Email && x.Password == credentials.Password).FirstOrDefaultAsync();
            return user == null ? null : UserHandler.MapToApp(user);
        }
        
        
    }
}