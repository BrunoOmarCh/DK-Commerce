﻿"use strict";

function fnUpdate(idCliente) {
    let cliente;

    cliente = {
        NombreRazonSocial: $("#NombreRazonSocialTxt").val(),
        TipoDocumento: $("#TipoDocumentoTxt").val(),
        NroDocumento: $("#NroDocumentoTxt").val(),
        ContactoId: $("#ContactoTxt").val(),
        Direccion: $("#DireccionTxt").val(),
        Ciudad: $("#CiudadTxt").val(),
        Region: $("#RegionTxt").val(),
        CodPostal: $("#CodPostalTxt").val(),
        Pais: $("#PaisTxt").val(),
        Telefono: $("#TelefonoTxt").val(),
        Fax: $("#FaxTxt").val()
    };

    $.ajax({
        type: "PUT",
        async: true,
        cache: false,
        data: { cliente: JSON.stringify(cliente) },
        url: "https://localhost:7220/cliente/update/" + idCliente,
        dataType: "text",
        crossDomain: true,
        success: function () {
            alert("Se actualizó el cliente: " + $("#NombreRazonSocialTxt").val());
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
    const idCliente = $("#ClienteIdTxt").val();
    fnUpdate(idCliente);
});
