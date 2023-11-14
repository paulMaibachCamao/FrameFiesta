using FrameFiesta.Contracts.Models;
using FrameFiesta.Database;
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
            var user = await _databaseService.Login(loginRequest.UserIdentification, loginRequest.Password).ConfigureAwait(false);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest registrationRequest)
        {
            var result = await _databaseService.Register<FrameFiestaDocument>(registrationRequest).ConfigureAwait(false);
            if (result)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut("blogpost")]
        public async Task<IActionResult> AddBlogPost(string description, string review, [FromBody] MotionPicture motionPicture)
        {
            try
            {
                if (motionPicture is Series)
                {
                    var seriesResult = await _databaseService.AddBlogPost(description, review, (Series)motionPicture).ConfigureAwait(false);
                    return seriesResult != null ? Ok(seriesResult) : StatusCode(500, null);
                }

                if (motionPicture is Film)
                {
                    var filmResult = await _databaseService.AddBlogPost(description, review, (Film)motionPicture).ConfigureAwait(false);
                    return filmResult != null ? Ok(filmResult) : StatusCode(500, null);
                }
                var result = await _databaseService.AddBlogPost(description, review, motionPicture).ConfigureAwait(false);
                return result != null ? Ok(result) : StatusCode(500, null);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("comment")]
        public async Task<IActionResult> AddComment(string userIdentification, [FromBody] string password, string blogId, string comment)
        {
            var result = await _databaseService.AddComment(userIdentification, password, blogId, comment).ConfigureAwait(false);
            return result != null ? Ok(result) : StatusCode(500, null);
        }

        [HttpDelete("comment")]
        public async Task<IActionResult> DeleteComment(string userIdentification, [FromBody] string password, string blogId, string commentId)
        {
            var result = await _databaseService.DeleteComment(userIdentification, password, blogId, commentId).ConfigureAwait(false);
            return result != null ? Ok(result) : StatusCode(500, null);
        }

        [HttpGet("blogposts")]
        public async Task<IActionResult> GetBlogPosts()
        {
            var blogPosts = await _databaseService.GetAllBlogPosts().ConfigureAwait(false);
            var users = await _databaseService.GetAllUsers().ConfigureAwait(false);
            var objects = blogPosts.Select(blogPost => ConvertToJsonObject(blogPost, users)).ToList();
            return Ok(objects);
        }

        private object ConvertToJsonObject(BlogPostFe blogPost, IEnumerable<UserDB> users)
        {
            var motionPicture = blogPost.RelatedMotionPicture;

            var commentsFe = blogPost.Comments.Select(bc =>
            {
                var user = users.FirstOrDefault(u => u.Name == bc.Name);
                return new CommentFe
                {
                    Id = bc.Id,
                    Text = user?.Comments.FirstOrDefault(uc => uc.ID == bc.Id)?.Text,
                    Date = user?.Comments.FirstOrDefault(uc => uc.ID == bc.Id)?.CreatedAt ?? default,
                    Name = user?.Name
                };
            }).ToList();

            if (motionPicture is Series series)
            {
                return new
                {
                    blogPost.Id,
                    blogPost.Date,
                    blogPost.Description,
                    blogPost.Review,
                    Comments = commentsFe,
                    RelatedMotionPicture = new
                    {
                        series.Title,
                        series.Country,
                        series.Director,
                        series.Actors,
                        series.Rating,
                        series.Image,
                        series.Genres,
                        series.InitialRelease,
                        series.Seasons,
                        series.Episodes,
                        Type = "Series"
                    }
                };
            }
            else if (motionPicture is Film film)
            {
                return new
                {
                    blogPost.Id,
                    blogPost.Date,
                    blogPost.Description,
                    blogPost.Review,
                    Comments = commentsFe,
                    RelatedMotionPicture = new
                    {
                        film.Title,
                        film.Country,
                        film.Director,
                        film.Actors,
                        film.Rating,
                        film.Image,
                        film.Genres,
                        film.InitialRelease,
                        film.RunTime,
                        Type = "Film"
                    }
                };
            }
            else
            {
                return new
                {
                    blogPost.Id,
                    blogPost.Date,
                    blogPost.Description,
                    blogPost.Review,
                    Comments = commentsFe,
                    RelatedMotionPicture = motionPicture
                };
            }
        }


    }
}