using EmployeeManagementSystem.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.DAL.DTO
{
    public class EmployeeDetailDto
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        public string HomeAddress { get; set; }

        public string Email { get; set; }

        public byte[] Image { get; set; }

        public string ImageName { get; set; }

        public string Department { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DateOfBirth { get; set; }

        public GenderEnum? GenderType { get; set; }
    }
}