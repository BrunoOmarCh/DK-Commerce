"use strict"; // Fuerza a declarar variables

function fnEliminar(idProducto) {
    $.ajax({
        type: "DELETE",
        contentType: "application/json; chartset=utf-8",// Trabaja con objetos Json; en formato UTF-8 (soporta tildes)
        async: true,
        cache: false,
        url: "https://localhost:7220/producto/delete/" + idProducto,
        success: function () {
            alert("Se eliminó el producto de código '" + idProducto + "', con éxito.");
        },
        error: function (param1, param2, param3) {
            console.error("param1", param1);
            console.error("param2", param2);
            console.error("param3", param3);
            alert("No se pudo eliminar el producto de código '" + idProducto + "'.");
        }
    });
}

function fnGet(idProducto) {
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        cache: false,
        url: "https://localhost:7220/producto/select-by-id/" + idProducto,
        success: function (data) {
            console.info("data:", data);
            var producto = "Nombre: " + data.NombreProducto + "<br>" +
                "Precio lista: " + data.PrecioLista + "<br>" +
                "Descuento: " + data.Descuento + "<br>" +
                "Precio venta: " + data.PrecioVenta;

            $("#ProductoResult").html(producto);
        },
        error: function (param1, param2, param3) {
            console.error("param1", param1);
            console.error("param2", param2);
            console.error("param3", param3);
            alert("No se pudo leer el producto de código '" + idProducto + "'.");
        }
    });
}

$("#BuscarBtn").on("click", function () {
    let idProdBuscar = $("#ProductoBuscarTxt").val();

    fnGet(idProdBuscar);
});

$("#EliminarBtn").on("click", function () {
    let idProd = $("#IdProductoTxt").val();

    fnEliminar(idProd);
});
