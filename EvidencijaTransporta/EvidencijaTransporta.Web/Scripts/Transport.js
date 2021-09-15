const DetailsBtnClick = (id) => {
    var urlTr = `/Transport/Details/${id}`;
    $.ajax({
        url: urlTr,
        contentType: 'application/html; charset=utf-8',
        type: 'GET',
        dataType: 'html',
    }).done(function (result) {
        document.getElementById(`dvDetails`).style.display = 'block';
        $(`#dvDetails`).html(result);
        })
        .fail(function (xhr, status) {
            alert(status);
        }) 
}

const Create = () => {
    var model = new Object();
    model.Date = new Date($('#txtDate').val()).toUTCString();
    model.SelectedTransportType = $('#selectType').val();
    model.ShipmentAmount = $('#txtAmount').val();
    model.VehicleType = $('#txtVehicle').val();

    var url = `/Transport/CreateReservateTransport/`;
    $.ajax({
        url: url,
        data: JSON.stringify(model),
        contentType: 'application/json; charset=utf-8',
        type: 'POST',
    }).done(function (result) {
        $('#dvTable').html(result);
    }).fail(function (xhr, status) {
        alert(status);
    })
}

const Delete = (id) => {
    var url = `/Transport/Delete/${id}`;
    $.ajax({
        url: url,
        contentType: 'application/html; charset=utf-8',
        type: 'GET',
        dataType: 'html'
    }).done(function (result) {
        $('#dvTable').html(result);
    }).fail(function (xhr, status) {
        alert(status);
    })
}

const Edit = (id) => {
    var model = new Object();
    model.Id = id;
    model.Date = new Date($('#txtDate').val()).toLocaleDateString("en-US");
    model.SelectedTransportType = $('#selectType').val();
    model.ShipmentAmount = $('#txtAmount').val();
    model.VehicleType = $('#txtVehicle').val();

    var urlTr = `/Transport/EditTransport/`;
    $.ajax({
        url: urlTr,
        contentType: 'application/json; charset=utf-8',
        type: 'POST',
        data: JSON.stringify(model),
    }).done(function (result) {
        $('#dvTable').html(result);
        DiscardChanges();
    })
        .fail(function (xhr, status) {
        alert(status);
    })
}

const FillEditFileds = (id) => {
        var urlTr = `/Transport/FillEditTransport/${id}`;

        $.ajax({
            url: urlTr,
            contentType: 'application/html; charset=utf-8',
            type: 'GET',
            dataType: 'html',
        }).done(function (result) {
            $('#dvEdit').html(result);
            document.getElementById("createTransport").style.display = 'none';
            document.getElementById("editTransport").style.display = 'block';
            document.getElementById("discardTransport").style.display = 'block';
        }).fail(function (xhr, status) {
                alert(status);
        })
}

const DiscardChanges = () => {
    document.getElementById("createTransport").style.display = 'block';
    document.getElementById("editTransport").style.display = 'none';
    document.getElementById("discardTransport").style.display = 'none';

    new Date($('#txtDate').val(new Date().toLocaleDateString("en-US")));
    $('#selectType').val(1);
    $('#txtAmount').val("");
    $('#txtVehicle').val("");
}