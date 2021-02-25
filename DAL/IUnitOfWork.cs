using EmployeeManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.DAL
{
    public interface IUnitOfWork
    {
        public GenericRepository<Department> DepartmentRepository { get; }
        public GenericRepository<EmployeeDetails> EmployeeRepository { get; }

        void SaveAsync();
    }
}