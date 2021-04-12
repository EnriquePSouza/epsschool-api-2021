using System;
using System.Threading.Tasks;
using EpsSchool.Domain.Commands;
using EpsSchool.Domain.Handlers;
using EpsSchool.Shared.Commands;
using EpsSchool.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EpsSchool.Tests.HandlersTests
{
    [TestClass]
    public class ChangeTeacherStatusHandlerTests
    {
        private readonly ChangeTeacherStatusCommand _invalidCommand = new ChangeTeacherStatusCommand();
        private readonly ChangeTeacherStatusCommand _validCommandActive = new ChangeTeacherStatusCommand(Guid.NewGuid(), true);
        private readonly ChangeTeacherStatusCommand _validCommandInactive = new ChangeTeacherStatusCommand(Guid.NewGuid(), false);

        // TODO - Make the mock for the mapper.
        // private readonly TeacherHandler _handler = new TeacherHandler(new FakeTeacherRepository());
        private GenericCommandResult _result = new GenericCommandResult();

        [TestMethod]
        [TestCategory("Handler")]
        public void Dado_um_comando_invalido_deve_interromper_a_execucao()
        {
            Assert.Fail();
            // async Task > This TestMethod need to be asynchronous.
            // _result = (GenericCommandResult) await _handler.Handle(_invalidCommand);
            // Assert.AreEqual(_result.Success, false);
        }

        [TestMethod]
        [TestCategory("Handler")]
        public void Dado_um_comando_valido_deve_atualizar_o_registro_de_professor_inativo()
        {
            Assert.Fail();
            // async Task > This TestMethod need to be asynchronous.
            // _result = (GenericCommandResult) await _handler.Handle(_validCommandInactive);
            // Assert.AreEqual(_result.Success, true);
        }

        [TestMethod]
        [TestCategory("Handler")]
        public void Dado_um_comando_valido_deve_atualizar_o_registro_de_professor_ativo()
        {
            Assert.Fail();
            // async Task > This TestMethod need to be asynchronous.
            // _result = (GenericCommandResult) await _handler.Handle(_validCommandActive);
            // Assert.AreEqual(_result.Success, true);
        }
    }
}