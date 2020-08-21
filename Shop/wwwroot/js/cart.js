$(function () {
    quantityInputs = document.getElementsByClassName("quantity-input")
    decreaseButtons = document.getElementsByClassName("decrease-quantity-button");

    Array.from(quantityInputs).forEach((el, index) => {
        if (el.value == 1) {
            decreaseButtons[index].classList.add("disabled-button");
        }
    });
});

function changeQuantity(productId, size, increase, index) {

    let functionName;

    if (increase == true) {
        functionName = "IncreaseQuantity"
    }
    else {
        functionName = "DecreaseQuantity"
    }

    let method = 'GET';
    let url = '../Cart/' + functionName;
    let data = { productId: productId, productSize: size};
    let dataType = '';
    let callback = function () {
        updateSingleItemInfo(productId, size, index);
        updateTotalCartInfo()
    }

    AjaxCall(method, url, data, dataType, callback)
}

function updateSingleItemInfo(productId, size, index) {
    let method = 'GET';
    let url = '../Cart/GetSingleItemInfo' ;
    let data = { productId: productId, productSize: size };
    let dataType = 'json';
    let callback = function (result) {

        let quantityInput = document.getElementsByClassName("quantity-input")[index];
        let productAmount = document.getElementsByClassName("amount")[index];
        let decreaseButton = document.getElementsByClassName("decrease-quantity-button")[index];

        quantityInput.value = result.quantity;
        productAmount.innerHTML = result.amount.toFixed(2) + ' zł';

        if (quantityInput.value == 1) {
            decreaseButton.classList.add("disabled-button");
        }
        else {
            decreaseButton.classList.remove("disabled-button");
        }
    }

    AjaxCall(method, url, data, dataType, callback)
}

function updateTotalCartInfo() {
    let method = 'GET';
    let url = '../Cart/GetTotalInfo';
    let data = {};
    let dataType = 'json';
    let callback = function (result) {

        let totalAmount = document.querySelector(".total-amount");
        totalAmount.innerHTML = result.amount.toFixed(2) + ' zł';

        if (result.quantity == 0) {
            document.querySelector(".number-of-cart-items").style.display = "none";
        } else {
            document.querySelector(".number-of-cart-items").style.display = "block";
            document.querySelector(".number-of-cart-items").innerHTML = result.quantity;
        }
    }

    AjaxCall(method, url, data, dataType, callback)
}


function increaseQuantity(index, productId, size) {
    changeQuantity(productId, size, true, index);
}

function decreaseQuantity(index, productId, size) {
    changeQuantity(productId, size, false, index);
}