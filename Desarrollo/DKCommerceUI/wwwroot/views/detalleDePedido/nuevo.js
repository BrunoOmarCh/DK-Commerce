"use strict";
function fnInsert() {
    let producto;

    producto = {
        NombreProducto: $("#NombreTxt").val(),
        PrecioVenta: $("#PrecioTxt").val(),
        ProveedorId: $("#ProveedorIdTxt").val(),
        CategoriaId: $("#CategoriaIdTxt").val()
    };

    $.ajax({ // Es un llamado con JavaScript a métodos de servidor
        type: "POST", // Método HTTP
        async: true, // Será asíncrono
        cache: false, // No usará la cache
        data: { producto: JSON.stringify(producto) }, // Se envía serializado, solo pasa texto
        url: "https://localhost:7220/producto/insert",
        dataType: "text", // 'text' porque está serializado
        crossDomain: true,// Los nombres de las propiedades de los objetos empiezan en minúsculas
        success: function () { // Invoca a una función anónima
            alert("Se insertó con éxito.");
        },
        error: function (param1, param2, param3) {
            console.error("param1", param1);
            console.error("param2", param2);
            console.error("param3", param3);
            alert("Ocurrió un error al insertar.");
        }
    });
}

$("#GuardarBtn").on("click", function () {// Evento click
    fnInsert();
});
