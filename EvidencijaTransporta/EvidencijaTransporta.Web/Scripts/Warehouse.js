const WarehouseInformation = (id) => {
    var urlTr = `/Warehouse/OpenStoreItems/${id}`;
    $.ajax({
        url: urlTr,
        contentType: 'application/html; charset=utf-8',
        type: 'GET',
        dataType: 'html',
    }).done(function (result) {
        document.getElementById('warehouseInfo').style.display = 'block';
        $('#warehouseInfo').html(result);
    }).fail(function (xhr, status) {
        alert(status);
    }) 
}

const OpenStorageForm = (id) => {
    var url = `/Warehouse/RenderStorage/${id}`;
    $.ajax({
        url: url,
        contentType: 'application/html; charset=utf-8',
        type: 'GET',
        dataType: 'html',
    }).done(function (result) {
        document.getElementById('dvStorage').style.display = 'block';
        $('#dvStorage').html(result);
    }).fail(function (xhr, status) {
        alert(status);
    }) 
}

const VerifyStorageInformation = (id) => {
    var model = new Object();
    model.Amount = $('#txtAmount').val();
    model.Type = $('#txtType').val();
    model.DateStored = new Date($('#txtDateFrom').val()).toLocaleDateString("en-US");
    model.DateCleared = new Date($('#txtDateTo').val()).toLocaleDateString("en-US");
    model.WarehouseId = id;

    if (!Date.parse(model.DateStored) || !Date.parse(model.DateCleared)) return alert('You must enter the date');
    if (Date.parse(model.DateStored) > Date.parse(model.DateCleared)) return alert('Date of storage cannot be after date cleared!');

    StoreInformation(model);
}

const StoreInformation = (model) => {
    var url = `/Warehouse/StoreInformation/`;
    $.ajax({
        url: url,
        data: JSON.stringify(model),
        contentType: 'application/json; charset=utf-8',
        type: 'POST',
    }).done(function (result) {
        $('#dvTable').html(result);
    }).fail(function (xhr, status) {
        alert('Storage is full');
    })
}

const HideDetails = () => {
    document.getElementById('warehouseInfo').style.display = 'none';
}