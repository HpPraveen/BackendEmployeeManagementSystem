using EmployeeManagementSystem.DAL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.DAL.Models
{
    public class EmployeeDetails
    {
        [Key]
        public long Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Date of Birth")]
        public string DateOfBirth { get; set; }

        public GenderEnum? Gender { get; set; }

        [Display(Name = "Home Address")]
        public string HomeAddress { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Contact Number (Mobile)")]
        public string TelNoMobile { get; set; }

        [Display(Name = "Employee Image")]
        public byte[] Image { get; set; }

        [Display(Name = "Image Name")]
        public string ImageName { get; set; }

        [Display(Name = "Department Id")]
        public long DepartmentId { get; set; }

        [Display(Name = "Is Deleted")]
        [DefaultValue("false")]
        public bool IsDeleted { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
    }
}