using System;
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

        public async Task<ICommandResult> Handle(CreateStudentCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false, "Aluno Invalido!", command.Notifications);
            
            // Creates the student object.
            var student = _mapper.Map<Student>(command);

            // TODO - Insert the student in one course.

            _repository.Create(student);
            await _repository.SaveAsync();

            var studentResult = _mapper.Map<CreateStudentCommand>(student);

            return new GenericCommandResult(true, "Aluno Salvo!", studentResult);
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
            student = _mapper.Map<Student>(command);

            // TODO - Verify if needs to update course too.

            _repository.Update(student);
            await _repository.SaveAsync();

            var studentResult = _mapper.Map<CreateStudentCommand>(student);

            return new GenericCommandResult(true, "Aluno Salvo!", studentResult);
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
            student.Status = command.Status.Equals(true);
            student.EndDate = command.Status.Equals(true) ? null : DateTime.Now;

            _repository.Update(student);
            await _repository.SaveAsync();

            var msg = student.Status ? "ativado" : "desativado";

            var studentResult = _mapper.Map<CreateStudentCommand>(student);

            return new GenericCommandResult(true, $"Aluno {msg} com sucesso!", studentResult);
        }
    }
}