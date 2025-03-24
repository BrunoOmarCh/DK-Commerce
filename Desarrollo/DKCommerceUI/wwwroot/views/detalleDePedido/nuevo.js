"use strict";

function fnInsert() {
    let detalleDePedido = {
        PedidoId: $("#PedidoIdTxt").val(),
        ProductoId: $("#ProductoIdTxt").val(),
        PrecioNeto: $("#PrecioNetoTxt").val(),
        Cantidad: $("#CantidadTxt").val(),
        Descuento: 0, // Se puede permitir modificar en el formulario si es necesario
        Igv: null, // Puede ser calculado en backend
        Isc: null, // Puede ser calculado en backend
        MontoSubTotal: $("#MontoSubTotalTxt").val()
    };

    $.ajax({
        type: "POST",
        async: true,
        cache: false,
        data: JSON.stringify(detalleDePedido),
        url: "https://localhost:7220/detalleDePedido/insert",
        contentType: "application/json",
        success: function () {
            alert("Se insertó el detalle del pedido con éxito.");
        },
        error: function (param1, param2, param3) {
            console.error("Error:", param1, param2, param3);
            alert("Ocurrió un error al insertar el detalle del pedido.");
        }
    });
}

$("#GuardarBtn").on("click", function () {
    fnInsert();
});
