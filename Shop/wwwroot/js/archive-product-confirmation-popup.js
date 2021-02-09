function showConfirmationPopup(productId, archive) {
    let title = "";
    let text = "";
    let succededTitle = "";
    let succededText = "";
    let buttonMessage = "";
    if (archive) {
        title = "Archiving the product";
        text = "Are you sure you want to archive this product?";
        succededTitle = "Archived succesfully!";
        succededText = "This product this product has been successfully moved to the archive."
        buttonMessage = "Yes, archive!"
    } else {
        title = "Restoring the product";
        text = "Are you sure you want to restore this product?"
        succededTitle = "Restored succesfully!";
        succededText = "This product has been succesfully restored."
        buttonMessage = "Yes, restore!"
    }

    Swal.fire({
        title: title,
        text: text,
        icon: 'warning',
        showCancelButton: true,
        buttonsStyling: false,
        customClass: {
            confirmButton: 'popup-button',
            cancelButton: 'popup-button popup-button-cancel',
            popup: 'popup-custom'
        },
        confirmButtonText: buttonMessage,
        cancelButtonText: 'Nie'
    }).then((result) => {
        if (result.value) {
            Swal.fire({
                title: succededTitle,
                text: succededText,
                icon: "success",
                showConfirmButton: false,
                customClass: {
                    popup: 'popup-custom'
                },
                timer: 1000
            }).then(() => {
                window.location.href = "/Product/Archive?productId=" + productId + "&archive=" + archive;
            })
        }
    })
}