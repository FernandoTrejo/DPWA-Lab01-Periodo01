$(document).ready(function () {
    $("#btnEditarJugador").click(function () {
        let codE = getParameterByName('codE');
        let codJ = getParameterByName('codJ');

        let nombre = $("#txtNombre").val();
        let dirFoto = $("#imgView").attr("src");
        let pos = $("#ddlisPos").val();
        let edad = $("#txtEdad").val();
        let estatura = $("#txtEstatura").val();
        let peso = $("#txtPeso").val();
        let codU = $("#ddlistU").val();
        let salario = $("#txtSalario").val();

        let url = "Operaciones/EditarJugador.aspx?equipo=" + codE + "&jugador=" + codJ + "&nombre=" + nombre + "&dirFoto=" + dirFoto + "&pos=" + pos + "&edad=" + edad + "&estatura=" + estatura + "&peso=" + peso + "&codU=" + codU + "&salario=" + salario;
        
        window.location.href = url;
    });
});

function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}