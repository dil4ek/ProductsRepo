var uriC = 'api/categories';

$(document).ready(function () {
    $.getJSON(uriC)
        .done(function (data) {
            $.each(data, function (key, item) {
                $('<li>', { text: formatCategory(item) }).appendTo($('#category'));
            });
        });
});

$("#FindCategory").click(function () {
    var id = $('#categoriesdId').val();
    $.getJSON(uriC + '/' + id)
        .done(function (data) {
            $('#category').text(formatCategory(data));
            $('#CategoryName').attr('value', data.CategoryName);
            $('#Description').attr('value', data.Description);
        })
        .fail(function (jqXHR, textStatus, err) {
            $('#category').text('Error: ' + err);
        });
})

$("AddCategory").click(function () {
    var value = getCategory();
    $.ajax({
        url: uriC,
        type: 'POST',
        data: JSON.stringify(value),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            WriteResponse(data);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });

    refreshInuts();
})

$("#UpdateCategory").click(function () {
    var id = $('#categoriesdId').val();
    var value = getCategory();

    $.ajax({
        url: uriC + '/' + id,
        type: 'PUT',
        data: JSON.stringify(value),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            WriteResponse(data);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });

    refreshInuts();
})

$("#DeleteCategory").click(function () {
    var id = $('#categoriesdId').val();
    $.ajax({
        url: uriC + '/' + id,
        type: 'DELETE',
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            WriteResponse(data);
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });

    refreshInuts();
})


function formatCategory(category) {
    return category.CategoryName + " : " + category.Description;
}


function getCategory() {
    var name = $('#CategoryName').val();
    var description = $('#Description').val();

    return {
        "CategoryName": name,
        "Description": description,
    }
}

function refreshInuts() {
    $('#categoriesdId').val(' ');
    $('#CategoryName').val(' ');
    $('#Description').val(' ');
}