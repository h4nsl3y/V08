function CheckTextField() {
    var notificationText = "Field(s) (";
    var flag = true;
    if (document.getElementById("employeeEmailId").value == "") { notificationText = notificationText.concat("Email ,"); flag = false };
    if (document.getElementById("employeePasswordId").value == "") { notificationText = notificationText.concat("Password "); flag = false };
    notificationText = notificationText.concat(") are mandatory")
    if (flag) { PostData() }
    else { document.getElementById("notificationId").innerHTML = notificationText; }
}
function PostData() {
    var data = {
        Email: document.getElementById("employeeEmailId").value,
        Password: document.getElementById("employeePasswordId").value
    }
    $.ajax({
        type: 'POST',
        url: "/Account/AuthenticateUser",
        data: data,
        success: function (result) {
            if (result.message == "Success") {
                alert("sucess")
                window.location.href = '/Home/EmployeeViewPage';
            }
            else {
                document.getElementById("notificationId").innerHTML = "Signing in Failed";
            }
        },
        error: function (error) {
            document.getElementById("notificationId").innerHTML = "Some Errors has been encountered";
        }
    });
}
function RegisterUser() { window.location.href = 'RegisterPage'; }