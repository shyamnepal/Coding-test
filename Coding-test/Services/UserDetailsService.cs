using Coding_test.Models;
using System.Text;

namespace Coding_test.Services
{
    public class UserDetailsService : IUserDetailsService
    {
        public  IWebHostEnvironment _environment;
        public UserDetailsService(IWebHostEnvironment environment)
        {

            _environment = environment;
        }
        public void AddData(UserDetail UserData)
        {
            try
            {
                //check if the upload Directory exists in webRootpath 
                //if Do not exist create uploads Directory

                if (!Directory.Exists(_environment.WebRootPath + "\\uploads\\"))
                {
                    Directory.CreateDirectory(_environment.WebRootPath + "\\uploads\\");
                }

                //Csv file path
                string file = _environment.WebRootPath+"\\uploads\\Output.csv";
                string separator = ",";
                StringBuilder output = new StringBuilder();

                //if the csv File exist in the file variable 
                //if there is file Don't exist create them with heading 
                //otherwise it will simply append the userdata

                if (!File.Exists(file))
                {
                    string[] headings = { "Name", "Gender", "phone", "Email", "Address", "Nationality", "Date of Birth", "Education Background", "Prefered Contact" };
                    output.AppendLine(string.Join(separator, headings));

                    string[] newLine = { UserData.Name, UserData.Gender, UserData.Phone, UserData.Email, UserData.Address, UserData.Nationality, UserData.DateOfBirth.ToString(), UserData.EducationBackground, UserData.PreferredModeOfContact };
                    output.AppendLine(string.Join(separator, newLine));

                    File.AppendAllText(file, output.ToString());
                }
                else
                {
                    string[] newLinew = { UserData.Name, UserData.Gender, UserData.Phone, UserData.Email, UserData.Address, UserData.Nationality, UserData.DateOfBirth.ToString(), UserData.EducationBackground, UserData.PreferredModeOfContact };
                    output.AppendLine(string.Join(separator, newLinew));

                    File.AppendAllText(file, output.ToString());
                }
                
                  

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
