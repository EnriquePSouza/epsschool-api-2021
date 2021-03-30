using System;
using EpsSchool.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EpsSchool.Tests.EntityTests
{
    [TestClass]
    public class StudentTests
    {
        private readonly Student _validStudent = new Student(1, 1, "Enrique", "Souza", "33458856", DateTime.Now);

        [TestMethod]
        public void Dado_um_novo_aluno_o_mesmo_nao_pode_estar_inativo()
        {
            Assert.AreEqual(_validStudent.Status, true);
        }
    }
}