using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MISA.Core.Entities;
using MISA.Core.Exceptions;
using MISA.Core.Interfaces.Infrastructure;
using MISA.Core.Interfaces.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.Api.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        IEmployeeRepository _employeeRepository;
        IEmployeeService _employeeService;

        public EmployeesController(IEmployeeRepository employeeRepository, IEmployeeService employeeService)
        {
            _employeeRepository = employeeRepository;
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var res = _employeeRepository.GetAll();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        [HttpGet("{employeeId}")]
        public IActionResult Get(Guid employeeId)
        {
            try
            {
                var res = _employeeRepository.GetById(employeeId);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult Post(Employee employee)
        {
            try
            {
                var res = _employeeService.InsertService(employee);
                return StatusCode(201, res);
            }
            catch (MISAValidateException ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = ex.Message,
                    data = employee
                };
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{employeeId}")]
        public IActionResult Put(Employee employee, Guid employeeId)
        {
            try
            {
                var res = _employeeService.UpdateService(employee, employeeId);
                return StatusCode(200, res);
            }
            catch (MISAValidateException ex)
            {
                var response = new
                {
                    devMsg = ex.Message,
                    userMsg = ex.Message,
                    data = employee
                };
                return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("{employeeId}")]
        public IActionResult Delete(Guid employeeId)
        {
            try
            {
                var res = _employeeRepository.Delete(employeeId);
                if (res > 0)
                {
                    return Ok(res);
                }
                else
                {
                    var response = new
                    {
                        devMsg = "Có lỗi xảy ra, vui lòng liên hệ Misa để được hỗ trợ",
                        userMsg = "Có lỗi xảy ra, vui lòng liên hệ Misa để được hỗ trợ",
                        data = res
                    };
                    return BadRequest(response);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}

