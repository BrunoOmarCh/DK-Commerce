"use strict";

function fnEliminar(pedidoId, productoId) {
    $.ajax({
        type: "DELETE",
        contentType: "application/json; charset=utf-8",
        async: true,
        cache: false,
        url: `https://localhost:7220/detalleDePedido/delete/${pedidoId}/${productoId}`,
        success: function () {
            alert(`Se eliminó el detalle del pedido (Pedido ID: ${pedidoId}, Producto ID: ${productoId}) con éxito.`);
        },
        error: function (param1, param2, param3) {
            console.error("Error:", param1, param2, param3);
            alert(`No se pudo eliminar el detalle del pedido (Pedido ID: ${pedidoId}, Producto ID: ${productoId}).`);
        }
    });
}

function fnGet(pedidoId, productoId) {
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        cache: false,
        url: `https://localhost:7220/detalleDePedido/select-by-id/${pedidoId}/${productoId}`,
        success: function (data) {
            console.info("data:", data);
            var detalle = `Pedido ID: ${data.PedidoId}<br>
                Producto ID: ${data.ProductoId}<br>
                Precio Neto: ${data.PrecioNeto}<br>
                Cantidad: ${data.Cantidad}<br>
                Descuento: ${data.Descuento}<br>
                IGV: ${data.Igv || "N/A"}<br>
                ISC: ${data.Isc || "N/A"}<br>
                SubTotal: ${data.MontoSubTotal || "N/A"}`;

            $("#DetalleDePedidoResult").html(detalle);
        },
        error: function (param1, param2, param3) {
            console.error("Error:", param1, param2, param3);
            alert(`No se pudo leer el detalle del pedido (Pedido ID: ${pedidoId}, Producto ID: ${productoId}).`);
        }
    });
}

$("#BuscarBtn").on("click", function () {
    let pedidoId = $("#PedidoIdTxt").val();
    let productoId = $("#ProductoIdTxt").val();
    fnGet(pedidoId, productoId);
});

$("#EliminarBtn").on("click", function () {
    let pedidoId = $("#EliminarPedidoIdTxt").val();
    let productoId = $("#EliminarProductoIdTxt").val();
    fnEliminar(pedidoId, productoId);
});
