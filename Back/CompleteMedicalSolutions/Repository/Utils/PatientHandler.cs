using System;
using Entities.Models;
using Repository.DTOs;

namespace Repository.Utils
{
    public class PatientHandler
    {
        public static PatientDTO MapToApp(Patient model)
        {
            try
            {
                return new PatientDTO()
                {
                    Id = model.Id,
                    Dni = model.Dni,
                    Name = model.Name,
                    Surname = model.Surname,
                    Birthday = model.Birthday,
                    Lender = model.Lender,
                    UpdatedAt = model.UpdatedAt,
                    Status = model.Status,
                    MedicalRecords = model.MedicalRecords,
                    Shifts = model.Shifts
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        
        public static Patient MapToDb(PatientDTO model)
        {
            try
            {
                return new Patient()
                {
                    Dni = model.Dni,
                    Name = model.Name,
                    Surname = model.Surname,
                    Birthday = model.Birthday,
                    Lender = model.Lender,
                    UpdatedAt = model.UpdatedAt,
                    Status = model.Status
                };
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static Patient UpdateToDb(Patient patientFromDb, PatientDTO entity)
        {
            try
            {
                patientFromDb.Dni = entity.Dni ?? patientFromDb.Dni;
                patientFromDb.Name = entity.Name ?? patientFromDb.Name;
                patientFromDb.Surname = entity.Surname ?? patientFromDb.Surname;
                patientFromDb.Birthday = entity.Birthday;
                patientFromDb.Lender = entity.Lender ?? patientFromDb.Lender;
                patientFromDb.UpdatedAt = DateTime.Now;
                patientFromDb.Status = entity.Status;
                return patientFromDb;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}