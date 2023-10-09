var productTable;

$(document).ready(function () {

    productTable = $('#tblProducts').DataTable({
        "ajax": {
            "url": "/Admin/Product/GetAll"
        },
        "columns": [
            { "data": "isbn" },
            { "data": "title" },
            { "data": "author" },
            { "data": "listPrice" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <a class="btn btn-warning">
                                <i class="bi bi-pencil-square"></i>&nbsp;
                                Edit
                            </a>
                            <a class="btn btn-danger">
                                <i class="bi bi-trash3"></i> &nbsp;
                                Delete
                            </a>                 
                    `
                }
            }
        ]
    })
});