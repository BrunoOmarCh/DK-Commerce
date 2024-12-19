"use strict";

function fnUpdate(idProveedor) {
    let proveedor = {
        Nombre: $("#NombreTxt").val(),
        Ruc: $("#RucTxt").val(),
        ContactoId: $("#ContactoTxt").val(),
        Direccion: $("#DireccionTxt").val(),
        Ciudad: $("#CiudadTxt").val(),
        Region: $("#RegionTxt").val(),
        CodPostal: $("#CodPostalTxt").val(),
        Pais: $("#PaisTxt").val(),
        Telefono: $("#TelefonoTxt").val(),
        Fax: $("#FaxTxt").val(),
        PaginaPrincipal: $("#PaginaPrincipalTxt").val()
    };

    console.log("Datos del proveedor:", proveedor);
    console.log("URL de la solicitud:", "https://localhost:7138/proveedor/update/" + idProveedor);

    $.ajax({
        type: "PUT",
        async: true,
        cache: false,
        data: JSON.stringify(proveedor),
        contentType: "application/json",
        url: "https://localhost:7138/proveedor/update/" + idProveedor,
        success: function () {
            alert("Se actualizó el proveedor: " + $("#NombreTxt").val());
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
    const idProveedor = $("#CodigoTxt").val();
    fnUpdate(idProveedor);
});

