$(document).ready(
    function () {
        $.ajax({
            type: 'GET',
            url: "GetTrainingList",
            data: 'json',
            success: function (trainings) {
                display(trainings)
            },
            error: function (error) {
                console.log(error);
            }
        });
    }
)

function display(trainings) {
    var parentContainer = document.getElementById('container-list-id');
    var table = document.getElementById('listContainerId');

    var tableBody = $('#listContainerId tbody');
    tableBody.empty();
    trainings.forEach(function (training) {
        var startdate = Date(training.StartDate);
        var row = '<tr>' + "<td id='id'>" + training.TrainingId + '</td>' +
            '<td>' + training.Title + '</td>' +
            '<td>' + startdate + '</td>' +
            '<td>' + training.ShortDescription + '<td>' +
            "<td><button class='item-button' onclick='getDetail("+training.TrainingId+")'>details</button><td>" +
               '</tr>';
        tableBody.append(row);
    })
}
function logOutUser() {
    $.ajax({
        type: 'POST',
        url: "/Account/LogUserOut",
        success: function (result) {
            if (result.message == "Success") {
                window.location.href = '/Account/LogInPage';
            }
            else {
                Alert("Failed to log out");
            }
        },
        error: function (error) {
            Alert("Some Errors has been encountered");
        }
    });
}
function getDetail(id) {
    console.log(id)
}