namespace MzansiBuilds.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Stage { get; set; } = string.Empty;
        public string SupportNeeded { get; set; } = string.Empty;
        public bool IsCompleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public ICollection<Milestone> Milestones { get; set; } = new List<Milestone>();
    }
}