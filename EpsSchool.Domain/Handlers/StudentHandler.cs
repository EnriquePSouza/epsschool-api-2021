using AutoMapper;
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
        private readonly IMapper _mapper;

        public StudentHandler(IStudentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ICommandResult Handle(CreateStudentCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Aluno Invalido!", command.Notifications);
            
            // Creates the student object.
            var student = _mapper.Map<Student>(command);

            _repository.Create(student);

            return new GenericCommandResult(true, "Aluno Salvo!", command);
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
            var studentsResult = student.Result;
            studentsResult = _mapper.Map(command, studentsResult);

            _repository.Update(studentsResult);

            return new GenericCommandResult(true, "Aluno Salvo!", command);
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
                return new GenericCommandResult(false, "Aluno não encontrado!", command);

            // Update the student status.
            var studentsResult = student.Result;

            if (command.Status.Equals(true))
            {
                studentsResult.Status = true;
            }
            else
            {
                studentsResult.Status = false;
            }

            _repository.Update(studentsResult);

            var msg = studentsResult.Status ? "ativado" : "desativado";

            return new GenericCommandResult(true, $"Aluno {msg} com sucesso!", command);
        }
    }
}