using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.Core.Entities;
using MyApp.Core.Interface;
using MyApp.Infrastructure.Repositories;

namespace MyApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IEmpolyeeRepository _empRepositories;
        public TestController(IEmpolyeeRepository empRepositories)
        {
            _empRepositories= empRepositories;
        }
        [HttpGet("GetAllEmployee")]
        public async Task<IActionResult> GetAllEmployee()
        {
            var res = await _empRepositories.GetAllAsync(); // ✅ await
            return Ok(res);
        }

        [HttpPost("SaveEmployee")]
        public async Task<IActionResult> SaveEmployee(CSharpCornerArticle article)
        {
            await _empRepositories.AddAsync(article); // ✅ await
            return Ok("Saved Successfully");
        }

        [HttpGet("GetEmployeeById")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var result = await _empRepositories.GetByIdAsync(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        [Route("Hello")]
        public  IActionResult hello()
        {
            return Ok("Hello");
        }
    }
}
