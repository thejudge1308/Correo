$(document).ready(function () {

    
    $("#Fecha").datepicker(
        {
            dateFormat: 'yy-mm-dd'
        }
    );
    $("#Guardar").on('click', function () {
        var rutR = $.trim($("#Rut").val());
        var nombreR = $.trim($("#Nombre").val());
        var sexoR = $.trim($("#Sexo").val());
        var domicilioR = $.trim($("#Domicilio").val());
        var fechaR = $.trim($("#Fecha").val());
        var fonoR = $.trim($("#Fono").val());
        var previR = $.trim($("#Previ").val());
        var opcionR = $.trim($("#sele").find(":selected").text());
        //console.log();


        if (rutR !== "" || nombreR !== "" || sexoR !== "" || domicilioR !== "" || fechaR !== "" || fonoR !== "" || previR !=="") {

            var jsonCajero = {
                rut: rutR,
                nombre: nombreR,
                sexo: sexoR,
                domicilio: domicilioR,
                fecha: fechaR,
                fono: fonoR,
                opcion: opcionR,
                previ: previR
            };
            console.log(jsonCajero);
            console.log(JSON.stringify(jsonCajero));
            $.ajax({
                type: "POST",
                url: "/Usuario/AgregarCajero",
                data: JSON.stringify(jsonCajero),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    
                },
                failure: function (response) {
                    alert("fallo");
                },
                error: function (response) {
                    alert("error");
                }
            });  



        } else {
            alert("Ingresa todos los datos");
        }
       
    });



});