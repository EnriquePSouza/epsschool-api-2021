using AutoMapper;
using EpsSchool.Domain.Dtos;
using EpsSchool.Domain.Entities;

namespace EpsSchool.Domain.Helpers
{
    public class SchoolProfile : Profile
    {
        public SchoolProfile()
        {
            CreateMap<Student, AlunoDto>()
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}")
                )
                .ForMember(
                    dest => dest.Idade,
                    opt => opt.MapFrom(src => src.DataNascimento.GetCurrentAge())
                );
            CreateMap<AlunoDto, Student>();
            CreateMap<Student, AlunoRegistrarDto>().ReverseMap();
            CreateMap<Student, AlunoPatchDto>().ReverseMap();

            CreateMap<Teacher, ProfessorDto>()
                .ForMember(
                    dest => dest.Nome,
                    opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}")
                    );
            CreateMap<ProfessorDto, Teacher>();
            CreateMap<Teacher, ProfessorRegistrarDto>().ReverseMap();

            CreateMap<DisciplinaDto, Subject>().ReverseMap();
            CreateMap<CursoDto, Course>().ReverseMap();
        }
    }
}