using AutoMapper;
using SisterLiDAL.Models;
using SisterliDTO.Model;

namespace SisterliDTO
{
    public class SisterliAutoMapper : Profile
    {
       public SisterliAutoMapper()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<Mom, MomDTO>();
            CreateMap<MomDTO, Mom>();
            CreateMap<MomDTO, UserDTO>();
            CreateMap<UserDTO, MomDTO>();
            CreateMap<Babysiter, BabysiterDTO>();
            CreateMap<BabysiterDTO, Babysiter>();
            CreateMap<BabysiterDTO, UserDTO>();
            CreateMap<UserDTO, BabysiterDTO>();
            CreateMap<BabysiterDTO, UserDTO>();
            CreateMap<UserDTO, BabysiterDTO>();

            CreateMap<Request, RequestDTO>();
            CreateMap<RequestDTO, Request>();
        }
    }
}