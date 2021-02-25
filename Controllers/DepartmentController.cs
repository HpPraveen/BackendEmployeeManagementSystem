using EmployeeManagementSystem.DAL;
using EmployeeManagementSystem.Services;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.Controllers
{
    [Route("")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.Name);
        private readonly DepartmentService _departmentService;

        public DepartmentController(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        [Route("AllDepartments")]
        public IActionResult GetAllDepartments()
        {
            _logger.InfoFormat("Request with verb [{0}] and Uri [{1}] executed", Request.Method, Request.Path);
            _logger.InfoFormat("Action GetAllDepartments started");
            try
            {
                var departmentList = _departmentService.GetAllDepartments();
                _logger.InfoFormat("Action GetAllDepartments completed");
                return Ok(departmentList);
            }
            catch (Exception ex)
            {
                _logger.InfoFormat("Action GetAllDepartments Failed");
                return new JsonResult(ex);
            }
        }
    }
}