$(document).ready(function () {

    console.log("asdasdasd");
   
    $("#Guardar").on('click', function () {
        var rut = $("#Rut").val();
        var nombre = $("#Nombre").val();
        var sexo = $("#Sexo").val();
        var domicilio = $("#Domicilio").val();
        var fecha = $("#Fecha").val();
        var fono = $("#Fono").val();
        var opcion = $("#sele option:selected").text();

        console.log(opcion + " : "+rut);
    });



});