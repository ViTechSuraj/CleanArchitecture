using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Interfaces;
using MyApp.Core;
using MyApp.Core.ApiResponse;
using MyApp.Core.DTOs.Roles;

namespace MyApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class RoleMasterController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IApiResponseInterface _response;

        public RoleMasterController(
            IRoleService roleService,
            IApiResponseInterface response)
        {
            _roleService = roleService;
            _response = response;
        }

        // 🔹 CREATE ROLE
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] CreateRoleDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(
                        _response.Failure("Invalid request data", ModelState)
                    );

                var roleId = await _roleService.CreateAsync(dto);

                return Ok(
                    _response.Success(roleId, "Role created successfully")
                );
            }
            catch (Exception ex)
            {
                return Ok(
                    _response.Failure(ex.Message, dto)
                );
            }
        }

        // 🔹 UPDATE ROLE
        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateRoleDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(
                        _response.Failure("Invalid request data", ModelState)
                    );

                await _roleService.UpdateAsync(id, dto);

                return Ok(
                    _response.Success(id, "Role updated successfully")
                );
            }
            catch (Exception ex)
            {
                return Ok(
                    _response.Failure(ex.Message, dto)
                );
            }
        }

        // 🔹 GET ALL ROLES
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var roles = await _roleService.GetAllAsync();

                return Ok(
                    _response.Success(roles, "Role list fetched successfully")
                );
            }
            catch (Exception ex)
            {
                return Ok(
                    _response.Failure(ex.Message, string.Empty)
                );
            }
        }

        // 🔹 GET ROLE BY ID
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var role = await _roleService.GetByIdAsync(id);

                if (role == null)
                    return Ok(
                        _response.Failure("Role not found", string.Empty)
                    );

                return Ok(
                    _response.Success(role, "Role fetched successfully")
                );
            }
            catch (Exception ex)
            {
                return Ok(
                    _response.Failure(ex.Message, id)
                );
            }
        }
    }

}
