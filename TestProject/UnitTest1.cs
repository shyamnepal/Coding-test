using Castle.Components.DictionaryAdapter;
using Coding_test.Controllers;
using Coding_test.Models;
using Coding_test.Services;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TestProject.IUserDetailsTest;

namespace TestProject
{
    public class UnitTest1
    {
        private readonly UserDetailsController _controller;
        private readonly IUserDetailsService _service;
        public UnitTest1()
        {
            _service = new UserDetailsServiceFacke();
            _controller=new UserDetailsController(_service);
        }
        [Fact]
        public async void Get_OnSucess_ReturnsListOfUsers()
        {
            
            // Act
            var result =_controller.UserView();
            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<UserDetail>>(
                viewResult.ViewData.Model);
            Assert.Equal(3, model.Count());



        }
    }
}