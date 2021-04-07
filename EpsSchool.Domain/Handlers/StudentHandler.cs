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
            var student = new Student(command.Name, command.Surname, 
                command.PhoneNumber, command.BirthDate);

            _repository.Create(student); // TODO - Change the method to async and resolve the task.

            return new GenericCommandResult(true, "Aluno Salvo!", command);
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
            
            Student studentResult = student.Result; // TODO - Change the method to async and resolve the task.

            // Update the student object with the new command data.
            studentResult.Name = command.Name;
            studentResult.Surname = command.Surname;
            studentResult.PhoneNumber = command.PhoneNumber;
            studentResult.Status = command.Status;

            _repository.Update(studentResult); // TODO - Change the method to async and resolve the task.

            return new GenericCommandResult(true, "Aluno Salvo!", command);
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

            // Update the student status.
            var studentsResult = student.Result; // TODO - Change the method to async and resolve the task.

             if(command.Status.Equals(true))
             {
                 studentsResult.Status = true; 
                 studentsResult.EndDate = null;
             }
             else
             {
                 studentsResult.Status = false;
                 studentsResult.EndDate = DateTime.Now;
             }
            
            _repository.Update(studentsResult); // TODO - Change the method to async and resolve the task.

            var msg = studentsResult.Status ? "ativado" : "desativado";

            return new GenericCommandResult(true, $"Aluno {msg} com sucesso!", command);
        }
    }
}