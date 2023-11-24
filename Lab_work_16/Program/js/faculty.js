$(document).ready(function() {
    $('#selectFaculty').click(function() {
        $.ajax({
            url: 'https://localhost:7149/api/Faculty/select',
            method: 'GET',
            success: function(response) {
                console.log(response);
                var ulFaculty = $('#ulFaculty')
                ulFaculty.empty()
                response.forEach(function(faculty) {
                    var li = $('<li>').text('Id: ' + faculty.id + ' Dean: ' + faculty.dean + ' Name: ' + faculty.name + ' NumberOfStudents: ' + faculty.numberOfStudents)
                    ulFaculty.append(li)
                })
            },
            error: function(error) {
                console.log(error);
            }
        })
    })
})

$(document).ready(function() {
    $('#insertFaculty').click(function(event) {
        event.preventDefault()

        var dean = $('#insertFacultyDean').val()
        var name = $('#insertFacultyName').val()
        var numberOfStudents = $('#insertFacultyNumberOfStudents').val()

        $.ajax({
            url: 'https://localhost:7149/api/Faculty/insert?dean=' + dean + '&name=' + name + '&numberOfStudents=' + numberOfStudents,
            method: 'POST',
            success: function(response) {
                console.log(response);
            },
            error: function(error) {
                console.log(error);
            }
        })
    })
})

$(document).ready(function() {
    $('#updateFaculty').click(function(event) {
        event.preventDefault()

        var id = $('#updateFacultyId').val()
        var dean = $('#updateFacultyDean').val()
        var name = $('#updateFacultyName').val()
        var numberOfStudents = $('#updateFacultyNumberOfStudents').val()

        $.ajax({
            url: 'https://localhost:7149/api/Faculty/update?id=' + id + '&dean=' + dean + '&name=' + name + '&numberOfStudents=' + numberOfStudents,
            method: 'PUT',
            success: function(response) {
                console.log(response);
            },
            error: function(error) {
                console.log(error);
            }
        })
    })
})

$(document).ready(function() {
    $('#deleteFaculty').click(function(event) {
        event.preventDefault()

        var id = $('#deleteFacultyId').val()

        $.ajax({
            url: 'https://localhost:7149/api/Faculty/delete?id=' + id,
            method: 'DELETE',
            success: function(response) {
                console.log(response);
            },
            error: function(error) {
                console.log(error);
            }
        })
    })
})