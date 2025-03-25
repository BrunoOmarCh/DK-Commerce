"use strict";

function fnInsert() {
    let parametro = {
        Clave: $("#ClaveTxt").val(),
        Grupo: $("#GrupoTxt").val(),
        Valor: $("#ValorTxt").val()
    };

    $.ajax({
        type: "POST",
        async: true,
        cache: false,
        data: JSON.stringify(parametro),
        url: "https://localhost:7220/parametro/insert",
        contentType: "application/json",
        success: function () {
            alert("Se insertó el parámetro con éxito.");
        },
        error: function (xhr) {
            console.error("Error:", xhr.responseText);
            alert("Ocurrió un error al insertar el parámetro.");
        }
    });
}

$("#GuardarBtn").on("click", function () {
    fnInsert();
});
