using System;
using EpsSchool.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EpsSchool.Tests.CommandsTests
{
    [TestClass]
    public class ChangeTeacherStatusCommandTests
    {
        private readonly ChangeTeacherStatusCommand _invalidCommand = new ChangeTeacherStatusCommand();
        private readonly ChangeTeacherStatusCommand _validCommand = new ChangeTeacherStatusCommand(Guid.NewGuid(), true);

        public ChangeTeacherStatusCommandTests()
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