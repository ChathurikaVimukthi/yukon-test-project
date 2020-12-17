using AutoMapper;
using YukonTest.Dtos.TimeTableHandle;
using YukonTest.Models;

namespace YukonTest
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Teacher, GetTeachersDto>();
            CreateMap<GetTeachersDto, Teacher>();
            CreateMap<UpdateLeaveDto, Teacher>();
            CreateMap<Teacher, UpdateLeaveDto>();
        }
    }
}