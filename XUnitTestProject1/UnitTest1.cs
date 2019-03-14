using APIWithToken.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }

        [Fact]
        public  void Task_GetPostById_Return_OkResult()
        {
            //Arrange  
            var controller = new TestController();
            var postId = 2;

            //Act  
            var data = controller.GetReq();

            //Assert  
            Assert.IsType<string>(data);
        }

        [Fact]
        public void Test_Token()
        {
            //Arrange  
            var controller = new TokenController();
            var postId = 2;

            //Act  
            var data = controller.Get("smit", "smit");

            //Assert  
            Assert.IsType<ObjectResult>(data);
        }
        [Fact]
        public void Test_TokenFailed()
        {
            //Arrange  
            var controller = new TokenController();
            var postId = 2;

            //Act  
            var data = controller.Get("666", "smit");

            //Assert  
            Assert.IsType<BadRequestResult>(data);
        }
    }
}
