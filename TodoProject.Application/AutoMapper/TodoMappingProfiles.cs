using AutoMapper;
using TodoProject.Application.Models;
using TodoProject.Domain.Entities;

namespace TodoProject.Application.AutoMapper
{
    public class TodoMappingProfiles : Profile
    {
        public TodoMappingProfiles()
        {
            CreateMap<PostPutTodoDto, Todo>();
            CreateMap<Todo, GetTodoDto>();
        }
    }
}