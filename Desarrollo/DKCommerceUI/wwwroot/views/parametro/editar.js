"use strict";

function fnUpdate(clave) {
    let parametro = {
        Grupo: $("#GrupoTxt").val(),
        Valor: $("#ValorTxt").val()
    };

    $.ajax({
        type: "PUT",
        async: true,
        cache: false,
        data: JSON.stringify(parametro),
        contentType: "application/json",
        url: `https://localhost:7220/parametro/update/${clave}`,
        success: function () {
            alert(`Se actualizó el parámetro con clave: ${clave} con éxito.`);
        },
        error: function (xhr) {
            console.error("Error:", xhr.responseText);
            alert("Ocurrió un error al actualizar el parámetro.");
        }
    });
}

$("#GuardarBtn").on("click", function () {
    const clave = $("#ClaveTxt").val();
    fnUpdate(clave);
});
