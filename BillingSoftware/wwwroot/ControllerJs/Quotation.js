function addUpdateQuotationSuccess(res) {
    $('.quotation-modal-body').html(res);
    $('#QuotationModal').modal({
        backdrop: 'static',
        keyboard: false
    });
}
function ChangeWorkType(e) {
    let WorkTypeId = $(e).val();
    HandleWorkTypeUI(WorkTypeId);
}

function HandleWorkTypeUI(WorkTypeId){
    if (WorkTypeId == '1') {
        $('.SparePartDiv').removeClass('d-none');
        $('.ReparingDiv').addClass('d-none');
        $('.repairing-multipleselect').val(null).trigger('change');
    }
    else if (WorkTypeId == '2') {
        $('.ReparingDiv').removeClass('d-none');
        $('.SparePartDiv').addClass('d-none');
        $('.sparepart-multipleselect').val(null).trigger('change');
    }
    else if (WorkTypeId == '3') {
        if ($('.ReparingDiv.d-none').length != 0) {
            $('.repairing-multipleselect').val(null).trigger('change');
        }
        if ($('.SparePartDiv.d-none').length > 0) {
            $('.sparepart-multipleselect').val(null).trigger('change');
        }
        $('.ReparingDiv').removeClass('d-none');
        $('.SparePartDiv').removeClass('d-none');
    }
    else {
    }
}

function ChangeSparePart(e) {
    //let SparePartId = $(e).val();
    let SparePartArray = [];
    let TotalSparePart = $(e).select2('data').length;
    for (var i = 0; i < TotalSparePart; i++) {
        let obj = { SparePartName: $(e).select2('data')[i].text, SparePartId: $(e).select2('data')[i].id, SparePartQuantity : '1' }
        SparePartArray.push(obj);
    }
    $.ajax({
        url: "/Quotation/GetSparePartFieldUI",
        method:"get",
        data: { model: JSON.stringify(SparePartArray)},
        success: function (res) {
            $(".DynamicSparePartDiv").html(res);
        }
    });
}
var Billing_Quotation = function () {
    return {
        DeleteQuotation(url, id) {
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