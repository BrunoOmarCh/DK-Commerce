"use strict"; // Fuerza a declarar variables

function fnEliminar(idProveedor) {
    $.ajax({
        type: "DELETE",
        contentType: "application/json; chartset=utf-8",// Trabaja con objetos Json; en formato UTF-8 (soporta tildes)
        async: true,
        cache: false,
        url: "https://localhost:7138/proveedor/delete/" + idProveedor,
        success: function () {
            alert("Se eliminó el proveedor de código '" + idProveedor + "', con éxito.");
        },
        error: function (param1, param2, param3) {
            console.error("param1", param1);
            console.error("param2", param2);
            console.error("param3", param3);
            alert("No se pudo eliminar el proveedor de código '" + idProveedor + "'.");
        }
    });
}

function fnGet(idProveedor) {
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        async: true,
        cache: false,
        url: "https://localhost:7220/proveedor/select-by-id/" + idProveedor,
        success: function (data) {
            console.info("data:", data);
            var proveedor = "Nombre: " + data.Nombre + "<br>" +
                "Ruc: " + data.Ruc + "<br>" +
                "Contacto: " + data.ContactoId + "<br>" +
                "Direccion: " + data.Direccion + "<br>" +
                "Ciudad: " + data.Ciudad + "<br>" +
                "Region: " + data.Region + "<br>" +
                "CodPostal: " + data.CodPostal + "<br>" +
                "Pais: " + data.Pais + "<br>" +
                "Telefono: " + data.Telefono + "<br>" +
                "Fax: " + data.Fax + "<br>" +
                "PaginaPrincipal: " + data.PaginaPrincipal;

            $("#ProveedorResult").html(proveedor);
        },
        error: function (param1, param2, param3) {
            console.error("param1", param1);
            console.error("param2", param2);
            console.error("param3", param3);
            alert("No se pudo leer el proveedor de código '" + idProveedor + "'.");
        }
    });
}

$("#BuscarBtn").on("click", function () {
    let idProvBuscar = $("#ProveedorBuscarTxt").val();

    fnGet(idProvBuscar);
});

$("#EliminarBtn").on("click", function () {
    let idProv = $("#ProveedorIdTxt").val();

    fnEliminar(idProv);
});
