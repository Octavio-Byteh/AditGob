$(function () {

});

function fillDDL(url, elementId, defaultText) {
    $.getJSON(url, null, function (data) {
        var items = "<option value>" + defaultText + "</option>";
        $.each(data, function (i, item) {
            //console.log(item);
            items = items + "<option value='" + item.value + "'>" + item.text + "</option>";
        });
        $("#" + elementId).html(items);
    })
}


function getLocation() {

    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showPosition);
    } else {
        $("#Coordenadas").val("Geolocation is not supported by this browser.");
    }
}

function showPosition(position) {
    //console.log(position);
    $("#Coordenadas").val(position.coords.latitude + "," + position.coords.longitude);
    $("#Coordenadax").val(position.coords.latitude);
    $("#Coordenaday").val(position.coords.longitude);
}



function fillDDL(url, elementId, defaultText) {
    $.getJSON(url, null, function (data) {
        var items = "<option value>" + defaultText + "</option>";
        $.each(data, function (i, item) {
            //console.log(item);
            items = items + "<option value='" + item.value + "'>" + item.text + "</option>";
        });
        $("#" + elementId).html(items);
    })
}

function LoadDataTableDocumentos(data,id) {
    $('#'+id).dataTable({
        data: data,
        columns: [
            {
                'data': 'id', render: function (data, type, full, meta) {
                    //return '<button class="btn btn-default divbutton"  onClick="showDetail(' + data + '); return false;">' + data + '</button>'
                    return '<div class="divcontenedor">' + data + '</div>'
                }
            },
            {
                'data': 'estatus', render: function (data, type, full, meta) {
                    //return '<div class="divcontenedor">' + data + '</div>'
                    return '<div class="divcontenedor"><span class="dot dot' + data + '"></span></div>'
                }
            },
            {
                'data': 'documento', render: function (data, type, full, meta) {
                    return '<div class="divcontenedor">' + data + '</div>'
                }
            },
            {
                'data': 'aprobado', render: function (data, type, full, meta) {
                    var iconos =
                        '<span class="fa-2x d-inline l-h-n color-fusion-400"> <i class="fal fa-upload" style="color:white;"></i></span> <span></span>' +
                        '<span class="fa-2x d-inline l-h-n color-fusion-400"> <i class="fal fa-download" style="color:white;"></i></span> <span></span>' +
                        '<span class="fa-2x d-inline l-h-n color-fusion-400"> <i class="fal fa-trash-alt" style="color:white;"></i></span> <span></span>' +
                        '<span class="fa-2x d-inline l-h-n color-fusion-400"> <i class="fal fa-file-search" style="color:white;"></i></span> <span></span>'
                    if (data == true) {
                        return iconos + '<input type="checkbox" checked name="brand">'
                    } else {
                        return iconos + '<input type="checkbox"  name="brand">'
                    }

                }
            },




        ],
        pageLength: 6,
        searching: false,
        bLengthChange: false,
        bInfo: false,
        bProcessing: true,
        responsive: true,
        language: {
            searchPlaceholder: "Buscar",
            processing: "Consulta en curso...",
            lengthMenu: "Mostrando _MENU_ elementos",
            info: " _START_ a _END_ de _TOTAL_ elementos",
            infoEmpty: " 0 elementos",
            infoFiltered: "(Filtrando _MAX_ elementos del total)",
            infoPostFix: "",
            loadingRecords: "Cargando...",
            zeroRecords: "No hay registros disponibles",
            emptyTable: "No hay registros disponibles",

        },

        responsive: true

    });
}



function LoadDataTable(data) {
    $('#dt-obras-checklist').dataTable({
        data: data,
        columns: [
            {
                'data': 'id', render: function (data, type, full, meta) {
                    //return '<button class="btn btn-default divbutton"  onClick="showDetail(' + data + '); return false;">' + data + '</button>'
                    return '<div class="divcontenedor">' + data + '</div>'
                }
            },
            {
                'data': 'nombre', render: function (data, type, full, meta) {
                    return '<div class="divcontenedorlargo">' + data + '</div>'
                }
            },
            {
                'data': 'administracion', render: function (data, type, full, meta) {

                    if (data == true) {
                        return '<input type="checkbox" checked name="brand">'
                    } else {
                        return '<input type="checkbox"  name="brand">'
                    }

                }
            },
            {
                'data': 'adjudicacion', render: function (data, type, full, meta) {

                    if (data == true) {
                        return '<input type="checkbox" checked name="brand">'
                    } else {
                        return '<input type="checkbox"  name="brand">'
                    }

                }
            },
            {
                'data': 'invitacion', render: function (data, type, full, meta) {

                    if (data == true) {
                        return '<input type="checkbox" checked name="brand">'
                    } else {
                        return '<input type="checkbox"  name="brand">'
                    }

                }
            },
            {
                'data': 'licitacion', render: function (data, type, full, meta) {

                    if (data == true) {
                        return '<input type="checkbox" checked name="brand">'
                    } else {
                        return '<input type="checkbox"  name="brand">'
                    }

                }
            },

        ],
        pageLength: 4,
        searching: false,
        bLengthChange: false,
        bInfo: false,
        bProcessing: true,
        responsive: true,
        language: {
            searchPlaceholder: "Buscar",
            processing: "Consulta en curso...",
            lengthMenu: "Mostrando _MENU_ elementos",
            info: " _START_ a _END_ de _TOTAL_ elementos",
            infoEmpty: " 0 elementos",
            infoFiltered: "(Filtrando _MAX_ elementos del total)",
            infoPostFix: "",
            loadingRecords: "Cargando...",
            zeroRecords: "No hay registros disponibles",
            emptyTable: "No hay registros disponibles",

        },

        responsive: true

    });
}

