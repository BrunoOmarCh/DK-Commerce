﻿"use strict";

function fnUpdate(idCompaniaDeEnvio) {
    let companiaDeEnvio;

    companiaDeEnvio = {
        NombreCompañia: $("#NombreCompañiaTxt").val(),
        Ruc: $("#RucTxt").val(),
        Telefono: $("#TelefonoTxt").val()
    };

    $.ajax({
        type: "PUT",
        async: true,
        cache: false,
        data: { companiaDeEnvio: JSON.stringify(companiaDeEnvio) },
        url: "https://localhost:7220/companiaDeEnvio/update/" + idCompaniaDeEnvio,
        dataType: "text",
        crossDomain: true,
        success: function () {
            alert("Se actualizó la compañía: " + $("#NombreCompañiaTxt").val());
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
    const idCompaniaDeEnvio = $("#CompaniaDeEnvioIdTxt").val();
    fnUpdate(idCompaniaDeEnvio);
});
