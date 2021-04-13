using System;
using EpsSchool.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EpsSchool.Tests.CommandsTests
{
    [TestClass]
    public class UpdateTeacherCommandTests
    {
        private readonly UpdateTeacherCommand _invalidCommand =
                                                new UpdateTeacherCommand(Guid.NewGuid(),
                                                        "", "", "", true);
        private readonly UpdateTeacherCommand _validCommand = 
                                                new UpdateTeacherCommand(Guid.NewGuid(),
                                                        "Enrique", "Souza", "33458856", true);

        public UpdateTeacherCommandTests()
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