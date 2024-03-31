using LoginAPI.Data;
using LoginAPI.Models;
using LoginAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LoginAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersAPIController : ControllerBase
    {
        private readonly IUserAPI _userAPI;

        public UsersAPIController(IUserAPI userAPI)
        {
            _userAPI = userAPI;
        }
        [HttpGet]
        public async Task<ActionResult<List<Users>>> GetUsersData()
        {
            var dataOfUsers = await _userAPI.GetUsersData();
            if(dataOfUsers is null)
            {
                return BadRequest();
            }
            return Ok(dataOfUsers);
        }

        [HttpGet("GetName"),Authorize]
        public async Task<ActionResult<string>> GetName()
        {
            var result=_userAPI.GetName();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUsersDataById(int id)
        {
            var dataOfUsers = await _userAPI.GetUsersDataById(id);
            if (dataOfUsers is null)
            {
                return BadRequest();
            }
            return Ok(dataOfUsers);
        }
        [HttpGet("{userName}/{password}")]
        public async Task<ActionResult<string>> GetUsersDataByUserNameAndPassword(string userName,string password)
        {
            var dataOfUsers = await _userAPI.GetUsersDataByUserNameAndPassword(userName, password);
            if (dataOfUsers is null)
            {
                return BadRequest();
            }
            return Ok(dataOfUsers);
        }
        [HttpPost]
        public async Task<ActionResult<string>> CreateUser(Users requestObject)
        {
            var result= await _userAPI.CreateUser(requestObject);
            if(result is null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
    }
}
