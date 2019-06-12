using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using HelloESDC.API.Database;
using HelloESDC.API.Models;
using HelloESDC.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace HelloESDC.Tests.App.Services
{
    /// <summary>
    /// The greeting controller test repository.
    /// </summary>
    public class GreetingServiceTest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GreetingServiceTest"/> class.
        /// </summary>
        public GreetingServiceTest()
        {
        }

        /// <summary>
        /// Test the that all items are returned.
        /// </summary>
        [Fact]
        public void GetAllItems_WhenCalled_ReturnsAllItems()
        {
            // Arrange
            var data = this.GetTestList();
            var mockSet = GetQueryableMockDbSet(data);
            var mockContext = new Mock<HelloESDCContext>();
            mockContext.Setup(c => c.Greetings).Returns(mockSet.Object);
            var service = new GreetingService(mockContext.Object);

            // Act
            var greetings = service.GetAllItems();

            // Assert
            greetings.Should().BeEquivalentTo(data);
        }

        /// <summary>
        /// Test the that all items are returned.
        /// </summary>
        [Fact]
        public void Get_WhenCalled_ReturnsThreeItems()
        {
            // Arrange
            var data = this.GetTestList();
            var mockSet = GetQueryableMockDbSet(data);
            var mockContext = new Mock<HelloESDCContext>();
            mockContext.Setup(c => c.Greetings).Returns(mockSet.Object);
            var service = new GreetingService(mockContext.Object);

            // Act
            var greetings = service.GetAllItems();

            // Assert
            greetings.Count().Should().Be(3);
        }

        private static Mock<DbSet<T>> GetQueryableMockDbSet<T>(List<T> sourceList)
         where T : class
        {
            var queryable = sourceList.AsQueryable();

            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            return mockSet;
        }

        private List<Greeting> GetTestList()
        {
            // Arrange
            var data = new List<Greeting>
            {
                new Greeting
                {
                    Id = Guid.NewGuid(),
                    Name = "Name 1",
                    Message = "Test 1",
                },
                new Greeting
                {
                    Id = Guid.NewGuid(),
                    Name = "Name 2",
                    Message = "Test 2",
                },
                new Greeting
                {
                    Id = Guid.NewGuid(),
                    Name = "Name 3",
                    Message = "Test 3",
                },
            };
            return data;
        }
    }
}
