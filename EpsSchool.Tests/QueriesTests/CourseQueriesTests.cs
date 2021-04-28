using System;
using System.Collections.Generic;
using System.Linq;
using EpsSchool.Domain.Entities;
using EpsSchool.Domain.Helpers;
using EpsSchool.Domain.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EpsSchool.Tests.QueriesTests
{
    [TestClass]
    public class CourseQueriesTests
    {
        private readonly Guid _courseId = new Guid("3d04b2dd-76f8-4baa-8a67-12064a7808b2");
        private readonly IList<Course> _courses = ListsManager.LoadCourseQueriesTestsSampleData();

        [TestMethod]
        [TestCategory("Query")]
        public void Dado_a_consulta_de_curso_por_identificador_unico_deve_retornar_1()
        {
            var result = _courses.AsQueryable()
                                  .Where(CourseQueries.GetById(_courseId));

            Assert.AreEqual(result.Count(), 1);
        }
        
    }
}