using AutoMapper;
using EpsSchool.Domain.Commands;
using EpsSchool.Domain.Entities;
using EpsSchool.Domain.Repositories;
using EpsSchool.Shared.Commands;
using EpsSchool.Shared.Handlers;
using Flunt.Notifications;

namespace EpsSchool.Domain.Handlers
{
    public class TeacherHandler :
        Notifiable,
        IHandler<CreateTeacherCommand>,
        IHandler<UpdateTeacherCommand>,
        IHandler<ChangeTeacherStatusCommand>
    {
        private readonly ITeacherRepository _repository;
        private readonly IMapper _mapper;

        public TeacherHandler(ITeacherRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ICommandResult Handle(CreateTeacherCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Professor Invalido!", command.Notifications);
            
            // Creates the teacher object.
            var teacher = new Teacher(command.Id, command.Registration, command.Name,
                command.Surname, command.PhoneNumber);

            _repository.Create(teacher);

            return new GenericCommandResult(true, "Professor Salvo!", teacher);
        }

        public ICommandResult Handle(UpdateTeacherCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Professor Invalido!", command.Notifications);
            
            // Check if the teacher exists.
            var teacher = _repository.GetById(command.Id);
            if (teacher == null)
                return new GenericCommandResult(false, "Professor não encontrado!", teacher);

            // Update the student object with the new command data.
            var teachersResult = teacher.Result;
            teachersResult = _mapper.Map(command, teachersResult);

            _repository.Update(teachersResult);

            return new GenericCommandResult(true, "Professor Salvo!", teacher);
        }

        public ICommandResult Handle(ChangeTeacherStatusCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Professor Invalido!", command.Notifications);
            
            // Check if the teacher exists.
            var teacher = _repository.GetById(command.Id);
            if (teacher == null)
                return new GenericCommandResult(false, "Professor não encontrado!", teacher);
            
            // Update the student status.
            var teachersResult = teacher.Result;

            if (command.Status.Equals(true))
            {
                teachersResult.Status = true;
            }
            else
            {
                teachersResult.Status = false;
            }

            _repository.Update(teachersResult);

            var msg = teachersResult.Status ? "ativado" : "desativado";

            return new GenericCommandResult(true, $"Professor {msg} com sucesso!", teacher);
        }
    }
}