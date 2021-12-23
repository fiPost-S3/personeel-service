using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using personeel_service.Controllers;
using personeel_service.Models;
using personeel_service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using personeel_service.Helpers;

namespace personeel_service.Test
{
    public class Tests
    {
        private Mock<IPersonService> serviceMock;

        private Person person1;
        private Person person2;
        private readonly List<Person> persons = new List<Person>();

        [SetUp]
        public void Setup()
        {
            // Instantiate mocks:
            serviceMock = new Mock<IPersonService>();
            
        // Create mock data:
            person1 = new Person(1, "Person_1", "person_1@testmail.com", "test", 1, "A22222A");
            person2 = new Person(2, "Person_2", "person_2@testmail.com", "test", 1, "A33333A");
            
            persons.Clear();
            persons.Add(person1);
            persons.Add(person2);
        }
        
        private static T GetObjectResultContent<T>(ActionResult<T> result)
        {
            return (T) ((ObjectResult) result.Result).Value;
        }

        [Test]
        public void GetPersons_Ok()
        {
            // Arrange
            serviceMock.Setup(x => x.GetAllAsync()).Returns(persons);
            var controller = new PersonController(serviceMock.Object);

            // Act
            var actionResult = controller.GetPerson();

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOf<OkObjectResult>(actionResult.Result);
            Assert.AreEqual(persons, GetObjectResultContent(actionResult));
        }


        [Test]
        public void GetPersonById_Ok()
        {
            // Arrange
            serviceMock.Setup(x => x.GetByIdAsync(person1.Id.ToString)).Returns(person1);
            var controller = new PersonController(serviceMock.Object);

            // Act
            var actionResult = controller.GetPerson(person1.Id);

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOf<OkObjectResult>(actionResult.Result);
            Assert.AreEqual(person1, GetObjectResultContent(actionResult));
        }
        
        [Test]
        public void GetPersonById_NotFound()
        {
            // Arrange
            serviceMock.Setup(x => x.GetByFontysId(person1.Id)).Throws<NotFoundException>();
            var controller = new PersonController(serviceMock.Object);

            // Act
            var actionResult = controller.GetPerson(person1.Id);

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOf<NotFoundObjectResult>(actionResult.Result);
        }

        [Test]
        public void Health() 
        {
            var controller = new PersonController(serviceMock.Object);

            // Act
            var actionResult = controller.Health();

            // Assert
            Assert.IsNotNull(actionResult);
            Assert.IsInstanceOf<OkResult>(actionResult);
        }
    }
}