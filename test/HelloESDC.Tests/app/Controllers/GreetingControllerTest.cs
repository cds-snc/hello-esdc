using HelloESDC.API.Database;
using HelloESDC.API.Models;
using HelloESDC.API.Service;
using HelloESDC.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using FluentAssertions;

namespace HelloESDC.Tests.App.Controllers
{
    public class GreetingControllerTest
    {

        public GreetingControllerTest()
        {

        }

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Arrange
            var expected = GetFakeGreetings();
            Mock<IGreetingService> mockGreetingService = new Mock<IGreetingService>();
            mockGreetingService.Setup(x => x.GetAllItems()).Returns(() => expected);

            var controller = new GreetingController(mockGreetingService.Object);

            // Act
            var result = controller.Get().Result;

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var greetings = okResult.Value.Should().BeAssignableTo<IEnumerable<Greeting>>().Subject;
            
            greetings.Count().Should().Be(3);
            greetings.ElementAt(0).Name.Should().Be("Hello ESDC");
        }

        [Fact]
        public void Get_Specific_WhenCalled_ReturnsOkResult()
        {
            // Arrange
            var expected = GetFakeGreetings().ElementAt(0);
            Mock<IGreetingService> mockGreetingService = new Mock<IGreetingService>();
            mockGreetingService.Setup(x => x.GetById(
                    It.IsAny<Guid>()
                )).Returns(() => expected);

            var controller = new GreetingController(mockGreetingService.Object);
            
            // Act
            var id = expected.Id;
            var result = controller.Get(id).Result;

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var greeting = okResult.Value.Should().BeAssignableTo<Greeting>().Subject;

            greeting.Id.Should().Be(id);
            greeting.Name.Should().Be("Hello ESDC");
        }

        [Fact]
        public void Get_Random_WhenCalled_ReturnsOkResult()
        {
            // Arrange
            var expected = GetFakeGreetings().ElementAt(1);
            Mock<IGreetingService> mockGreetingService = new Mock<IGreetingService>();
            mockGreetingService.Setup(x => x.GetRandom()).Returns(() => expected);

            var controller = new GreetingController(mockGreetingService.Object);

            // Act
            var id = expected.Id;
            var result = controller.Random().Result;

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var greeting = okResult.Value.Should().BeAssignableTo<Greeting>().Subject;

            greeting.Id.Should().Be(id);
            greeting.Name.Should().Be("Hello World");
        }

        private List<Greeting> GetFakeGreetings()
        {
            return new List<Greeting>
            {
                new Greeting
                {
                    Id = Guid.NewGuid(),
                    Name = "Hello ESDC",
                    Message = "Test 1",
                },
                new Greeting
                {
                    Id = Guid.NewGuid(),
                    Name = "Hello World",
                    Message = "Test 2",
                },
                new Greeting
                {
                    Id = Guid.NewGuid(),
                    Name = "Hello Everybody",
                    Message = "Test 3",
                },
            };
        } 
    }
}