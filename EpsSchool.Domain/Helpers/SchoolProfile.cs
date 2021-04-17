using AutoMapper;
using EpsSchool.Domain.Commands;
using EpsSchool.Domain.Dtos;
using EpsSchool.Domain.Entities;

namespace EpsSchool.Domain.Helpers
{
    public class SchoolProfile : Profile
    {
        public SchoolProfile()
        {
            CreateMap<Student, StudentDto>()
                .ForMember(
                    dest => dest.FullName,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")
                )
                .ForMember(
                    dest => dest.Age,
                    opt => opt.MapFrom(src => src.BirthDate.GetCurrentAge())
                );
            CreateMap<StudentDto, Student>();
            CreateMap<Student, CreateStudentCommand>().ReverseMap();
            CreateMap<Student, UpdateStudentCommand>().ReverseMap();
            CreateMap<Student, StudentReportDto>().ReverseMap();

            CreateMap<Teacher, TeacherDto>()
                .ForMember(
                    dest => dest.FullName,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}")
                    );
            CreateMap<TeacherDto, Teacher>();
            CreateMap<Teacher, CreateTeacherCommand>().ReverseMap();
            CreateMap<Teacher, UpdateTeacherCommand>().ReverseMap();

            CreateMap<SubjectDto, Subject>().ReverseMap();
            CreateMap<CourseDto, Course>().ReverseMap();
            CreateMap<CourseSubjectDto, CourseSubject>().ReverseMap();
        }
    }
}