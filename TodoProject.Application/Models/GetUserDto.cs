namespace TodoProject.Application.Models
{
    public class GetUserDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<GetTodoDto>? Todos { get; set; }

        public GetUserDto(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}