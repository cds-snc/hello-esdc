using HelloESDC.API.Models;
using HelloESDC.API.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HelloESDC.Tests.App
{
    /// <summary>
    /// The greeting controller test repository.
    /// </summary>
    public class GreetingControllerTest
    {
        GreetingController controller = null;
        IGreetingService service = null;
        Guid guid = Guid.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="GreetingControllerTest"/> class.
        /// </summary>
        public GreetingControllerTest()
        {
            this.service = new GreetingService();
            this.controller = new GreetingController(this.service);
            this.guid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");
        }

        /// <summary>
        /// Test the ok result for the get result.
        /// </summary>
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = this.controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        /// <summary>
        /// Test the that all items are returned.
        /// </summary>
        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = this.controller.Get().Result as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<Greeting>>(okResult.Value);
        }

        /// <summary>
        /// // Tests not found with unknown guid.
        /// </summary>
        [Fact]
        public void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = this.controller.Get(Guid.NewGuid());

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        /// <summary>
        /// Tests existing guid passed and ok result returned.
        /// </summary>
        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsOkResult()
        {
            // Arrange
            var testGuid = this.guid;

            // Act
            var okResult = this.controller.Get(this.guid);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        /// <summary>
        /// Tests existing guid finds correct item.
        /// </summary>
        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsRightItem()
        {
            // Arrange
            var testGuid = this.guid;

            // Act
            var okResult = this.controller.Get(testGuid).Result as OkObjectResult;

            // Assert
            Assert.IsType<Greeting>(okResult.Value);
            Assert.Equal(testGuid, (okResult.Value as Greeting).Id);
        }

        /// <summary>
        /// Tests add invalid object returns bad request.
        /// </summary>
        //Add Tests
        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var nameMissingItem = new Greeting()
            {
                Message = "Not real"
            };
            this.controller.ModelState.AddModelError("Name", "Required");

            // Act
            var badResponse = this.controller.Post(nameMissingItem);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        /// <summary>
        /// Add valid object return created response.
        /// </summary>
        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            Greeting testItem = new Greeting()
            {
                Name = "Donald Duck",
                Message = "He is one funny duck!"
            };

            // Act
            var createdResponse = this.controller.Post(testItem);

            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }


        /// <summary>
        /// Add valid object return response has created item.
        /// </summary>
        [Fact]
        public void Add_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            var testItem = new Greeting()
            {
                Name = "Donald Duck",
                Message = "He is one funny duck!"
            };

            // Act
            var createdResponse = this.controller.Post(testItem) as CreatedAtActionResult;
            var item = createdResponse.Value as Greeting;

            // Assert
            Assert.IsType<Greeting>(item);
            Assert.Equal("Donald Duck", item.Name);
        }

        /// <summary>
        /// Remove non existing guid returns not found response.
        /// </summary>
        //Remove Tests
        [Fact]
        public void Remove_NotExistingGuidPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            var notExistingGuid = Guid.NewGuid();

            // Act
            var badResponse = this.controller.Remove(notExistingGuid);

            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }

        /// <summary>
        /// Remove existing guid return ok result.
        /// </summary>
        [Fact]
        public void Remove_ExistingGuidPassed_ReturnsOkResult()
        {
            // Arrange
            var existingGuid = this.guid;

            // Act
            var okResponse = this.controller.Remove(existingGuid);

            // Assert
            Assert.IsType<OkResult>(okResponse);
        }

        /// <summary>
        /// Remove existing guid removed one item.
        /// </summary>
        [Fact]
        public void Remove_ExistingGuidPassed_RemovesOneItem()
        {
            // Arrange
            var existingGuid = this.guid;

            // Act
            var okResponse = this.controller.Remove(existingGuid);

            // Assert
            Assert.Equal(2, this.service.GetAllItems().Count);
        }
    }
}
