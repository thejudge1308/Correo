$(document).ready(function () {

    console.log("asdasdasd");
    $("#Fecha").datepicker();
    $("#Guardar").on('click', function () {
        var rut = $.trim($("#Rut").val());
        var nombre = $.trim($("#Nombre").val());
        var sexo = $.trim($("#Sexo").val());
        var domicilio = $.trim($("#Domicilio").val());
        var fecha = $.trim($("#Fecha").val());
        var fono = $.trim($("#Fono").val());
        var previ = $.trim($("#Previ").val());
        var opcion = $.trim($("#sele option:selected").text());
        if (rut != "" || nombre != "" || sexo != "" || domicilio != "" || fecha != "" || fono != "" || previ!="") {

            var datos = {
                ru: rut,
                no: nombre,
                se: sexo,
                dom: domicilio,
                fe: fecha,
                fo: fono,
                op: opcion,
                pre: previ
            };

            $.ajax({
                type: "POST",
                url: "/Usuario/AgregarCajero",
                data: JSON.stringify(datos),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    
                },
                failure: function (response) {
                    mostrarAlerta(response.responseText);
                },
                error: function (response) {
                    mostrarAlerta(response.responseText);
                }
            });  



        } else {
            alert("Ingresa todos los datos");
        }
        console.log(opcion + " : "+rut);
    });



});