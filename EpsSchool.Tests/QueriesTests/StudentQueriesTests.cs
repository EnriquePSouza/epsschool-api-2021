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
        private IList<Student> _students;
        private readonly Guid _studentId = new Guid("3d04b2dd-76f8-4baa-8a67-12064a7808b2");

        [TestMethod]
        [TestCategory("Query")]
        public void Dado_a_consulta_de_aluno_por_identificador_unico_deve_retornar_1()
        {
            _students = ListsManager.LoadStudentQueriesTestsSampleData();

            var result = _students.AsQueryable()
                                  .Where(StudentQueries.GetStudentById(_studentId));

            Assert.AreEqual(result.Count(), 1);
        }

        [TestMethod]
        [TestCategory("Query")]
        public void Dado_a_consulta_de_alunos_por_nome_completo_deve_retornar_2()
        {
            PageParams pageParam = new PageParams();

            pageParam.Name = "Joana";

            _students = ListsManager.LoadStudentQueriesTestsSampleData();

            var result = _students.AsQueryable()
                                  .Where(StudentQueries.GetAllWhenPageParamsContainsName(pageParam));

            Assert.AreEqual(result.Count(), 2);
        }

        [TestMethod]
        [TestCategory("Query")]
        public void Dado_a_consulta_de_alunos_por_matricula_deve_retornar_1()
        {
            PageParams pageParam = new PageParams();

            pageParam.Enrollment = DateTime.Now.ToString("yydd") +
                           _studentId.GetHashCode().ToString().Replace("-", "51").Substring(0, 5);

            _students = ListsManager.LoadStudentQueriesTestsSampleData();

            var result = _students.AsQueryable()
                                  .Where(StudentQueries.GetAllWhenPageParamsContainsEnrollment(pageParam));

            Assert.AreEqual(result.Count(), 1);
        }

        [TestMethod]
        [TestCategory("Query")]
        public void Dado_a_consulta_de_alunos_por_status_deve_retornar_1()
        {
            PageParams pageParam = new PageParams();

            pageParam.Status = "0";

            _students = ListsManager.LoadStudentQueriesTestsSampleData();

            var result = _students.AsQueryable()
                                  .Where(StudentQueries.GetAllWhenPageParamsContainsStatus(pageParam));

            Assert.AreEqual(result.Count(), 1);
        }

        [TestMethod]
        [TestCategory("Query")]
        public void Dado_a_consulta_de_alunos_por_codigo_identificador_de_curso_deve_retornar_3()
        {
            var courseId = new Guid("3a00bebe-ace3-42e8-ad35-4a4104ae2b72");

            _students = ListsManager.LoadStudentQueriesTestsSampleData();

            var result = _students.AsQueryable()
                                  .Where(StudentQueries.GetAllByCourseIdAsync(courseId));

            Assert.AreEqual(result.Count(), 3);
        }
        
    }
}