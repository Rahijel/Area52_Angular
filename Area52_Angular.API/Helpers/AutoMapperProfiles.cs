using Area52_Angular.API.DTOs;
using Area52_Angular.API.Models;
using AutoMapper;

namespace Area52_Angular.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Book, BookForListDTO>();
            CreateMap<User, UserForDetailDTO>();
        }
    }
}