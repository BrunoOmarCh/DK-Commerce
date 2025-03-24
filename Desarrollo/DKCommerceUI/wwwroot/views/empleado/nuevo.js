"use strict";

function fnInsert() {
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
        type: "POST",
        async: true,
        cache: false,
        data: JSON.stringify(empleado),
        url: "https://localhost:7220/empleado/insert",
        contentType: "application/json",
        success: function () {
            alert("Se insertó el empleado con éxito.");
        },
        error: function (xhr) {
            console.error("Error:", xhr.responseText);
            alert("Ocurrió un error al insertar el empleado.");
        }
    });
}

$("#GuardarBtn").on("click", function () {
    fnInsert();
});
