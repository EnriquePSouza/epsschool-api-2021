using System;
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
    public class CreateStudentHandlerTests
    {
        private readonly CreateStudentCommand _invalidCommand = new CreateStudentCommand
                                                                ("","","",DateTime.Now,
                                                                 CoursesSampleDataManager.course1.Id);
        private readonly CreateStudentCommand _validCommand = new CreateStudentCommand
                                                              ("Enrique", "Souza", "33458856",
                                                                DateTime.Now, CoursesSampleDataManager.course1.Id);
                                                                
        // TODO - Make the mock for the mapper.
        // private readonly StudentHandler _handler = new StudentHandler(new FakeStudentRepository());
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
        public void Dado_um_comando_valido_deve_criar_o_registro_de_aluno()
        {
            Assert.Fail();
            // async Task > This TestMethod need to be asynchronous.
            // _result = (GenericCommandResult) await _handler.Handle(_validCommand);
            // Assert.AreEqual(_result.Success, true);
        }
    }
}