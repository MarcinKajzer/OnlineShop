function getFavouritesNumber() {
    let method = 'GET';
    let url = '../Favourites/GetQuantity';
    let dataType = 'json';
    let data = {};
    let callback = function (quantity) {
        if (quantity == 0) {
            document.querySelector(".number-of-favourites").style.display = "none";
        }
        else {
            document.querySelector(".number-of-favourites").style.display = "block";
            document.querySelector(".number-of-favourites").innerHTML = quantity;
        }
    }

    AjaxCall(method, url, data, dataType, callback)
}

getFavouritesNumber();
