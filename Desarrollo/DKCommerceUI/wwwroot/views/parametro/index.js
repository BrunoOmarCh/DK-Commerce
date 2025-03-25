"use strict";

function fnEliminar(clave) {
    $.ajax({
        type: "DELETE",
        contentType: "application/json; charset=utf-8",
        async: true,
        cache: false,
        url: `https://localhost:7220/parametro/delete/${clave}`,
        success: function () {
            alert(`Se eliminó el parámetro con clave: ${clave} con éxito.`);
        },
        error: function (xhr) {
            console.error("Error:", xhr.responseText);
            alert(`No se pudo eliminar el parámetro con clave: ${clave}.`);
        }
    });
}

function fnGet(clave) {
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        cache: false,
        url: `https://localhost:7220/parametro/select?clave=${clave}`,
        success: function (data) {
            console.info("Datos obtenidos:", data);
            let resultado = `<strong>Clave:</strong> ${data.Clave} <br>
                <strong>Grupo:</strong> ${data.Grupo || "N/A"} <br>
                <strong>Valor:</strong> ${data.Valor || "N/A"}`;

            $("#ParametroResult").html(resultado);
        },
        error: function (xhr) {
            console.error("Error:", xhr.responseText);
            alert("No se pudo obtener el parámetro.");
        }
    });
}

$("#BuscarBtn").on("click", function () {
    let clave = $("#ClaveTxt").val();
    fnGet(clave);
});

$("#EliminarBtn").on("click", function () {
    let clave = $("#EliminarClaveTxt").val();
    fnEliminar(clave);
});
