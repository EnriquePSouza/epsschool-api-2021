using System;
using EpsSchool.Domain.Commands;
using EpsSchool.Domain.Handlers;
using EpsSchool.Shared.Commands;
using EpsSchool.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EpsSchool.Tests.HandlerTests
{
    [TestClass]
    public class ChangeStudentStatusHandlerTests
    {
        private readonly ChangeStudentStatusCommand _invalidCommand = new ChangeStudentStatusCommand();
        private readonly ChangeStudentStatusCommand _validCommandActive = new ChangeStudentStatusCommand(Guid.NewGuid(), true);
        private readonly ChangeStudentStatusCommand _validCommandInactive = new ChangeStudentStatusCommand(Guid.NewGuid(), false);
        private readonly StudentHandler _handler = new StudentHandler(new FakeStudentRepository());
        private GenericCommandResult _result = new GenericCommandResult();

        [TestMethod]
        public void Dado_um_comando_invalido_deve_interromper_a_execucao()
        {
            _result = (GenericCommandResult)_handler.Handle(_invalidCommand);
            Assert.AreEqual(_result.Success, false);
        }

        [TestMethod]
        public void Dado_um_comando_valido_deve_atualizar_o_registro_de_aluno_inativo()
        {
            _result = (GenericCommandResult)_handler.Handle(_validCommandInactive);
            Assert.AreEqual(_result.Success, true);
        }

        [TestMethod]
        public void Dado_um_comando_valido_deve_atualizar_o_registro_de_aluno_ativo()
        {
            _result = (GenericCommandResult)_handler.Handle(_validCommandActive);
            Assert.AreEqual(_result.Success, true);
        }
    }
}