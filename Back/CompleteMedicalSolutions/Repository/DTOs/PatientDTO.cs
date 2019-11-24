using System;
using System.Collections.Generic;
using Entities.Models;

namespace Repository.DTOs
{
    public class PatientDTO
    {
        public int Id { get; set; }
        public string Dni { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public string Lender { get; set; }
        public DateTime UpdatedAt { get; set; }
        public sbyte Status { get; set; }

        public ICollection<MedicalRecord> MedicalRecords { get; set; }
        public ICollection<Shift> Shifts { get; set; }
    }
}