using System;
using EpsSchool.Domain.Entities;
using EpsSchool.Shared.Commands;

namespace EpsSchool.Domain.Commands
{
    public class CreateStudentComandResult : ICommandResult
    {
        public CreateStudentComandResult() { }
        public CreateStudentComandResult(bool success, string message, Guid id)
        {
            Success = success;
            Message = message;
            Id = id;

        }
        
        public bool Success { get; set; }
        public string Message { get; set; }
        public Guid Id { get; set; }
    }
}