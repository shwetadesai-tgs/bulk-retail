using AutoMapper;
using User.Core.Domain;
using User.Core.Models;

namespace User.API.Helpers
{
    public class AutoMapperProfiler : Profile
    {
        public AutoMapperProfiler()
        {
            CreateMap<UserModel, Users>();
            CreateMap<RegisterModel, Users>();
            CreateMap<UpdateModel, Users>();
        }
    }
}
