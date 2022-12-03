using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodoProject.Application.Abstractions;
using TodoProject.Application.Models;
using TodoProject.Domain.Entities;

namespace TodoProject.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;

        public UserController(ILogger<UserController> logger, IUserRepository userRepo, IMapper mapper)
        {
            _logger = logger;
            _userRepo = userRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetUserDto>>> GetUsers()
        {
            var users = await _userRepo.GetUsersAsync();
            var toDto = _mapper.Map<List<GetUserDto>>(users);
            return toDto;

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetUserDto>> GetUser(int id)
        {
            var todo = await _userRepo.GetUserByIdAsync(id);

            if (todo == null)
            {
                return NotFound();
            }

            var toDto = _mapper.Map<GetUserDto>(todo);
            return toDto;
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(PostPutUserDto user)
        {
            _logger.LogInformation($"User: {user}");
            var toEntity = _mapper.Map<User>(user);
            var createdUser = await _userRepo.CreateUserAsync(toEntity);
            return CreatedAtAction(nameof(GetUser), new { id = createdUser.UserId }, createdUser);
        }
    }
}