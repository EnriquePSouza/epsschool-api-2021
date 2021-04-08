using System;
using EpsSchool.Domain.Commands;
using EpsSchool.Domain.Handlers;
using EpsSchool.Shared.Commands;
using EpsSchool.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EpsSchool.Tests.HandlersTests
{
    [TestClass]
    public class UpdateStudentHandlerTests
    {
        private readonly UpdateStudentCommand _invalidCommand = new UpdateStudentCommand(Guid.NewGuid(), "", "", "", true);
        private readonly UpdateStudentCommand _validCommand = new UpdateStudentCommand(Guid.NewGuid(), "Enrique", "Souza", "33458856", true);
        private readonly StudentHandler _handler = new StudentHandler(new FakeStudentRepository());
        private GenericCommandResult _result = new GenericCommandResult();

        [TestMethod]
        [TestCategory("Handler")]
        public void Dado_um_comando_invalido_deve_interromper_a_execucao()
        {
            _result = (GenericCommandResult)_handler.Handle(_invalidCommand);
            Assert.AreEqual(_result.Success, false);
        }

        [TestMethod]
        [TestCategory("Handler")]
        public void Dado_um_comando_valido_deve_atualizar_o_registro_de_aluno()
        {
            _result = (GenericCommandResult)_handler.Handle(_validCommand);
            Assert.AreEqual(_result.Success, true);
        }
    }
}