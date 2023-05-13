using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using User.API.Helpers;
using User.Core.Domain;
using User.Core.IServices;
using User.Core.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace User.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly AppSettings _appSettings;

        public UserController(IUserService userService,
            IMapper mapper,
            IOptions<AppSettings> appSettings,
            IConfiguration configuration)
        {
            _userService = userService;
            _mapper = mapper;
            _configuration = configuration;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateModel model)
        {
            var user = await _userService.Authenticate(model.Email, model.Password);

            if (user == null)
                return BadRequest(new { message = "Email or password is incorrect" });

            string token = await CreateToken(user);

            // return basic user info and authentication token
            return Ok(new
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Token = token
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            // map model to entity
            var user = _mapper.Map<Users>(model);

            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }

                // create user
                await _userService.InsertUserAsync(user, model.Password);
                return Ok("Register successfully.");
            }
            catch (Exception ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
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

        //[HttpPost]
        //[Route("AddNewUser")]
        //public async Task<IActionResult> Create(UserModel userModel)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return StatusCode(StatusCodes.Status400BadRequest, ModelState);
        //        }

        //        var user = _mapper.Map<Users>(userModel);
        //        await _userService.InsertUserAsync(user);
        //        return Ok("Record saved successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex);
        //    }
        //}

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> Update(int id, UpdateModel model)
        {
            // map model to entity and set id
            var users = _mapper.Map<Users>(model);
            users.Id = id;

            try
            {
                if (model == null || users.Id == 0)
                    return BadRequest();

                var user = await _userService.GetUserByIdAsync(users.Id);

                if (users == null || user == null)
                    return NotFound();

                //user.FirstName = userModel.FirstName;
                //user.LastName = userModel.LastName;
                //user.Phone = userModel.Phone;
                //user.Email = userModel.Email;

                await _userService.UpdateUserAsync(users, model.Password);
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

        #region CreateToken
        private async Task<string> CreateToken(Users user)
        {
            var http=new HttpClient();
            var reqData = new[]
            {
                new KeyValuePair<string,string>("grant_type",_configuration["IdentityServer:grant_type"]),
                new KeyValuePair<string,string>("Scope",_configuration["IdentityServer:Scope"]),
                new KeyValuePair<string,string>("client_id",_configuration["IdentityServer:client_id"]),
                new KeyValuePair<string,string>("client_secret",_configuration["IdentityServer:client_secret"]),
            };
            var res= await http.PostAsync(_configuration["IdentityServer:Url"], new FormUrlEncodedContent(reqData));
            var jwt = "";
            if(res.IsSuccessStatusCode)
            {
                var tokenData= await res.Content.ReadAsStringAsync();
                var resData = JsonConvert.DeserializeObject<AuthToken>(tokenData);
                jwt = resData?.Access_token;
            }
            //List<Claim> claims = new List<Claim>
            //{
            //    new Claim(ClaimTypes.Email,user.Email)
            //};
            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.Secret));

            //var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            //var token = new JwtSecurityToken(
            //    claims: claims,
            //    expires: DateTime.Now.AddSeconds(3600),
            //    signingCredentials: cred);

            //var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        #endregion
    }
}