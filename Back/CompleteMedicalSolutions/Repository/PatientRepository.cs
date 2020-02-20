using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repository.DTOs;
using Repository.Enums;
using Repository.Interfaces;
using Repository.Utils;

namespace Repository
{
    public class PatientRepository: IRepository<PatientDTO>
    {
        private readonly CmsolutionsContext _context;

        public PatientRepository(CmsolutionsContext context)
        {
            _context = context;
        }

        public List<PatientDTO> GetAllAsync()
        {
            return _context.Patients.Select(PatientHandler.MapToApp).ToList();
        }
        

        public async Task<PatientDTO> GetAsync(int id)
        {
            var patient = await _context.Patients.Where(x => x.Id == id).Include(p => p.MedicalRecords).ThenInclude(m => m.User).FirstOrDefaultAsync();
            return PatientHandler.MapToApp(patient);
        }

        public async Task<bool> AddAsync(PatientDTO entity)
        {
            _context.Patients.Add(PatientHandler.MapToDb(entity));
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<bool> UpdateAsync(int id, PatientDTO entity)
        {
            try
            {
                var patient = await _context.Patients.Where(x => x.Id == id).FirstOrDefaultAsync();

                patient = PatientHandler.UpdateToDb(patient, entity);
                
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
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
    }
}