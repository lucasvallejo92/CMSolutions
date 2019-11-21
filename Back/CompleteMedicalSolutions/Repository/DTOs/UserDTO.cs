using System;
using Entities;

namespace Repository.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public DateTime UpdatedAt { get; set; }
        public sbyte Status { get; set; }
    }
}