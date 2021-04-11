using System;
using System.Threading.Tasks;
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

        public async Task<ICommandResult> Handle(CreateTeacherCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Professor Invalido!", command.Notifications);
            
            // Creates the teacher object.
            // TODO - Use automapper to make this object.
            var teacher = new Teacher(command.FirstName, command.LastName, command.PhoneNumber, command.SubjectId);

            _repository.Create(teacher);
            await _repository.SaveAsync();

            // TODO - Use automapper to make a more visible teacherReturn item for UI use.

            return new GenericCommandResult(true, "Professor Salvo!", teacher);
        }

        public async Task<ICommandResult> Handle(UpdateTeacherCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Professor Invalido!", command.Notifications);
            
            // Check if the teacher exists.
            var teacher = await _repository.GetById(command.Id);
            if (teacher == null)
                return new GenericCommandResult(false, "Professor não encontrado!", command);

            // Update the teacher object with the new command data.
            // TODO - Use automapper to make this object.
            teacher.FirstName = command.FirstName;
            teacher.LastName = command.LastName;
            teacher.PhoneNumber = command.PhoneNumber;
            teacher.Status = command.Status;

            // TODO - Verify if needs to update subject too.

            _repository.Update(teacher);
            await _repository.SaveAsync();

            // TODO - Use automapper to make a more visible teacherReturn item for UI use.

            return new GenericCommandResult(true, "Professor Salvo!", teacher);
        }

        public async Task<ICommandResult> Handle(ChangeTeacherStatusCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Professor Invalido!", command.Notifications);
            
            // Check if the teacher exists.
            var teacher = await _repository.GetById(command.Id);
            if (teacher == null)
                return new GenericCommandResult(false, "Professor não encontrado!", teacher);

            // Update the teacher status.
            teacher.Status = command.Status.Equals(true);
            teacher.EndDate = command.Status.Equals(true) ? null : DateTime.Now;
             
            _repository.Update(teacher);
            await _repository.SaveAsync();

            // TODO - Use automapper to make a more visible teacherReturn item for UI use.

            var msg = teacher.Status ? "ativado" : "desativado";

            return new GenericCommandResult(true, $"Professor {msg} com sucesso!", teacher);
        }
    }
}