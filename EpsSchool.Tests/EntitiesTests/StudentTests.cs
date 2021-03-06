using System;
using EpsSchool.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EpsSchool.Tests.EntitiesTests
{
    [TestClass]
    public class StudentTests
    {
        private readonly Student _student = new Student("Enrique", "Souza", "33458856", DateTime.Now);

        [TestMethod]
        [TestCategory("Entity")]
        public void Dado_um_novo_aluno_o_mesmo_deve_ter_codigo_identificador_e_data_de_aniversario()
        {
            Assert.IsNotNull(_student.Id);
            Assert.IsNotNull(_student.BirthDate);
        }

        [TestMethod]
        [TestCategory("Entity")]
        public void Dado_um_novo_aluno_o_mesmo_deve_ter_matricula_de_9_caracteres_e_estar_ativo()
        {
            Assert.AreEqual(9, _student.Enrollment.Length);
            Assert.AreEqual(_student.Status, true);
        }

        [TestMethod]
        [TestCategory("Entity")]
        public void Dado_um_novo_aluno_o_mesmo_deve_ter_data_de_inicio_e_não_deve_ter_data_de_fim()
        {
            Assert.IsNotNull(_student.StartDate);
            Assert.IsNull(_student.EndDate);
        }
    }
}