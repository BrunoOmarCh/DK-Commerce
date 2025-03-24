"use strict";

function fnUpdate(idContactoProveedor) {
    let contactoProveedor = {
        NombreContacto: $("#NombreContactoTxt").val(),
        CargoContacto: $("#CargoContactoTxt").val(),
        Dni: $("#DniTxt").val()
    };

    console.log("Datos del contacto proveedor:", contactoProveedor);
    console.log("URL de la solicitud:", "https://localhost:7220/contactoProveedor/update/" + idContactoProveedor);

    $.ajax({
        type: "PUT",
        async: true,
        cache: false,
        data: JSON.stringify(contactoProveedor),
        contentType: "application/json",
        url: "https://localhost:7220/contactoProveedor/update/" + idContactoProveedor,
        success: function () {
            alert("Se actualizó el contacto proveedor: " + $("#NombreContactoTxt").val());
        },
        error: function (xhr, status, error) {
            console.error("Error Status: " + status);
            console.error("Error Thrown: " + error);
            console.error("Response Text: " + xhr.responseText);
            alert("Ocurrió un error al actualizar: " + xhr.responseText);
        }
    });
}

$("#GuardarBtn").on("click", function () {
    const idContactoProveedor = $("#ContactoProveedorIdTxt").val();
    fnUpdate(idContactoProveedor);
});
