﻿using ContactsAPI.Domain.DTO;
using ContactsAPI.Domain.Entities;
using ContactsAPI.Domain.Generic;
using ContactsAPI.Services.Implementations;
using ContactsAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace ContactsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]

        public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO requestDTO)
        {
            var result = new Result<Domain.DTO.AppUserDTO>();

            result.RequestTime = DateTime.Now;

            var response = await _authService.Register(requestDTO);

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

        [HttpPost("login")]

        public async Task<IActionResult> Login([FromBody] LoginRequestDTO requestDTO)
        {
            var result = new Result<LoginResponseDTO>();

            result.RequestTime = DateTime.Now;

            var response = await _authService.Login(requestDTO);

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

        [HttpPost("assign-role")]

        public async Task<IActionResult> AssignRole([FromBody] AssignRoleDTO requestDTO)
        {
            var result = new Result<bool>();

            result.RequestTime = DateTime.Now;

            var response = await _authService.AssignRole(requestDTO.Email, requestDTO.RoleName);

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
