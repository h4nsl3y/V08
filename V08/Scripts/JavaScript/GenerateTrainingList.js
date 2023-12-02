function display(trainings) {
var parentContainer = document.getElementById('listContainerId');
    for (var key in trainings) {
        //console.log(trainings[key])
        var training = trainings[key];
        console.log(training)
        if (key > 0) {
            var originalDiv = document.getElementById('trainingContainerId');
            var clonedDiv = originalDiv.cloneNode(true);
            clonedDiv.id = 'trainingContainerId-'.concat(key);
            //clonedDiv.textContent = 'Cloned Div Content';
            parentContainer.appendChild(clonedDiv);
            //  var parentContainer = document.getElementById('trainingContainerId-'.concat(key));
            var trainingTitleLabel = parentContainer.querySelector('#trainingTitleId');
            var trainingDepartmentLabel = parentContainer.querySelector('#trainingDepartmentId');
            var smallDescriptionId = parentContainer.querySelector('#smallDescriptionId');
            trainingTitleLabel.textContent = training.Title;
            trainingDepartmentLabel.textContent = training.Department;
            smallDescriptionId.textContent = training.ShortDescription;
            console.log(training.ShortDescription)
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