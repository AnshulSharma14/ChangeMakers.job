var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tbldata').DataTable({
        "ajax": {
            "url": "/Administrator/Jobs/GetAll"
        },
        "columns": [
            { "data": "name", "width": "15%" },
            { "data": "email", "width": "15%" },
            { "data": "companyName", "width": "15%" },
            { "data": "salary", "width": "15%" },
            { "data": "category.name", "width": "15%" },
            { "data": "jobType.name", "width": "15%" },
            { "data": "jobCities.name", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                        <a href="/Administrator/Jobs/Upsert/${data}" class="btn btn-info">
                     Edit
                    <a class="btn btn-danger" onclick=Delete("/Administrator/Jobs/Delete/${data}")>
                     <i class="fa fa-trash-alt"></i>
                     </a>
					</div>
                        `
                },
                "width": "15%"
            }
        ]
    });
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