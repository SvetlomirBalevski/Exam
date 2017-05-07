using System.Collections.Generic;
using NUnit.Framework;
using Moq;
using ProjectManager.Data;
using ProjectManager.Contracts;
using ProjectManager.Common.Exceptions;
using ProjectManager.Commands;
using ProjectManager.Core.Contracts;
using ProjectManager.Common.Contracts;
using ProjectManager.Common;
using ProjectManager.Models;

namespace ProjectManager.Tests
{
    [TestFixture]
    public class CreateTaskCommandShould
    {
        [Test]
        public void ThrowsIfInvalidParametersCountArePassed()
        {
            var database = new Mock<IDatabase>();
            var modelsFactory = new Mock<IModelFactory>();
            var parameters = new List<string> { "1", "2", "3", "4", "5" };

            var command = new CreateTaskCommand(database.Object, modelsFactory.Object);

            Assert.Throws<UserValidationException>(() => command.Execute(parameters));
        }
        [Test]
        public void ThrowsIfNoParametersCountArePassed()
        {
            var database = new Mock<IDatabase>();
            var modelsFactory = new Mock<IModelFactory>();
            var parameters = new List<string>();

            var sut = new CreateTaskCommand(database.Object, modelsFactory.Object);

            Assert.Throws<UserValidationException>(() => sut.Execute(parameters));
        }
        [Test]
        public void CreatesTaskWithPassedParameters()
        {
            var task = new Mock<ITask>();
            var owner = new Mock<IUser>();
            task.Object.Owner = owner.Object;
            var model = new Mock<IModelFactory>();
            var sut = model.Object.CreateTask(owner.Object, "Pesho", "Gosho");
            Assert.AreEqual(sut.Name, "Pesho");
        }
    }
}
