using AutoMapper;
using MSTART_Task.DTO;
using MSTART_Task.Models;

namespace MSTART_Task.helpers
{
    public class MappingUser:Profile
    {
        public MappingUser()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO,User>();

        }
    }
}
