using System;
using EpsSchool.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EpsSchool.Tests.CommandsTests
{
    [TestClass]
    public class UpdateSubjectCommandTests
    {
        private readonly UpdateSubjectCommand _invalidCommand = 
                                                new UpdateSubjectCommand(Guid.NewGuid(),
                                                        "");
        private readonly UpdateSubjectCommand _validCommand = 
                                                new UpdateSubjectCommand(Guid.NewGuid(),
                                                        "Matemática");

        public UpdateSubjectCommandTests()
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