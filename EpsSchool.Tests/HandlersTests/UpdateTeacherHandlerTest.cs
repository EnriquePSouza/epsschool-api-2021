using System;
using System.Threading.Tasks;
using EpsSchool.Domain.Commands;
using EpsSchool.Domain.Handlers;
using EpsSchool.Shared.Commands;
using EpsSchool.Tests.Helpers;
using EpsSchool.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EpsSchool.Tests.HandlersTests
{
    [TestClass]
    public class UpdateTeacherHandlerTests
    {
        private readonly UpdateTeacherCommand _invalidCommand = 
                                                new UpdateTeacherCommand(Guid.NewGuid(),
                                                        "", "", "", true);
        private readonly UpdateTeacherCommand _validCommand = 
                                                new UpdateTeacherCommand(Guid.NewGuid(),
                                                        "Enrique", "Souza", "33458856", true);
        private readonly TeacherHandler _handler = 
                                            new TeacherHandler(
                                                    new FakeTeacherRepository(), FakeMapper.mapper );
        private GenericCommandResult _result = new GenericCommandResult();

        [TestMethod]
        [TestCategory("Handler")]
        public async Task Dado_um_comando_invalido_o_manipulador_deve_interromper_a_execucao()
        {
            _result = (GenericCommandResult) await _handler.Handle(_invalidCommand);
            Assert.AreEqual(_result.Success, false);
        }

        [TestMethod]
        [TestCategory("Handler")]
        public async Task Dado_um_comando_valido_o_manipulador_deve_atualizar_o_registro_de_professor()
        {
            _result = (GenericCommandResult) await _handler.Handle(_validCommand);
            Assert.AreEqual(_result.Success, true);
        }
    }
}