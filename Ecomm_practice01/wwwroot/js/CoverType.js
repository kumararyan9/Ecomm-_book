var dataTable;

$(document).ready(function () {
    loadDataTable();
})
function loadDataTable() {
    dataTable = $('#tbldata').DataTable({
        "lengthMenu": [[5, 10, 15, -1], [5, 10, 15, "All"]],
        "pageLength": 5,
        "ajax": {
            "url":"/Admin/CoverType/GetAll"
        },
        "columns": [
            {
                "data": "id",
                "render": function (data) {
                    return `
                      <div class="text-align-left">
                      <a href="/Admin/CoverType/Credit/${data}" class="btn btn-primary">
                      <i class="fas fa-edit"></i></a>
                      </div>
                    `;
                }                
            },
            { "data": "name", "width": "60%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                       <div class="text-align-left">
                       <a class="btn btn-danger" onclick=Delete("/Admin/CoverType/Delete/${data}")>
                       <i class="fas fa-trash-alt"></i></a>
                       </div>
                    `;
                }
            }
        ]
    })
}
function Delete(url) {
    swal({
        title: "Delete Info!!",
        text: "Sure Want to delete?",
        buttons: true,
        icon: "warning",
        dangerModel:true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                url: url,
                type: "Delete",
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}