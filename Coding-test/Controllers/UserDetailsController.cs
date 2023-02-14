using Coding_test.Models;
using Coding_test.Services;
using Microsoft.AspNetCore.Mvc;

namespace Coding_test.Controllers
{
    public class UserDetailsController : Controller
    {
        private readonly IUserDetailsService _service;
        public UserDetailsController(IUserDetailsService service)
        {
            _service = service;
        }

        // return Index page
        public IActionResult Index()
        {
            return View();
        }

        //http post request
        [HttpPost]
        public async Task<IActionResult> Create(UserDetail UserData)
        {
            //check the model validation
            //
            if (!ModelState.IsValid)
            {
                return View("Index", UserData);
            }
            //if the modle is valid then 
            //our data added to the csv file 
            //the csv file implementation in UserDetailsService class which implements IUserService interface

            _service.AddData(UserData);
            return RedirectToAction(nameof(Index));
        }

        //This method is to get the data from csv file
        public async Task<IActionResult> UserView()
        {
         
            var data = _service.GetData();
            return View(data);
        }

        

        
    }
}
