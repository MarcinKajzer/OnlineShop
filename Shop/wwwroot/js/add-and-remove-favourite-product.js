function addToFavourites(productId, index) {
    $(document).ready(function () {
        $.ajax({
            type: 'GET',
            url: '../Favourites/Add',
            data: { productId: productId },
            success: function () {
                document.getElementsByClassName("favoutites-links-container")[index].innerHTML =
                    '<a onclick="removeFromFavourites(' + productId + ',' + index + ')" class="remove-from-favourites"></a>';

                if (document.querySelector(".number-of-favourites").style.display == "none") {
                    document.querySelector(".number-of-favourites").style.display = "block";
                    document.querySelector(".number-of-favourites").innerHTML = 1;
                }
                else {
                    document.querySelector(".number-of-favourites").innerHTML = parseInt(document.querySelector(".number-of-favourites").innerHTML) + 1;
                }
            },
            error: function (ex) {
                alert('Coś poszło nie tak' + ex);
            }
        });
        return false;
    })
}

function removeFromFavourites(productId, index) {
    $(document).ready(function () {
        $.ajax({
            type: 'GET',
            url: '../Favourites/Remove',
            data: { productId: productId },
            success: function () {
                document.getElementsByClassName("favoutites-links-container")[index].innerHTML =
                    '<a onclick="addToFavourites(' + productId + ',' + index + ')" class="add-to-favourites"></a>';

                document.querySelector(".number-of-favourites").innerHTML = parseInt(document.querySelector(".number-of-favourites").innerHTML) - 1;

                if (document.querySelector(".number-of-favourites").innerHTML == 0) {
                    document.querySelector(".number-of-favourites").style.display = "none";
                }
                else {
                    document.querySelector(".number-of-favourites").style.display = "block";
                }
            },
            error: function (ex) {
                alert('Coś poszło nie tak' + ex);
            }
        });
        return false;
    })
}