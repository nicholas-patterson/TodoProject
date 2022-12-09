using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoProject.Domain.Entities;

namespace TodoProject.Application.Models
{
    public class GetTodoDto
    {
        public int TodoId { get; set; }
        public string Title { get; set; }
        public bool IsComplete { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }

        public GetTodoDto(string title)
        {
            Title = title;
        }
    }
}