using Castle.Components.DictionaryAdapter;
using Coding_test.Controllers;
using Coding_test.Models;
using Coding_test.Services;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Linq;
using TestProject.IUserDetailsTest;

namespace TestProject
{
    public class UnitTestUserDetailsController
    {
        private readonly UserDetailsController _controller;
        private readonly IUserDetailsService _service;
        public UnitTestUserDetailsController()
        {
            _service = new UserDetailsServiceFacke();
            _controller=new UserDetailsController(_service);
        }

        [Fact]
        public void TestIndexView()
        {
            // Arrange
            var result = _controller.Index() as ViewResult;
            // Act
            var ViewResult = Assert.IsType<ViewResult>(result);

            // Assert
            Assert.Equal("Index", ViewResult.ViewName);

        }
        [Fact]
        public async Task Get_OnSucess_ReturnsListOfUsers()
        {

            // Arrange
            var result = _controller.UserView().Result;

            // Act
            var okResult = result as OkObjectResult;
            
            // Assert
            
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<UserDetail>>(
                viewResult.ViewData.Model);
            Assert.Equal(3, model.Count());



        }
        [Fact]
        public async Task Add_Returnview_WhenModelStateIsInvalid()
        {
            // Arrange
            _controller.ModelState.AddModelError("Name", "Required");
            var newUser = new UserDetail() { Email = "shyamnepal@gmail.com", Address = "ktm", DateOfBirth = DateTime.Now, Gender = "male", EducationBackground = "BIT", Nationality = "nepali", Phone = "9843117125", PreferredModeOfContact = "email" };
            
            // Act
            var result = _controller.Create(newUser).Result;
            var okResult = result as ViewResult;

            // Assert
            var viewResutl = Assert.IsType<ViewResult>(okResult);
            Assert.Equal("Index", okResult.ViewName);
            
        }

        [Fact]
        public async Task ModelSucess_Result()
        {
            // Arrange 
            var newUser = new UserDetail() { Name = "shyam", Email = "shyamnepal@gmail.com", Address = "ktm", DateOfBirth = DateTime.Now, Gender = "male", EducationBackground = "BIT", Nationality = "nepali", Phone = "9843117125", PreferredModeOfContact = "email" };

            // Act

            var result = _controller.Create(newUser).Result;
            var   okResult = result as RedirectToActionResult;

            // Assert
            var viewResult = Assert.IsType<RedirectToActionResult>(okResult);
            Assert.Equal("UserView", viewResult.ActionName);

        }
        [Fact]
        public async Task Get_By_Id()
        {
            // Act

            var result = _controller.Details(3).Result;
            var okResult = result as ViewResult;
            var user =(UserDetail) okResult.ViewData.Model;

            // Assert
            var viewResult = Assert.IsType<ViewResult>(okResult);
            Assert.Equal("Details", viewResult.ViewName);
            Assert.NotNull(viewResult);
            Assert.Equal("check", user.Name);
            
            
     
            
            
            
          
        }

        


    }
}