using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Api.Model.JWT;
using MyApp.Application.Interfaces;
using MyApp.Core.ApiResponse;
using MyApp.Core.DTOs.EmployeeMasterDtos;
using MyApp.Core.DTOs.LoginDtos;
using MyApp.Core.Entities.EmployeeMasterEntites;

namespace MyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeMasterController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IApiResponseInterface _response;
        private readonly IJwtTokenService _jwtToken;
        public EmployeeMasterController(IEmployeeService employeeService, IApiResponseInterface response, IJwtTokenService jwtToken)
        {
            _employeeService = employeeService;
            _response = response;
            _jwtToken = jwtToken;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(_response.Failure("Invalid request data", ModelState));

            var employeeId = await _employeeService.CreateAsync(dto);

            return Ok(_response.Success(employeeId, "Employee created successfully"));
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateEmployeeDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(_response.Failure("Invalid request data", ModelState));

            await _employeeService.UpdateAsync(id, dto);

           
            return Ok(_response.Success(id, "Employee updated successfully"));
        }
        [Authorize]
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeService.GetAllAsync();
            return Ok(_response.Success(employees, "All Employee Get successfully"));
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _employeeService.GetByIdAsync(id);

            if (employee == null)
                return NotFound(_response.Failure("Employee not found",id));
            
            return Ok(_response.Success(employee, "Employee Get successfully"));
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(_response.Failure("Invalid request data", ModelState));

            try
            {
                var employee = await _employeeService.LoginAsync(dto);
                var token = _jwtToken.GenerateToken(employee);

                var result = new
                {
                    token,
                    employeeId = employee.Id,
                    roleId = employee.RoleId,
                    centerId = employee.CenterId
                };


                return Ok(_response.Success(result, "Login successful"));
            }
            catch(Exception ex)
            {
                return Ok(_response.Failure(ex.Message,dto));
            }
            
        }
    }
}
