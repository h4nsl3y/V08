$(document).ready(
    function () {
        $.ajax({
            type: 'GET',
            url: "/Training/GetTrainingList",
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
    let parentContainer = document.getElementById('container-list-id');
    let table = document.getElementById('listContainerId');

    let tableBody = $('#listContainerId tbody');
    tableBody.empty();
    trainings.forEach(function (training) {
        let startdate = Date(training.StartDate);
        let row = '<tr>' + "<td id='id'>" + training.TrainingId + '</td>' +
            '<td>' + training.Title + '</td>' +
            '<td>' + startdate + '</td>' +
            '<td>' + training.ShortDescription + '<td>' +
            "<td><button class='item-button' onclick='displayDetail("+training.TrainingId+")'>details</button><td>" +
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
function displayDetail(id) {
    let urlString = "/Training/GetTraining/".concat(id)
    $.ajax({
        type: 'GET',
        url: urlString,
        data: 'json',
        success: function (training) { displayTrainingDetails(training)},
        error: function (error) {
            console.log(error);
        }
    });
}

function hideDetail() {
    let overlay = document.getElementById("screenOverlay");
    overlay.style.visibility = "hidden";
}

function displayTrainingDetails(training) {
    let overlay = document.getElementById("screenOverlay");

    let trainingTitle = document.getElementById("detailTitle");
    let trainingId = document.getElementById("detailId")
    let trainingDepartment = document.getElementById("detailDepartmentPriority");
    let trainingPrerequisite = document.getElementById("detailRequirement");
    let trainingDescription = document.getElementById("detailDescription");
    let trainingDate = document.getElementById("detailDate");

    trainingTitle.textContent = "Title : " + training.Title;
    trainingId.textContent = "Id : " + training.TrainingId;
    trainingDepartment.textContent = "Priority to department : " + training.DepartmentId;
    trainingPrerequisite.textContent = "Prerequisite : " + training.Prerequisite;
    trainingDescription.textContent = "Description : " + training.LongDescription;
    trainingDate.textContent = "Date : " + Date(training.StartDate);

    overlay.style.visibility = "visible";
}
function enroll() {
    let trainingId = document.getElementById("detailId").textContent
    let Id = trainingId.split(" ")[2]
    let urlString = "/Enrollment/RegisterEnrollment/".concat(Id)
    $.ajax({
        type: "POST",
        url: urlString,
        success: function (result) {
            if (result.message == "success") {
                console.log("sucess")
            }
            else {
                console.log("failed")
            }
        },
        error: function (error) {
            console.log("error")
        }
    });

    
}
