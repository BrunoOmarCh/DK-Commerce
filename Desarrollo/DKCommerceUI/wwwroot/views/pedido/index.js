"use strict";

$("#BuscarBtn").on("click", function () {
    let pedidoId = $("#PedidoIdTxt").val();

    $.ajax({
        type: "GET",
        url: `https://localhost:7220/pedido/select?pedidoId=${pedidoId}`,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        cache: false,
        success: function (data) {
            let resultado = `<strong>Pedido ID:</strong> ${data.PedidoId} <br>
                <strong>Cliente ID:</strong> ${data.ClienteId} <br>
                <strong>ID Empleado:</strong> ${data.IdEmpleado || "N/A"} <br>
                <strong>Fecha Pedido:</strong> ${data.FechaPedido || "N/A"} <br>
                <strong>Fecha Entrega:</strong> ${data.FechaEntrega || "N/A"} <br>
                <strong>Monto Total:</strong> ${data.MontoTotal || "N/A"}`;

            $("#PedidoResult").html(resultado);
        },
        error: function (xhr) {
            alert("No se pudo obtener el pedido.");
            console.error("Error:", xhr.responseText);
        }
    });
});

$("#EliminarBtn").on("click", function () {
    let pedidoId = $("#EliminarPedidoIdTxt").val();

    $.ajax({
        type: "DELETE",
        url: `https://localhost:7220/pedido/delete/${pedidoId}`,
        contentType: "application/json; charset=utf-8",
        async: true,
        cache: false,
        success: function () {
            alert(`Se eliminó el pedido con ID: ${pedidoId} con éxito.`);
        },
        error: function (xhr) {
            alert(`No se pudo eliminar el pedido con ID: ${pedidoId}.`);
            console.error("Error:", xhr.responseText);
        }
    });
});
