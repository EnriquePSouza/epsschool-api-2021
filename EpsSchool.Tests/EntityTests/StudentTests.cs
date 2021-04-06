using System;
using System.Diagnostics;
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
            var student = new Student("Enrique", "Souza", "33458856", date);

            Assert.IsNotNull(student.Id);

            Assert.IsNotNull(student.Registration);
            Assert.AreEqual(8, student.Registration.Length);

            Assert.IsNotNull(student.StartDate);
            Assert.IsNull(student.EndDate);

            Assert.AreEqual(student.Status, true);

            Assert.AreEqual(student.Birthdate, date);
        }
    }
}