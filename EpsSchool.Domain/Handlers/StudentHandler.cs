using System;
using EpsSchool.Domain.Commands;
using EpsSchool.Domain.Entities;
using EpsSchool.Domain.Repositories;
using EpsSchool.Shared.Commands;
using EpsSchool.Shared.Handlers;
using Flunt.Notifications;

namespace EpsSchool.Domain.Handlers
{
    public class StudentHandler :
        Notifiable,
        IHandler<CreateStudentCommand>,
        IHandler<UpdateStudentCommand>,
        IHandler<ChangeStudentStatusCommand>
    {
        private readonly IStudentRepository _repository;

        public StudentHandler(IStudentRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateStudentCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Aluno Invalido!", command.Notifications);
            
            // Creates the student object.
            var student = new Student(command.FirstName, command.LastName, 
                command.PhoneNumber, command.BirthDate);

            _repository.Create(student); // TODO - Change the method to async and resolve the task.

            return new GenericCommandResult(true, "Aluno Salvo!", student);
        }

        public ICommandResult Handle(UpdateStudentCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Aluno Invalido!", command.Notifications);
            
            // Check if the student exists.
            var student = _repository.GetById(command.Id); // TODO - Change the method to async and resolve the task.
            if (student == null)
                return new GenericCommandResult(false, "Aluno não encontrado!", command);

            // TODO - Make this a service method in one TeacherService, and test it.
            // Update the student object with the new command data.
            student.FirstName = command.FirstName;
            student.LastName = command.LastName;
            student.PhoneNumber = command.PhoneNumber;
            student.Status = command.Status;

            _repository.Update(student); // TODO - Change the method to async and resolve the task.

            return new GenericCommandResult(true, "Aluno Salvo!", student);
        }

        public ICommandResult Handle(ChangeStudentStatusCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Aluno Invalido!", command.Notifications);
            
            // Check if the student exists.
            var student = _repository.GetById(command.Id); // TODO - Change the method to async and resolve the task.
            if (student == null)
                return new GenericCommandResult(false, "Aluno não encontrado!", command);

            // TODO - Make this a service method in one StudentService, and test it.
            // Update the student status.
             if(command.Status.Equals(true))
             {
                 student.Status = true; 
                 student.EndDate = null;
             }
             else
             {
                 student.Status = false;
                 student.EndDate = DateTime.Now;
             }
            
            _repository.Update(student); // TODO - Change the method to async and resolve the task.

            var msg = student.Status ? "ativado" : "desativado";

            return new GenericCommandResult(true, $"Aluno {msg} com sucesso!", student);
        }
    }
}