using HelloESDC.API.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HelloESDC.Tests
{
    public class GreetingControllerTest
    {
        #region Member Variables
        GreetingController _controller = null;
        IGreetingService _service = null;
        Guid _guid = Guid.Empty;
        #endregion

        #region Constructor
        public GreetingControllerTest()
        {
            _service = new GreetingServiceFake();
            _controller = new GreetingController(_service);
            _guid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");
        }
        #endregion

        #region Get Tests
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.Get().Result as OkObjectResult;

            // Assert
            var items = Assert.IsType<List<GreetingItem>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }
        #endregion

        #region Get By Id Tests
        [Fact]
        public void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.Get(Guid.NewGuid());

            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult.Result);
        }

        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsOkResult()
        {
            // Arrange
            var testGuid = _guid;

            // Act
            var okResult = _controller.Get(_guid);

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsRightItem()
        {
            // Arrange
            var testGuid = _guid;

            // Act
            var okResult = _controller.Get(testGuid).Result as OkObjectResult;

            // Assert
            Assert.IsType<GreetingItem>(okResult.Value);
            Assert.Equal(testGuid, (okResult.Value as GreetingItem).Id);
        }
        #endregion

        #region Add Tests
        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var nameMissingItem = new GreetingItem()
            {
                Message = "Not real"
            };
            _controller.ModelState.AddModelError("Name", "Required");

            // Act
            var badResponse = _controller.Post(nameMissingItem);

            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }


        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            GreetingItem testItem = new GreetingItem()
            {
                Name = "Donald Duck",
                Message = "He is one funny duck!"
            };

            // Act
            var createdResponse = _controller.Post(testItem);

            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }


        [Fact]
        public void Add_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            var testItem = new GreetingItem()
            {
                Name = "Donald Duck",
                Message = "He is one funny duck!"
            };

            // Act
            var createdResponse = _controller.Post(testItem) as CreatedAtActionResult;
            var item = createdResponse.Value as GreetingItem;

            // Assert
            Assert.IsType<GreetingItem>(item);
            Assert.Equal("Donald Duck", item.Name);
        }
        #endregion

        #region Remove Tests
        [Fact]
        public void Remove_NotExistingGuidPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            var notExistingGuid = Guid.NewGuid();

            // Act
            var badResponse = _controller.Remove(notExistingGuid);

            // Assert
            Assert.IsType<NotFoundResult>(badResponse);
        }

        [Fact]
        public void Remove_ExistingGuidPassed_ReturnsOkResult()
        {
            // Arrange
            var existingGuid = _guid;

            // Act
            var okResponse = _controller.Remove(existingGuid);

            // Assert
            Assert.IsType<OkResult>(okResponse);
        }
        [Fact]
        public void Remove_ExistingGuidPassed_RemovesOneItem()
        {
            // Arrange
            var existingGuid = _guid;

            // Act
            var okResponse = _controller.Remove(existingGuid);

            // Assert
            Assert.Equal(2, _service.GetAllItems().Count);
        }
        #endregion
    }
}
