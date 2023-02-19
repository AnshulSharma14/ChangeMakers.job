var dataTable
$(document).ready(function () {
    loadDataTable();
})
function loadDataTable() {
    dataTable = $('#tbldata').DataTable({
        "ajax": {
            "url": "/Administrator/Company/GetAll"
        },
        "columns": [

            { "data": "name", "width": "15%" },
            { "data": "streetAddress", "width": "15%" },
            { "data": "city", "width": "15%" },
            { "data": "state", "width": "15%" },
            { "data": "phoneNumber", "width": "15%" },
            { "data": "gStIn", "width": "15%" },

            {
                "data": "id",
                "render": function (data) {
                    return `
                    <div class="text-center">
                     <a href="/Administrator/Company/Upsert/${data}" class="btn btn-info">
                     Edit
                     </a>
                     <a class="btn btn-danger" onclick=Delete("/Administrator/Company/Delete/${data}")>
                     <i class="fa fa-trash-alt"></i>
                     </a>
                     </div>
                    `;
                }
            }
        ]
    })
}
function Delete(url) {
    swal({
        title: "Want to Delete Data",
        text: "Delete Information!!!!",
        buttons: true,
        icon: "warning",
        dangerModel: true
    }).then(WillDelete => {
        if (WillDelete) {
            $.ajax({
                url: url,
                type: "Delete",
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message)
                    }
                }
            })
        }
    })
}