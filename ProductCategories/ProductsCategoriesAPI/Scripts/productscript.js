var uri = 'api/products';

//$(document).ready(function () {
    $.getJSON(uri)
        .done(function (data) {
            $.each(data, function (key, item) {
                //  $('<li>', { text: formatItem(item)}).wrap('#image').attr('src', itemitem.URLImige).appendTo($('#products'));
                $('<li>', { text: formatItem(item) }).appendTo($('#products'));
            });
        });
//});

$("#FindByCategory").click(function() {
    var id = $('#categorydId').val();
    var name = $('#categoryName').val();
    $('#products').empty();
    $.getJSON(uri + '?' + 'idCategory=' + id + '&' + 'nameCategory=' + name)
        .done(function (data) {
            $.each(data, function (key, item) {
                $("<li><img></li>")
                .find("img")
                .attr('src', item.URLImige)
                .end()
                .text(formatItem(item))
                .appendTo("#products");
            });
        })
        .fail(function (jqXHR, textStatus, err) {
            $('#products').text('Error: ' + err);
        });
})

$("#FindByID").click(function () {
    var id = $('#productId').val();
    $.getJSON(uri + '/' + id)
        .done(function (data) {
            $('#ProductName').attr('value', data.ProductName);
            $('#CategoryID').attr('value', data.IdCategory);
            $('#ProductDescription').attr('value', data.ProductDescription);
        })
        .fail(function (jqXHR, textStatus, err) {
            $('#products').text('Error: ' + err);
        });
})


$("#UpdateProduct").click(function() {
    var id = $('#productId').val();
    var value = getProduct();

    $.ajax({
        url: uri + '/' + id,
        type: 'PUT',
        data: JSON.stringify(value),
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            WriteResponse(data);
            refreshInuts();
        },
        error: function (x, y, z) {
            alert(x + '\n' + y + '\n' + z);
        }
    });

    refreshInuts();
})

$("#AddProduct").click(function () {
    var value = getProduct();
    $.ajax({
        url: uri,
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

$("#DeleteProduct").click(function () {
    var id = $('#productId').val();
    $.ajax({
        url: uri + '/' + id,
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

function formatItem(item) {
    return item.ProductName + ' : ' + item.ProductDescription
}

function getProduct() {
    var name = $('#ProductName').val();
    var categoriID = $('#CategoryID').val();
    var description = $('#ProductDescription').val();
    var url = $('#url').val();

    return {
        "IdCategory": categoriID,
        "ProductName": name,
        "ProductDescription": description,
        "URLImige": url
    }

}

function refreshInuts() {
    $('#productId').val(" ");
   $('#ProductName').val(" ");
    $('#CategoryID').val(" ");
   $('#ProductDescription').val(" ");
   $('#url').val(" ");
}