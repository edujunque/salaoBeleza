$(document).ready(function () {
    $('.table').DataTable({
        "columnDefs": [{
            "targets": 'no-sort',
            "orderable": false,
        }],
        "paging": true,
        "lengthChange": true,
        "searching": true,
        "ordering": true,
        "info": true,
        "autoWidth": false,
        "url": "http://cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Portuguese-Brasil.json"
    });
});