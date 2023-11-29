using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProjectTosend.Domain.DTOs;
using UserProjectTosend.Domain.Models;

namespace UserProjectToSend.Apliaction.Mapper;

public class UserProfileMapper:Profile
{
    public UserProfileMapper() 
    {
        CreateMap<UserProfile,UserProfileDTO>().ReverseMap();
        CreateMap<UserProfile, UserProfileToUpdateDTO>().ReverseMap();
    }
}
