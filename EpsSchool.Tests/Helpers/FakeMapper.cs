using AutoMapper;
using EpsSchool.Domain.Helpers;

namespace EpsSchool.Tests.Helpers
{
    public class FakeMapper
    {
        public static IMapper mapper = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new SchoolProfile());

        }).CreateMapper();
    }
}