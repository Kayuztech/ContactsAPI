using ContactsAPI.Domain.DTO;
using ContactsAPI.Domain.Entities;
using ContactsAPI.Domain.Generic;
using ContactsAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ContactsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly SignInManager<AppUser> _signInManager;

        public ContactController(IContactService contactService, SignInManager<AppUser> signInManager)
        {
            _contactService = contactService;
            _signInManager = signInManager;
        }

        [HttpPost("add-contact")]
        [Authorize]
        public async Task<IActionResult> AddContact([FromBody] AddContactRequestDTO requestDTO)
        {
            var result = new Result<AddContactResponseDTO>();

            var user = await _signInManager.UserManager.GetUserAsync(User);

            result.RequestTime = DateTime.Now;

            var response = await _contactService.AddContact(requestDTO, user.Id);

            if (response.IsSuccess)
            {
                result.ResponseTime = DateTime.Now;
                result = response;
                return Ok(result);
            }

            result = response;
            result.ResponseTime = DateTime.Now;
            return BadRequest(result);
        }
    }
}
