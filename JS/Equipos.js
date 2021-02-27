$(document).ready(function () {
    $("#btnEditarEquipo").click(function () {
        let codE = getParameterByName('equipo');

        let dirFoto = $("#imgView").attr("src");
        let nombre = $("#txtNombre").val();

        let url = "Operaciones/EditarEquipo.aspx?equipo=" + codE + "&dirFoto=" + dirFoto + "&nombre=" + nombre;

        window.location.href = url;
    });
});

function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}