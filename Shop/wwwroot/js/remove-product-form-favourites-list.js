function removeFromFavourites(productId, index) {
    $(document).ready(function () {
        $.ajax({
            type: 'GET',
            url: '../Favourites/Remove',
            data: { productId: productId },
            success: function () {
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
            },
            error: function (ex) {
                alert('Coś poszło nie tak' + ex);
            }
        });
        return false;
    })
}