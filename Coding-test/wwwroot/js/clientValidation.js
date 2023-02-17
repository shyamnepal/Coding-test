const form = document.getElementById('form');
const name = document.getElementById('name');
const email = document.getElementById('email');
const address = document.getElementById('address');
const nationality = document.getElementById('nationality');
const educatioinBackground = document.getElementById('educationBackground');
const phone = document.getElementById('phone');
const contact = document.getElementById('contact');
const dateofBirth = document.getElementById('dateofBirth');
var gender = document.getElementsByName('gender');
const female = document.getElementById('Female')
var isValid1 = false;
var isValid2 = false;
var isValid3 = false;
var isValid4 = false;
var isValid5 = false;
var isValid6 = false;
var isValid7 = false;
var isValid8 = false;
var isValid9 = false;


// Today date 
var today = new Date().toISOString().split('T')[0];

// When the page load then execute the function
// And set the max date is today so that we can not select the future date
window.onload = (event) => {
    console.log("page loaded");
    document.getElementsByName("dateofBirth")[0].setAttribute('max', today);

};

// When our form submit this addEventLister is called 
// and check our validation 

form.addEventListener('submit', e => {
    e.preventDefault();

    validateInputs();
    if (isValid1 && isValid2 && isValid3 && isValid4 && isValid5 && isValid6 && isValid7 && isValid8 && isValid9 ) {
        form.submit();
        
    }
  
});

// Set Error function helps us to set the
// error and show in the web page in client side 

const setError = (element, message) => {
    const inputControl = element.parentElement;
    const errorDisplay = inputControl.querySelector('.error');

    errorDisplay.innerText = message;
    inputControl.classList.add('error');
    inputControl.classList.remove('success')
}
// Setsuccess give the show the success.
// It remove the error
const setSuccess = element => {
    const inputControl = element.parentElement;
    const errorDisplay = inputControl.querySelector('.error');

    errorDisplay.innerText = '';
    inputControl.classList.add('success');
    inputControl.classList.remove('error');
};


// Email validation 
const isValidEmail = email => {
    const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
}
// Phone number 10 digit number
const ph = /^\d{10}$/;
// Alphabet not show in phone number 
// It is also for phone number validation 
const letter = /^[A-Za-z]+$/;
    


const validateInputs = () => {
    const nameValue = name.value.trim();
    const emailValue = email.value.trim();
    const addressValue = address.value.trim();
    const nationalityValue = nationality.value.trim();
    const educatioinBackgroundValue = educatioinBackground.value.trim();
    const phoneValue = phone.value.trim();
    const contactValue = contact.value.trim();
    const dateofBirthValue = dateofBirth.value.trim();

  

    // Checking every input fields is valid of not.
    // All the condition is apply bellow. 
   
    if (nameValue === '') {
        isValid1 = false;
        setError(name, 'Name is required');
    } else {
        isValid1 = true;
        setSuccess(name);
    }

    if (emailValue === '') {
        isValid2 = false;
        setError(email, 'Email is required');
    } else if (!isValidEmail(emailValue)) {
        isValid2 = false;
        setError(email, 'Provide a valid email address');
    } else {
        isValid2 = true;
        setSuccess(email);
    }

    if (addressValue === '') {
        isValid3 = false;
        setError(address, 'Address is required');
    } else {
        isValid3 = true;
        setSuccess(address);
    }

    if (nationalityValue === '') {
        isValid4 = false;
        setError(nationality, 'Nationality is required');
    } else {
        isValid4 = true;
        setSuccess(nationality);
    }

    if (educatioinBackgroundValue === '') {
        isValid5 = false;
        setError(educatioinBackground, 'Education Background is required');
    } else {
        isValid5 = true;
        setSuccess(educatioinBackground);
    }


    if (phoneValue === '') {
        isValid6 = false;
        setError(phone, 'Phone number is required');
    } else if ((phoneValue.match(letter))) {
        isValid6 = false;
        setError(phone, 'please Enter number only');

    } else if (!(phoneValue.match(ph))) {
        isValid6 = false;
        setError(phone, 'please Enter 10 digit number');
    } else {
        isValid6 = true;
        setSuccess(phone);
    }

    if (dateofBirthValue === '') {
        isValid7 = false;
        setError(dateofBirth, 'Date of Birth is required');
    } else {
        isValid7 = true;
        setSuccess(dateofBirth);
    }


    if (contactValue === '') {
        isValid8 = false;
        setError(contact, 'please select Prefered Mode of Contact');
    } else {
        isValid8 = true;
        setSuccess(contact);
    }


    if (!(gender[0].checked || gender[1].checked)) {
        isValid9 = false;
        setError(female, 'please select Male or Female');
    } else {
        isValid9 = true;
        setSuccess(female);
    }

  

};
