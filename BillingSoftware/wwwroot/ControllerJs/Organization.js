function addUpdateOrganizationSuccess(res) {
    $('.organization-modal-body').html(res);
    $('#OrganizationModal').modal('show');
}
function addUpdatePostSuccess(res) {
    $('.grid-div').html(res);
    $('#OrganizationModal').modal('hide');
}
var Billing_Organization = function () {
    return {
        DeleteOrganization(url, id) {
            swal({
                title: "Warning",
                text: "Are You sure want to Delete?",
                icon: "warning",
                buttons: true,
                confirmButtonColor: '#dc3545',
                cancelButtonClass: 'btn-secondary waves-effect',
                confirmButtonClass: 'btn-danger waves-effect waves-light',
                showCancelButton: true,
                showCloseButton: true,
                buttons: ["Cancel", "Delete"],
                closeModal: true
            }).then(val => {
                if (val.dismiss == 'cancel') { swal.close(); }
                if (val.value) {
                    swal.close();
                    $.get(url, { Id: id }, function (res) {
                        // Get values from Doms
                        debugger;
                        if (res.Response != "") {
                            $('.grid-div').html(res);
                            toastr.success('Record successfully deleted');
                        }
                        else {
                            toastr.error("Something went wrong");
                        }

                    });
                }
            });
        }
    }
}();