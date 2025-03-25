"use strict";

$("#GuardarBtn").on("click", function () {
    let pedido = {
        ClienteId: $("#ClienteIdTxt").val(),
        IdEmpleado: $("#IdEmpleadoTxt").val(),
        FechaPedido: $("#FechaPedidoTxt").val(),
        FechaEntrega: $("#FechaEntregaTxt").val(),
        MontoTotal: $("#MontoTotalTxt").val()
    };

    $.ajax({
        type: "POST",
        url: "https://localhost:7220/pedido/insert",
        data: JSON.stringify(pedido),
        contentType: "application/json",
        async: true,
        cache: false,
        success: function () {
            alert("Se insertó el pedido con éxito.");
        },
        error: function (xhr) {
            alert("Ocurrió un error al insertar el pedido.");
            console.error("Error:", xhr.responseText);
        }
    });
});
