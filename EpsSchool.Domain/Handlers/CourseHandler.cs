using System;
using System.Threading.Tasks;
using AutoMapper;
using EpsSchool.Domain.Commands;
using EpsSchool.Domain.Entities;
using EpsSchool.Domain.Repositories;
using EpsSchool.Shared.Commands;
using EpsSchool.Shared.Handlers;
using Flunt.Notifications;

namespace EpsSchool.Domain.Handlers
{
    public class CourseHandler :
        Notifiable,
        ICourseHandler<CreateCourseCommand>,
        ICourseHandler<UpdateCourseCommand>
    {
        private readonly ICourseRepository _repoCourse;
        private readonly IMapper _mapper;

        public CourseHandler(ICourseRepository repoCourse, IMapper mapper)
        {
            _repoCourse = repoCourse;
            _mapper = mapper;
        }

        public async Task<ICommandResult> CourseHandle(CreateCourseCommand command)
        {   
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false,
                                    "Curso Invalido!", command.Notifications);
            
            // Creates the course object.
            var course = _mapper.Map<Course>(command);

            _repoCourse.Create(course);
            await _repoCourse.SaveAsync();

            return new GenericCommandResult(true, "Curso Salvo!", command);
        }

        public async Task<ICommandResult> CourseHandle(UpdateCourseCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false,
                            "Curso Invalido!", command.Notifications);

            // Check if the course exists.
            var course = await _repoCourse.GetByIdAsync(command.Id);
            if (course == null)
                return new GenericCommandResult(false,
                            "Curso não encontrado!", command);

            // Update the course object with the new command data.
            course = _mapper.Map<Course>(command);

            _repoCourse.Update(course);
            await _repoCourse.SaveAsync();

            return new GenericCommandResult(true, "Curso Salvo!", command);
        }

    }
}