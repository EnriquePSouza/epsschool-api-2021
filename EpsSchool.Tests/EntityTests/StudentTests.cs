using System;
using EpsSchool.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EpsSchool.Tests.EntityTests
{
    [TestClass]
    public class StudentTests
    {

        [TestMethod]
        public void Dado_um_novo_aluno_o_mesmo_deve_ser_valido()
        {
            var date = DateTime.Now;
            var student = new Student(1, 1, "Enrique", "Souza", "33458856", DateTime.Now);
            Assert.AreEqual(student.Status, true);
            Assert.AreEqual(student.StartDate, date);
            Assert.AreEqual(student.EndDate, null);
        }
    }
}