var dataTable
$(document).ready(function () {
    loadDataTable();
})
function loadDataTable() {
    dataTable = $('#tbldata').DataTable({
        "ajax": {
            "url": "/Administrator/JCity/GetAll"
        },
        "columns": [

            { "data": "name", "width": "70%" },

            {
                "data": "id",
                "render": function (data) {
                    return `
                    <div class="text-center">
                     <a href="/Administrator/JCity/Upsert/${data}" class="btn btn-info">
                     Edit
                     </a>
                     <a class="btn btn-danger" onclick=Delete("/Administrator/JCity/Delete/${data}")>
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