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
                    Password = "PRIVATE",
                    Name = model.Name,
                    Surname = model.Surname,
                    ProfId = model.ProfId,
                    EnrollmentNum = model.EnrollmentNum,
                    EnrollmentType = model.EnrollmentType,
                    Phone = model.Phone,
                    Address = model.Address,
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
        
        public static User MapToDb(UserDTO model)
        {
            try
            {
                return new User()
                {
                    Id = model.Id,
                    Email = model.Email,
                    Password = model.Password,
                    Name = model.Name,
                    Surname = model.Surname,
                    ProfId = model.ProfId,
                    EnrollmentNum = model.EnrollmentNum,
                    EnrollmentType = model.EnrollmentType,
                    Phone = model.Phone,
                    Address = model.Address,
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
        public static User UpdateToDb(User userFromDb, UserDTO entity)
        {
            try
            {
                userFromDb.Email = entity.Email ?? userFromDb.Email;
                userFromDb.Password = entity.Password ?? userFromDb.Password;
                userFromDb.Name = entity.Name;
                userFromDb.Surname = entity.Surname;
                userFromDb.ProfId = entity.ProfId;
                userFromDb.EnrollmentNum = entity.EnrollmentNum;
                userFromDb.EnrollmentType = entity.EnrollmentType;
                userFromDb.Phone = entity.Phone;
                userFromDb.Address = entity.Address;
                userFromDb.Type = entity.Type;
                // TODO: resolve date conflict
                // userFromDb.UpdatedAt = new DateTime();
                userFromDb.Status = entity.Status;
                return userFromDb;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}