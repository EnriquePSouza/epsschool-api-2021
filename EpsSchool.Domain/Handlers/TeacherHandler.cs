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
            var teacher = _mapper.Map<Teacher>(command);

            _repository.Create(teacher); // TODO - Change the method to async and resolve the task.

            return new GenericCommandResult(true, "Professor Salvo!", teacher);
        }

        public ICommandResult Handle(UpdateTeacherCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Professor Invalido!", command.Notifications);
            
            // Check if the teacher exists.
            var teacher = _repository.GetById(command.Id); // TODO - Change the method to async and resolve the task.
            if (teacher == null)
                return new GenericCommandResult(false, "Professor não encontrado!", teacher);

            // Update the student object with the new command data.
            var teachersResult = teacher.Result; // TODO - Change the method to async and resolve the task.
            teachersResult = _mapper.Map(command, teachersResult);

            _repository.Update(teachersResult); // TODO - Change the method to async and resolve the task.

            return new GenericCommandResult(true, "Professor Salvo!", teacher);
        }

        public ICommandResult Handle(ChangeTeacherStatusCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Professor Invalido!", command.Notifications);
            
            // Check if the teacher exists.
            var teacher = _repository.GetById(command.Id); // TODO - Change the method to async and resolve the task.
            if (teacher == null)
                return new GenericCommandResult(false, "Professor não encontrado!", teacher);
            
            // Update the student status.
            var teachersResult = teacher.Result;

            teachersResult.Status = command.Status.Equals(true);

            _repository.Update(teachersResult); // TODO - Change the method to async and resolve the task.

            var msg = teachersResult.Status ? "ativado" : "desativado";

            return new GenericCommandResult(true, $"Professor {msg} com sucesso!", teacher);
        }
    }
}