namespace TodoProject.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        
        public string? FirstName { get; set; }
        
        public string? LastName { get; set; }

        public List<Todo> Todos { get; set; } = new();

    }
}