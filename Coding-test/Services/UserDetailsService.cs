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
                    string[] headings = {"Id","Name", "Gender", "phone", "Email", "Address", "Nationality", "Date of Birth", "Education Background", "Prefered Contact" };
                    output.AppendLine(string.Join(separator, headings));
                    int count = 1;
                    string[] newLine = {count.ToString(), UserData.Name, UserData.Gender, UserData.Phone, UserData.Email, UserData.Address, UserData.Nationality, UserData.DateOfBirth.ToString(), UserData.EducationBackground, UserData.PreferredModeOfContact };
                    output.AppendLine(string.Join(separator, newLine));

                    File.AppendAllText(file, output.ToString());
                }
                else
                {
                    var lines = File.ReadAllLines(file);
                    var count = lines.Length;

                    string[] newLinew = {count.ToString(), UserData.Name, UserData.Gender, UserData.Phone, UserData.Email, UserData.Address, UserData.Nationality, UserData.DateOfBirth.ToString(), UserData.EducationBackground, UserData.PreferredModeOfContact };
                    output.AppendLine(string.Join(separator, newLinew));

                    File.AppendAllText(file, output.ToString());
                } 
                
            } catch (Exception ex)

            {
                throw ex;
            }


        }

        //This method is to get the data from csv file 
        //and give the data to the controller class

        public IEnumerable<UserDetail> GetData()
        {
            try
            {
                //path of our csv file 
                var csvpath = _environment.WebRootPath + "\\uploads\\Output.csv";
                List<UserDetail> Values = File.ReadAllLines(csvpath)
                    .Skip(1)
                    .Select(v => FromCsv(v))
                    .ToList();

                return Values;
            }catch(Exception ex)
            {
                throw ex;
            }

            
        }

        

        public dynamic GetUserById(int id)
        {
            try
            {
                //path of our csv file 
                var csvpath = _environment.WebRootPath + "\\uploads\\Output.csv";
                List<UserDetail> Values = File.ReadAllLines(csvpath)
                    .Skip(1)
                    .Select(v => FromCsv(v))
                    .ToList();
                var user = Values.Where(x => x.Id == id).FirstOrDefault();
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       

        // create a Methods that return UserDetail 
        //each value are assign to the UserDetails model and return UserDetails objects
        UserDetail FromCsv(string csvLine)
        {
            try
            {
                string[] values = csvLine.Split(',');
                UserDetail dailyValues = new UserDetail();
                dailyValues.Id = Convert.ToInt32(values[0]);
                dailyValues.Name = Convert.ToString(values[1]);
                dailyValues.Gender = Convert.ToString(values[2]);
                dailyValues.Phone = Convert.ToString(values[3]);
                dailyValues.Email = Convert.ToString(values[4]);
                dailyValues.Address = Convert.ToString(values[5]);
                dailyValues.Nationality = Convert.ToString(values[6]);
                dailyValues.DateOfBirth = Convert.ToDateTime(values[7]);
                dailyValues.EducationBackground = Convert.ToString(values[8]);
                dailyValues.PreferredModeOfContact = Convert.ToString(values[9]);

                return dailyValues;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
