var dttPers; // grid 

$(document).ready(function () {

    dttPers = $('#dtt-lista-personas').DataTable(
    {
        /*** 1. Diseño ***/
        "dom":
            "<'row'<'col-sm-12'>>" +
            "<'row'<'col-sm-12'tr>>" +
            //"<'row'<'col-sm-12't>>" +
            //"<'row'<'col-sm-12'r>>" +
            "<'row'<'col-sm-6'i><'col-sm-6'p>>",
        "language":
        {
            "zeroRecords": "No hay datos",
            //"info": "Mostrando _START_ de _END_ de _TOTAL_ registros totales",
            "info": "Registros del _START_ al _END_ de _TOTAL_ totales",
            "infoEmpty": "Sin datos",
            "processing": '<i class="fa fa-spinner fa-pulse fa-3x fa-fw"></i>',
            "oPaginate": {
                "sPrevious": "&#9668",
                "sNext": "&#9658"
            },
        },

        "columnDefs":
        [
            { className: "cls-center-text-button", "targets": [0] }
        ],
        "pagingType": "numbers",

        /*** 2. Interacción ***/
        "scrollX": true,
        "order": [[1, "desc"]],
        "pageLength": 10,

        /*** 3. Configuración para interactuar con el servidor de datos vía Ajax ***/
        "processing": true,
        "serverSide": true,
        "deferLoading": 0,
        "ajax":
        {
            "url": "GetListaPersonas",
            "data": function (d) // filtros
            {
                //d.pdFecIni = "19/08/2016"; // sTxtFechaInicial;
                //d.pdFecFin = "18/09/2017"; //sTxtFechaFinal;
                d.pnCantServ = $('#inp-id').val(); // sTxtFechaInicial;
            },
            "type": "POST"
        },

        /*** 4. Definición de todas la columnas ***/
        "columns": // aqui se puede cambiar el orden de las columnas
        [
            //{
            //    data: "D_FEC_REGISTRO", width: 85,
            //    "render": function (data, type, row) {
            //        return moment(data).format('DD/MM/YYYY')
            //    },
            //},
            { data: "ID", width: 50 },
            { data: "NOMBRE", width: 150 },
            { data: "APELLIDOS", width: 150 },
            { data: "FECHA_NACIMIENTO", width: 85 },
            { data: "SEXO", width: 55 }
            //{ data: "SEXO", width: 55 },
            //{
            //    data: null, width: 60, "orderable": false,
            //    "render": function (data, type, row) {
            //        if (data == 'M')
            //            return 'Masculino';
            //        else
            //            return 'Femenino';
            //    },
            //}
        ],
    });

    $('#btn-insertar').click(function () {
        grabarDatosCliente();
        dttPers.ajax.reload();
    });
})

function ajaxHelperLoader2(async, messageLoad, objData, fnBeforeSend, fnError, fnSuccess, type, url) {
    var jsonData = JSON.stringify(objData);//convierte el objeto con datos en formato Json
    //messageBoxLoader(messageLoad, null);
    /* Toda la data enviada y recibida es en formato Json */
    $.ajax({
        async: async,
        beforeSend: function (jqXHR, settings) { if (fnBeforeSend !== null) fnBeforeSend(jqXHR, settings); },
        complete: function (jqXHR, textStatus) {
            //$.unblockUI();
            alert('termino');
        },
        contentType: 'application/json',//  tipo de dato de envio al Servidor - EN EVALUACION (si lo omitimos normalmente funciona todo bien)
        data: jsonData,
        dataType: 'json',// tipo de dato de retorno del Servidor
        error: function (jqXHR, textStatus, errorThrown) { if (fnError !== null) fnError(jqXHR, textStatus, errorThrown); },
        success: function (data, textStatus, jqXHR) { if (fnSuccess !== null) fnSuccess(data, textStatus, jqXHR); },
        type: type,
        url: url
    });
}

function extraerDatosPersonas() {
    var personaBE = new Object();
    personaBE.nombre = $('inp-nombre').val();
    personaBE.apellidos = $('inp-apellidos').val();
    personaBE.fechaNac = $('inp-fecha-nacimiento').val();
    personaBE.sexo = $('slc-sexo').comboVal();
    return personaBE;
}

function grabarDatosCliente() {
    //if (validarDatosCliente()) { //esta pendiente la validación
    var hojaPersona = extraerDatosPersonas();
    //ajaxHelperLoader2(true, 'Grabando...', hojaPerfil, null, null, manejarRespuesta, 'POST', 'RegistrarHojaPerfil');
    ajaxHelperLoader2(true, 'Grabando...', hojaPersona, null, null, null, 'POST', 'RegistrarPersonas');
    //}

}