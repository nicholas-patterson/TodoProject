namespace TodoProject.Domain.Entities
{
    public class Todo
    {
        public int TodoId { get; set; }
        public string? Title { get; set; }
        public bool IsComplete { get; set; }
        public DateTime CreatedAt { get; set; }
        
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}