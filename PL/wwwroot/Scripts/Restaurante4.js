function ModalOpen() {
    $('#ModalForm').modal('show');
}

function ModalClose() {
    $('#ModalForm').modal('close');
}

function Validate(IdRestaurante) {
    var restaurante1 = {
        IdRestaurante: $('#IdRestaurante').val(),
    }
    if (restaurante1.IdRestaurante == "") {
        Add();
    }
    else {
        Update();
    }
}

function Form() {
    var restaurante = {
        IdRestaurante: $('#IdRestaurante').val(),
        Nombre: $('#Nombre').val(),
        CantidadEmpleados: $('#CantidadEmpleados').val(),
        CapacidadClientes: $('#CapacidadClientes').val(),
        FechaInauguracion: $('#FechaInauguracion').val(),
        Calificacion: $('#Calificacion').val(),
    }
    if (restaurante.IdRestaurante == null || restaurante.IdRestaurante == "" || restaurante.IdRestaurante == 0) {
        $.ajax({
            type: 'POST',
            url: 'http://localhost:5289/api/Restaurante/Add',
            dataType: 'json',
            data: restaurante,
            success: function (result) {
                $('#myModal').modal();
                $('#Modal').modal('show');
                Console(respond);
            },
            error: function (result) {
                alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
            }
        });
    }
    else {
        $.ajax({
            type: 'POST',
            url: 'http://localhost:5289/api/Restaurante/Update',
            datatype: 'json',
            data: restaurante,
            success: function (result) {
                $('#myModal').modal();
                $('#Modal').modal('show');
                Console(respond);
            },
            error: function (result) {
                alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
            }
        });
    };
};

function Update() {

    var restaurante = {
        IdRestaurante: $('#IdRestaurante').val(),
        Nombre: $('#Nombre').val(),
        CantidadEmpleados: $('#CantidadEmpleados').val(),
        CapacidadClientes: $('#CapacidadClientes').val(),
        FechaInauguracion: $('#FechaInauguracion').val(),
        Calificacion: $('#Calificacion').val(),
    }
    $.ajax({
        type: 'POST',
        url: 'http://localhost:5289/api/Restaurante/Update',
        datatype: 'json',
        data: restaurante,
        success: function (result) {
            $('#myModal').modal();
            $('#Modal').modal('show');
            GetAll();
            Console(respond);
        },
    });

};

function Addd() {
    var restaurante = {
        idRestaurante: 0,
        nombre: $('#Nombre').val(),
        cantidadEmpleados: $('#CantidadEmpleados').val(),
        capacidadClientes: $('#CapacidadClientes').val(),
        fechaInauguracion: $('#FechaInauguracion').val(),
        calificacion: $('#Calificacion').val(),
    }
    $.ajax({
        method: 'POST',
        dataType: 'application/json',
        url: 'http://localhost:5289/api/Restaurante/Add',
        data: restaurante,
        success: function (result) {
            $('#myModal').modal('show');
            $('#ModalForm').modal('show');
        },
        error: function (result) {
            alert('Error en la consulta.');
        }
    });
};

function Add() {
    $.ajax({
        method: 'POST',
        dataType: 'application/json',
        url: 'http://localhost:5289/api/Restaurante/Add',
        data: {
            "idRestaurante": 0,
            "nombre": $('#Nombre').val(),
            "cantidadEmpleados": $('#CantidadEmpleados').val(),
            "capacidadClientes": $('#CapacidadClientes').val(),
            "fechaInauguracion": $('#FechaInauguracion').val(),
            "calificacion": $('#Calificacion').val(),
        },
        success: function (result) {
            $('#myModal').modal('show');
            $('#ModalForm').modal('show');
        },
        error: function (result) {
            alert('Error en la consulta.');
        }
    });
};