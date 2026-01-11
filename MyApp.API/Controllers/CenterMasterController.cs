using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Core.ApiResponse;
using MyApp.Core.DTOs.Center;
using MyApp.Infrastructure.Interface;

namespace MyApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
   // [Authorize]
    public class CenterMasterController : ControllerBase
    {
        private readonly ICenterService _centerService;
        private readonly IApiResponseInterface _response;

        public CenterMasterController(
            ICenterService centerService,
            IApiResponseInterface response)
        {
            _centerService = centerService;
            _response = response;
        }

        // 🔹 CREATE CENTER
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] CreateCenterDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(
                        _response.Failure("Invalid request data", ModelState)
                    );

                var id = await _centerService.CreateAsync(dto);

                return Ok(
                    _response.Success(id, "Center created successfully")
                );
            }
            catch (Exception ex)
            {
                return Ok(
                    _response.Failure(ex.Message, dto)
                );
            }
        }

        // 🔹 UPDATE CENTER
        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCenterDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(
                        _response.Failure("Invalid request data", ModelState)
                    );

                await _centerService.UpdateAsync(id, dto);

                return Ok(
                    _response.Success(id, "Center updated successfully")
                );
            }
            catch (Exception ex)
            {
                return Ok(
                    _response.Failure(ex.Message, dto)
                );
            }
        }

        // 🔹 DELETE CENTER (SOFT DELETE)
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _centerService.DeleteAsync(id);

                return Ok(
                    _response.Success(id, "Center deleted successfully")
                );
            }
            catch (Exception ex)
            {
                return Ok(
                    _response.Failure(ex.Message, id)
                );
            }
        }

        // 🔹 GET ALL CENTERS
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var centers = await _centerService.GetAllAsync();

                return Ok(
                    _response.Success(centers, "Center list fetched successfully")
                );
            }
            catch (Exception ex)
            {
                return Ok(
                    _response.Failure(ex.Message, string.Empty)
                );
            }
        }

        // 🔹 GET CENTER BY ID
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var center = await _centerService.GetByIdAsync(id);

                if (center == null)
                    return Ok(
                        _response.Failure("Center not found", string.Empty)
                    );

                return Ok(
                    _response.Success(center, "Center fetched successfully")
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
