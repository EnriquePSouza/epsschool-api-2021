using AutoMapper;
using EpsSchool.Domain.Commands;
using EpsSchool.Domain.Entities;

namespace EpsSchool.Domain.Helpers
{
    public class SchoolProfile : Profile
    {
        public SchoolProfile()
        {
            CreateMap<Student, StudentCommand>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.Name} {src.Surname}")
                )
                .ForMember(
                    dest => dest.Age,
                    opt => opt.MapFrom(src => src.Birthdate.GetCurrentAge())
                );
            CreateMap<StudentCommand, Student>();
            CreateMap<Student, CreateStudentCommand>().ReverseMap();
            CreateMap<Student, UpdateStudentCommand>().ReverseMap();

            CreateMap<Teacher, TeacherCommand>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.Name} {src.Surname}")
                    );
            CreateMap<TeacherCommand, Teacher>();
            CreateMap<Teacher, CreateTeacherCommand>().ReverseMap();

            CreateMap<SubjectCommand, Subject>().ReverseMap();
            CreateMap<CourseCommand, Course>().ReverseMap();
        }
    }
}