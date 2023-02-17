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

        // return Index page.
        public IActionResult Index()
        {
            return View("Index");
        }

        // http post request. It take userDetails value.
       
        [HttpPost]
        public async Task<IActionResult> Create(UserDetail UserData)
        {
            // check the model validation.
            // If  model is invalid then return view.
         
            if (!ModelState.IsValid)
            {
                return View("Index", UserData);
            }
            // If the modle is valid then our data added to the csv file. 
            // The csv file implementation in UserDetailsService class which implements IUserService interface.



            _service.AddData(UserData);
            return RedirectToAction(nameof(UserView));
        }

        // This method is to get the data from csv file.
        public async Task<IActionResult> UserView()
        {
         
            var data =  _service.GetData();
            return View(data);
        }

        // This method is to get the Details of the particular user by id.
        public async Task<IActionResult> Details(int id)
        {
            var getById =  _service.GetUserById(id);
            return View("Details",getById);
        }

        
    }
}
