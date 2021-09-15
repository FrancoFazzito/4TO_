// Call the dataTables jQuery plugin
$(document).ready(function() {
    $('#dataTable').DataTable(
        {
            language: {
                url: '/Scripts/dashboard/localization/Spanish.json'
            },
            "order": [[0, "desc"]], // Orden por defecto
            "columnDefs": [
                { "type": "date", "targets": 1 }, // Asigno tipo Date a la columna de fecha
                { orderable: false, "targets": 5 }  // Desactivar ordenado en columna con índice 5
            ],
            "lengthMenu": [5, 10, 25, 50]
        }
    );
});

$(document).on("click", ".open-detail", function () {
    var productName = $(this).data('product-title');
    var productDesc = $(this).data('product-desc');
    var artistName = $(this).data('artist-name');
    var artistDesc = $(this).data('artist-desc');
    var productImage = $(this).data('product-image');

    $(".modal-body #productName").text("Nombre del producto: " + productName);
    $(".modal-body #productDesc").text("Descripción del producto: " + productDesc);
    $(".modal-body #artistName").text("Artista: " + artistName);
    $(".modal-body #artistDesc").text("Descripción del artista: " + artistDesc);
    $(".modal-body #productImage").attr("src", "/Content/img/product/" + productImage);
});