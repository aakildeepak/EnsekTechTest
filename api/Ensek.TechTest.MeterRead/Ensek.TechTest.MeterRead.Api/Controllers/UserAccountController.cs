using Ensek.TechTest.MeterRead.Domain.Models;
using Ensek.TechTest.MeterRead.Services;
using Ensek.TechTest.MeterRead.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ensek.TechTest.MeterRead.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccountController : ControllerBase
    {
        private readonly IUserAccountService _userAccountService;

        public UserAccountController(IUserAccountService userAccountService)
        {
            _userAccountService = userAccountService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<UserAccountDto>>> GetAllUsers()
        {
            var users = await _userAccountService.GetAllUsersAsync();

            return Ok(users);
        }

        [HttpGet]
        [Route("{accountId}")]
        public async Task<ActionResult<UserAccountDto>> GetById(int accountId)
        {
            var userAccount = await _userAccountService.GetUserAsync(accountId);

            if (userAccount == null) return NotFound();

            return Ok(userAccount);
        }

        [HttpPost]
        public async Task<ActionResult> AddUser(UserAccountDto userData)
        {
            var userAccount = await _userAccountService.GetUserAsync(userData.AccountId);

            if(userAccount != null)
            {
                return Conflict(new { message = "User already exists." });
            }  
            else
            {
                userAccount = await _userAccountService.AddUserAsync(userData);

                return CreatedAtAction(nameof(AddUser), new { id = userAccount.AccountId }, userAccount);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(UserAccountDto userData)
        {
            if (userData == null || userData.Id == 0)
                return BadRequest();

            var userAccount = await _userAccountService.GetUserAsync(userData.Id);

            if (userAccount == null)
            {
                return Conflict(new { message = "User does not exists." });
            }
            else
            {
                userAccount = await _userAccountService.UpdateUserAsync(userAccount.Id, userData);

                return Ok(userAccount);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            if (id < 1)
                return BadRequest();

            var userAccount = await _userAccountService.FindUserByIdAsync(id);

            if (userAccount == null)
                return NotFound();

            await _userAccountService.DeleteUserByIdAsync(id);

            return Ok();
        }
    }
}
