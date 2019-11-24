using System;
using Entities.Models;
using Repository.DTOs;

namespace Repository.Utils
{
    public class UserHandler
    {
        // Map object to DTO
        public static UserDTO MapToApp(User model)
        {
            try
            {
                return new UserDTO()
                {
                    Id = model.Id,
                    Email = model.Email,
                    Type = model.Type,
                    UpdatedAt = model.UpdatedAt,
                    Status = model.Status
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}