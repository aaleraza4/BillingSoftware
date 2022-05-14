function addUpdateRepairWorkSuccess(res) {
    $('.repairing-modal-body').html(res);
    $('#RepairWorkModal').modal('show');
}
function addUpdatePostSuccess(res) {
    $('.grid-div').html(res);
    $('#RepairWorkModal').modal('hide');
}