"use strict";

function fnUpdate(idProducto) {
    let producto;

    producto = {
        NombreProducto: $("#NombreTxt").val(),
        PrecioVenta: $("#PrecioTxt").val()
    };

    $.ajax({
        type: "PUT",
        async: true,
        cache: false,
        data: { producto: JSON.stringify(producto) },
        url: "https://localhost:7220/producto/update/" + idProducto,
        dataType: "text",
        crossDomain: true,
        success: function () {
            alert("Se actualizó el producto: " + $("#NombreTxt").val());
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
    const idProducto = $("#CodigoTxt").val();
    fnUpdate(idProducto);
});
