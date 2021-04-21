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
        private readonly IStudentRepository _repoStudent;
        private readonly IMapper _mapper;

        public StudentHandler(IStudentRepository repoStudent, IMapper mapper)
        {
            _repoStudent = repoStudent;
            _mapper = mapper;
        }

        public async Task<ICommandResult> Handle(CreateStudentCommand command)
        {
            CreateStudentComandResult studentResult;
            
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
            {
                studentResult = new CreateStudentComandResult(false,
                                    "Aluno Invalido!", command.Notifications);
                return studentResult;
            }

            // Creates the student object.
            var student = _mapper.Map<Student>(command);

            _repoStudent.Create(student);
            await _repoStudent.SaveAsync();

            studentResult = new CreateStudentComandResult(true,
                                "Aluno Salvo!", command.Notifications);
            studentResult.Id = student.Id;

            return studentResult;
        }

        public async Task<ICommandResult> Handle(UpdateStudentCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false,
                            "Aluno Invalido!", command.Notifications);

            // Check if the student exists.
            var student = await _repoStudent.GetById(command.Id);
            if (student == null)
                return new GenericCommandResult(false,
                            "Aluno não encontrado!", command);

            // Update the student object with the new command data.
            student = _mapper.Map<Student>(command);

            _repoStudent.Update(student);
            await _repoStudent.SaveAsync();

            return new GenericCommandResult(true, "Aluno Salvo!", command);
        }

        public async Task<ICommandResult> Handle(ChangeStudentStatusCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false,
                            "Aluno Invalido!", command.Notifications);

            // Check if the student exists.
            var student = await _repoStudent.GetById(command.Id);
            if (student == null)
                return new GenericCommandResult(false,
                            "Aluno não encontrado!", command);

            // Update the student status.
            student.Status = command.Status.Equals(true);
            student.EndDate = command.Status.Equals(true) 
                                                ? (DateTime?)null 
                                                : (DateTime?)DateTime.Now;

            _repoStudent.Update(student);
            await _repoStudent.SaveAsync();

            var msg = student.Status ? "ativado" : "desativado";

            return new GenericCommandResult(true, 
                        $"Aluno {msg} com sucesso!", command);
        }
    }
}