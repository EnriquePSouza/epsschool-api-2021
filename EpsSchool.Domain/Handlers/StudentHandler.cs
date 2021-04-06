using System.Threading.Tasks;
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
                return new GenericCommandResult(false, "Aluno não encontrado!", student);

            // Update the student object with the new command data.
            var studentsResult = student.Result; // TODO - Change the method to async and resolve the task.
            studentsResult = _mapper.Map(command, studentsResult);

            _repository.Update(studentsResult); // TODO - Change the method to async and resolve the task.

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

            studentsResult.Status = command.Status.Equals(true);
            
            _repository.Update(studentsResult); // TODO - Change the method to async and resolve the task.

            var msg = studentsResult.Status ? "ativado" : "desativado";

            return new GenericCommandResult(true, $"Aluno {msg} com sucesso!", command);
        }
    }
}