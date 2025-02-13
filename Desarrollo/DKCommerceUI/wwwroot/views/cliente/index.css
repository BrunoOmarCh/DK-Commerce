"use strict"; // Fuerza a declarar variables correctamente

function fnEliminar(idCliente) {
    $.ajax({
        type: "DELETE",
        contentType: "application/json; charset=utf-8", // Soporta caracteres especiales
        async: true,
        cache: false,
        url: "https://localhost:7220/cliente/delete/" + idCliente,
        success: function () {
            alert("Se eliminó el cliente con ID '" + idCliente + "' correctamente.");
        },
        error: function (param1, param2, param3) {
            console.error("param1", param1);
            console.error("param2", param2);
            console.error("param3", param3);
            alert("No se pudo eliminar el cliente con ID '" + idCliente + "'.");
        }
    });
}

function fnGet(idCliente) {
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        cache: false,
        url: "https://localhost:7220/cliente/select-by-id/" + idCliente,
        success: function (data) {
            console.info("data:", data);
            var cliente = "Nombre/Razón Social: " + data.NombreRazonSocial + "<br>" +
                "Tipo de Documento: " + (data.TipoDocumento || "No registrado") + "<br>" +
                "Número de Documento: " + (data.NroDocumento || "No registrado") + "<br>" +
                "Contacto ID: " + (data.ContactoId || "No registrado") + "<br>" +
                "Dirección: " + (data.Direccion || "No registrada") + "<br>" +
                "Ciudad: " + (data.Ciudad || "No registrada") + "<br>" +
                "Región: " + (data.Region || "No registrada") + "<br>" +
                "Código Postal: " + (data.CodPostal || "No registrado") + "<br>" +
                "País: " + (data.Pais || "No registrado") + "<br>" +
                "Teléfono: " + (data.Telefono || "No registrado") + "<br>" +
                "Fax: " + (data.Fax || "No registrado");

            $("#ClienteResult").html(cliente);
        },
        error: function (param1, param2, param3) {
            console.error("param1", param1);
            console.error("param2", param2);
            console.error("param3", param3);
            alert("No se pudo leer el cliente con ID '" + idCliente + "'.");
        }
    });
}

$("#BuscarBtn").on("click", function () {
    let idClienteBuscar = $("#ClienteBuscarTxt").val();

    fnGet(idClienteBuscar);
});

$("#EliminarBtn").on("click", function () {
    let idCliente = $("#ClienteIdTxt").val();

    fnEliminar(idCliente);
});
