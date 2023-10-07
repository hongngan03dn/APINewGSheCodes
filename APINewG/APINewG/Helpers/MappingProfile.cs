using APINewG.Entities;
using APINewG.Models;
using AutoMapper;

namespace APINewG.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Role, RoleModel>().ReverseMap();
        }
    }
}
