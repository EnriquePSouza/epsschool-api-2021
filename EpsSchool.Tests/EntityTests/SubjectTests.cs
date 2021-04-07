using System;
using EpsSchool.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EpsSchool.Tests.EntityTests
{
    [TestClass]
    public class SubjectTests
    {
        private readonly Subject _subject = new Subject("Informática", Guid.NewGuid());

        [TestMethod]
        public void Dada_uma_nova_disciplina_a_mesma_deve_ter_codigo_identificador()
        {
            Assert.IsNotNull(_subject.Id);
        }
    }
}