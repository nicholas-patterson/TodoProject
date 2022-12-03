namespace TodoProject.Application.Models
{
    public class PostPutUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public PostPutUserDto(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}