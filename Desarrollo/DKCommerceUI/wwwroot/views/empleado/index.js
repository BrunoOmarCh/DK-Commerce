"use strict"; // Fuerza a declarar variables correctamente

function fnEliminarCategoria(idCategoria) {
    $.ajax({
        type: "DELETE",
        contentType: "application/json; charset=utf-8", // Trabaja con objetos JSON en formato UTF-8
        async: true,
        cache: false,
        url: "https://localhost:7220/categoria/delete/" + idCategoria,
        success: function () {
            alert("Se eliminó la categoría de código '" + idCategoria + "' con éxito.");
        },
        error: function (param1, param2, param3) {
            console.error("Error Param1:", param1);
            console.error("Error Param2:", param2);
            console.error("Error Param3:", param3);
            alert("No se pudo eliminar la categoría de código '" + idCategoria + "'.");
        }
    });
}

function fnGetCategoria(idCategoria) {
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        cache: false,
        url: "https://localhost:7220/categoria/select-by-id/" + idCategoria,
        success: function (data) {
            console.info("Datos recibidos:", data);
            const categoria = "Nombre: " + data.Nombre + "<br>" +
                "Descripción: " + (data.Descripcion || "N/A") + "<br>" +
                "Suspendido: " + (data.Suspendido ? "Sí" : "No");

            $("#CategoriaResult").html(categoria);
        },
        error: function (param1, param2, param3) {
            console.error("Error Param1:", param1);
            console.error("Error Param2:", param2);
            console.error("Error Param3:", param3);
            alert("No se pudo obtener la categoría de código '" + idCategoria + "'.");
        }
    });
}

$("#BuscarBtn").on("click", function () {
    const idCategoriaBuscar = $("#CategoriaBuscarTxt").val();
    if (!idCategoriaBuscar) {
        alert("Por favor, ingrese un código de categoría para buscar.");
        return;
    }
    fnGetCategoria(idCategoriaBuscar);
});

$("#EliminarBtn").on("click", function () {
    const idCategoria = $("#CategoriaIdTxt").val();
    if (!idCategoria) {
        alert("Por favor, ingrese un código de categoría para eliminar.");
        return;
    }
    fnEliminarCategoria(idCategoria);
});