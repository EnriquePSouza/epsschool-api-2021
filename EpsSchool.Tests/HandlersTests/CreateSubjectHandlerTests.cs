using System;
using System.Threading.Tasks;
using EpsSchool.Domain.Commands;
using EpsSchool.Domain.Handlers;
using EpsSchool.Domain.Helpers.SampleDataManagers;
using EpsSchool.Shared.Commands;
using EpsSchool.Tests.Helpers;
using EpsSchool.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EpsSchool.Tests.HandlersTests
{
    [TestClass]
    public class CreateSubjectHandlerTests
    {
        private readonly CreateSubjectCommand _invalidCommand =
                                                new CreateSubjectCommand("");
        private readonly CreateSubjectCommand _validCommand =
                                                new CreateSubjectCommand("Matemática");
        private readonly SubjectHandler _handler = 
                                            new SubjectHandler(
                                                    new FakeSubjectRepository(),
                                                    FakeMapper.mapper );
        private GenericCommandResult _result = new GenericCommandResult();

        [TestMethod]
        [TestCategory("Handler")]
        public async Task Dado_um_comando_invalido_o_manipulador_deve_interromper_a_execucao()
        {
            _result = (GenericCommandResult)await _handler.SubjectHandle(_invalidCommand);
            Assert.AreEqual(_result.Success, false);
        }

        [TestMethod]
        [TestCategory("Handler")]
        public async Task Dado_um_comando_valido_o_manipulador_deve_criar_o_registro_de_disciplina()
        {
            _result = (GenericCommandResult)await _handler.SubjectHandle(_validCommand);
            Assert.AreEqual(_result.Success, true);
        }
    }
}