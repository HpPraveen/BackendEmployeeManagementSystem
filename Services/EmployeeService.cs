using EmployeeManagementSystem.DAL;
using EmployeeManagementSystem.DAL.DTO;
using EmployeeManagementSystem.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Services
{
    public class EmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public EmployeeDetails GetEmployeeByEmployeeId(long employeeId)
        {
            return _unitOfWork.EmployeeRepository.Get(e => e.Id == employeeId).FirstOrDefault();
        }

        public List<EmployeeDetailDto> GetAllEmployeeDetails()
        {
            var employeeDtoList = new List<EmployeeDetailDto>();
            var employeeDetailList = _unitOfWork.EmployeeRepository.Get(e => e.IsDeleted == false).ToList();
            if (employeeDetailList.Count > 0)
            {
                return EmployeeDetails(employeeDetailList);
            }
            return employeeDtoList;
        }

        public List<EmployeeDetailDto> GetEmployeeDetails(string name, string mail)
        {
            var employeeDtoList = new List<EmployeeDetailDto>();
            var employeeDetailList = _unitOfWork.EmployeeRepository.Get(e => e.IsDeleted == false && (e.FirstName == name || e.LastName == name || e.FirstName + " " + e.LastName == name) && e.Email == mail).ToList();
            if (employeeDetailList.Count > 0)
            {
                return EmployeeDetails(employeeDetailList);
            }
            return employeeDtoList;
        }

        public List<EmployeeDetailDto> EmployeeDetails(List<EmployeeDetails> employeeDetailList)
        {
            var employeeDtoList = new List<EmployeeDetailDto>();
            foreach (var employeeDetails in employeeDetailList)
            {
                var department = _unitOfWork.DepartmentRepository.GetById(employeeDetails.DepartmentId).DepartmentName.ToString();
                var currentYear = DateTime.Today.Year;
                var birthYear = employeeDetails.DateOfBirth;
                var age = 0;
                if (birthYear != null)
                {
                    age = currentYear - DateTime.Parse(birthYear).Year;
                }

                var employeeDto = new EmployeeDetailDto
                {
                    Id = employeeDetails.Id,
                    Name = employeeDetails.FirstName + " " + employeeDetails.LastName,
                    Email = employeeDetails.Email,
                    Gender = employeeDetails.Gender.ToString(),
                    Image = employeeDetails.Image,
                    HomeAddress = employeeDetails.HomeAddress,
                    Age = age,
                    Department = department,
                    FirstName = employeeDetails.FirstName,
                    LastName = employeeDetails.LastName,
                    DateOfBirth = employeeDetails.DateOfBirth?.ToString(),
                    GenderType = employeeDetails.Gender,
                    ImageName = employeeDetails.ImageName
                };
                employeeDtoList.Add(employeeDto);
            }
            return employeeDtoList;
        }

        public bool InsertEmployeeDetails(EmployeeDetails employeeDetails)
        {
            try
            {
                _unitOfWork.EmployeeRepository.Insert(employeeDetails);
                _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateEmployeeDetails(EmployeeDetails employeeDetails)
        {
            try
            {
                _unitOfWork.EmployeeRepository.Update(employeeDetails);
                _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteEmployeeDetails(long employeeId)
        {
            var employeeDetail = GetEmployeeByEmployeeId(employeeId);
            if (employeeDetail != null)
            {
                return IsDeleteEmployee(employeeDetail);
            }
            return false;
        }

        public bool IsDeleteEmployee(EmployeeDetails employeeDetail)
        {
            try
            {
                employeeDetail.IsDeleted = true;
                return UpdateEmployeeDetails(employeeDetail);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}