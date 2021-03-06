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
    public class TeacherQueriesTests
    {
        private readonly Guid _teacherId = new Guid("b4fabc54-ce8c-4009-beb4-51d577563c65");
        private readonly Guid _studentId = new Guid("3d04b2dd-76f8-4baa-8a67-12064a7808b2");

        [TestMethod]
        [TestCategory("Query")]
        public void Dado_a_consulta_de_professor_por_identificador_unico_deve_retornar_1()
        {
            IList<Teacher> teachers = ListsManager.LoadTeacherQueriesTestsSampleData();

            var result = teachers.AsQueryable()
                                  .Where(TeacherQueries.GetTeacherById(_teacherId));

            Assert.AreEqual(result.Count(), 1);
        }

        [TestMethod]
        [TestCategory("Query")]
        public void Dado_a_consulta_de_professores_por_codigo_identificador_de_aluno_deve_retornar_1()
        {
            IList<CourseSubject> coursesSubjects = ListsManager.LoadCourseSubjectQueriesTestsSampleData();

            var result = coursesSubjects.AsQueryable()
                                  .Where(TeacherQueries.GetAllByStudentIdAsync(_studentId));

            Assert.AreEqual(result.Count(), 1);
        }
        
    }
}