using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoProject.Domain
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Todo>? Todos { get; set; }

        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}