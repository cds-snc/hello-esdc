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
            var okResult = controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
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