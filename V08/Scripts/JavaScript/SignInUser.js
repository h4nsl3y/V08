function CheckTextField() {
    var notificationText = "Field(s) ";
    var flag = true;
    if (document.getElementById("EmployeeId").value == "") { notificationText = notificationText.concat("Employee ,"); flag = false };
    if (document.getElementById("PasswordId").value == "") { notificationText = notificationText.concat("Password ,"); flag = false };
    notificationText = notificationText.concat("are mandatory")
    if (flag) { PostData() }
    else { document.getElementById("notificationId").innerHTML = notificationText; }
}
function PostData() {
    var data = {
        EmployeeId: document.getElementById("EmployeeId").value,
        Password: document.getElementById("PasswordId").value
    }
    $.ajax({
        type: 'POST',
        url: "AuthenticateUser",
        data: data,
        success: function (result) {
            console.log(result);
            if (result.message == "Success") {
                window.location.href = 'EmployeeViewPage';
            }
            else {
                document.getElementById("notificationId").innerHTML = "Signing in Failed"
            }
        },
        error: function (error) {
            console.log(error);
        }
    });
}
function RegisterUser() { window.location.href = '/Register'; }