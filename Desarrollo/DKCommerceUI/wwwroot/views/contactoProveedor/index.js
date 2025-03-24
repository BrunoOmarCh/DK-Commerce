"use strict";

function fnEliminar(idContactoProveedor) {
    $.ajax({
        type: "DELETE",
        contentType: "application/json; charset=utf-8",
        async: true,
        cache: false,
        url: "https://localhost:7220/contactoProveedor/delete/" + idContactoProveedor,
        success: function () {
            alert("Se eliminó el contacto proveedor de código '" + idContactoProveedor + "' con éxito.");
        },
        error: function (param1, param2, param3) {
            console.error("param1", param1);
            console.error("param2", param2);
            console.error("param3", param3);
            alert("No se pudo eliminar el contacto proveedor de código '" + idContactoProveedor + "'.");
        }
    });
}

function fnGet(idContactoProveedor) {
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        cache: false,
        url: "https://localhost:7220/contactoProveedor/select-by-id/" + idContactoProveedor,
        success: function (data) {
            console.info("data:", data);
            var contactoProveedor = "Nombre: " + data.NombreContacto + "<br>" +
                "Cargo: " + data.CargoContacto + "<br>" +
                "DNI: " + data.Dni;

            $("#ContactoProveedorResult").html(contactoProveedor);
        },
        error: function (param1, param2, param3) {
            console.error("param1", param1);
            console.error("param2", param2);
            console.error("param3", param3);
            alert("No se pudo leer el contacto proveedor de código '" + idContactoProveedor + "'.");
        }
    });
}

$("#BuscarBtn").on("click", function () {
    let idBuscar = $("#ContactoProveedorBuscarTxt").val();
    fnGet(idBuscar);
});

$("#EliminarBtn").on("click", function () {
    let idEliminar = $("#ContactoProveedorIdTxt").val();
    fnEliminar(idEliminar);
});
