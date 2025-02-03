"use strict";

function fnUpdate(idPedido, idProducto) {
    let detalleDePedido;

    detalleDePedido = {
        PrecioNeto: parseFloat($("#PrecioNetoTxt").val()),
        Cantidad: parseInt($("#CantidadTxt").val()),
        Descuento: parseFloat($("#DescuentoTxt").val() || 0),
        Igv: parseFloat($("#IgvTxt").val() || 0),
        Isc: parseFloat($("#IscTxt").val() || 0),
        MontoSubTotal: parseFloat($("#MontoSubTotalTxt").val() || 0)
    };

    $.ajax({
        type: "PUT",
        async: true,
        cache: false,
        data: { detalleDePedido: JSON.stringify(detalleDePedido) },
        url: "https://localhost:7220/detalleDePedido/update/" + idPedido + "/" + idProducto,
        dataType: "text",
        crossDomain: true,
        success: function () {
            alert("Se actualizó el detalle del pedido: " + idPedido);
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
    const idPedido = $("#PedidoIdTxt").val();
    const idProducto = $("#ProductoIdTxt").val();
    fnUpdate(idPedido, idProducto);
});
