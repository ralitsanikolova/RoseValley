window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, 'Operation Successful!')
    }
    if (type === "error") {
        toastr.error(message, 'Operation Failed!')
    }
}

window.ShowSwal = (type, message) => {
    if (type === "success") {
        Swal.fire(
            'Successul operation!',
            message,
            'success'
        )
    }
    if (type === "error") {
        Swal.fire(
            'Error Upload!',
            message,
            'error')
    }
}

function ShowDeleteConfirm() {
    $('#deleteConfirmationModal').modal('show');
}

function HideDeleteConfirm() {
    $('#deleteConfirmationModal').modal('hide');
}

