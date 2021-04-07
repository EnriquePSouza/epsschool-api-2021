using System;
using EpsSchool.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EpsSchool.Tests.EntityTests
{
    [TestClass]
    public class CourseSubjectTests
    {
        private readonly CourseSubject _courseSubject = new CourseSubject(Guid.NewGuid(), Guid.NewGuid());

        [TestMethod]
        public void Dado_um_novo_curso_o_mesmo_deve_ter_codigo_identificador()
        {
            Assert.IsNotNull(_courseSubject.Id);
        }
    }
}