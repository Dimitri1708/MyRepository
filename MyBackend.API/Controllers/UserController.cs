using Microsoft.AspNetCore.Mvc;
using schoolProject.WebApi.Models;
using schoolProject.WebApi.Repositories;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace schoolProject.WebApi.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        private readonly ILogger<User> _logger;

        public UserController(UserRepository userRepository, ILogger<User> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        [HttpPost(Name = "Register")]
        public async Task add(User user)
        {
            await _userRepository.InsertAsync(user);
        }
    }
}
