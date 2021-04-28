using System;
using EpsSchool.Domain.Commands;
using EpsSchool.Domain.Helpers.SampleDataManagers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EpsSchool.Tests.CommandsTests
{
    [TestClass]
    public class CreateCourseCommandTests
    {
        private readonly CreateCourseCommand _invalidCommand =
                                                new CreateCourseCommand("");
        private readonly CreateCourseCommand _validCommand =
                                                new CreateCourseCommand("Informática");

        public CreateCourseCommandTests()
        {
            _invalidCommand.Validate();
            _validCommand.Validate();
        }

        [TestMethod]
        [TestCategory("Command")]
        public void Dado_um_comando_invalido()
        {
            Assert.AreEqual(_invalidCommand.Valid, false);
        }

        [TestMethod]
        [TestCategory("Command")]
        public void Dado_um_comando_valido()
        {
            Assert.AreEqual(_validCommand.Valid, true);
        }
    }
}