using AutoMapper;
using Mstartt_Task.DTO;
using Mstartt_Task.Models;

namespace Mstartt_Task.helpers
{
    public class MappingUser: Profile
    {
        public MappingUser()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}
