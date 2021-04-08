using EpsSchool.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EpsSchool.Tests.EntitiesTests
{
    [TestClass]
    public class CourseTests
    {
        private readonly Course _course = new Course("Informática");

        [TestMethod]
        [TestCategory("Entity")]
        public void Dado_um_novo_curso_o_mesmo_deve_ter_codigo_identificador()
        {
            Assert.IsNotNull(_course.Id);
        }
    }
}