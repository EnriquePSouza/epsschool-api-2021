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
    public class StudentQueriesTests
    {
        private readonly Guid _studentId = new Guid("3d04b2dd-76f8-4baa-8a67-12064a7808b2");
        private readonly IList<Student> _students = ListsManager.LoadStudentQueriesTestsSampleData();

        [TestMethod]
        [TestCategory("Query")]
        public void Dado_a_consulta_de_aluno_por_identificador_unico_deve_retornar_1()
        {
            var result = _students.AsQueryable()
                                  .Where(StudentQueries.GetStudentById(_studentId));

            Assert.AreEqual(result.Count(), 1);
        }

        [TestMethod]
        [TestCategory("Query")]
        public void Dado_a_consulta_de_alunos_por_nome_completo_deve_retornar_2()
        {
            var name = "Joana";

            var result = _students.AsQueryable()
                                  .Where(StudentQueries.GetAllByName(name));

            Assert.AreEqual(result.Count(), 2);
        }

        [TestMethod]
        [TestCategory("Query")]
        public void Dado_a_consulta_de_alunos_por_matricula_deve_retornar_1()
        {
            var enrollment = DateTime.Now.ToString("yydd") +
                        _studentId.GetHashCode().ToString().Replace("-", "51").Substring(0, 5);

            var result = _students.AsQueryable()
                                  .Where(StudentQueries.GetAllByEnrollment(enrollment));

            Assert.AreEqual(result.Count(), 1);
        }

        [TestMethod]
        [TestCategory("Query")]
        public void Dado_a_consulta_de_alunos_por_status_deve_retornar_1()
        {
            var status = "0";

            var result = _students.AsQueryable()
                                  .Where(StudentQueries.GetAllByStatus(status));

            Assert.AreEqual(result.Count(), 1);
        }

        [TestMethod]
        [TestCategory("Query")]
        public void Dado_a_consulta_de_alunos_por_codigo_identificador_de_curso_deve_retornar_3()
        {
            var courseId = new Guid("3a00bebe-ace3-42e8-ad35-4a4104ae2b72");

            var result = _students.AsQueryable()
                                  .Where(StudentQueries.GetAllByCourseIdAsync(courseId));

            Assert.AreEqual(result.Count(), 3);
        }
        
    }
}