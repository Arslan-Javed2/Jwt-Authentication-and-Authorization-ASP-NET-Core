using LoginAPI.Data;
using LoginAPI.Models;
using LoginAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoginAPI.Controllers
{
    [Route("api/[controller]")]//attribute routing
    [ApiController]
    public class StudentAPIController : ControllerBase
    {
        private readonly IStudentAPI _studentAPI;

        public StudentAPIController(IStudentAPI studentAPI)
        {
            _studentAPI = studentAPI;
        }

        [HttpGet, Authorize(Roles ="Ali")]
        public async Task<ActionResult<List<Students>>> GetStudents()
        {
            var data = await _studentAPI.GetStudents();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Students>> GetStudentsById(Guid id)
        {
            var data=await _studentAPI.GetStudentsById(id);
            if (data == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(data);
            }
        }

        [HttpPost]
        public async Task<ActionResult<string>> CreateStudent(Students data)
        {
            var result=await _studentAPI.CreateStudent(data);
            if(result is null)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        //[HttpPut("{id}")]
        //public async Task<ActionResult<String>> UpdateData(Guid id,Students data)
        //{
        //    if(id != data.Id)
        //    {
        //        return BadRequest("No data to update!");
        //    }
        //    _context.Entry(data).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();
        //    return Ok("Data updated successfully!");
        //}

        [HttpDelete("{id}")]
        public async Task<ActionResult<String>> DeleteData(Guid id)
        {
            var data = await _studentAPI.DeleteData(id);
            
            return Ok(data);
        }
    }
}
