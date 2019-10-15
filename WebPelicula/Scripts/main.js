
function listarPedido() {
    var table;
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: '/Pedido/ListarPedido',
        dataType: 'json',
        success: function (data) {
            //Datatable
            $('#tbl').DataTable({

                destroy: true,
                searching: true,
                "pagingType": "full_numbers",
                language: {
                    "decimal": "",
                    "emptyTable": "No hay información",
                    "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
                    "infoEmpty": "Mostrando 0 to 0 of 0 Entradas",
                    "infoFiltered": "(Filtrado de _MAX_ total entradas)",
                    "infoPostFix": "",
                    "thousands": ",",
                    "lengthMenu": "Mostrar _MENU_ Entradas",
                    "loadingRecords": "Cargando...",
                    "processing": "Procesando...",
                    "search": "Buscar:",
                    "zeroRecords": "Sin resultados encontrados",
                    "paginate": {
                        "first": "Primero",
                        "last": "Ultimo",
                        "next": "Siguiente",
                        "previous": "Anterior"
                    }
                },

                

                fields: [                    
                 {
                    label: 'Cod:',
                }, {
                    label: 'Cod Cliente:',
                }, {
                    label: 'Nom Cliente:',
                }, {
                    label: 'Cod Articulo',
                }, {
                    label: 'Nom Articulo:',
                }, {
                    label: 'Cantidad',
                }, {
                    label: 'Estado',
                }, 


                ],

                data: data,
                columns: [     
                    {
                        data: null,
                        defaultContent: '',
                        className: 'select-checkbox',
                        orderable: false
                    },

                    { data: 'Codigo_Ped' },
                    { data: 'CodigoCliente_ped' },
                    { data: 'NombreCliente_Ped' },
                    { data: 'CodigoArticulo_Ped' },
                    { data: 'NombreArticulo_Ped' },
                    { data: 'CantidadArticulo_Ped' },
                    { data: 'EstadoArticulo_Ped' },                   
                ],

                select: {
                    style: 'os',
                    selector: 'td:first-child'
                },

            })      

            var table = $('#tbl').DataTable();
            var datafila; 

            $('#tbl tbody').on('click', 'tr', function () {
                //alert('Row index: ' + table.row(this).index());
                console.log(table.row(this).data());
                datafila = table.row(this).data();
                console.log(datafila.codigoa);
                $('#codigoa').val(datafila.Codigo_Ped);
                $('#codigoc').val(datafila.CodigoCliente_ped);                
                $('#articulo').val(datafila.CodigoArticulo_Ped);
                $('#cantidad').val(datafila.CantidadArticulo_Ped);                
                $('#estado').val(datafila.EstadoArticulo_Ped);                
                /*var tblData = table.rows('.selected').data();
                var tmpData;
                $.each(tblData, function (i, val) {
                    tmpData = tblData[i];
                    alert(tmpData);
                });*/ 
            });

            
        },
        error: function (result) {
            alert("ha ocurrido un error");
        }
    });
}



function obtenerConsecutivo() {       
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: '/Pelicula/ObtenerConsecutivo',
        dataType: 'json',
        success: function (data) {            
            $('#codigo').val(data);            
        },
        error: function (result) {
            alert("ha ocurrido un error");
        }
    });
}
/*-----------------------Pedido-------------------------------*/
function obtenerConsecutivoPedido() {
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: '/Pedido/ObtenerConsecutivoPedido',
        dataType: 'json',
        success: function (data) {
            $('#codigoa').val(data);
        },
        error: function (result) {
            alert("ha ocurrido un error");
        }
    });
}


/*----------------------Pedido-----------------------*/
function listarArticulos() {
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        //data:"{etnia:"+JSON.stringify(etnia)+"}",
        url: "/Pedido/ListarArticulos",
        success: function (data) {
            /*alert("etnia: " + data[0]);                            
            $("#etnia").html(data[0]);*/
            $.each(data, function (key, val) {
                $('select[name="articulo"]').append($('<option>', {
                    value: val.Codigo,
                    text: val.Nombre
                }));
            });
        },
        error: function (result) {
            alert("ha ocurrido un error");
        }
    });
}

function guardarCliente() {
    codigo = $('#codigo').val();
    nombre = $('#nombre').val();
    apellido = $('#apellido').val();
    identificacion = $('#id').val();
    direccion = $('#direccion').val();
    telefono = $('#telefono').val();
    correo = $('#correo').val();
    if (codigo == '' || nombre == '' || apellido == '' || identificacion == '' || direccion == '') {
        $('#error_message').html("Algunos campos están vacios");
    }
    else {
        $('#error_message').html('');
        $.ajax({
            url: "/Pelicula/GuardarCliente",
            method: "POST",
            data: {
                codigo: codigo, nombre: nombre, apellido: apellido,
                identificacion: identificacion, direccion: direccion,
                telefono: telefono, correo: correo
            },
            success: function (data) {
                $("form").trigger("reset");
                if (data == 1) {
                    $('#success_message').fadeIn().html("Cliente Guardado Exitosamente");
                    setTimeout(function () {
                        $('#success_message').fadeOut("Slow");
                    }, 5000);
                }
            }
        });
    }
}
/*-----------------------Pedido-------------------------------*/
function guardarPedido() {
    codigoa = $('#codigoa').val();
    codigoc = $('#codigoc').val();
    nombre = $('#nombre').val();

    codarticulo = $('#articulo').val();
    articulo = $('select[name="articulo"] option:selected').text();
    
    cantidad = $('#cantidad').val();
    estado= $('#estado').val();
    

    console.log(codigoa);
    console.log(codigoc);
    console.log(nombre);
    console.log(codarticulo);
    console.log(articulo);
    console.log(cantidad);
    console.log(estado);
    


    
    if (codigoa == '' || codigoc == '' || nombre == '' || articulo == '' || cantidad == '' || estado == '') {
        $('#error_message').html("Algunos campos están vacios");
    }
    else {
        $('#error_message').html('');
        $.ajax({
            url: "/Pedido/GuardarPedido",
            method: "POST",
            data: {
                codigoa: codigoa, codigoc: codigoc, nombre: nombre, codarticulo: codarticulo, articulo: articulo,                
                cantidad: cantidad, estado: estado,
            },
            success: function (data) {
                $("form").trigger("reset");
                if (data == 1) {
                    $('#success_message').fadeIn().html("Pedido Registrado Exitosamente");
                    setTimeout(function () {
                        $('#success_message').fadeOut("Slow");
                    }, 5000);
                }
            }
        });
    }
}

/*pedido*/
function eliminarPedido() {
    codigo = $('#codigo').val();
    if (codigo == '') {
        $('#error_message').html("Algunos campos están vacios");
    }
    else {
        $('#error_message').html('');
        $.ajax({
            url: "/Pelicula/EliminarPedido",
            method: "POST",
            data: {
                codigo: codigo
            },
            success: function (data) {
                $("form").trigger("reset");
                if (data == 1) {
                    $('#success_message').fadeIn().html("Cliente Eliminado Exitosamente");
                    setTimeout(function () {
                        $('#success_message').fadeOut("Slow");
                    }, 5000);
                }
            }
        });
    }
}

function actualizarPedido() {
    codigoa = $('#codigoa').val();
    codigoc = $('#codigoc').val();
    nombre = $('#nombre').val();
    articulo = $('#articulo').val();
    cantidad = $('#cantidad').val();    
    estado = $('#estado').val();
     
    if (codigoa == '' || codigoc == '' ||  articulo == '' || cantidad == '' || estado == '') {
        $('#error_message').html("Algunos campos están vacios");
    }
    else {
        $('#error_message').html('');
        $.ajax({
            url: "/Pelicula/ActualizarPedido",
            method: "POST",
            data: {
                codigoa: codigoa, codigoc: codigoc, articulo: articulo, cantidad: cantidad,
                estado: estado
                
            },
            success: function (data) {
                $("form").trigger("reset");
                if (data == 1) {
                    $('#success_message').fadeIn().html("Pedido Actualizado Exitosamente");
                    setTimeout(function () {
                        $('#success_message').fadeOut("Slow");
                    }, 5000);
                }
            }
        });
    }
}




function eliminarPedido() {
    codigo = $('#codigoa').val();    
    if (codigo == '') {
        $('#error_message').html("Algunos campos están vacios");
    }
    else {
        $('#error_message').html('');
        $.ajax({
            url: "/Pedido/EliminarPedido",
            method: "POST",
            data: {
                codigo: codigo
            },
            success: function (data) {
                $("form").trigger("reset");
                if (data == 1) {
                    $('#success_message').fadeIn().html("Pedido Eliminado Exitosamente");
                    setTimeout(function () {
                        $('#success_message').fadeOut("Slow");
                    }, 5000);
                }
            }
        });
    }
}

function actualizarCliente() {
    codigo = $('#codigo').val();
    nombre = $('#nombre').val();
    apellido = $('#apellido').val();
    identificacion = $('#id').val();
    direccion = $('#direccion').val();
    telefono = $('#telefono').val();
    correo = $('#correo').val();
    if (codigo == '' || nombre == '' || apellido == '' || identificacion == '' || direccion == '') {
        $('#error_message').html("Algunos campos están vacios");
    }
    else {
        $('#error_message').html('');
        $.ajax({
            url: "/Pelicula/ActualizarCliente",
            method: "POST",
            data: {
                codigo: codigo, nombre: nombre, apellido: apellido,
                identificacion: identificacion, direccion: direccion,
                telefono: telefono, correo: correo
            },
            success: function (data) {
                $("form").trigger("reset");
                if (data == 1) {
                    $('#success_message').fadeIn().html("Cliente Actualizado Exitosamente");
                    setTimeout(function () {
                        $('#success_message').fadeOut("Slow");
                    }, 5000);
                }
            }
        });
    }
}





/*-----------------------Pedido-------------------------------*/
function obtenerNombreCliente() {
    var codigoc = $("#codigoc").val();
    var dataToLog = { 'codigoc': codigoc};

    $.ajax({
        type: "POST",
        url: "/Pedido/ObtenerNombreCliente",
        
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(dataToLog),
              
                 
        dataType: 'json',
        success: function (data) {
            //$('#nombre').html(data[0].nombre);
            $('#nombre').val(data[0].nombre + ' ' + data[0].apellido); 
        },
        error: function (request, status, error) {
            alert(request.responseText);
        }
    });
}

