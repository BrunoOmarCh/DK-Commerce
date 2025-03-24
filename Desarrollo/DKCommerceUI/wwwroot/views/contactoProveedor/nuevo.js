"use strict";

function fnInsert() {
    let contactoProveedor;

    contactoProveedor = {
        NombreContacto: $("#NombreContactoTxt").val(),
        CargoContacto: $("#CargoContactoTxt").val(),
        Dni: $("#DniTxt").val()
    };

    $.ajax({
        type: "POST",
        async: true,
        cache: false,
        data: { contactoProveedor: JSON.stringify(contactoProveedor) },
        url: "https://localhost:7220/contactoProveedor/insert",
        dataType: "text",
        crossDomain: true,
        success: function () {
            alert("Se insertó con éxito.");
        },
        error: function (param1, param2, param3) {
            console.error("param1", param1);
            console.error("param2", param2);
            console.error("param3", param3);
            alert("Ocurrió un error al insertar.");
        }
    });
}

$("#GuardarBtn").on("click", function () {
    fnInsert();
});
