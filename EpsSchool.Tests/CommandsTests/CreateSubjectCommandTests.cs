using System;
using EpsSchool.Domain.Commands;
using EpsSchool.Domain.Helpers.SampleDataManagers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EpsSchool.Tests.CommandsTests
{
    [TestClass]
    public class CreateSubjectCommandTests
    {
        private readonly CreateSubjectCommand _invalidCommand =
                                                new CreateSubjectCommand("");
        private readonly CreateSubjectCommand _validCommand =
                                                new CreateSubjectCommand("Matemática");

        public CreateSubjectCommandTests()
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