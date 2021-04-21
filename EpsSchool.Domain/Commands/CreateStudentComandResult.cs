using System;
using EpsSchool.Domain.Entities;
using EpsSchool.Shared.Commands;

namespace EpsSchool.Domain.Commands
{
    public class CreateStudentComandResult : ICommandResult
    {
        public CreateStudentComandResult() { }
        public CreateStudentComandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }
        
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public Guid Id { get; set; }
    }
}