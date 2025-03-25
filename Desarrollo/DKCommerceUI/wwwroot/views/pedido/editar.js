"use strict";

$("#GuardarBtn").on("click", function () {
    let pedido = {
        ClienteId: $("#ClienteIdTxt").val(),
        IdEmpleado: $("#IdEmpleadoTxt").val(),
        FechaPedido: $("#FechaPedidoTxt").val(),
        FechaEntrega: $("#FechaEntregaTxt").val(),
        MontoTotal: $("#MontoTotalTxt").val()
    };
    let pedidoId = $("#PedidoIdTxt").val();

    $.ajax({
        type: "PUT",
        url: `https://localhost:7220/pedido/update/${pedidoId}`,
        data: JSON.stringify(pedido),
        contentType: "application/json",
        async: true,
        cache: false,
        success: function () {
            alert(`Se actualizó el pedido con ID: ${pedidoId} con éxito.`);
        },
        error: function (xhr) {
            alert("Ocurrió un error al actualizar el pedido.");
            console.error("Error:", xhr.responseText);
        }
    });
});
