using AutoMapper;
using UserProjectTosend.Domain.DTOs;
using UserProjectTosend.Domain.Models;

namespace UserProjectToSend.Apliaction.Mapper;

public class UserProfileMapper:Profile
{
    public UserProfileMapper() 
    {
        CreateMap<UserProfile,UserProfileDTO>().ForMember(des=>des.firstName,opt=>opt.MapFrom(src=>src.FirstName))
            .ForMember(des=>des.lastName,opt=>opt.MapFrom(src=>src.LastName))
            .ForMember(des => des.personalNumber, opt => opt.MapFrom(src => src.personalNumber))
            .ReverseMap();
        //CreateMap<UserProfile,UserProfileDTO>().ReverseMap();
    }
}
