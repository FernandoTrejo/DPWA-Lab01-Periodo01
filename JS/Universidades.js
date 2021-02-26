$(document).ready(function () {
    $("#btnEditarUniversidad").click(function () {
        let nombreNuevo = $("#txtNombre").val();
        let codU = getParameterByName('u');

        let url = "Operaciones/EditarUniversidad.aspx?u=" + codU + "&nombre=" + nombreNuevo;
        window.location.href = url;
    });
});

function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}