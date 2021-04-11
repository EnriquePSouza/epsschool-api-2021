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

        public async Task<ICommandResult> Handle(CreateStudentCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Aluno Invalido!", command.Notifications);
            
            // Creates the student object.
            // TODO - Use automapper to make this object.
            var student = new Student(command.FirstName, command.LastName, 
                command.PhoneNumber, command.BirthDate);

            // TODO - Insert the student in one course.

            _repository.Create(student);
            await _repository.SaveAsync();

            // TODO - Use automapper to make a more visible studentReturn item for UI use.

            return new GenericCommandResult(true, "Aluno Salvo!", student);
        }

        public async Task<ICommandResult> Handle(UpdateStudentCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Aluno Invalido!", command.Notifications);
            
            // Check if the student exists.
            var student = await _repository.GetById(command.Id);
            if (student == null)
                return new GenericCommandResult(false, "Aluno não encontrado!", command);

            // Update the student object with the new command data.
            // TODO - Use automapper to make this object.
            student.FirstName = command.FirstName;
            student.LastName = command.LastName;
            student.PhoneNumber = command.PhoneNumber;
            student.Status = command.Status;

            // TODO - Verify if needs to update course too.

            _repository.Update(student);
            await _repository.SaveAsync();

            // TODO - Use automapper to make a more visible studentReturn item for UI use.

            return new GenericCommandResult(true, "Aluno Salvo!", student);
        }

        public async Task<ICommandResult> Handle(ChangeStudentStatusCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Aluno Invalido!", command.Notifications);
            
            // Check if the student exists.
            var student = await _repository.GetById(command.Id);
            if (student == null)
                return new GenericCommandResult(false, "Aluno não encontrado!", command);

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
            
            _repository.Update(student);
            await _repository.SaveAsync();

            // TODO - Use automapper to make a more visible studentReturn item for UI use.

            var msg = student.Status ? "ativado" : "desativado";

            return new GenericCommandResult(true, $"Aluno {msg} com sucesso!", student);
        }
    }
}