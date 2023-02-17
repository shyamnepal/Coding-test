using Coding_test.Models;
using Coding_test.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.IUserDetailsTest
{
    internal class UserDetailsServiceFacke : IUserDetailsService
    {
        private readonly List<UserDetail> _userDetails;
        public UserDetailsServiceFacke()
        {
            _userDetails = new List<UserDetail>()
            {
                new UserDetail(){Id=1, Name="shyam", Email="shyamnepal@gmail.com", Address="ktm",DateOfBirth=DateTime.Now,Gender= "male",EducationBackground="BIT", Nationality="nepali",Phone="9843117125", PreferredModeOfContact="email"},
               new UserDetail() {Id=2, Name = "rajeep", Email = "shyamnepal@gmail.com", Address = "ktm", DateOfBirth = DateTime.Now, Gender = "male", EducationBackground = "BIT", Nationality = "nepali", Phone = "9843117125", PreferredModeOfContact = "email" },
                new UserDetail(){Id=3, Name="check", Email="check@gmail.com", Address="ktm",DateOfBirth=DateTime.Now,Gender= "male",EducationBackground="BIT", Nationality="nepali",Phone="9843117125", PreferredModeOfContact="email"}

            };
        }
       
        public void AddData(UserDetail UserData)
        {
            _userDetails.Add(UserData);
        }

        public IEnumerable<UserDetail> GetData()
        {
            return _userDetails;
        }

        public dynamic GetUserById(int id)
        {
            var user = _userDetails.Where(x => x.Id == id).FirstOrDefault();
            return user;
        }
    }
}
