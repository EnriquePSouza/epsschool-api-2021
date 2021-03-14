using AutoMapper;
using EpsSchool.Api.Dtos;
using EpsSchool.Api.Models;

namespace EpsSchool.Api.Helpers
{
    public class SchoolProfile : Profile
    {
        public SchoolProfile()
        {
            CreateMap<Aluno, AlunoDto>()
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}")
                )
            ;
        }
    }
}