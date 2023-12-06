function CheckTextField() {
    var notificationText = "Field(s) : ";
    var flag = true;
    if (document.getElementById("FirstNameId").value == "") { notificationText = notificationText.concat("First name ,"); flag = false };
    if (document.getElementById("LastNameId").value == "") { notificationText = notificationText.concat("Last name ,"); flag = false };
    if (document.getElementById("NationalIdentificationNumberId").value == "") { notificationText = notificationText.concat("National identification number ,"); flag = false };
    if (document.getElementById("MobileNumberId").value == "") { notificationText = notificationText.concat("Mobile number ,"); flag = false };
    if (document.getElementById("EmailId").value == "") { notificationText = notificationText.concat("email ,"); flag = false };
    notificationText = notificationText.concat("are mandatory")
    if (flag) { PostData() }
    else {
        var FormElement = document.getElementById("container-form"); 
        console.log(FormElement.getBoundingClientRect().height)
        FormElement.style.height = FormElement.getBoundingClientRect().height + 50 + "px";
        document.getElementById("notificationId").innerHTML = notificationText;
    }
}
function PostData() {
    var userDetails = {
        FirstName: document.getElementById("FirstNameId").value,
        OtherName: document.getElementById("OtherNameId").value,
        LastName: document.getElementById("LastNameId").value,
        NationalIdentificationNumber: document.getElementById("NationalIdentificationNumberId").value,
        MobileNumber: document.getElementById("MobileNumberId").value,
        Email: document.getElementById("EmailId").value
    }
    $.ajax({
        type: 'POST',
        url: "RegisterUser",
        data: userDetails,
        success: function (result) {
            if (result.message == "Success") {
                window.location.href = '/Home/EmployeeViewPage';
            }
            else {
                document.getElementById("notificationId").innerHTML = result.message;
            }
        },
        error: function (error) {
            document.getElementById("notificationId").innerHTML = "Some Errors has been encountered";
        }
    });
}