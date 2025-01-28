"use strict";

function fnInsert() {
    let categoria;

    categoria = {
        Nombre: $("#NombreTxt").val(),
        Descripcion: $("#DescripcionTxt").val(),
        Suspendido: $("#SuspendidoChk").is(":checked")
    };

    $.ajax({
        type: "POST",
        async: true,
        cache: false,
        data: { categoria: JSON.stringify(categoria) },
        url: "https://localhost:7220/categoria/insert",
        dataType: "text",
        crossDomain: true,
        success: function () {
            alert("La categoría se insertó con éxito.");
        },
        error: function (param1, param2, param3) {
            console.error("param1", param1);
            console.error("param2", param2);
            console.error("param3", param3);
            alert("Ocurrió un error al insertar la categoría.");
        }
    });
}

$("#GuardarBtn").on("click", function () {
    fnInsert();
});
