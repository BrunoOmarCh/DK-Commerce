"use strict";

function fnUpdate(idContactoProveedor) {
    let contactoProveedor;

    contactoProveedor = {
        NombreContacto: $("#NombreContactoTxt").val(),
        CargoContacto: $("#CargoContactoTxt").val(),
        Dni: $("#DniTxt").val()
    };

    $.ajax({
        type: "PUT",
        async: true,
        cache: false,
        data: { contactoProveedor: JSON.stringify(contactoProveedor) },
        url: "https://localhost:7220/contactoProveedor/update/" + idContactoProveedor,
        dataType: "text",
        crossDomain: true,
        success: function () {
            alert("Se actualizó el contacto: " + $("#NombreContactoTxt").val());
        },
        error: function (param1, param2, param3) {
            console.error("param1", param1);
            console.error("param2", param2);
            console.error("param3", param3);
            alert("Ocurrió un error al actualizar");
        }
    });
}

$("#GuardarBtn").on("click", function () {
    const idContactoProveedor = $("#ContactoProveedorIdTxt").val();
    fnUpdate(idContactoProveedor);
});
