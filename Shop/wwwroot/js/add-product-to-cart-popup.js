function addToCart(productId, productName, index) {

    let size = document.getElementsByClassName("size-and-quantity")[index].querySelector("input:checked").value;
    let quantity = document.getElementsByClassName("quantity")[index].value

    let method = 'POST';
    let url = '../Cart/Add';
    let data = { Id: productId, Quantity: quantity, SelectedSize: size };
    let dataType = '';
    let callback = function () {

        let itemWordVariation = "";

        switch (parseInt(quantity)) {
            case 1:
                itemWordVariation = "przedmiot";
                break;
            case 2:
            case 3:
            case 4:
                itemWordVariation = "przedmioty";
                break;
            default:
                itemWordVariation = "przedmiotów";
        }

        Swal.fire({
            title: "Dodałeś " + quantity + " " + itemWordVariation + " do koszyka",
            text: productName,
            icon: 'success',
            buttonsStyling: false,
            customClass: {
                confirmButton: 'popup-button',
                cancelButton: 'popup-button popup-button-cancel',
                popup: 'popup-custom'
            },
            showCancelButton: true,
            confirmButtonText: 'Przejdź do koszyka',
            cancelButtonText: 'Kontynuuj zakupy'
        }).then((result) => {
            if (result.value) {
                window.location.href = "/Cart/Index";
            }
        })

        getCartItemsNumber();
    }

    AjaxCall(method, url, data, dataType, callback)
}