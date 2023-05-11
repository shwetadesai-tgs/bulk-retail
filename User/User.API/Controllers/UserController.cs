using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using User.Core.Domain;
using User.Core.IServices;
using User.Core.Models;

namespace User.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService,
            IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet, Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            if (users == null)
                return NotFound();

            return Ok(users);
        }

        [HttpGet("GetUserById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        [Route("AddNewUser")]
        public async Task<IActionResult> Create(UserModel userModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }

                var user = _mapper.Map<Users>(userModel);
                await _userService.InsertUserAsync(user);
                return Ok("Record saved successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> Update(UserModel userModel)
        {
            try
            {
                if (userModel == null || userModel.Id == 0)
                    return BadRequest();

                var user = await _userService.GetUserByIdAsync(userModel.Id);

                if (user == null)
                    return NotFound();

                user.FirstName = userModel.FirstName;
                user.LastName = userModel.LastName;
                user.Phone = userModel.Phone;
                user.Email = userModel.Email;

                await _userService.UpdateUserAsync(user);
                return Ok("Record updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if (user == null)
                return NotFound($"User Not Found with Id: {id}");

            await _userService.DeleteUserAsync(user);
            return Ok($"User Deleted with Id : {id}");
        }
    }
}