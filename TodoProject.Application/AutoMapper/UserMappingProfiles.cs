using AutoMapper;
using TodoProject.Application.Models;
using TodoProject.Domain.Entities;

namespace TodoProject.Application.AutoMapper
{
    public class UserMappingProfiles : Profile
    {

        public UserMappingProfiles()
        {
            CreateMap<User, GetUserDto>();
            CreateMap<PostPutUserDto, User>();

        }
    }
}