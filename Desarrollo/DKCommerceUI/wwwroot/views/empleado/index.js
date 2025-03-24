"use strict";

function fnEliminar(empleadoId) {
    $.ajax({
        type: "DELETE",
        contentType: "application/json; charset=utf-8",
        async: true,
        cache: false,
        url: `https://localhost:7220/empleado/delete/${empleadoId}`,
        success: function () {
            alert(`Se eliminó el empleado con ID: ${empleadoId} con éxito.`);
        },
        error: function (xhr) {
            console.error("Error:", xhr.responseText);
            alert(`No se pudo eliminar el empleado con ID: ${empleadoId}.`);
        }
    });
}

function fnGet(empleadoId, nombres) {
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        cache: false,
        url: `https://localhost:7220/empleado/select?empleadoId=${empleadoId}&nombres=${nombres}`,
        success: function (data) {
            console.info("Datos obtenidos:", data);
            let resultado = `<strong>ID:</strong> ${data.EmpleadoId} <br>
                <strong>Nombres:</strong> ${data.Nombres} <br>
                <strong>Apellido Paterno:</strong> ${data.ApellidoPaterno || "N/A"} <br>
                <strong>Apellido Materno:</strong> ${data.ApellidoMaterno || "N/A"} <br>
                <strong>Email:</strong> ${data.Email || "N/A"}`;

            $("#EmpleadoResult").html(resultado);
        },
        error: function (xhr) {
            console.error("Error:", xhr.responseText);
            alert("No se pudo obtener el empleado.");
        }
    });
}

$("#BuscarBtn").on("click", function () {
    let empleadoId = $("#EmpleadoIdTxt").val();
    let nombres = $("#NombresTxt").val();
    fnGet(empleadoId, nombres);
});

$("#EliminarBtn").on("click", function () {
    let empleadoId = $("#EliminarEmpleadoIdTxt").val();
    fnEliminar(empleadoId);
});
