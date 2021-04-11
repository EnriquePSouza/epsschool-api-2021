using System;
using EpsSchool.Domain.Commands;
using EpsSchool.Domain.Helpers.SampleDataManagers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EpsSchool.Tests.CommandsTests
{
    [TestClass]
    public class CreateStudentCommandTests
    {
        private readonly CreateStudentCommand _invalidCommand = new CreateStudentCommand
                                                                ("","","",DateTime.Now,
                                                                 CoursesSampleDataManager.course1.Id);
        private readonly CreateStudentCommand _validCommand = new CreateStudentCommand
                                                              ("Enrique", "Souza", "33458856",
                                                                DateTime.Now, CoursesSampleDataManager.course1.Id);

        public CreateStudentCommandTests()
        {
            _invalidCommand.Validate();
            _validCommand.Validate();
        }

        [TestMethod]
        [TestCategory("Command")]
        public void Dado_um_comando_invalido()
        {
            Assert.AreEqual(_invalidCommand.Valid, false);
        }

        [TestMethod]
        [TestCategory("Command")]
        public void Dado_um_comando_valido()
        {
            Assert.AreEqual(_validCommand.Valid, true);
        }
    }
}