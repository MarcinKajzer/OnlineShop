function showConfirmationPopup(orderId) {
    Swal.fire({
        title: 'Sending the order',
        text: "Are you sure the order has been shipped?",
        icon: 'warning',
        showCancelButton: true,
        buttonsStyling: false,
        customClass: {
            confirmButton: 'popup-button',
            cancelButton: 'popup-button popup-button-cancel',
            popup: 'popup-custom'
        },
        confirmButtonText: 'Yes!',
        cancelButtonText: 'No'
    }).then((result) => {
        if (result.value) {
            Swal.fire({
                title: 'The order has been shipped!',
                text: 'Order status has been succesfully changed.',
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