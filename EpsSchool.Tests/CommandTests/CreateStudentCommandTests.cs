using System;
using EpsSchool.Domain.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EpsSchool.Tests.CommandTests
{
    [TestClass]
    public class CreateStudentCommandTests
    {
        private readonly CreateStudentCommand _invalidCommand = new CreateStudentCommand(0,0,"","","",DateTime.Now);
        private readonly CreateStudentCommand _validCommand = new CreateStudentCommand(1, 1, "Enrique", "Souza", "33458856", DateTime.Now);

        public CreateStudentCommandTests()
        {
            // Só serve dentro do construtor se tudo que vc for testar nesse objeto precisar ser validado.
            _invalidCommand.Validate();
            _validCommand.Validate();
        }

        // Passa um aluno invalido para o teste ser positivo.
        [TestMethod]
        public void Dado_um_comando_invalido()
        {
            Assert.AreEqual(_invalidCommand.Valid, false);
        }

        // Passa um aluno valido para o teste ser positivo.
        [TestMethod]
        public void Dado_um_comando_valido()
        {
            Assert.AreEqual(_validCommand.Valid, true);
        }
    }
}