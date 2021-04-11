using System.Threading.Tasks;
using EpsSchool.Domain.Commands;
using EpsSchool.Domain.Handlers;
using EpsSchool.Domain.Helpers.SampleDataManagers;
using EpsSchool.Shared.Commands;
using EpsSchool.Tests.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EpsSchool.Tests.HandlersTests
{
    [TestClass]
    public class CreateTeacherHandlerTests
    {
        private readonly CreateTeacherCommand _invalidCommand = new CreateTeacherCommand("","","",
                                                                                          SubjectsSampleDataManager.subject1.Id);
        private readonly CreateTeacherCommand _validCommand = new CreateTeacherCommand("Enrique", "Souza", "33458856",
                                                                                        SubjectsSampleDataManager.subject1.Id);
        private readonly TeacherHandler _handler = new TeacherHandler(new FakeTeacherRepository());
        private GenericCommandResult _result = new GenericCommandResult();

        [TestMethod]
        [TestCategory("Handler")]
        public async Task Dado_um_comando_invalido_deve_interromper_a_execucao()
        {
            _result = (GenericCommandResult) await _handler.Handle(_invalidCommand);
            Assert.AreEqual(_result.Success, false);
        }

        [TestMethod]
        [TestCategory("Handler")]
        public async Task Dado_um_comando_valido_deve_criar_o_registro_de_professor()
        {
            _result = (GenericCommandResult) await _handler.Handle(_validCommand);
            Assert.AreEqual(_result.Success, true);
        }
    }
}