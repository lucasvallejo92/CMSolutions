﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace Entities.Models
{
    public partial class Patient
    {
        public Patient()
        {
            MedicalRecords = new HashSet<MedicalRecord>();
            Shifts = new HashSet<Shift>();
        }

        public int Id { get; set; }
        public string Dni { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthday { get; set; }
        public string Lender { get; set; }
        public string UpdatedAt { get; set; }
        public sbyte Status { get; set; }

        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; }
        public virtual ICollection<Shift> Shifts { get; set; }
    }
}