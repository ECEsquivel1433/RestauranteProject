function ModalOpen() {
    $('#ModalForm').modal('show');
}

function ModalClose() {
    $('#ModalForm').modal('close');
}



function Form() {
    var restaurante = {
        IdRestaurante: $('#txtIdRestaurante').val(),
        Nombre: $('#txtNombre').val(),
        CantidadEmpleados: $('#txtCantidadEmpleados').val(),
        CapacidadClientes: $('#txtCapacidadClientes').val(),
        FechaInauguracion: $('#txtFechaInauguracion').val(),
        Calificacion: $('#txtCalificacion').val(),
    }
    if (restaurante.IdRestaurante == null || restaurante.IdRestaurante == 0) {
        $.ajax({
            type: 'POST',
            url: 'http://localhost:5289/api/Restaurante/Add',
            dataType: 'json',
            data: restaurante,
            success: function (result) {
                $('#myModal').modal();
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
