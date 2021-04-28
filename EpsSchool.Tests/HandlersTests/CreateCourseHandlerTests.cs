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
    public class CreateCourseHandlerTests
    {
        private readonly CreateCourseCommand _invalidCommand =
                                                new CreateCourseCommand("");
        private readonly CreateCourseCommand _validCommand =
                                                new CreateCourseCommand("Informática");
        private readonly CourseHandler _handler = 
                                            new CourseHandler(
                                                    new FakeCourseRepository(),
                                                    FakeMapper.mapper );
        private GenericCommandResult _result = new GenericCommandResult();

        [TestMethod]
        [TestCategory("Handler")]
        public async Task Dado_um_comando_invalido_o_manipulador_deve_interromper_a_execucao()
        {
            _result = (GenericCommandResult)await _handler.CourseHandle(_invalidCommand);
            Assert.AreEqual(_result.Success, false);
        }

        [TestMethod]
        [TestCategory("Handler")]
        public async Task Dado_um_comando_valido_o_manipulador_deve_criar_o_registro_de_disciplina()
        {
            _result = (GenericCommandResult)await _handler.CourseHandle(_validCommand);
            Assert.AreEqual(_result.Success, true);
        }
    }
}