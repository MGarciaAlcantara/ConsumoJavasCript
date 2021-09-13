$(document).ready(function () {
    GetAll();

});

function GetAll() {
    $.ajax({
        type: 'GET',
        // url: 'http://localhost:14225/api/empleado',
        url: '/Empleado/GetAllJS',
        success: function (result) { //200 OK
            $('#Empleado tbody').empty();
            $.each(result.Objects, function (i, empleado) {
                var filas =
                    '<tr>'
                        + '<td class="text-center"> '
                            + '<a class="btn btn-primary glyphicon glyphicon-wrench" href="#" onclick="GetById(' + empleado.Id + ')">'
                        + '</a> '
                        + '</td>'
                        + "<td  id='id' class='text-center'>" + empleado.Id + "</td>"
                          + "<td class='text-center'>" + empleado.NumeroNomina + "</td>"
                        + "<td class='text-center'>" + empleado.Nombre + "</td>"
                        + "<td class='text-center'>" + empleado.ApellidoPaterno + "</ td>"
                        + "<td class='text-center'>" + empleado.ApellidoMaterno + "</td>"
                         + "<td class='text-center'>" + empleado.EntidadFederativa.Id + "</td>"
                        //+ '<td class="text-center">  <a href="#" onclick="return Eliminar(' + subCategoria.IdSubCategoria + ')">' + '<img  style="height: 25px; width: 25px;" src="../img/delete.png" />' + '</a>    </td>'
                        + '<td class="text-center"> <button class="btn btn-danger" onclick="Delete(' + empleado.Id + ')"><span class="glyphicon glyphicon-trash" style="color:#FFFFFF"></span></button></td>'

                    + "</tr>";
                $("#Empleado tbody").append(filas);
            });
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
};

function Form() {

    var IdEmpleado = $('#txtIdEmpleado').val()

    if (IdEmpleado == 0) {
        $('#ModalUpdate').modal('show');
        Add();

    }
    else {
        Update();
    }
}


function EntidadFederativaGetAll() {
    $("#ddlEstados").empty();
    $.ajax({
        type: 'GET',
        url: 'http://localhost:14225/api/entidadfederativa',
        success: function (result) {
            $("#ddlEstados").append('<option value="' + 0 + '">' + 'Seleccione una opción' + '</option>');
            $.each(result.Objects, function (i, entidadFederativa) {
                $("#ddlEstados").append('<option value="'
                                           + entidadFederativa.Id + '">'
                                           + entidadFederativa.Estado + '</option>');
            });
        }
    });
}

function ModalAdd() {
    $('#txtIdEmpleado').val("");
    $('#txtNumeroNomina').val("");
    $('#txtNombre').val("");
    $('#txtApellidoPaterno').val("");
    $('#txtApellidoMaterno').val("");
    $('#ddlEstados').val(0);

    $('#ModalUpdate').modal('show');
}

function Add() {

    //var empleado = {
    //    Id: 0,
    //    NumeroNomina: $('#txtNumeroNomina').val(),
    //    Nombre: $('#txtNombre').val(),
    //    ApellidoPaterno: $('#txtApellidoPaterno').val(),
    //    ApellidoMaterno: $('#txtApellidoMaterno').val(),
    //    EntidadFederativa: {
    //        Id: $('#ddlEstados').val()     
    //    }
    //}
    var empleado = new Object();

    empleado.Id = 0;
    empleado.NumeroNomina = $('#txtNumeroNomina').val();
    empleado.Nombre = $('#txtNombre').val();
    empleado.ApellidoPaterno = $('#txtApellidoPaterno').val();
    empleado.ApellidoMaterno = $('#txtApellidoMaterno').val();
    empleado.EntidadFederativa = new Object();
    empleado.EntidadFederativa.Id = $('#ddlEstados').val()

    $.ajax({
        type: 'POST',
        // url: 'http://localhost:14225/api/empleado',
        url: '/Empleado/AddJS/',
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ empleado: empleado }),
        success: function (result) {
            $('#myModal').modal();
            $('#ModalUpdate').modal('hide');
            GetAll();
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
};


function GetById(IdEmpleado) {
    $.ajax({
        type: 'GET',
        // url: 'http://localhost:14225/api/empleado/' + IdEmpleado,
        url: '/Empleado/GetByIdJS?IdEMpleado=' + IdEmpleado,
        // data: {IdEmpleado:IdEmpleado},

        success: function (result) {
            $('#txtIdEmpleado').val(IdEmpleado);
            $('#txtNumeroNomina').val(result.Object.NumeroNomina);
            $('#txtNombre').val(result.Object.Nombre);
            $('#txtApellidoPaterno').val(result.Object.ApellidoPaterno);
            $('#txtApellidoMaterno').val(result.Object.ApellidoMaterno);
            $('#ddlEstados').val(result.Object.EntidadFederativa.Id);

            $('#ModalUpdate').modal('show');
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }


    });

}


function Update() {

    //var empleado = {
    //    Id: $('#txtIdEmpleado').val(),
    //    NumeroNomina: $('#txtNumeroNomina').val(),
    //    Nombre: $('#txtNombre').val(),
    //    ApellidoPaterno: $('#txtApellidoPaterno').val(),
    //    ApellidoMaterno: $('#txtApellidoMaterno').val(),
    //    EntidadFederativa: {
    //        Id: $('#ddlEstados').val()
    //    }
    //}

    var empleado = new Object();

    empleado.Id=$('#txtIdEmpleado').val();
    empleado.NumeroNomina = $('#txtNumeroNomina').val();
    empleado.Nombre = $('#txtNombre').val();
    empleado.ApellidoPaterno = $('#txtApellidoPaterno').val();
    empleado.ApellidoMaterno = $('#txtApellidoMaterno').val();
    empleado.EntidadFederativa = new Object();
    empleado.EntidadFederativa.Id = $('#ddlEstados').val()

    var x = $('#txtIdEmpleado').val();
    $.ajax({
        type: 'POST',
       // url: 'http://localhost:14225/api/empleado/' + x,
        url: '/Empleado/UpdateJS',
        datatype: 'json',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ empleado: empleado }),
        success: function (result) {
            $('#myModal').modal();
            $('#ModalUpdate').modal('hide');
            GetAll();
            Console(respond);
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });

};

function Delete(IdEmpleado) {

    if (confirm("¿Estas seguro de eliminar el empleado seleccionado?")) {
        $.ajax({
            type: 'GET',
            // url: 'http://localhost:14225/api/empleado' + IdEmpleado,
            url: '/Empleado/DeleteJS?IdEmpleado=' + IdEmpleado,
            //data: { IdEmpleado: IdEmpleado },
            success: function (result) {
                $('#myModal').modal();
                GetAll();
            },
            error: function (result) {
                alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
            }
        });

    };
};
