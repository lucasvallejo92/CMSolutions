using System;
using Entities;
using Newtonsoft.Json;

namespace Repository.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int ProfId { get; set; }
        public string EnrollmentNum { get; set; }
        public string EnrollmentType { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime UpdatedAt { get; set; }
        public sbyte Status { get; set; }
    }
}