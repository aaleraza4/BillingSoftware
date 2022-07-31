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

function HandleWorkTypeUI(WorkTypeId) {
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
        let obj = { SparePartName: $(e).select2('data')[i].text, SparePartId: $(e).select2('data')[i].id, SparePartQuantity: '1' }
        SparePartArray.push(obj);
    }
    $.ajax({
        url: "/Quotation/GetSparePartFieldUI",
        method: "get",
        data: { model: JSON.stringify(SparePartArray) },
        success: function (res) {
            $(".DynamicSparePartDiv").html(res);
        }
    });
}
function ChangeRepairingWork(e) {
    //let RepairingWorkId = $(e).val();
    let RepairingWorkArray = [];
    let RepairingWorkLength = $(e).select2('data').length;
    for (var i = 0; i < RepairingWorkLength; i++) {
        let obj = { RepairingWorkName: $(e).select2('data')[i].text, RepairingWorkId: $(e).select2('data')[i].id/*, SparePartQuantity : '1'*/ }
        RepairingWorkArray.push(obj);
    }
    $.ajax({
        url: "/Quotation/GetReparingWorkFieldsUI",
        method: "get",
        data: { model: JSON.stringify(RepairingWorkArray) },
        success: function (res) {
            $(".DynamicReparingDiv").html(res);
        }
    });
}
function ChangeOrganizationType(e) {
    let OrganizationTypeId = $(e).val();
    if (OrganizationTypeId == '1') {
        $('.organization-select').select2({
            placeholder: "Please select organization",
            allowClear: true
        });
        $('.OrganizationDiv').removeClass('d-none');
        $('.CustomerDiv').addClass('d-none');
        $('.customer-select').val(null).trigger('change');
    }
    else if (OrganizationTypeId == '2') {
        $('.OrganizationDiv').addClass('d-none');
        $('.CustomerDiv').removeClass('d-none');
        $('.customer-select').select2({
            placeholder: "Please select customer",
            allowClear: true
        });
        $('.organization-select').val(null).trigger('change');
    }
    else {
        $('.OrganizationDiv').addClass('d-none');
        $('.CustomerDiv').addClass('d-none');
        $('.organization-select').val(null).trigger('change');
        $('.customer-select').val(null).trigger('change');
    }
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