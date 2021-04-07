using System;
using EpsSchool.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EpsSchool.Tests.EntityTests
{
    [TestClass]
    public class StudentCourseSubjectTests
    {
        private readonly StudentCourseSubject _studentCourseSubject = new StudentCourseSubject(Guid.NewGuid(), Guid.NewGuid());

        [TestMethod]
        public void Dado_um_novo_registro_de_aluno_para_um_curso_o_mesmo_deve_ter_data_de_inicio()
        {
            Assert.IsNotNull(_studentCourseSubject.StartDate);
        }

        [TestMethod]
        public void Dado_um_novo_registro_de_aluno_para_um_curso_o_mesmo_nao_deve_ter_nota_e_data_de_fim()
        {
            Assert.IsNull(_studentCourseSubject.EndDate);
            Assert.IsNull(_studentCourseSubject.Grade);
        }
    }
}