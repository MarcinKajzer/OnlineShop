function showConfirmationPopup(productId) {
    Swal.fire({
        title: 'Usuwanie produktu',
        text: "Czy jesteś pewien, że chcesz przenieść ten produkt do archiwum?",
        icon: 'warning',
        showCancelButton: true,
        buttonsStyling: false,
        customClass: {
            confirmButton: 'popup-button',
            cancelButton: 'popup-button popup-button-cancel',
            popup: 'popup-custom'
        },
        confirmButtonText: 'Tak, archiwizuj!',
        cancelButtonText: 'Nie'
    }).then((result) => {
        if (result.value) {
            Swal.fire({
                title: 'Usunięto!',
                text: 'Ten produkt został pomyślnie przeniesiony do archiwum',
                icon: "success",
                showConfirmButton: false,
                customClass: {
                    popup: 'popup-custom'
                },
                timer: 1000
            }).then(() => {
                window.location.href = "/Product/Delete?productId=" + productId;
            })
        }
    })
}