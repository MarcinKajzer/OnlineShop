function getCartItemsNumber() {
    let method = 'GET';
    let url = '../Cart/GetTotalInfo';
    let dataType = 'json';
    let data = {};
    let callback = function (result) {
        if (result.quantity == 0) {
            document.querySelector(".number-of-cart-items").style.display = "none";
        }
        else {
            document.querySelector(".number-of-cart-items").style.display = "block";
            document.querySelector(".number-of-cart-items").innerHTML = result.quantity;
        }
    }

    AjaxCall(method, url, data, dataType, callback)
}

getCartItemsNumber();

