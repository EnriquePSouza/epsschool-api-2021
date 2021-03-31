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

        public TeacherHandler(ITeacherRepository repository)
        {
            _repository = repository;
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

            // Update the teacher object with the new command data.
            teacher = new Teacher(teacher.Id, teacher.Registration, command.Name,
                command.Surname, command.PhoneNumber); // VERIFY

            _repository.Update(teacher);

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
            
            // Update the teacher status.
            teacher.ChangeStatus(command.Status);

            _repository.Update(teacher);

            var msg = teacher.Status ? "ativado" : "desativado";

            return new GenericCommandResult(true, $"Professor {msg} com sucesso!", teacher);
        }
    }
}