$(document).ready(function() {
    $('#selectDepartment').click(function() {
        $.ajax({
            url: 'https://localhost:7149/api/Department/select',
            method: 'GET',
            success: function(response) {
                console.log(response);
                var ulDepartment = $('#ulDepartment')
                ulDepartment.empty()
                response.forEach(function(department) {
                    var li = $('<li>').text('Id: ' + department.id + ' Manager: ' + department.manager + ' Name: ' + department.name + ' NumberOfTeachers: ' + department.numberOfTeachers + ' FacultyId: ' + department.facultyId + ' Image: ')
                    var img = new Image()
                    img.src = 'data:image/png;base64,' + department.image
                    img.style.width = '300px'
                    img.style.height = 'auto'
                    li.append(img)
                    ulDepartment.append(li)
                })
            },
            error: function(error) {
                console.log(error);
            }
        })
    })
})

$(document).ready(function() {
    $('#insertDepartment').click(function(event) {
        event.preventDefault()

        var image = $('#insertDepartmentImage')[0].files[0]
        var manager = $('#insertDepartmentManager').val()
        var name = $('#insertDepartmentName').val()
        var numberOfTeachers = $('#insertDepartmentNumberOfTeachers').val()
        var facultyId = $('#insertDepartmentFacultyId').val()
        var formData = new FormData()
        formData.append('image', image)

        $.ajax({
            url: 'https://localhost:7149/api/Department/insert?manager=' + manager + '&name=' + name + '&numberOfTeachers=' + numberOfTeachers + '&facultyId=' + facultyId,
            method: 'POST',
            data: formData,
            contentType: false,
            processData: false,
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
    $('#updateDepartment').click(function(event) {
        event.preventDefault()

        var id = $('#updateDepartmentId').val()
        var image = $('#updateDepartmentImage')[0].files[0]
        var manager = $('#updateDepartmentManager').val()
        var name = $('#updateDepartmentName').val()
        var numberOfTeachers = $('#updateDepartmentNumberOfTeachers').val()
        var facultyId = $('#updateDepartmentFacultyId').val()
        var formData = new FormData()
        formData.append('image', image)

        $.ajax({
            url: 'https://localhost:7149/api/Department/update?id=' + id + '&manager=' + manager + '&name=' + name + '&numberOfTeachers=' + numberOfTeachers + '&facultyId=' + facultyId,
            method: 'PUT',
            data: formData,
            contentType: false,
            processData: false,
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
    $('#deleteDepartment').click(function(event) {
        event.preventDefault()

        var id = $('#deleteDepartmentId').val()

        $.ajax({
            url: 'https://localhost:7149/api/Department/delete?id=' + id,
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