using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using HelloESDC.API.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace HelloESDC.Tests.App.Controllers
{
    /// <summary>
    /// Class to test the greeting controller
    /// </summary>
    public class GreetingControllerTest
    {
        private readonly Mock<IGreetingService> mockGreetingService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GreetingControllerTest"/> class.
        /// </summary>
        public GreetingControllerTest()
        {
            this.mockGreetingService = new Mock<IGreetingService>();
        }

        /// <summary>
        /// Class that tests returns ok, count and name.
        /// </summary>
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Arrange
            var expected = this.GetFakeGreetings();
            this.mockGreetingService.Setup(x => x.GetAllItems()).Returns(() => expected);

            var controller = new GreetingController(this.mockGreetingService.Object);

            // Act
            var result = controller.Get().Result;

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var greetings = okResult.Value.Should().BeAssignableTo<IEnumerable<Greeting>>().Subject;
            greetings.Count().Should().Be(3);
            greetings.ElementAt(0).Name.Should().Be("Hello ESDC");
        }

        /// <summary>
        /// Tests the expected vs the specific id and name.
        /// </summary>
        [Fact]
        public void Get_Specific_WhenCalled_ReturnsOkResult()
        {
            // Arrange
            var expected = new Greeting
                {
                    Id = Guid.NewGuid(),
                    Name = "Hello ESDC",
                    Message = "Test 1",
                };

            this.mockGreetingService.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(() => expected);

            // Act
            var controller = new GreetingController(this.mockGreetingService.Object);
            var result = controller.Get(expected.Id).Result;

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var greeting = okResult.Value.Should().BeAssignableTo<Greeting>().Subject;
            greeting.Id.Should().Be(expected.Id);
            greeting.Name.Should().Be("Hello ESDC");
        }

        [Fact]
        public void Get_Specific_NonExistentId_ReturnsNotFound()
        {
            // Arrange
            this.mockGreetingService.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(() => null);

            // Act
            var controller = new GreetingController(this.mockGreetingService.Object);
            var result = controller.Get(Guid.NewGuid()).Result;

            // Assert
            var notFoundResult = result.Should().BeOfType<NotFoundResult>().Subject;
        }

        /// <summary>
        /// Class that tests the expected vs the random.
        /// </summary>
        [Fact]
        public void Get_Random_WhenCalled_ReturnsOkResult()
        {
            // Arrange
            var expected = new Greeting
                {
                    Id = Guid.NewGuid(),
                    Name = "Hello ESDC",
                    Message = "Test 1",
                };

            this.mockGreetingService.Setup(x => x.GetRandom()).Returns(() => expected);

            // Act
            var controller = new GreetingController(this.mockGreetingService.Object);
            var result = controller.Random().Result;

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var greeting = okResult.Value.Should().BeAssignableTo<Greeting>().Subject;
            greeting.Id.Should().Be(expected.Id);
            greeting.Name.Should().Be("Hello ESDC");
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