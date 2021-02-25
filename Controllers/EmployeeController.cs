using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using EmployeeManagementSystem.DAL;
using EmployeeManagementSystem.DAL.Models;
using EmployeeManagementSystem.Services;
using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    [Route("")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType.Name);
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("AllEmployeeDetails")]
        public IActionResult GetAllEmployees()
        {
            _logger.InfoFormat("Request with verb [{0}] and Uri [{1}] executed", Request.Method, Request.Path);
            _logger.InfoFormat("Action GetAllEmployees started");
            try
            {
                var employeeDetailList = _employeeService.GetAllEmployeeDetails();
                _logger.InfoFormat("Action GetAllEmployees completed");
                return Ok(employeeDetailList);
            }
            catch (Exception ex)
            {
                _logger.InfoFormat("Action GetAllEmployees Failed");
                return new JsonResult(ex);
            }
        }

        [HttpGet]
        [Route("GetEmployeeDetails/{name}/{email}")]
        public IActionResult GetEmployeeByNameAndEmail(string name, string email)
        {
            _logger.InfoFormat("Request with verb [{0}] and Uri [{1}] executed", Request.Method, Request.Path);
            _logger.InfoFormat("Action GetEmployeeByNameAndEmail started");
            try
            {
                var employeeDetailList = _employeeService.GetEmployeeDetails(name, email);
                _logger.InfoFormat("Action GetEmployeeByNameAndEmail completed");
                return Ok(employeeDetailList);
            }
            catch (Exception ex)
            {
                _logger.InfoFormat("Action GetEmployeeByNameAndEmail Failed");
                return new JsonResult(ex);
            }
        }

        [HttpPost]
        [Route("AddNewEmployee")]
        public IActionResult AddNewEmployeeDetails([FromBody] EmployeeDetails employeeDetails)
        {
            _logger.InfoFormat("Request with verb [{0}] and Uri [{1}] executed", Request.Method, Request.Path);
            _logger.InfoFormat("Action AddNewEmployeeDetails started");
            try
            {
                var result = _employeeService.InsertEmployeeDetails(employeeDetails);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.InfoFormat("Action AddNewEmployeeDetails Failed");
                return new JsonResult(ex);
            }
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public IActionResult UpdateEmployeeDetails([FromBody] EmployeeDetails employeeDetails)
        {
            _logger.InfoFormat("Request with verb [{0}] and Uri [{1}] executed", Request.Method, Request.Path);
            _logger.InfoFormat("Action UpdateEmployeeDetails started");
            try
            {
                var result = _employeeService.UpdateEmployeeDetails(employeeDetails);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.InfoFormat("Action UpdateEmployeeDetails Failed");
                return new JsonResult(ex);
            }
        }

        [HttpDelete]
        [Route("DeleteEmployee/{employeeId}")]
        public IActionResult DeleteEmployeeDetails(long employeeId)
        {
            _logger.InfoFormat("Request with verb [{0}] and Uri [{1}] executed", Request.Method, Request.Path);
            _logger.InfoFormat("Action DeleteEmployeeDetails started");
            try
            {
                var result = _employeeService.DeleteEmployeeDetails(employeeId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.InfoFormat("Action DeleteEmployeeDetails Failed");
                return new JsonResult(ex);
            }
        }
    }
}