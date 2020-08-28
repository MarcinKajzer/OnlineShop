function removeFromFavourites(productId, index) {

    let method = 'GET';
    let url = '../Favourites/Remove';
    let data = { productId: productId };
    let dataType = '';
    let callback = function () {
        document.getElementsByClassName("single-product")[index].style.display = "none";

        document.querySelector(".number-of-favourites").innerHTML = parseInt(document.querySelector(".number-of-favourites").innerHTML) - 1;

        if (document.querySelector(".number-of-favourites").innerHTML == 0) {
            document.querySelector(".number-of-favourites").style.display = "none";

            let p = document.createElement("p");
            p.innerHTML = "Nie masz obecnie ulubionych produktów";
            p.classList.add("no-products-info")
            document.querySelector(".favourites-list").appendChild(p);
        }
        else {
            document.querySelector(".number-of-favourites").style.display = "block";
        }
    }

    AjaxCall(method, url, data, dataType, callback)
}