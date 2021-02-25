using EmployeeManagementSystem.DAL;
using EmployeeManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Services
{
    public class DepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Department> GetAllDepartments()
        {
            return _unitOfWork.DepartmentRepository.Get().ToList();
        }
    }
}