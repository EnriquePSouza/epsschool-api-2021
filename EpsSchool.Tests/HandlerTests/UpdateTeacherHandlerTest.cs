using System;
using EpsSchool.Domain.Commands;
using EpsSchool.Domain.Handlers;
using EpsSchool.Shared.Commands;
using EpsSchool.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EpsSchool.Tests.HandlerTests
{
    [TestClass]
    public class UpdateTeacherHandlerTests
    {
        private readonly UpdateTeacherCommand _invalidCommand = new UpdateTeacherCommand(Guid.NewGuid(), "", "", "", true);
        private readonly UpdateTeacherCommand _validCommand = new UpdateTeacherCommand(Guid.NewGuid(), "Enrique", "Souza", "33458856", true);
        private readonly TeacherHandler _handler = new TeacherHandler(new FakeTeacherRepository());
        private GenericCommandResult _result = new GenericCommandResult();

        [TestMethod]
        public void Dado_um_comando_invalido_deve_interromper_a_execucao()
        {
            _result = (GenericCommandResult)_handler.Handle(_invalidCommand);
            Assert.AreEqual(_result.Success, false);
        }

        [TestMethod]
        public void Dado_um_comando_valido_deve_atualizar_o_registro_de_professor()
        {
            _result = (GenericCommandResult)_handler.Handle(_validCommand);
            Assert.AreEqual(_result.Success, true);
        }
    }
}