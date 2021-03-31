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
            var student = new Student(command.Id, command.Registration, command.Name,
                command.Surname, command.PhoneNumber, command.Birthdate);

            _repository.Create(student);

            return new GenericCommandResult(true, "Aluno Salvo!", student);
        }

        public ICommandResult Handle(UpdateStudentCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Aluno Invalido!", command.Notifications);
            
            // Check if the student exists.
            var student = _repository.GetById(command.Id);
            if (student == null)
                return new GenericCommandResult(false, "Aluno não encontrado!", student);

            // Update the student object with the new command data.
            student = new Student(student.Id, student.Registration, command.Name,
                command.Surname, command.PhoneNumber, student.Birthdate); // VERIFY

            _repository.Update(student);

            return new GenericCommandResult(true, "Aluno Salvo!", student);
        }

        public ICommandResult Handle(ChangeStudentStatusCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Aluno Invalido!", command.Notifications);
            
            // Check if the student exists.
            var student = _repository.GetById(command.Id);
            if (student == null)
                return new GenericCommandResult(false, "Aluno não encontrado!", student);
            
            // Update the Student Status.
            student.ChangeStatus(command.Status);

            _repository.Update(student);

            var msg = student.Status ? "ativado" : "desativado";

            return new GenericCommandResult(true, $"Aluno {msg} com sucesso!", student);
        }
    }
}