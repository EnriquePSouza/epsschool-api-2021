using EpsSchool.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EpsSchool.Tests.CommandsTests
{
    [TestClass]
    public class CreateTeacherCommandTests
    {
        private readonly CreateTeacherCommand _invalidCommand = new CreateTeacherCommand("","","");
        private readonly CreateTeacherCommand _validCommand = new CreateTeacherCommand("Enrique", "Souza", "33458856");

        public CreateTeacherCommandTests()
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