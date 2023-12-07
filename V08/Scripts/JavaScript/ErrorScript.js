function RedirectToEmployeeView() {
    $.ajax({
        type: 'POST',
        url: "RedirectHome",
        success: function (result) {
            alert("sucess")
            window.location.href = "/Error/PageNotFound";
        },
        error: function (error) {
            alert("An error has occured")
        }
    });
}