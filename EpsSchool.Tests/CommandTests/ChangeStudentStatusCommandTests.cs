using System;
using EpsSchool.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EpsSchool.Tests.CommandTests
{
    [TestClass]
    public class ChangeStudentStatusCommandTests
    {
        private readonly ChangeStudentStatusCommand _invalidCommand = new ChangeStudentStatusCommand();
        private readonly ChangeStudentStatusCommand _validCommand = new ChangeStudentStatusCommand(Guid.NewGuid(), true);

        public ChangeStudentStatusCommandTests()
        {
            _invalidCommand.Validate();
            _validCommand.Validate();
        }

        [TestMethod]
        public void Dado_um_comando_invalido()
        {
            Assert.AreEqual(_invalidCommand.Valid, false);
        }

        [TestMethod]
        public void Dado_um_comando_valido()
        {
            Assert.AreEqual(_validCommand.Valid, true);
        }
    }
}