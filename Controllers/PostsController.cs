using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using MzansiBuilds.Data;
using MzansiBuilds.Models;

namespace MzansiBuilds.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly AppDbContext _db;

        public PostsController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await _db.Posts
                .Include(p => p.User)
                .Include(p => p.Comments)
                .ThenInclude(c => c.User)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();

            return Ok(posts.Select(p => new {
                p.Id,
                p.Content,
                p.Stage,
                p.SupportNeeded,
                p.CreatedAt,
                Author = p.User.FullName,
                Comments = p.Comments.Select(c => new {
                    c.Id,
                    c.Content,
                    Author = c.User.FullName,
                    c.CreatedAt
                })
            }));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostDto dto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var post = new Post
            {
                Content = dto.Content,
                Stage = dto.Stage,
                SupportNeeded = dto.SupportNeeded,
                UserId = userId
            };
            _db.Posts.Add(post);
            await _db.SaveChangesAsync();
            return Ok(new { message = "Post created!", post.Id });
        }

        [HttpPost("{id}/comments")]
        [Authorize]
        public async Task<IActionResult> AddComment(int id, [FromBody] AddCommentDto dto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var comment = new Comment
            {
                Content = dto.Content,
                PostId = id,
                UserId = userId
            };
            _db.Comments.Add(comment);
            await _db.SaveChangesAsync();
            return Ok(new { message = "Comment added!" });
        }
    }

    public record CreatePostDto(string Content, string Stage, string SupportNeeded);
    public record AddCommentDto(string Content);
}