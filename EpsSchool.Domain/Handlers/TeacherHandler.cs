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
    public class TeacherHandler :
        Notifiable,
        ITeacherHandler<CreateTeacherCommand>,
        ITeacherHandler<UpdateTeacherCommand>,
        ITeacherHandler<ChangeTeacherStatusCommand>
    {
        private readonly ITeacherRepository _repository;
        private readonly IMapper _mapper;

        public TeacherHandler(ITeacherRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ICommandResult> TeacherHandle(CreateTeacherCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false,
                            "Professor Invalido!", command.Notifications);

            // Creates the teacher object.
            var teacher = _mapper.Map<Teacher>(command);

            _repository.Create(teacher);
            await _repository.SaveAsync();

            return new GenericCommandResult(true, "Professor Salvo!", command);
        }

        public async Task<ICommandResult> TeacherHandle(UpdateTeacherCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false,
                            "Professor Invalido!", command.Notifications);

            // Check if the teacher exists.
            var teacher = await _repository.GetById(command.Id);
            if (teacher == null)
                return new GenericCommandResult(false,
                            "Professor não encontrado!", command);

            // Update the teacher object with the new command data.
            teacher = _mapper.Map<Teacher>(command);

            _repository.Update(teacher);
            await _repository.SaveAsync();

            return new GenericCommandResult(true, "Professor Salvo!", command);
        }

        public async Task<ICommandResult> TeacherHandle(ChangeTeacherStatusCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false,
                            "Professor Invalido!", command.Notifications);

            // Check if the teacher exists.
            var teacher = await _repository.GetById(command.Id);
            if (teacher == null)
                return new GenericCommandResult(false,
                            "Professor não encontrado!", teacher);

            // Update the teacher status.
            teacher.Status = command.Status.Equals(true);
            teacher.EndDate = command.Status.Equals(true) ? (DateTime?)null : (DateTime?)DateTime.Now;

            _repository.Update(teacher);
            await _repository.SaveAsync();

            var msg = teacher.Status ? "ativado" : "desativado";

            return new GenericCommandResult(true, $"Professor {msg} com sucesso!", command);
        }
    }
}