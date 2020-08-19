let numberOfFavourites = document.querySelector(".number-of-favourites");
let addOrRemoveFavouriteProductLinksContainer = document.getElementsByClassName("favoutites-links-container");


function addToFavourites(productId, index) {

    let method = 'GET';
    let url = '../Favourites/Add';
    let data = { productId: productId };
    let dataType = '';
    let callback = function () {

        addOrRemoveFavouriteProductLinksContainer[index].innerHTML =
            '<a onclick="removeFromFavourites(' + productId + ',' + index + ')" class="remove-from-favourites"></a>';

        if (numberOfFavourites.style.display == "none") {
            numberOfFavourites.style.display = "block";
            numberOfFavourites.innerHTML = 1;
        }
        else {
            numberOfFavourites.innerHTML = parseInt(numberOfFavourites.innerHTML) + 1;
        }
    }

    AjaxCall(method, url, data, dataType, callback)

}

function removeFromFavourites(productId, index) {

    let method = 'GET';
    let url = '../Favourites/Remove';
    let data = { productId: productId };
    let dataType = '';
    let callback = function () {

        addOrRemoveFavouriteProductLinksContainer[index].innerHTML =
            '<a onclick="addToFavourites(' + productId + ',' + index + ')" class="add-to-favourites"></a>';

        numberOfFavourites.innerHTML = parseInt(numberOfFavourites.innerHTML) - 1;

        if (numberOfFavourites.innerHTML == 0) {
            numberOfFavourites.style.display = "none";
        }
        else {
            numberOfFavourites.style.display = "block";
        }
    }

    AjaxCall(method, url, data, dataType, callback)
}