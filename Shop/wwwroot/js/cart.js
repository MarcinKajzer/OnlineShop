function setQuantity(index, productId, size, direction) {
    let quantityInput = document.getElementsByClassName("quantity-input")[index]
    let productAmount = document.getElementsByClassName("amount")[index]
    let totalAmount = document.querySelector(".total-amount");

    let functionName;

    if (direction == 1) {
        functionName = "IncreaseQuantity"
    }
    else {
        functionName = "DecreaseQuantity"
    }

    $(document).ready(function () {
        $.ajax({
            type: 'GET',
            url: '../Cart/' + functionName,
            dataType: 'json',
            data: { productId: productId, productSize: size },
            success: function (result) {
                quantityInput.value = result.currentItemQuantity;
                totalAmount.innerHTML = result.totalAmount.toFixed(2) + ' zł';
                productAmount.innerHTML = result.currentItemAmount.toFixed(2) + ' zł';
                document.querySelector(".number-of-cart-items").innerHTML = result.totalQuantity;
            },
            error: function (ex) {
                alert('Coś poszło nie tak' + ex);
            }
        });
        return false;
    })
}

function increaseQuantity(index, productId, size) {
    setQuantity(index, productId, size, 1)
}

function decreaseQuantity(index, productId, size) {
    setQuantity(index, productId, size, 0)
}