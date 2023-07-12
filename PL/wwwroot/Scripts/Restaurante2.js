function ModalOpen() {
    $('#ModalForm').modal('show');
}

function ModalClose() {
    $('#ModalForm').modal('close');
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

    var subcategoria = {
        IdEmpleado: $('#txtIdEmpleado').val(),
        Nombre: $('#txtNombre').val(),
        Descripcion: $('#txtDescripcion').val(),
        IdCategoria: {
            IdCategoria: $('#txtIdCategoria').val()
        }

    }

    $.ajax({
        type: 'POST',
        url: 'https://localhost:44314/api/Empleado/Update',
        datatype: 'json',
        data: subcategoria,
        success: function (result) {
            $('#myModal').modal();
            $('#Modal').modal('show');
            GetAll();
            Console(respond);
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });

};

function Add() {

    var subcategoria = {
        IdEmpleado: 0,
        Nombre: $('#txtNombre').val(),
        Descripcion: $('#txtDescripcion').val(),
        Categoria: {
            IdCategoria: $('#ddlCategorias').val()
        }
    }
    $.ajax({
        type: 'POST',
        url: 'https://localhost:44314/api/Empleado/Add',
        dataType: 'json',
        data: subcategoria,
        success: function (result) {
            $('#myModal').modal();
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
};
