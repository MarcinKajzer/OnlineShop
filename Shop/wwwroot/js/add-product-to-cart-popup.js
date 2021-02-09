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
                itemWordVariation = "item";
                break;
            default:
                itemWordVariation = "items";
        }

        Swal.fire({
            title: "You have added " + quantity + " " + itemWordVariation + " to your cart",
            text: productName,
            icon: 'success',
            buttonsStyling: false,
            customClass: {
                confirmButton: 'popup-button',
                cancelButton: 'popup-button popup-button-cancel',
                popup: 'popup-custom'
            },
            showCancelButton: true,
            confirmButtonText: 'Go to cart',
            cancelButtonText: 'Contitue shopping'
        }).then((result) => {
            if (result.value) {
                window.location.href = "/Cart/Index";
            }
        })

        getCartItemsNumber();
    }

    AjaxCall(method, url, data, dataType, callback)
}