"use strict";

function fnUpdate(pedidoId, productoId) {
    let detalleDePedido = {
        PrecioNeto: $("#PrecioNetoTxt").val(),
        Cantidad: $("#CantidadTxt").val(),
        Descuento: 0, // Si es necesario, puedes agregar un input para Descuento
        Igv: null, // Se puede calcular en backend
        Isc: null, // Se puede calcular en backend
        MontoSubTotal: $("#MontoSubTotalTxt").val()
    };

    console.log("Datos del detalle de pedido:", detalleDePedido);
    console.log("URL de la solicitud:", `https://localhost:7220/detalleDePedido/update/${pedidoId}/${productoId}`);

    $.ajax({
        type: "PUT",
        async: true,
        cache: false,
        data: JSON.stringify(detalleDePedido),
        contentType: "application/json",
        url: `https://localhost:7220/detalleDePedido/update/${pedidoId}/${productoId}`,
        success: function () {
            alert(`Se actualizó el detalle del pedido (Pedido ID: ${pedidoId}, Producto ID: ${productoId}).`);
        },
        error: function (xhr, status, error) {
            console.error("Error Status:", status);
            console.error("Error Thrown:", error);
            console.error("Response Text:", xhr.responseText);
            alert("Ocurrió un error al actualizar: " + xhr.responseText);
        }
    });
}

$("#GuardarBtn").on("click", function () {
    const pedidoId = $("#PedidoIdTxt").val();
    const productoId = $("#ProductoIdTxt").val();
    fnUpdate(pedidoId, productoId);
});
