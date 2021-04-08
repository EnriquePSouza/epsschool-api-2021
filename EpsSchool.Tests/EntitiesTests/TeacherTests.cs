using System;
using EpsSchool.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EpsSchool.Tests.EntitiesTests
{
    [TestClass]
    public class TeacherTests
    {
        private readonly Teacher _teacher = new Teacher("Enrique", "Souza", "33458856");

        [TestMethod]
        [TestCategory("Entity")]
        public void Dado_um_novo_professor_o_mesmo_deve_ter_codigo_identificador()
        {
            Assert.IsNotNull(_teacher.Id);
        }

        [TestMethod]
        [TestCategory("Entity")]
        public void Dado_um_novo_professor_o_mesmo_deve_ter_registro_de_8_caracteres_e_estar_ativo()
        {
            Assert.AreEqual(8, _teacher.Enrollment.Length);
            Assert.AreEqual(_teacher.Status, true);
        }

        [TestMethod]
        [TestCategory("Entity")]
        public void Dado_um_novo_professor_o_mesmo_deve_ter_data_de_inicio_e_não_deve_ter_data_de_fim()
        {
            Assert.IsNotNull(_teacher.StartDate);
            Assert.IsNull(_teacher.EndDate);
        }
    }
}