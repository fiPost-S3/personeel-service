using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using personeel_service.Controllers;
using personeel_service.Models;
using personeel_service.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace personeel_service.Test
{
    public class Tests
    {
        private Mock<IPersonService> serviceMock;

        private Person person;
        private List<Person> persons;

        [SetUp]
        public void Setup()
        {
            // Instantiate mocks:
            serviceMock = new Mock<IPersonService>();


            // Create mock data:
            person = new Person("1", "test", "test@niettest.nl");
            persons = new List<Person>
            {
                person,
                new Person("2", "alf", "test@test.nl"),
            };
        }

        [Test]
        public void GetPersons()
        {
            // Arrange
            serviceMock.Setup(x => x.GetAll()).Returns(persons);
            var controller = new PersonController(serviceMock.Object);

            // Act
            ActionResult<IEnumerable<Person>> result = controller.GetPerson();

            // Assert
            Assert.AreEqual(2, result.Value.ToList().Count);
            Assert.IsInstanceOf<ActionResult<IEnumerable<Person>>>(result);
        }


        [Test]
        public void GetPersonById()
        {
            // Arrange
            serviceMock.Setup(x => x.GetById("1")).Returns(person);
            var controller = new PersonController(serviceMock.Object);

            // Act
            ActionResult<Person> result = controller.GetPerson("1");

            // Assert
            Assert.AreEqual("test", result.Value.Name);
            Assert.IsInstanceOf<ActionResult<Person>>(result);
        }
    }
}