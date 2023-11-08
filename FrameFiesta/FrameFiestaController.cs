using FrameFiesta.Contracts.Models;
using FrameFiesta.Database;
using Microsoft.AspNetCore.Mvc;
using FrameFiesta.Utilities.ExtensionMethods.Models;

namespace FrameFiesta.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrameFiestaController : ControllerBase
    {
        private readonly IRepository _repository;

        public FrameFiestaController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest loginRequest)
        {
            var user = await _repository.Login(loginRequest.UserIdentification, loginRequest.Password);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.ConvertUserDbToUser());
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest registrationRequest)
        {
            var result = await _repository.Register<FrameFiestaDocument>(registrationRequest);
            if (result)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}