function RedirectToEmployeeView() {
    $.ajax({
        type: 'POST',
        url: "RedirectHome",
        success: function (result) {
            window.location.href = result.redirectToUrl;
        },
        error: function (error) {
            alert("An error has occured")
        }
    });
}