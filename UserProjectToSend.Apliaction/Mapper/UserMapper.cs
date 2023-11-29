using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProjectTosend.Domain.DTOs;
using UserProjectTosend.Domain.Models;

namespace UserProjectToSend.Apliaction.Mapper;

public class UserMapper:Profile
{
    public UserMapper()
    {
        //CreateMap<User,UserDTOToAdd>().ReverseMap();
        //CreateMap<User,UserDTOToUpdate>().ReverseMap();
    }
}
