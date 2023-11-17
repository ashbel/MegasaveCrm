$(function () {
    $("*[data-href]").click(function () {
        window.location = $(this).data("href");
        return false;
    });
});

$(function () {
    $("#example1").DataTable({
        dom: "Blfrtip",
        buttons: [
            "copy", "csv", "excel", "pdf", "print"
        ],
        "order": [[0, "desc"]]
    });
    $("#example2").DataTable({
        "order": [[0, "desc"]]
    });
    $("#example3").DataTable();
    $("#example4").DataTable(
        {
            "order": [[0, "desc"]],
            "columnDefs": [
                {
                    "targets": [0],
                    "visible": false,
                    "searchable": false
                }]
        });
    $("#example5").DataTable({
        "order": [[0, "desc"]],
        "columnDefs": [
            {
                "targets": [0],
                "type": "date"
            }
        ],
    });
    $("#example6").DataTable();
    $("#example7").DataTable();
    $("#example8").DataTable();
    var tableNine = $("#example9").DataTable();
    var counter = 1;
    $("#addRow").on("click", function () {
        tableNine.row.add().draw(false);
        counter++;
    });
    $("#addRow").click();

    $("#example10").DataTable({
        'paging': true,
        'lengthChange': false,
        'searching': false,
        'ordering': true,
        'info': true,
        'autoWidth': false
    });
    $("table.display").DataTable({
        "order": [[0, "desc"]],
        "columnDefs": [
            {
                "targets": [0],
                "visible": false,
                "searchable": false
            }]
    });


   
});
