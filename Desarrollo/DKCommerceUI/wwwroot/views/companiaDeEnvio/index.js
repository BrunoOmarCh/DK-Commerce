"use strict"; // Forzar declaración de variables correctamente

function fnEliminar(idCompania) {
    $.ajax({
        type: "DELETE",
        contentType: "application/json; charset=utf-8", // Soporta caracteres especiales
        async: true,
        cache: false,
        url: "https://localhost:7220/companiaDeEnvio/delete/" + idCompania,
        success: function () {
            alert("Se eliminó la compañía de envío con ID '" + idCompania + "' correctamente.");
        },
        error: function (param1, param2, param3) {
            console.error("param1", param1);
            console.error("param2", param2);
            console.error("param3", param3);
            alert("No se pudo eliminar la compañía de envío con ID '" + idCompania + "'.");
        }
    });
}

function fnGet(idCompania) {
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        cache: false,
        url: "https://localhost:7220/companiaDeEnvio/select-by-id/" + idCompania,
        success: function (data) {
            console.info("data:", data);
            var compania = "Nombre de la Compañía: " + data.NombreCompañia + "<br>" +
                "RUC: " + (data.Ruc || "No registrado") + "<br>" +
                "Teléfono: " + (data.Telefono || "No registrado");

            $("#CompaniaDeEnvioResult").html(compania);
        },
        error: function (param1, param2, param3) {
            console.error("param1", param1);
            console.error("param2", param2);
            console.error("param3", param3);
            alert("No se pudo leer la compañía de envío con ID '" + idCompania + "'.");
        }
    });
}

$("#BuscarBtn").on("click", function () {
    let idCompaniaBuscar = $("#CompaniaDeEnvioBuscarTxt").val();

    fnGet(idCompaniaBuscar);
});

$("#EliminarBtn").on("click", function () {
    let idCompania = $("#CompaniaDeEnvioIdTxt").val();

    fnEliminar(idCompania);
});
