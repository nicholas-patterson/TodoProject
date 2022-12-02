using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoProject.Domain
{
    public class Todo
    {
        public int TodoId { get; set; }
        public string Title { get; set; }
        public bool IsComplete { get; set; }
        public DateTime CreatedAt { get; set; }


        public int UserId { get; set; }
        public User? User { get; set; }

        public Todo(string title)
        {
            Title = title;
        }
    }
}