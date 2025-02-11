"use strict"; // Fuerza a declarar variables

function fnEliminar(pedidoId, productoId) {
    $.ajax({
        type: "DELETE",
        contentType: "application/json; charset=utf-8", // Trabaja con objetos Json; en formato UTF-8 (soporta tildes)
        async: true,
        cache: false,
        url: "https://localhost:7220/detallepedido/delete/" + pedidoId + "/" + productoId,
        success: function () {
            alert("Se eliminó el detalle de pedido con ID Pedido '" + pedidoId + "' y ID Producto '" + productoId + "' con éxito.");
        },
        error: function (param1, param2, param3) {
            console.error("param1", param1);
            console.error("param2", param2);
            console.error("param3", param3);
            alert("No se pudo eliminar el detalle de pedido con ID Pedido '" + pedidoId + "' y ID Producto '" + productoId + "'.");
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
        url: "https://localhost:7220/detallepedido/select-by-id/" + pedidoId + "/" + productoId,
        success: function (data) {
            console.info("data:", data);
            var detalleDePedido = "Precio Neto: " + data.PrecioNeto + "<br>" +
                "Cantidad: " + data.Cantidad + "<br>" +
                "Descuento: " + data.Descuento + "<br>" +
                "IGV: " + data.Igv + "<br>" +
                "ISC: " + data.Isc + "<br>" +
                "Monto SubTotal: " + data.MontoSubTotal;

            $("#DetalleDePedidoResult").html(detalleDePedido);
        },
        error: function (param1, param2, param3) {
            console.error("param1", param1);
            console.error("param2", param2);
            console.error("param3", param3);
            alert("No se pudo leer el detalle de pedido con ID Pedido '" + pedidoId + "' y ID Producto '" + productoId + "'.");
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
