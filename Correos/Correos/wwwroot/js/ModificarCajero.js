$(document).ready(function () {


    $("#usuarioctual_Fecha").datepicker(
        {
            dateFormat: 'yy-mm-dd'
        }
    );
    $("#Guardar").on('click', function () {
        var rutR = $.trim($("#usuarioctual_Rut").val());
        var nombreR = $.trim($("#usuarioctual_Nombre").val());
        var sexoR = $.trim($("#usuarioctual_Sexo").val());
        var domicilioR = $.trim($("#usuarioctual_Domicilio").val());
        var fechaR = $.trim($("#usuarioctual_Fecha").val());
        var fonoR = $.trim($("#usuarioctual_Fono").val());
        var previR = $.trim($("#usuarioctual_Previ").val());
        var opcionR = $.trim($("#sele").find(":selected").text());
        //console.log();


        if (rutR !== "" || nombreR !== "" || sexoR !== "" || domicilioR !== "" || fechaR !== "" || fonoR !== "" || previR !== "") {

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
                url: "/Usuario/ModificarUsuario",
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