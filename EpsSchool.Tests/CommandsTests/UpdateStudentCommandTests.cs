using System;
using EpsSchool.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EpsSchool.Tests.CommandsTests
{
    [TestClass]
    public class UpdateStudentCommandTests
    {
        private readonly UpdateStudentCommand _invalidCommand = 
                                                new UpdateStudentCommand(Guid.NewGuid(),
                                                        "", "", "", true);
        private readonly UpdateStudentCommand _validCommand = 
                                                new UpdateStudentCommand(Guid.NewGuid(),
                                                        "Enrique", "Souza", "33458856", true);

        public UpdateStudentCommandTests()
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