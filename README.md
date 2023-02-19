
# Coding Task

It is the simple project that is develop in asp.net core mvc. In this projec user can give the input from the client side using form and after submit the form It will save the data on the output.csv file in the wwwroot/uploads/ directory. At the same time you will redirect to the next UserView page. In this page all the user details are show in the table. There is Details button where user can get the individual information.

The form is fully validate for client side as well as server side so that there is no error if the form is invalid input or empty.

I have also host this samll application on web server which link is give below:\
[Click me ](http://codingtask.somee.com/)

## Documentation

# solution 
In this section I am explain aobut the solution that is apply in my projects.\
First user opens the application then it shows the form on the client side and then the user fills the form. If the form is valid then go to the backend part where there is a Create method that takes UserDetails types. This method also checks if the model is valid or not. If it is valid then pass the data to IUserDetailsService. This interface is implements by UserDetailsService class and there is a method called AddData which takes the parameters of UserDetails types of data. Under this function first, the program checks if there is uploads directory in the wwwroot folders. if not exist then create uploads directory. if uploads directory exists again check if there is output.csv file inside the uploads directory. If not exist create an output.csv file with a heading and append the UserDetails types data in the CSV file. If output.csv exist then only append the UserDetails types data in the CSV file. 

\
After create User It automatically go to the another page where all user are show in the table. At the time of submit of the form It goes to the backend part. There is a UserView method which does not take any parameters it call GetData method in UserDetailsService class. GetData method read all the file from output.csv file except line one because line one is heading. At the same time FromCsv method call which convert UserDetail types data and return the controller class. and this data was sent to the froent part. 


\
In the table there is Details link button. if the button is clicked it redirect to the Details page where individual data is available in the form. In a backend there is Details method which take id as a parameter and call GetUserById method in the UserDetailsService class where implements IUserDetailsService. GetUserById method read all the data form output.csv file and search the user by id. After find the id of the user it return the data to the controller class and send the data to the view in Details page. 


\
I have done some xunit tests on the project. All the tests are available in the TestProject folders under UnitTestUserDetailsController class. All the test cases are valid and successful.

\
I have also used Dockerfile in the project which is run well. I create a docker image and run it in the container. I also push my image in the docker hub. the link is given below. 
- [@docker image](hub.docker.com/repository/docker/shyam595/codingtest/general)



## Authors

- [@Shyam Sundar Nepal](https://github.com/shyamnepal/Coding-test)





## 🚀 About Me
I'm a backend developer enthusiastic to learn new technology and work with group of people and share idea and knowledge. I am Interested in C# programming language. 




## Tech Stack

**Client:** cshtml, CSS, JavaScript 

**Server:** ASP.NET core MVC



## Run Locally

Clone the project

```bash
  git clone https://github.com/shyamnepal/Coding-test
```

Go to the project directory

```bash
  cd Coding-test/Coding-test/
```



Start the server

```bash
  dotnet run 
```


## Running Tests

To run tests, run the following command after clone the project

```bash
  cd Coding-test
```
```bash
  dotnet test
```

# Screenshots
![form](https://user-images.githubusercontent.com/61022806/219957603-8c712767-2e64-48a7-a955-56cd9ddb7ac7.PNG)

![UserData](https://user-images.githubusercontent.com/61022806/219957623-e9678538-1256-40f2-b9d7-0881377cfdf9.PNG)

![individual_user](https://user-images.githubusercontent.com/61022806/219957642-2c73875f-705b-4c4c-a306-803d6f089dfa.PNG)

## Url

#### Get all User

```http
  GET /UserDetails/UserView
```



#### Get individual user

```http
  GET /UserDetails/UserView/Details?Id=1
```

#### Get individual user

```http
  post /UserDetails/ or /
```

