using System;
using EpsSchool.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EpsSchool.Tests.CommandTests
{
    [TestClass]
    public class CreateStudentCommandTests
    {
        private readonly CreateStudentCommand _invalidCommand = new CreateStudentCommand("","","",DateTime.Now);
        private readonly CreateStudentCommand _validCommand = new CreateStudentCommand("Enrique", "Souza", "33458856", DateTime.Now);

        public CreateStudentCommandTests()
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