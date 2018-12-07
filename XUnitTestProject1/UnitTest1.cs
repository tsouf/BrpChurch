
using BRPChurch.Controllers;
using BRPChurch.Models;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            BRPChurchContext context = new BRPChurchContext();
           
            var controller = new ActivitiesController(context);
            var result = controller.GetType();
            Assert.Equal("", result.GetProperties());

        }
    }
}
