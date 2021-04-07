using System;
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
            var teacher = new Teacher(command.Name, command.Surname, command.PhoneNumber);

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
                return new GenericCommandResult(false, "Professor não encontrado!", command);

            // TODO - Make this a service method in one TeacherService, and test it.
            // Update the student object with the new command data.
            teacher.Name = command.Name;
            teacher.Surname = command.Surname;
            teacher.PhoneNumber = command.PhoneNumber;
            teacher.Status = command.Status;

            _repository.Update(teacher); // TODO - Change the method to async and resolve the task.

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
            
            // TODO - Make this a service method in one TeacherService, and test it.
            // Update the student status.
             if(command.Status.Equals(true))
             {
                 teacher.Status = true; 
                 teacher.EndDate = null;
             }
             else
             {
                 teacher.Status = false;
                 teacher.EndDate = DateTime.Now;
             }

            _repository.Update(teacher); // TODO - Change the method to async and resolve the task.

            var msg = teacher.Status ? "ativado" : "desativado";

            return new GenericCommandResult(true, $"Professor {msg} com sucesso!", teacher);
        }
    }
}