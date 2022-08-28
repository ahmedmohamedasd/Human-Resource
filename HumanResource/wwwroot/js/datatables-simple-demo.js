window.addEventListener('DOMContentLoaded', event => {
    // Simple-DataTables
    // https://github.com/fiduswriter/Simple-DataTables/wiki

    const datatablesSimple = document.getElementById('datatablesSimple');
    if (datatablesSimple) {
        new simpleDatatables.DataTable(datatablesSimple);
    }
});
//$('#datatablesSimple').DataTable({
//    createdRow: function (row, data, dataIndex) {
//        // Set the data-status attribute, and add a class
//        $(row).find('input:eq(0)')
//            .attr('data-status', data.status ? 'locked' : 'unlocked')
//            .addClass('form-control');
//    }
//});
