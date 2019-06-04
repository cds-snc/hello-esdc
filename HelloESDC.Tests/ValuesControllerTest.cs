using HelloESDC.API.Controllers;
using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace HelloESDC.Tests
{
    public class ValuesControllerTest
    {
        #region Member Variables
        ValuesController _controller = null;
        #endregion

        #region Contructors
        public ValuesControllerTest()
        {
            _controller = new ValuesController();
        }
        #endregion

        #region Test Methods

        //Test the Get Methods
        [Fact]
        public void Get_String_Array()
        {
            if (null != _controller)
            {
                //Act
                var actual = _controller.Get();
                if (null != actual)
                {
                    var actualValue = actual.Value;
                    var expected = new string[] { "value1", "value2" };

                    //Assert
                    Assert.Equal(expected, actualValue);
                }
            }
        }

        ///
        [Fact]
        public void Get_By_Id()
        {
            if (null != _controller)
            {
                //Act
                var test = int.MinValue;

                test = 1;
                var actual = _controller.Get(test);
                if (null != actual)
                {
                    var actualValue = actual.Value;
                    var expected = "value";

                    //Assert
                    Assert.Equal(expected, actualValue);
                }
            }
        }
        #endregion
    }
}
