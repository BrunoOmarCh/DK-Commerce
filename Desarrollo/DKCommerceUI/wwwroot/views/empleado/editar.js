"use strict";

function fnUpdate(empleadoId) {
    let empleado = {
        Nombres: $("#NombresTxt").val(),
        ApellidoPaterno: $("#ApellidoPaternoTxt").val(),
        ApellidoMaterno: $("#ApellidoMaternoTxt").val(),
        TipoDocIdentidad: $("#TipoDocTxt").val(),
        NroDocIdentidad: $("#NroDocTxt").val(),
        Cargo: $("#CargoTxt").val(),
        Email: $("#EmailTxt").val()
    };

    $.ajax({
        type: "PUT",
        async: true,
        cache: false,
        data: JSON.stringify(empleado),
        contentType: "application/json",
        url: `https://localhost:7220/empleado/update/${empleadoId}`,
        success: function () {
            alert(`Se actualizó el empleado con ID: ${empleadoId} con éxito.`);
        },
        error: function (xhr) {
            console.error("Error:", xhr.responseText);
            alert("Ocurrió un error al actualizar el empleado.");
        }
    });
}

$("#GuardarBtn").on("click", function () {
    const empleadoId = $("#EmpleadoIdTxt").val();
    fnUpdate(empleadoId);
});
