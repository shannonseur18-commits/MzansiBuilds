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
    public class ProjectsController : ControllerBase
    {
        private readonly AppDbContext _db;

        public ProjectsController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetProjects()
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var projects = await _db.Projects
                .Include(p => p.Milestones)
                .Where(p => p.UserId == userId)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
            return Ok(projects);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateProject([FromBody] CreateProjectDto dto)
        {
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var project = new Project
            {
                Name = dto.Name,
                Description = dto.Description,
                Stage = dto.Stage,
                SupportNeeded = dto.SupportNeeded,
                UserId = userId
            };
            _db.Projects.Add(project);
            await _db.SaveChangesAsync();
            return Ok(new { message = "Project created!", project.Id });
        }

        [HttpPost("{id}/milestones")]
        [Authorize]
        public async Task<IActionResult> AddMilestone(int id, [FromBody] AddMilestoneDto dto)
        {
            var milestone = new Milestone
            {
                Title = dto.Title,
                ProjectId = id
            };
            _db.Milestones.Add(milestone);
            await _db.SaveChangesAsync();
            return Ok(new { message = "Milestone added!" });
        }

        [HttpPut("{id}/complete")]
        [Authorize]
        public async Task<IActionResult> CompleteProject(int id)
        {
            var project = await _db.Projects.FindAsync(id);
            if (project == null) return NotFound();
            project.IsCompleted = true;
            await _db.SaveChangesAsync();
            return Ok(new { message = "Project completed!" });
        }

        [HttpGet("completed")]
        public async Task<IActionResult> GetCompletedProjects()
        {
            var projects = await _db.Projects
                .Include(p => p.User)
                .Where(p => p.IsCompleted)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
            return Ok(projects.Select(p => new {
                p.Id,
                p.Name,
                p.Description,
                Author = p.User.FullName,
                p.CreatedAt
            }));
        }
    }

    public record CreateProjectDto(string Name, string Description, string Stage, string SupportNeeded);
    public record AddMilestoneDto(string Title);
}