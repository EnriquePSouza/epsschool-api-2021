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
    public class SubjectHandler :
        Notifiable,
        ISubjectHandler<CreateSubjectCommand>,
        ISubjectHandler<UpdateSubjectCommand>
    {
        private readonly ISubjectRepository _repoSubject;
        private readonly IMapper _mapper;

        public SubjectHandler(ISubjectRepository repoSubject, IMapper mapper)
        {
            _repoSubject = repoSubject;
            _mapper = mapper;
        }

        public async Task<ICommandResult> SubjectHandle(CreateSubjectCommand command)
        {   
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false,
                                    "Disciplina Invalida!", command.Notifications);
            
            // Creates the subject object.
            var subject = _mapper.Map<Subject>(command);

            _repoSubject.Create(subject);
            await _repoSubject.SaveAsync();

            return new GenericCommandResult(true, "Disciplina Salva!", command);
        }

        public async Task<ICommandResult> SubjectHandle(UpdateSubjectCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return new GenericCommandResult(false,
                            "Disciplina Invalida!", command.Notifications);

            // Check if the subject exists.
            var subject = await _repoSubject.GetByIdAsync(command.Id);
            if (subject == null)
                return new GenericCommandResult(false,
                            "Disciplina não encontrada!", command);

            // Update the subject object with the new command data.
            subject = _mapper.Map<Subject>(command);

            _repoSubject.Update(subject);
            await _repoSubject.SaveAsync();

            return new GenericCommandResult(true, "Disciplina Salva!", command);
        }

    }
}