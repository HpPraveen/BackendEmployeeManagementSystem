using EmployeeManagementSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly XyzEmployeeDbContext _dbContext;

        public UnitOfWork(XyzEmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public GenericRepository<EmployeeDetails> EmployeeRepository
        {
            get
            {
                return new GenericRepository<EmployeeDetails>(_dbContext);
            }
        }

        public GenericRepository<Department> DepartmentRepository
        {
            get
            {
                return new GenericRepository<Department>(_dbContext);
            }
        }

        public void SaveAsync()
        {
            _dbContext.SaveChangesAsync();
        }
    }
}