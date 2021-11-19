function getAllPersons() {
    $.get("/Ajax/GetPersons", null, function (data) {
        $("#PersonList").html(data);
    });
}

function getPersonByID() {
    var personIDValue = document.getElementById('PersonIdInput').value;
    $.post("/Ajax/FindPersonById", { personID: personIDValue }, function (data) {
        $("#PersonList").html(data);
    });
}