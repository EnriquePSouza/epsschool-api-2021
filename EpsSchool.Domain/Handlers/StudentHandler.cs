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
            
            // Gera item para inserir no banco.
            var student = new Student(command.Id, command.Registration, command.Name, command.Surname, command.PhoneNumber, command.Birthdate);

            // Salva no banco
            _repository.Create(student);

            // Retorna um resultado para a tela
            return new GenericCommandResult(true, "Aluno Salvo!", student);
        }

        public ICommandResult Handle(UpdateStudentCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Aluno Invalido!", command.Notifications);
            
            // TODO - Precisa verificar se existe e depois atualizar no banco.
            var student = _repository.GetById(command.Id);

            // Salva no banco
            _repository.Update(student);

            // Retorna um resultado para a tela
            return new GenericCommandResult(true, "Aluno Salvo!", student);
        }

        public ICommandResult Handle(ChangeStudentStatusCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Aluno Invalido!", command.Notifications);
            
            // TODO - Precisa verificar se existe e depois atualizar no banco.
            var student = _repository.GetById(command.Id);

            // Alterar Estado
            student.IsActive();

            // Salva no banco
            _repository.Update(student);

            // Retorna um resultado para a tela
            return new GenericCommandResult(true, "Aluno Salvo!", student);
        }
    }
}