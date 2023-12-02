function display(trainings) {
    var parentContainer = document.getElementById('container-list-id');
    for (var key in trainings) {
        var training = trainings[key];
        console.log(training)
        if (key > 0) {
            var originalDiv = document.getElementById('trainingContainerId');
            var clonedDiv = originalDiv.cloneNode(true);
            clonedDiv.id = 'trainingContainerId-'.concat(key);
            parentContainer.appendChild(clonedDiv);
            var trainingTitleLabel = parentContainer.querySelector('#trainingTitleId');
            var trainingDepartmentLabel = parentContainer.querySelector('#trainingDepartmentId');
            var smallDescriptionId = parentContainer.querySelector('#smallDescriptionId');
            trainingTitleLabel.textContent = training.Title;
            trainingDepartmentLabel.textContent = training.Department;
            smallDescriptionId.textContent = training.ShortDescription;
        }
        else {
            var trainingTitleLabel = document.getElementById('trainingTitleId');
            var trainingDepartmentLabel = document.getElementById('trainingDepartmentId');
            var smallDescriptionId = document.getElementById('smallDescriptionId');
            trainingTitleLabel.textContent = training.Title;
            trainingDepartmentLabel.textContent = training.Department;
            smallDescriptionId.textContent = training.ShortDescription;
        }
    }
}
function logOutUser() {
        $.ajax({
            type: 'GET',
            url: "LogUserOut",
            success: function (result) {
                console.log(result);
                if (result.message == "Success") {
                    window.location.href = 'LogInPage';
                }
                else {
                    Alert("Failed to log out");
                }
            },
            error: function (error) {
                console.lof("Some Errors has been encountered");
            }
        });
    }