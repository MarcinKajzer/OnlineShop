function showConfirmationPopup(productId, archive) {
    let title = "";
    let text = "";
    let succededTitle = "";
    let succededText = "";
    let buttonMessage = "";
    if (archive) {
        title = "Usuwanie produktu";
        text = "Czy jesteś pewien, że chcesz przenieść ten produkt do archiwum?";
        succededTitle = "Usunięto!";
        succededText = "Ten produkt został pomyślnie przeniesiony do archiwum"
        buttonMessage = "Tak, archiwizuj!"
    } else {
        title = "Przywracanie produktu";
        text = "Czy jesteś pewien, że chcesz przywrócić ten produkt z archiwum?"
        succededTitle = "Przywrócono!";
        succededText = "Ten produkt został pomyślnie przywrócony z archiwum"
        buttonMessage = "Tak, przywróć!"
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