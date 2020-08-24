function showConfirmationPopup(productId) {
    Swal.fire({
        title: 'Usuwanie produktu',
        text: "Czy jesteś pewien, że chcesz przenieść ten produkt do archiwum?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#1C551B',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Tak, archiwizuj!',
        cancelButtonText: 'Nie'
    }).then((result) => {
        if (result.value) {
            Swal.fire({
                title: 'Usunięto!',
                text: 'Ten produkt został pomyślnie przeniesiony do archiwum',
                icon: "success",
                showConfirmButton: false,
                timer: 1000
            }).then(() => {
                window.location.href = "/Product/Delete?productId=" + productId;
            })
        }
    })
}