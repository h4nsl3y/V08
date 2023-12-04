

function display(data) {
    var account = data['Item1']
    var trainings = data['Item2']
    console.log(account)
    var parentContainer = document.getElementById('container-list-id');

    document.getElementById('account-img-id').textContent = account.FirstName.charAt(0) + account.LastName.charAt(0)
    var accountFullName = document.getElementById('account-fullname-id')
    if (account.OtherName != null) { accountFullName.textContent = account.FirstName + " " + account.OtherName + " " + account.LastName }
    else { accountFullName.textContent = account.FirstName + " " + account.LastName }

    
    for (var key in trainings) {
        var training = trainings[key];
        
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
        type: 'POST',
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
            Alert("Some Errors has been encountered");
        }
    });
}