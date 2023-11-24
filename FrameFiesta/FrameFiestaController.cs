using FrameFiesta.Contracts.Models;
using FrameFiesta.Database;
using FrameFiesta.Utilities.ExtensionMethods.Models;
using Microsoft.AspNetCore.Mvc;

namespace FrameFiesta.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrameFiestaController : ControllerBase
    {
        private readonly IDatabaseService _databaseService;

        public FrameFiestaController(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest loginRequest)
        {
            try
            {
                var user = await _databaseService.Login(loginRequest.UserIdentification, loginRequest.Password).ConfigureAwait(false);
                if (user == null)
                {
                    return NotFound("User not found");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest registrationRequest)
        {
            try
            {
                var result = await _databaseService.Register<FrameFiestaDocument>(registrationRequest).ConfigureAwait(false);
                if (result != null)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("user")]
        public async Task<IActionResult> DeleteUserAsync([FromBody] LoginRequest user)
        {
            try
            {
                var result = await _databaseService.DeleteUser(user.UserIdentification, user.Password).ConfigureAwait(false);
                return result == true ? Ok(result) : BadRequest(result);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("blogpost")]
        public async Task<IActionResult> AddBlogPost([FromBody] BlogPostDb blogPost)
        {
            try
            {
                if (blogPost == null)
                {
                    return BadRequest("Blog post is null.");
                }

                var result = await _databaseService.AddBlogPost(blogPost).ConfigureAwait(false);
                var users = await _databaseService.GetAllUsers().ConfigureAwait(false);
                return StatusCode(201, result.ConvertToJsonObject(users));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("comment")]
        public async Task<IActionResult> AddComment([FromBody] LoginRequest user, string blogId, string comment)
        {
            try
            {
                var result = await _databaseService.AddComment(user.UserIdentification, user.Password, blogId, comment).ConfigureAwait(false);
                return result != null ? Ok(result) : StatusCode(500, null);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("comment")]
        public async Task<IActionResult> DeleteComment([FromBody] LoginRequest user, string blogId, string commentId)
        {
            try
            {
                var result = await _databaseService.DeleteComment(user.UserIdentification, user.Password, blogId, commentId).ConfigureAwait(false);
                return result == true ? Ok(result) : StatusCode(500, null);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("blogposts")]
        public async Task<IActionResult> GetBlogPosts()
        {
            try
            {
                var blogPosts = await _databaseService.GetAllBlogPosts().ConfigureAwait(false);
                var users = await _databaseService.GetAllUsers().ConfigureAwait(false);
                var objects = blogPosts.Select(blogPost => blogPost.ConvertToJsonObject(users)).ToList();
                return Ok(objects);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}