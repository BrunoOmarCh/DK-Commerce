﻿"use strict";

function fnUpdateCategoria(categoriaId) {
    let categoria = {
        Nombre: $("#NombreTxt").val(),
        Descripcion: $("#DescripcionTxt").val(),
        Suspendido: $("#SuspendidoChk").is(":checked")
    };

    console.log("Datos de la categoría:", categoria);
    console.log("URL de la solicitud:", "https://localhost:7220/categoria/update/" + categoriaId);

    $.ajax({
        type: "PUT",
        async: true,
        cache: false,
        data: JSON.stringify(categoria),
        contentType: "application/json",
        url: "https://localhost:7220/categoria/update/" + categoriaId,
        success: function () {
            alert("Se actualizó la categoría: " + $("#NombreTxt").val());
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
    const categoriaId = $("#CategoriaIdTxt").val();
    fnUpdateCategoria(categoriaId);
});