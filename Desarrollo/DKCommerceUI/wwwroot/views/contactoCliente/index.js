"use strict"; // Fuerza a declarar variables

function fnEliminar(idContacto) {
    $.ajax({
        type: "DELETE",
        contentType: "application/json; charset=utf-8", // Trabaja con objetos Json; en formato UTF-8 (soporta tildes)
        async: true,
        cache: false,
        url: "https://localhost:7220/contactocliente/delete/" + idContacto,
        success: function () {
            alert("Se eliminó el contacto de código '" + idContacto + "', con éxito.");
        },
        error: function (param1, param2, param3) {
            console.error("param1", param1);
            console.error("param2", param2);
            console.error("param3", param3);
            alert("No se pudo eliminar el contacto de código '" + idContacto + "'.");
        }
    });
}

function fnGet(idContacto) {
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        cache: false,
        url: "https://localhost:7220/contactocliente/select-by-id/" + idContacto,
        success: function (data) {
            console.info("data:", data);
            var contacto = "Nombre Contacto: " + data.NombreContacto + "<br>" +
                "Cargo: " + data.CargoContacto + "<br>" +
                "Tipo Documento: " + data.TipoDocumento + "<br>" +
                "Número Documento: " + data.NroDocumento;

            $("#ContactoClienteResult").html(contacto);
        },
        error: function (param1, param2, param3) {
            console.error("param1", param1);
            console.error("param2", param2);
            console.error("param3", param3);
            alert("No se pudo leer el contacto de código '" + idContacto + "'.");
        }
    });
}

$("#BuscarBtn").on("click", function () {
    let idContactoBuscar = $("#ContactoClienteBuscarTxt").val();
    fnGet(idContactoBuscar);
});

$("#EliminarBtn").on("click", function () {
    let idContacto = $("#ContactoIdTxt").val();
    fnEliminar(idContacto);
});
