function showConfirmationPopup(orderId) {
    Swal.fire({
        title: 'Wysyłanie zamówienia',
        text: "Czy jesteś pewien, że zamówienie zostało wysłane?",
        icon: 'warning',
        showCancelButton: true,
        buttonsStyling: false,
        customClass: {
            confirmButton: 'popup-button',
            cancelButton: 'popup-button popup-button-cancel',
            popup: 'popup-custom'
        },
        confirmButtonText: 'Tak, zostało wysłane!',
        cancelButtonText: 'Nie'
    }).then((result) => {
        if (result.value) {
            Swal.fire({
                title: 'Wysłano!',
                text: 'Status zamówienie został zmieniony pomyślnie',
                icon: "success",
                showConfirmButton: false,
                customClass: {
                    popup: 'popup-custom'
                },
                timer: 1000
            }).then(() => {
                window.location.href = "/Order/SendShipping?orderId=" + orderId;
            })
        }
    })
}