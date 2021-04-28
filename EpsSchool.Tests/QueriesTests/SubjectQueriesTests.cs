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
    public class SubjectQueriesTests
    {
        private readonly Guid _subjectId = new Guid("3d04b2dd-76f8-4baa-8a67-12064a7808b2");
        private readonly IList<Subject> _subjects = ListsManager.LoadSubjectQueriesTestsSampleData();

        [TestMethod]
        [TestCategory("Query")]
        public void Dado_a_consulta_de_disciplina_por_identificador_unico_deve_retornar_1()
        {
            var result = _subjects.AsQueryable()
                                  .Where(SubjectQueries.GetById(_subjectId));

            Assert.AreEqual(result.Count(), 1);
        }
        
    }
}