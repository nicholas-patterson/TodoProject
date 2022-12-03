using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoProject.Application.Models
{
    public class PostPutTodoDto
    {
        public string Title { get; set; }
        public bool IsComplete { get; set; }
        public int UserId { get; set; }

        public PostPutTodoDto(string title)
        {
            Title = title;
        }
    }
}