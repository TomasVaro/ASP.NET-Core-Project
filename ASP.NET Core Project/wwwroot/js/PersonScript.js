function getAllPersons() {
        $.get("/Ajax/GetPersons", null, function (data) {
            $("#PersonList").html(data);
        })
        document.getElementById('errorMessages').innerHTML = "";
    }

function getPersonByID() {
    var personIDValue = document.getElementById('PersonIdInput').value;
    if (personIDValue == "")
    {
        document.getElementById('errorMessages').innerHTML = "You must enter an ID";
    }
    else
    {
        $.post("/Ajax/FindPersonById", { personID: personIDValue }, function (data) {
            $("#PersonList").html(data);
        })
        document.getElementById('errorMessages').innerHTML = "";
    }
}

function deletePersonByID() {
    var personIDValue = document.getElementById('PersonIdInput').value;
    if (personIDValue == "")
    {
        document.getElementById('errorMessages').innerHTML = "You must enter an ID";
    }
    else
    {
        $.post("/Ajax/DeletePersonById", { personID: personIDValue }, function (data) {
        })
            .done(function () {
                getAllPersons();
                document.getElementById('errorMessages').innerHTML = "Successfully deleted person.";
            })
            .fail(function () {
                document.getElementById('errorMessages').innerHTML = "Could not delete person.";
            });
    }
}